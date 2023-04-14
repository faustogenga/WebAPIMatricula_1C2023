$(document).ready(function () {
    var codigoGira;

    $('#GirasTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitosoGira").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCamposGira();
        location.reload();
    });

    $("#btnAgregarGira").click(function () {
        if (validarCamposGira()) {

            var codigoGira = document.getElementById("IDAgregarGiraCodigo").value;

            if (codigoGira == "") {

                $.ajax({
                    url: '/Gira/AgregarGira',
                    type: 'POST',
                    data: {
                        codigoGira: document.getElementById("IDAgregarGiraCodigoGira").value,
                        organizacion: document.getElementById("IDAgregarGiraOrganizacion").value,
                        carreras: document.getElementById("IDAgregarGiraCarreras").value,
                        fecha: document.getElementById("IDAgregarGiraFecha").value,
                        horaSalida: document.getElementById("IDAgregarGiraHoraSalida").value,
                        horaRegreso: document.getElementById("IDAgregarGiraHoraRegreso").value,
                        tipo: document.getElementById("IDAgregarGiraTipo").value,

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposGira();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarGiraTipo");
                var tipoSelect = e.value;
                $.ajax({
                    url: '/Gira/EditarGira',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarGiraCodigo").value,
                        codigoGira: document.getElementById("IDAgregarGiraCodigoGira").value,
                        organizacion: document.getElementById("IDAgregarGiraOrganizacion").value,
                        carreras: document.getElementById("IDAgregarGiraCarreras").value,
                        fecha: document.getElementById("IDAgregarGiraFecha").value,
                        horaSalida: document.getElementById("IDAgregarGiraHoraSalida").value,
                        horaRegreso: document.getElementById("IDAgregarGiraHoraRegreso").value,
                        tipo: tipoSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposGira();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarGira").click(function () {
        limpiarCamposGira();
    });


    $("a[name='btnEditarGira']").click(function () {

        codigoGira = $(this).data("id");
        var verDetalle = VerDetalleGira(codigoGira);

    });

    $("a[name='btnEliminarGira']").click(function () {

        codigoGira = $(this).data("id");
        $('#modalVentanaEliminarGira').modal('show');
    });

    $("#btnAbrirDialogAgregarGira").click(function () {
        $('#modalAgregarGira').modal('show');
    });

    $("#btnAceptarEliminarGiraConfirmacion").click(function () {

        $.ajax({
            url: '/Gira/EliminarGira',
            type: 'POST',
            data: {
                Codigo: codigoGira
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCamposGira();
                $('#modalVentanaEliminarGira').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarGiraConfirmacion").click(function () {
        $('#modalVentanaEliminarGira').modal('hide');
        location.reload();
    });

    $("#textoBuscarGira").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#GirasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCamposGira() {
    $('#modalAgregarGira').modal('hide');
    
    document.getElementById("IDAgregarGiraCodigoGira").value = "";
    document.getElementById("IDAgregarGiraOrganizacion").value = "";
    document.getElementById("IDAgregarGiraCarreras").value = "";
    document.getElementById("IDAgregarGiraFecha").value = "";
    document.getElementById("IDAgregarGiraHoraSalida").value = "";
    document.getElementById("IDAgregarGiraHoraRegreso").value = "";
    document.getElementById("IDAgregarGiraTipo").value = "";

    $("IDAgregarGiraCodigoGira").css('border', '1px solid #ced4da');
    $("IDAgregarGiraOrganizacion").css('border', '1px solid #ced4da');
    $("IDAgregarGiraCarreras").css('border', '1px solid #ced4da');
    $("IDAgregarGiraFecha").css('border', '1px solid #ced4da');
    $("IDAgregarGiraHoraSalida").css('border', '1px solid #ced4da');
    $("IDAgregarGiraHoraRegreso").css('border', '1px solid #ced4da');
    $("IDAgregarGiraTipo").css('border', '1px solid #ced4da');
    
}



function validarCamposGira() {
    var bandera = true;
    var AgregarGiraCodigoGira = document.getElementById("IDAgregarGiraCodigoGira").value;
    var AgregarGiraOrganizacion = document.getElementById("IDAgregarGiraOrganizacion").value;
    var AgregarGiraCarreras = document.getElementById("IDAgregarGiraCarreras").value;
    var AgregarGiraFecha = document.getElementById("IDAgregarGiraFecha").value;
    var AgregarGiraHoraSalida = document.getElementById("IDAgregarGiraHoraSalida").value;
    var AgregarGiraHoraRegreso = document.getElementById("IDAgregarGiraHoraRegreso").value;
    var AgregarGiraTipo = document.getElementById("IDAgregarGiraTipo").value;


    if (AgregarGiraCodigoGira == "") {
        $("#IDAgregarGiraCodigoGira").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarGiraCodigoGira').css('border', '1px solid #ced4da');
    }

    if (AgregarGiraOrganizacion == "") {
        $("#IDAgregarGiraOrganizacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarGiraOrganizacion').css('border', '1px solid #ced4da');
    }

    if (AgregarGiraCarreras == "") {
        $("#IDAgregarGiraCarreras").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarGiraCarreras').css('border', '1px solid #ced4da');
    }

    if (AgregarGiraFecha == "") {
        $("#IDAgregarGiraFecha").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarGiraFecha').css('border', '1px solid #ced4da');
    }
    if (AgregarGiraHoraSalida == "") {
        $("#IDAgregarGiraHoraSalida").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarGiraHoraSalida').css('border', '1px solid #ced4da');
    }
    if (AgregarGiraHoraRegreso == "") {
        $("#IDAgregarGiraHoraRegreso").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarGiraHoraRegreso').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleGira(codigo) {

    $.ajax({
        url: '/Gira/VerDetalleGira',
        type: 'POST',
        data: {
            codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarGiraTipo").value = response.tipo;
            document.getElementById("IDAgregarGiraCodigoGira").value = response.codigoGira;
            document.getElementById("IDAgregarGiraOrganizacion").value = response.organizacion;
            document.getElementById("IDAgregarGiraCarreras").value = response.carreras;
            document.getElementById("IDAgregarGiraFecha").value = response.fecha;
            document.getElementById("IDAgregarGiraHoraSalida").value = response.horaSalida;
            document.getElementById("IDAgregarGiraHoraRegreso").value = response.horaRegreso;
            document.getElementById("IDAgregarGiraCodigo").value = response.codigo;
            $('#modalAgregarGira').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
