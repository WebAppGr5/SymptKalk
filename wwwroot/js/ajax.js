

      //"1","3,"5"... 1,"2",4 eller 1,2,4...
function hentDiagnoserGittSymptomer(inputIdList, inputVarighetValgListe) {
    let inputConverted = inputIdList.map((x) => Number(x));
    let inputVarighetValgListeConverted = inputVarighetValgListe.map((x) => Number(x));

    let listeTilSend = [];

    inputConverted.forEach((ele,idx) => {
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

         });
}

function hentSymptomer() {
        $.get({
            url: "Diagnose/getSymptomer",
            data: {},
            contentType: "application/json; charset=utf-8"
        }).done((res) => {
            var IDList = document.querySelectorAll('input[name="1"]:checked').value;
            }

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
function hentSymptomerGittSymptomGruppeId(id) {

    $.get({
        url: "Diagnose/getSymptomerGittGruppeId",
        data: { id: Number(id) },
        contentType: "application/json; charset=utf-8"
    }).done((res) => {

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
            
        });
    }

function hentDiagnoseGrupper() {
    $.get({
        url: "Diagnose/getDiagnoseGrupper",
        data: {},
        contentType: "application/json; charset=utf-8"
    }).done((res) => {

    });
}

