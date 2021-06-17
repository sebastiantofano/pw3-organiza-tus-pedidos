// Feature: Agrego boton de ocultamiento de articulos eliminados
$("#body-table").find("tr").hide().filter(":contains('VIGENTE')").show();
$(".dataTables_paginate, #CheckboxOcultarEliminados").on('click', function () {
    $("#body-table").find("tr").show();
    if ($("#CheckboxOcultarEliminados").prop("checked") == true) {
        $("#body-table").find("tr").hide().filter(":contains('VIGENTE')").show();
    }
})