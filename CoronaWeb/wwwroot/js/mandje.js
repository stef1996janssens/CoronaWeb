"use strict";
for (const plusKnop of document.getElementsByClassName("hoger")) {
    plusKnop.onclick = async function () {
        const parent = this.parentElement;
        const spanAantal = parent.getElementsByClassName("aantal")[0];
        const aantal = Number(spanAantal.innerText);
        spanAantal.innerText = aantal + 1;

        // Array met gegevens doorsturen met Post Request
        const id = this.dataset.id;
        const response = await fetch(`https://localhost:5001/mandje/plus/${id}`,{ method: "POST"});
    }
}

for (const lagerKnop of document.getElementsByClassName("lager")) {
    lagerKnop.onclick = async function () {
        const parent = this.parentElement;
        const spanAantal = parent.getElementsByClassName("aantal")[0];
        const aantal = Number(spanAantal.innerText);
        if (aantal > 0) {
            spanAantal.innerText = aantal - 1;

            // Array met gegevens doorsturen met Post Request
            const id = this.dataset.id;
            const response = await fetch(`https://localhost:5001/mandje/min/${id}`, { method: "POST" });
        }


    }
}


