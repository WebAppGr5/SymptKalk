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
/*function list() {
var ID = [];

//Hode
for (i=001; i < 013; i++ ){
var check  = document.getElementById(i);
    if (check.checked){
        if(i in ID === false){
           ID += i;
        }
    }
    else{
        if(i in ID === true){
            ID -= i;
        }
    }
    i++;
}
//Overkropp
for (i=101; i < 117; i++ ){
var check  = document.getElementById(i);
    if (check.checked){
        if(i in ID === false){
           ID += i;
        }
    }
    else{
        if(i in ID === true){
            ID -= i;
        }
    }
    i++;
}
//underkropp
for (i=201; i < 218; i++ ){
var check  = document.getElementById(i);
    if (check.checked){
        if(i in ID === false){
           ID += i;
        }
    }
    else{
        if(i in ID === true){
            ID -= i;
        }
    }
    i++;
}
console.log(ID);
}*/

function checked(){

let sympt = document.querySelectorAll('input[name="1"]:checked');
var IDs = [];
sympt.forEach((checkbox)=> {
    if(id in IDs === false) {
        IDs.push(checkbox.id);
        }
    });
if (sympt === false){
    if(id in IDs === true){
        IDs -= id;
        }
    }

}
//https://www.javascripttutorial.net/javascript-dom/javascript-checkbox/ Linken til hvor jeg fant koden jeg brukte for dette

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