$(document).ready(function () {
    var codigoClub;

    $('#ClubesTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitosoClub").click(function () {
        $('#modalVentanaExitosaClub').modal('hide');
        limpiarCamposClub();
        location.reload();
    });

    $("#btnAgregarClub").click(function () {
        if (validarCamposClub()) {

            var codigoClub = document.getElementById("IDAgregarClubCodigo").value;

            if (codigoClub == "") {

                $.ajax({
                    url: '/Club/AgregarClub',
                    type: 'POST',
                    data: {
                        nombre: document.getElementById("IDAgregarClubNombre").value,
                        horario: document.getElementById("IDAgregarClubHorario").value,
                        ubicacion: document.getElementById("IDAgregarClubUbicacion").value,
                        contacto: document.getElementById("IDAgregarClubContacto").value,
                        encargado: document.getElementById("IDAgregarClubEncargado").value,
                        tipo: document.getElementById("IDAgregarClubTipo").value,

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposClub();
                        $('#modalVentanaExitosaClub').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarClubTipo");
                var tipoSelect = e.value;
                $.ajax({
                    url: '/Club/EditarClub',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarClubCodigo").value,
                        nombre: document.getElementById("IDAgregarClubNombre").value,
                        horario: document.getElementById("IDAgregarClubHorario").value,
                        ubicacion: document.getElementById("IDAgregarClubUbicacion").value,
                        contacto: document.getElementById("IDAgregarClubContacto").value,
                        encargado: document.getElementById("IDAgregarClubEncargado").value,
                        tipo: tipoSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposClub();
                        $('#modalVentanaExitosaClub').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarClub").click(function () {
        limpiarCamposClub();
    });


    $("a[name='btnEditarClub']").click(function () {

        codigoClub = $(this).data("id");
        var verDetalle = VerDetalleClub(codigoClub);

    });

    $("a[name='btnEliminarClub']").click(function () {

        codigoClub = $(this).data("id");
        $('#modalVentanaEliminarClub').modal('show');
    });

    $("#btnAbrirDialogAgregarClub").click(function () {
        $('#modalAgregarClub').modal('show');
    });

    $("#btnAceptarEliminarClubConfirmacion").click(function () {

        $.ajax({
            url: '/Club/EliminarClub',
            type: 'POST',
            data: {
                Codigo: codigoClub
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCamposClub();
                $('#modalVentanaEliminarClub').modal('hide');
                $('#modalVentanaExitosaClub').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarClubConfirmacion").click(function () {
        $('#modalVentanaEliminarClub').modal('hide');
        location.reload();
    });

    $("#textoBuscarClub").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ClubsTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCamposClub() {
    $('#modalAgregarClub').modal('hide');
    
    document.getElementById("IDAgregarClubNombre").value = "";
    document.getElementById("IDAgregarClubHorario").value = "";
    document.getElementById("IDAgregarClubUbicacion").value = "";
    document.getElementById("IDAgregarClubContacto").value = "";
    document.getElementById("IDAgregarClubEncargado").value = "";
    document.getElementById("IDAgregarClubTipo").value = "";

    $("IDAgregarClubNombre").css('border', '1px solid #ced4da');
    $("IDAgregarClubHorario").css('border', '1px solid #ced4da');
    $("IDAgregarClubUbicacion").css('border', '1px solid #ced4da');
    $("IDAgregarClubContacto").css('border', '1px solid #ced4da');
    $("IDAgregarClubEncargado").css('border', '1px solid #ced4da');
    $("IDAgregarClubTipo").css('border', '1px solid #ced4da');
    
}



function validarCamposClub() {
    var bandera = true;
    var AgregarClubNombre = document.getElementById("IDAgregarClubNombre").value;
    var AgregarClubHorario = document.getElementById("IDAgregarClubHorario").value;
    var AgregarClubUbicacion = document.getElementById("IDAgregarClubUbicacion").value;
    var AgregarClubContacto = document.getElementById("IDAgregarClubContacto").value;
    var AgregarClubEncargado = document.getElementById("IDAgregarClubEncargado").value;
    var AgregarClubTipo = document.getElementById("IDAgregarClubTipo").value;


    if (AgregarClubNombre == "") {
        $("#IDAgregarClubNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarClubCodigoClub').css('border', '1px solid #ced4da');
    }

    if (AgregarClubHorario == "") {
        $("#IDAgregarClubHorario").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarClubHorario').css('border', '1px solid #ced4da');
    }

    if (AgregarClubUbicacion == "") {
        $("#IDAgregarClubUbicacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarClubUbicacion').css('border', '1px solid #ced4da');
    }

    if (AgregarClubContacto == "") {
        $("#IDAgregarClubContacto").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarClubContacto').css('border', '1px solid #ced4da');
    }
    if (AgregarClubEncargado == "") {
        $("#IDAgregarClubEncargado").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarClubEncargado').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleClub(codigo) {

    $.ajax({
        url: '/Club/VerDetalleClub',
        type: 'POST',
        data: {
            codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarClubTipo").value = response.tipo;
            document.getElementById("IDAgregarClubNombre").value = response.nombre;
            document.getElementById("IDAgregarClubHorario").value = response.horario;
            document.getElementById("IDAgregarClubUbicacion").value = response.ubicacion;
            document.getElementById("IDAgregarClubContacto").value = response.contacto;
            document.getElementById("IDAgregarClubEncargado").value = response.encargado;
            document.getElementById("IDAgregarClubCodigo").value = response.codigo;
            $('#modalAgregarClub').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
