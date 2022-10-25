function kategoriHode() {

    var x = document.getElementById("hode");
    if (x.style.display === "") {
        x.style.display ="none";
    }
    else {
        x.style.display = "";
    }
}

function kategoriOverkropp() {

    var x = document.getElementById("overkropp");
    if (x.style.display === "none") {
        x.style.display ="block";
    }
    else {
        x.style.display = "none";
    }
}

function kategoriUnderkropp() {

    var x = document.getElementById("underkropp");
    if (x.style.display === "none") {
        x.style.display ="block";
    }
    else {
        x.style.display = "none";
    }
}
// husk å referere til kilde koden er hentet fra