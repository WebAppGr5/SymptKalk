

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
    }).done(async (res) => {
        $("#diagnoser").empty();
        let html = "<h2 class='underoverskrift'>Diagnoser:</h2>";
        $(html).appendTo("#diagnoser");
        res.forEach((diagnose) => {
            let html = "";
            html += "<div>";
            html += "<h3> " + String(diagnose.navn);

       

            html += "      <i  class='fa-solid fa-xmark  fa-2xl' onclick='forgetDiagnose(\"" + String(diagnose.diagnoseId) + "\")'></i>"
            html += "      <button class='knapp2' onclick='endre(\"" + String(diagnose.diagnoseId) + "\")'>Endre</button>"
            html += "</h3 > ";
            html += String(diagnose.beskrivelse);
            html += "      </div>";
            html += "         <br>";
            $(html).appendTo("#diagnoser");
        });


    }).fail((x) => {
        swal("Fikk ikke hentet diagnosene", "Prøv igjen senere", "error")
    });
}
function nyDiagnose() {
    let symptomer = checked().map((x)=>Number(x));
    let varigheter = [];
    symptomer.forEach((symId) => {
        let valg = document.getElementById("varighet" + String(symId)).selectedIndex;
        varigheter.push(valg);

    });

    let diagnoseDTO = {
        navn: String($("#navnDiagnose").val()),
        beskrivelse: String($("#beskrivelseDiagnose").val()),
        dypForklaring: String($("#dypForklaringDiagnose").val()),
        symptomer: symptomer,
        varigheter: varigheter
    }
    $.post({
        url: "Diagnose/nyDiagnose",
        data: JSON.stringify(diagnoseDTO),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
    }).done(async (res) => {
        await swal("Fikk lagret diagnosen", "Fikk lagret diagnosen", "success");
        sendIdAndSelectListToServer();
    }).fail((x) => {
        swal("Fikk ikke legge til", "Prøv igjen senere", "error")
    });


}

function utforEndring() {

    let diagnose = {
        diagnoseId: Number($("#diagnoseIdEndre").val()) ,
        navn: String($("#navnDiagnose").val()),
        beskrivelse: String($("#beskrivelseDiagnose").val()),
        dypForklaring: String($("#dypForklaringDiagnose").val())
    }
    $.post({
        url: "Diagnose/update",
        data: JSON.stringify(diagnose),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
    }).done(async (res) => {
         await swal("Fikk endret diagnosen", "Fikk endret diagnosen", "success");
        sendIdAndSelectListToServer();
    }).fail((x) => {
        swal("Fikk ikk endre", "Prøv igjen senere", "error")
    });


}

function forgetDiagnose(diagnoseId) {
    
    $.get({
        url: "Diagnose/forgetDiagnose/" + String(diagnoseId),
        data: { },
        contentType: "application/json; charset=utf-8"
    }).done(async (res) => {
        await swal("Diagnosen er nå glemt", "Fra nå av vil du aldri se denne diagnosen mer", "success");
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
        }).fail((x) => {
        swal("Noe gikk galt", "prøv igjen senere", "error")
        });
}
function hentDiagnoseGittDiagnoseId( id) {
    $.get({
        url: "Diagnose/hentDiagnoseGittDiagnoseId/" +String(id),
        data: {},
        contentType: "application/json; charset=utf-8"
    }).done((res) => {
        $("#navnDiagnose").val(String(res.navn));
        $("#beskrivelseDiagnose").val(String(res.beskrivelse));
        $("#dypForklaringDiagnose").val(String(res.dypForklaring));
        $("#diagnoseIdEndre").val(String(res.diagnoseId));
    }).fail((x) => {
        swal("Noe gikk galt", "prøv igjen senere", "error")
    });
}
function hentDiagnoser() {
    $.get({
        url: "Diagnose/getDiagnoser",
        data: {},
        contentType: "application/json; charset=utf-8"
    }).done(async (res) => {

        $("#diagnoser").empty();
        let html = "<h2 class='underoverskrift'>Diagnoser:</h2>";
        $(html).appendTo("#diagnoser");
        res.forEach((diagnose) => {
            let html = "";
            html += "<div>";
            html += "<h3> " + String(diagnose.navn);



            html += "      <i  class='fa-solid fa-xmark  fa-2xl' onclick='forgetDiagnose(\"" + String(diagnose.diagnoseId) + "\")'></i>"
            html += "      <button class='knapp2' onclick='endre(\"" + String(diagnose.diagnoseId) + "\")'>Endre</button>"
            html += "</h3 > ";
            html += String(diagnose.beskrivelse);
            html += "      </div>";
            html += "         <br>";
            $(html).appendTo("#diagnoser");
        });
        await swal("Fikk hentet diagnosene", "Ved å trykke på checkboxene og ved å variere hvor lenge en har hatt ulike symptomer, så vil listen over diagnoser du kan ha endre seg", "success")

    }).fail((x) => {
        swal("Fikk ikke hentet diagnosene", "Prøv igjen senere", "error")
    });
}
function hentSymptomerGittSymptomGruppeId(id, name) {

    $.get({
        url: "Diagnose/getSymptomerGittGruppeId/" + String(id),
        data: { },
        contentType: "application/json; charset=utf-8"
    }).done(async (res) => {
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
       
    });
}
function hentDiagnoserGittDiagnoseGruppe(id) {

    $.get({
        url: "Diagnose/getDiagnoserGittId/" + String(id),
        data: { },
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
