

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
            html += "<h3> " + String(diagnose.navn);

            if (Number(diagnose.padState) == 0) {
                html += "     <i class='fa-solid fa-lock fa-2xl' onclick='changePadState(\"" + String(diagnose.diagnoseId) + "\",\"" + String(diagnose.padState) + "\")'></i>";
            }
            if (Number(diagnose.padState) == 1) {
                html += "      <i class='fas  fa-lock-open fa-2xl' onclick='changePadState(\"" + String(diagnose.diagnoseId) + "\",\"" + String(diagnose.padState) + "\")'></i>";
            }

            html += "      <i  class='fa-solid fa-xmark  fa-2xl' onclick='forgetDiagnose(\"" + String(diagnose.diagnoseId) + "\")'></i>"
            html += "</h3 > ";
            html += String(diagnose.beskrivelse);
            html += "      </div>";
            html += "         <br>";
            $(html).appendTo("#diagnoser");
        });
        swal("Fikk hentet diagnosene", "Symptomene og varigheten til de ulike symptomene endret seg - det gjorde også diagnosene", "success")

    }).fail((x) => {
        swal("Fikk ikke hentet diagnosene", "Prøv igjen senere", "error")
    });
}
function changePadState(diagnoseId, currentState) {
    let wantedState = 0;
    if (Number(currentState) == 0)
        wantedState = 1;
    else
        wantedState = 0;

    let diagnoseDTO = {
        diagnoseId: Number(diagnoseId),
        padState: Number(wantedState)
    }


    $.post({
        url: "Diagnose/changePadState",
        data: JSON.stringify(diagnoseDTO),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
    }).done((res) => {
        swal("Fikk utført endringen", "Fra nå av vil du huske hvorvidt dette er en akutell diagnose", "success")
        sendIdAndSelectListToServer();
    }).fail((x) => {
        swal("Kunne ikke endre hengelås tilstand", "Prøv igjen senere", "error")
    });
}

function forgetDiagnose(diagnoseId) {
    
    $.get({
        url: "Diagnose/forgetDiagnose",
        data: { id: Number(diagnoseId) },
        contentType: "application/json; charset=utf-8"
    }).done((res) => {
        swal("Diagnosen er nå glemt", "Fra nå av vil du aldri se denne diagnosen mer", "success");
        sendIdAndSelectListToServer();
    }).fail((x) => {
        swal("Kunne ikke å fjerne diagnosen", "Prøv igjen senere", "error")
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

     
            let html = "<input class='symptomene' type='checkbox' id='" + String(symptom.symptomId)+"' name='1' value='" + String(name) + "' onclick='checkbox(this)'>";
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
        swal("Velkommen til symptom kalkulatoren", "Trykk på de ulike checkboxene gjemt under svarte knappene, og varier hvor lenge du har hatt symptomet. \n Når du gjør dette vil du få diagnoser som inneholder de symptomene du har ", "info")
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

