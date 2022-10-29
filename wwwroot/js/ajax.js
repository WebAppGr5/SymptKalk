

      //"1","3,"5"... 1,"2",4 eller 1,2,4...
function hentDiagnoserGittSymptomer(inputIdList, inputVarighetValgListe) {
    let inputConverted = inputIdList.map((x) => Number(x));
    let inputVarighetValgListeConverted = inputVarighetValgListe.map((x) => Number(x));

    let listeTilSend = [];

    inputConverted.forEach((ele, idx) => {
        let symptomDTO = {
            id: ele,
            varighet: inputVarighetValgListeConverted[idx]
        }
        listeTilSend.push(symptomDTO);
    });
    $.post({
        url: "Diagnose/getDiagnoserGittSymptomer",
        data: JSON.stringify(listeTilSend),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
    }).done((res) => {
        $("#diagnoser").empty();
        let html = "<h2 class='underoverskrift'>Diagnoser:</h2>";
        $(html).appendTo("#diagnoser");
        res.forEach((diagnose) => {
            let html = "";
            html += "<div>";
            html += "<h4> " + String(diagnose.navn) + "</h4 > ";
            html += String(diagnose.beskrivelse);
            html += "      </div>";
            html += "         <br>";
            $(html).appendTo("#diagnoser");
    });

         });
}

function hentSymptomer() {
        $.get({
            url: "Diagnose/getSymptomer",
            data: {},
            contentType: "application/json; charset=utf-8"
        }).done((res) => {
            var IDList = document.querySelectorAll('input[name="1"]:checked').value;
            tidsint();
        });
}

function hentDiagnoser() {
    $.get({
        url: "Diagnose/getDiagnoser",
        data: {},
        contentType: "application/json; charset=utf-8"
    }).done((res) => {

    });
}
function hentSymptomerGittSymptomGruppeId(id, name) {

    $.get({
        url: "Diagnose/getSymptomerGittGruppeId",
        data: { id: Number(id) },
        contentType: "application/json; charset=utf-8"
    }).done((res) => {
        res.forEach((symptom) => {

     
            let html = "<input type='checkbox' id='" + String(symptom.symptomId)+"' name='1' value='" + String(name) + "' onclick='checkbox(this)'>";
            html += "<label for='" + String(symptom.symptomId) + "'>" + String(symptom.navn) + "</label>";

            html += "<label class='varighet' for='varighet" + String(symptom.symptomId) + "'>Velg varighet</label>";
            html += "<select class='varighet' id='varighet" + String(symptom.symptomId) + "'  onchange='sendIdAndSelectListToServer()'>";
            html += "   <option>--</option>";
            html += "    <option>1-3 dager</option>";
            html += "    <option>Flere dager</option>";
            html += "     <option>1-3 uker</option>";
            html += "     <option>1-3 måneder</option>";
            html += "       <option>Flere måneder</option>";
            html += "       <option>1-3 år</option>";
            html += "       <option>Flere år</option>";
            html += "    </select>";

            html += "     <br/>";
           $(html).appendTo("#symGruppe" + String(symptom.symptomGruppeId));
        });
    });
}
function hentDiagnoserGittDiagnoseGruppe(id) {

    $.get({
        url: "Diagnose/getDiagnoserGittId",
        data: { id: Number(id) },
        contentType: "application/json; charset=utf-8"
    }).done((res) => {
      
    });
}
    function hentSymptomGrupper() {
         $.get({
             url: "Diagnose/getSymptomGrupper",
            data: {},
            contentType: "application/json; charset=utf-8"
         }).done((res) => {
             res.forEach((symGruppe) => {
                 let html = "<div id='meny" + String(symGruppe.symptomGruppeId) + "' >";
                 html += "<button class='knapp' onclick='toggleKategori(\"symGruppe" + String(symGruppe.symptomGruppeId) + "\")'>" + String(symGruppe.navn);
                 html += "<img class='dropDownIkon' src='img/pilned.png' alt='dropdown ikon'>";
                 html += "</button>"

                 html += "<div id = 'symGruppe" + String(symGruppe.symptomGruppeId) + "' style = 'display:none' >";

                 html += "</div>";
                 html += "</div>";
                 $(html).appendTo("#symptomGrupper");
                 hentSymptomerGittSymptomGruppeId(symGruppe.symptomGruppeId, symGruppe.navn);
             });
         
        });
    }

function hentDiagnoseGrupper() {
    $.get({
        url: "Diagnose/getDiagnoseGrupper",
        data: {},
        contentType: "application/json; charset=utf-8"
    }).done((res) => {

    });

    return []
}

