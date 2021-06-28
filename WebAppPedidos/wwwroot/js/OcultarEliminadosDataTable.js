// Feature: Agrego boton de ocultamiento de articulos eliminados
var ano = new Date().getFullYear();
$("#body-table").find("tr").hide().filter(":contains('VIGENTE')").show();
$(".dataTables_paginate, #CheckboxOcultarEliminados, #CheckboxOcultarModificadosAntiguos, .form-control").on('click', function () {
    $("#body-table").find("tr").show();
    if ($("#CheckboxOcultarEliminados").prop("checked") == true && $("#CheckboxOcultarModificadosAntiguos").prop("checked") == true) {
        $("#body-table").find("tr").hide().filter(":contains('VIGENTE')").filter(`:contains('${ano}')`).show();
    }
    else if ($("#CheckboxOcultarEliminados").prop("checked") == true && $("#CheckboxOcultarModificadosAntiguos").prop("checked") != true) {
        $("#body-table").find("tr").hide().filter(":contains('VIGENTE')").show();
    }
    else if ($("#CheckboxOcultarEliminados").prop("checked") != true && $("#CheckboxOcultarModificadosAntiguos").prop("checked") == true) {
        $("#body-table").find("tr").hide().filter(`:contains('${ano}')`).show();
    }
})
