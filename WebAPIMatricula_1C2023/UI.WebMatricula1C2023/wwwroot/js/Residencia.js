$(document).ready(function () {
    var codigoResidencia;

    $('#ResidenciasTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitosoResidencia").click(function () {
        $('#modalVentanaExitosaResidencia').modal('hide');
        limpiarCamposResidencia();
        location.reload();
    });

    $("#btnAgregarResidencia").click(function () {
        if (validarCamposResidencia()) {

            var codigoResidencia = document.getElementById("IDAgregarResidenciaCodigo").value;

            if (codigoResidencia == "") {

                $.ajax({
                    url: '/Residencia/AgregarResidencia',
                    type: 'POST',
                    data: {
                        cedula: document.getElementById("IDAgregarResidenciaCedula").value,
                        pais: document.getElementById("IDAgregarResidenciaPais").value,
                        provincia: document.getElementById("IDAgregarResidenciaProvincia").value,
                        canton: document.getElementById("IDAgregarResidenciaCanton").value,
                        distrito : document.getElementById("IDAgregarResidenciaDistrito").value,
                        dirExacta: document.getElementById("IDAgregarResidenciaDirExacta").value
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposResidencia();
                        $('#modalVentanaExitosaResidencia').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                $.ajax({
                    url: '/Residencia/EditarResidencia',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarResidenciaCodigo").value,
                        cedula: document.getElementById("IDAgregarResidenciaCedula").value,
                        pais: document.getElementById("IDAgregarResidenciaPais").value,
                        provincia: document.getElementById("IDAgregarResidenciaProvincia").value,
                        canton: document.getElementById("IDAgregarResidenciaCanton").value,
                        distrito: document.getElementById("IDAgregarResidenciaDistrito").value,
                        dirExacta: document.getElementById("IDAgregarResidenciaDirExacta").value,
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposResidencia();
                        $('#modalVentanaExitosaResidencia').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarResidencia").click(function () {
        limpiarCamposResidencia();
    });


    $("a[name='btnEditarResidencia']").click(function () {

        codigoResidencia = $(this).data("id");
        var verDetalle = VerDetalleResidencia(codigoResidencia);

    });

    $("a[name='btnEliminarResidencia']").click(function () {

        codigoResidencia = $(this).data("id");
        $('#modalVentanaEliminarResidencia').modal('show');
    });

    $("#btnAbrirDialogAgregarResidencia").click(function () {
        $('#modalAgregarResidencia').modal('show');
    });

    $("#btnAceptarEliminarResidenciaConfirmacion").click(function () {

        $.ajax({
            url: '/Residencia/EliminarResidencia',
            type: 'POST',
            data: {
                Codigo: codigoResidencia
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCamposResidencia();
                $('#modalVentanaEliminarResidencia').modal('hide');
                $('#modalVentanaExitosaResidencia').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarResidenciaConfirmacion").click(function () {
        $('#modalVentanaEliminarResidencia').modal('hide');
        location.reload();
    });

    $("#textoBuscarResidencia").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ResidenciasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCamposResidencia() {
    $('#modalAgregarResidencia').modal('hide');

    document.getElementById("IDAgregarResidenciaCodigo").value = "";
    document.getElementById("IDAgregarResidenciaCedula").value = "";
    document.getElementById("IDAgregarResidenciaPais").value = "";
    document.getElementById("IDAgregarResidenciaProvincia").value = "";
    document.getElementById("IDAgregarResidenciaCanton").value = "";
    document.getElementById("IDAgregarResidenciaDistrito").value = "";
    document.getElementById("IDAgregarResidenciaDirExacta").value = "";

    $("IDAgregarResidenciaCedula").css('border', '1px solid #ced4da');
    $("IDAgregarResidenciaPais").css('border', '1px solid #ced4da');
    $("IDAgregarResidenciaProvincia").css('border', '1px solid #ced4da');
    $("IDAgregarResidenciaCanton").css('border', '1px solid #ced4da');
    $("IDAgregarResidenciaDistrito").css('border', '1px solid #ced4da');
    $("IDAgregarResidenciaDirExacta").css('border', '1px solid #ced4da');

}



function validarCamposResidencia() {
    var bandera = true;
    var agregarResidenciaCedula = document.getElementById("IDAgregarResidenciaCedula").value;
    var agregarResidenciaPais = document.getElementById("IDAgregarResidenciaPais").value;
    var agregarResidenciaProvincia = document.getElementById("IDAgregarResidenciaProvincia").value;
    var agregarResidenciaCanton = document.getElementById("IDAgregarResidenciaCanton").value;
    var agregarResidenciaDistrito = document.getElementById("IDAgregarResidenciaDistrito").value;
    var agregarResidenciaDirExacta = document.getElementById("IDAgregarResidenciaDirExacta").value;


    if (agregarResidenciaCedula == "") {
        $("#IDAgregarResidenciaCedula").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarResidenciaCedula').css('border', '1px solid #ced4da');
    }

    if (agregarResidenciaPais == "") {
        $("#IDAgregarResidenciaPais").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarResidenciaPais').css('border', '1px solid #ced4da');
    }

    if (agregarResidenciaProvincia == "") {
        $("#IDAgregarResidenciaProvincia").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarResidenciaProvincia').css('border', '1px solid #ced4da');
    }

    if (agregarResidenciaCanton == "") {
        $("#IDAgregarResidenciaCanton").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarResidenciaCanton').css('border', '1px solid #ced4da');
    }

    if (agregarResidenciaDistrito == "") {
        $("#IDAgregarResidenciaDistrito").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarResidenciaDistrito').css('border', '1px solid #ced4da');
    }

    if (agregarResidenciaDirExacta == "") {
        $("#IDAgregarResidenciaDirExacta").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarResidenciaDirExacta').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleResidencia(codigo) {

    $.ajax({
        url: '/Residencia/VerDetalleResidencia', 
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarResidenciaCodigo").value = response.codigo;
            document.getElementById("IDAgregarResidenciaCedula").value = response.cedula;
            document.getElementById("IDAgregarResidenciaPais").value = response.pais;
            document.getElementById("IDAgregarResidenciaProvincia").value = response.provincia;
            document.getElementById("IDAgregarResidenciaCanton").value = response.canton;
            document.getElementById("IDAgregarResidenciaDistrito").value = response.distrito;
            document.getElementById("IDAgregarResidenciaDirExacta").value = response.dirExacta;
            $('#modalAgregarResidencia').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
