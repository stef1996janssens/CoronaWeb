using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CoronaData.Models;
using CoronaData.Repositories;
using CoronaServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace CoronaWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IKlantRepository klantRepository;
        private readonly GemeenteService gemeenteService;
        private readonly AdresService adresService;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender, IKlantRepository klantRepository
            , GemeenteService gemeenteService, 
            AdresService adresService)
            
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            this.klantRepository = klantRepository;
            this.gemeenteService = gemeenteService;
            this.adresService = adresService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public string UserName { get; set; }

            public int Klantnr { get; set; }
            [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
            public string Familienaam { get; set; }
            [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
            public string Voornaam { get; set; }

            public string Telefoonnr { get; set; }
            [Required(ErrorMessage = "dit veld is verplicht in te vullen")]
            public string Gsmnr { get; set; }
            public virtual Adres Adres { get; set; }
            
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //CONTROLE OF GEMEENTE AL BESTAAT, ANDERS GEMEENTE TOEVOEGEN
                var gemeente = new Gemeente();
                Gemeente alGekendeGemeente = await gemeenteService.GetGemeenteByNameAndPostcode(Input.Adres.Gemeente.Naam, Input.Adres.Gemeente.Postcode);
                if (alGekendeGemeente != null)
                {
                    gemeente = alGekendeGemeente;
                }
                else
                {
                    gemeente = new Gemeente
                    {
                        Naam = Input.Adres.Gemeente.Naam,
                        Postcode = Input.Adres.Gemeente.Postcode
                    };
                }

                //CONTROLE OF ADRES AL BESTAAT, ANDERS ADRES TOEVOEGEN
                var adres = new Adres();
                Adres alGekendAdres = new Adres();
                if (Input.Adres.Bus == null)
                {
                   alGekendAdres = await adresService.GetAdresByStraatAndHuisnrAndGemeenteAndPostcode(Input.Adres.Straatnaam, Input.Adres.Huisnr, Input.Adres.Gemeente.Naam, Input.Adres.Gemeente.Postcode);
                }
                else
                {
                   alGekendAdres = await adresService.GetAdresByStraatAndHuisnrAndBusAndGemeenteAndPostcode(Input.Adres.Straatnaam, Input.Adres.Huisnr, Input.Adres.Bus, Input.Adres.Gemeente.Naam, Input.Adres.Gemeente.Postcode);
                }
                if (alGekendAdres != null)
                {
                    adres = alGekendAdres;
                }
                else
                {
                    adres = new Adres
                    {
                        Straatnaam = Input.Adres.Straatnaam,
                        Huisnr = Input.Adres.Huisnr,
                        Bus = Input.Adres.Bus,
                        Gemeente = gemeente
                    };
                }


                //Creëren van KLANT
                var klant = new Klant
                {
                    Voornaam = Input.Voornaam,
                    Familienaam = Input.Familienaam,
                    Adres = adres,
                    Telefoonnr = Input.Telefoonnr,
                    Gsmnr = Input.Gsmnr,
                    Email = Input.Email

                };
                klantRepository.Add(klant);
                

                //Creëren van USER
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
