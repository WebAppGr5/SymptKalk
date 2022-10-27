 function checkbox() {
    var checkBox = document.getElementById("001");
    var dropdown = document.getElementById("varighet001");

    if (checkBox.checked) {
        checkBox.style.display = "block";
    }
    else {
        dropdown.style.display = "none";
    }
} 
/**
$('[type="checkbox"][id="001"]').click(function () {
    $("select.varighet001").toggle(this.checked);
}); 
*/
function checkbox(inp) {
    let dropwdown = document.getElementById("varighet" + String(inp.id));
    if (inp.checked) {

        dropwdown.selectedIndex = 1;
        dropwdown.style.display = "inline";
    }
    else {
        dropwdown.selectedIndex = 0;
        dropwdown.style.display = "none";
    }
} 