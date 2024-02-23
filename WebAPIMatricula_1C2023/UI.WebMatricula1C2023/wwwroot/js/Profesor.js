$(document).ready(function () {
    var codigoProfesor;

    $('#ProfesoresTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitosoProfesor").click(function () {
        $('#modalVentanaExitosaProfesor').modal('hide');
        limpiarCamposProfesor();
        location.reload();
    });

    $("#btnAgregarProfesor").click(function () {
        if (validarCamposProfesor()) {

            var codigoProfesor = document.getElementById("IDAgregarProfesorCodigo").value;

            if (codigoProfesor == "") {

                $.ajax({
                    url: '/Profesor/AgregarProfesor',
                    type: 'POST',
                    data: {
                        identificacion: document.getElementById("IDAgregarProfesorIdentificacion").value,
                        nombreProfesor: document.getElementById("IDAgregarProfesorNombreProfesor").value,
                        correoElectronico: document.getElementById("IDAgregarProfesorCorreoElectronico").value,
                        carreraProfesional: document.getElementById("IDAgregarProfesorCarreraProfesional").value

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposProfesor();
                        $('#modalVentanaExitosaProfesor').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                $.ajax({
                    url: '/Profesor/EditarProfesor',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarProfesorCodigo").value,
                        identificacion: document.getElementById("IDAgregarProfesorIdentificacion").value,
                        nombreProfesor: document.getElementById("IDAgregarProfesorNombreProfesor").value,
                        correoElectronico: document.getElementById("IDAgregarProfesorCorreoElectronico").value,
                        carreraProfesional: document.getElementById("IDAgregarProfesorCarreraProfesional").value
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposProfesor();
                        $('#modalVentanaExitosaProfesor').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarProfesor").click(function () {
        limpiarCamposProfesor();
    });


    $("a[name='btnEditarProfesor']").click(function () {

        codigoProfesor = $(this).data("id");
        var verDetalle = VerDetalleProfesor(codigoProfesor);

    });

    $("a[name='btnEliminarProfesor']").click(function () {

        codigoProfesor = $(this).data("id");
        $('#modalVentanaEliminarProfesor').modal('show');
    });

    $("#btnAbrirDialogAgregarProfesor").click(function () {
        $('#modalAgregarProfesor').modal('show');
    });

    $("#btnAceptarEliminarProfesorConfirmacion").click(function () {

        $.ajax({
            url: '/Profesor/EliminarProfesor',
            type: 'POST',
            data: {
                Codigo: codigoProfesor
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCamposProfesor();
                $('#modalVentanaEliminarProfesor').modal('hide');
                $('#modalVentanaExitosaProfesor').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarProfesorConfirmacion").click(function () {
        $('#modalVentanaEliminarProfesor').modal('hide');
        location.reload();
    });

    $("#textoBuscarProfesor").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#ProfesorsTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCamposProfesor() {
    $('#modalAgregarProfesor').modal('hide');

    document.getElementById("IDAgregarProfesorCodigo").value = "";
    document.getElementById("IDAgregarProfesorIdentificacion").value = "";
    document.getElementById("IDAgregarProfesorNombreProfesor").value = "";
    document.getElementById("IDAgregarProfesorCorreoElectronico").value = "";
    document.getElementById("IDAgregarProfesorCarreraProfesional").value = "";

    $("IDAgregarProfesorIdentificacion").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorNombreProfesor").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorCorreoElectronico").css('border', '1px solid #ced4da');
    $("IDAgregarProfesorCarreraProfesional").css('border', '1px solid #ced4da');
}



function validarCamposProfesor() {
    var bandera = true;
    var agregarProfesorIdentificacion = document.getElementById("IDAgregarProfesorIdentificacion").value;
    var agregarProfesorNombreProfesor = document.getElementById("IDAgregarProfesorNombreProfesor").value;
    var agregarProfesorCorreoElectronico = document.getElementById("IDAgregarProfesorCorreoElectronico").value;
    var agregarProfesorCarreraProfesional = document.getElementById("IDAgregarProfesorCarreraProfesional").value;

    if (agregarProfesorIdentificacion == "") {
        $("#IDAgregarProfesorIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorIdentificacion').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorNombreProfesor == "") {
        $("#IDAgregarProfesorNombreProfesor").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorNombreProfesor').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorCorreoElectronico == "") {
        $("#IDAgregarProfesorCorreoElectronico").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorCorreoElectronico').css('border', '1px solid #ced4da');
    }

    if (agregarProfesorCarreraProfesional == "") {
        $("#IDAgregarProfesorCarreraProfesional").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarProfesorCarreraProfesional').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleProfesor(codigo) {

    $.ajax({
        url: '/Profesor/VerDetalleProfesor',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarProfesorCarreraProfesional").value = response.carreraProfesional;
            document.getElementById("IDAgregarProfesorNombreProfesor").value = response.nombreProfesor;
            document.getElementById("IDAgregarProfesorCorreoElectronico").value = response.correoElectronico;
            document.getElementById("IDAgregarProfesorIdentificacion").value = response.identificacion;
            document.getElementById("IDAgregarProfesorCodigo").value = response.codigo;
            $('#modalAgregarProfesor').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
