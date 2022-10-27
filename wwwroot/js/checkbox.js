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
    let checkBox = document.getElementById("varighet" + String(inp.id));
    if (inp.checked) {

        checkBox.selectedIndex = 1;
        checkBox.style.display = "inline";
    }
    else {
        checkBox.selectedIndex = 0;
        checkBox.style.display = "none";
    }
} 