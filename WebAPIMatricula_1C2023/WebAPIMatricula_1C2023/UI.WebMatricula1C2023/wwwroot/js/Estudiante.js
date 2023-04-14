$(document).ready(function () {
    var codigoEstudiante;

    $('#EstudiantesTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitoso").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCampos();
        location.reload();
    });

    $("#btnAgregarEstudiante").click(function () {
        if (validarCamposEstudiante()) {

            var codigoEstudiante = document.getElementById("IDAgregarEstudianteCodigo").value;

            if (codigoEstudiante == "") {

                $.ajax({
                    url: '/Estudiante/AgregarEstudiante',
                    type: 'POST',
                    data: {
                        identificacion: document.getElementById("IDAgregarEstudianteIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarEstudianteNombre").value,
                        correoElectronico: document.getElementById("IDAgregarEstudianteCorreo").value,
                        estado: document.getElementById("IDAgregarEstudianteEstado").value

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarEstudianteEstado");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Estudiante/EditarEstudiante',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarEstudianteCodigo").value,
                        identificacion: document.getElementById("IDAgregarEstudianteIdentificacion").value,
                        nombreCompleto: document.getElementById("IDAgregarEstudianteNombre").value,
                        correoElectronico: document.getElementById("IDAgregarEstudianteCorreo").value,
                        estado: estadoSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCampos();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarEstudiante").click(function () {
        limpiarCampos();
    });


    $("a[name='btnEditarEstudiante']").click(function () {

        codigoEstudiante = $(this).data("id");
        var verDetalle = VerDetalleEstudiante(codigoEstudiante);

    });

    $("a[name='btnEliminarEstudiante']").click(function () {

        codigoEstudiante = $(this).data("id");
        $('#modalVentanaEliminarEstudiante').modal('show');
    });

    $("#btnAbrirDialogAgregarEstudiante").click(function () {
        $('#modalAgregarEstudiante').modal('show');
    });

    $("#btnAceptarEliminarEstudianteConfirmacion").click(function () {

        $.ajax({
            url: '/Estudiante/EliminarEstudiante',
            type: 'POST',
            data: {
                Codigo: codigoEstudiante
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCampos();
                $('#modalVentanaEliminarEstudiante').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarEstudianteConfirmacion").click(function () {
        $('#modalVentanaEliminarEstudiante').modal('hide');
        location.reload();
    });

    $("#textoBuscarEstudiante").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#EstudiantesTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCampos() {
    $('#modalAgregarEstudiante').modal('hide');

    document.getElementById("IDAgregarEstudianteCodigo").value = "";
    document.getElementById("IDAgregarEstudianteIdentificacion").value = "";
    document.getElementById("IDAgregarEstudianteNombre").value = "";
    document.getElementById("IDAgregarEstudianteCorreo").value = "";
    document.getElementById("IDAgregarEstudianteEstado").value = "";

    $("IDAgregarEstudianteIdentificacion").css('border', '1px solid #ced4da');
    $("IDAgregarEstudianteNombre").css('border', '1px solid #ced4da');
    $("IDAgregarEstudianteCorreo").css('border', '1px solid #ced4da');
    $("IDAgregarEstudianteEstado").css('border', '1px solid #ced4da');
}



function validarCamposEstudiante() {
    var bandera = true;
    var agregarEstudianteIdentificacion = document.getElementById("IDAgregarEstudianteIdentificacion").value;
    var agregarEstudianteNombre = document.getElementById("IDAgregarEstudianteNombre").value;
    var agregarEstudianteCorreo = document.getElementById("IDAgregarEstudianteCorreo").value;
    var agregarEstudianteEstado = document.getElementById("IDAgregarEstudianteEstado").value;

    if (agregarEstudianteIdentificacion == "") {
        $("#IDAgregarEstudianteIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEstudianteIdentificacion').css('border', '1px solid #ced4da');
    }

    if (agregarEstudianteNombre == "") {
        $("#IDAgregarEstudianteNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEstudianteNombre').css('border', '1px solid #ced4da');
    }

    if (agregarEstudianteCorreo == "") {
        $("#IDAgregarEstudianteCorreo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEstudianteCorreo').css('border', '1px solid #ced4da');
    }

    if (agregarEstudianteIdentificacion == "") {
        $("#IDAgregarEstudianteIdentificacion").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarEstudianteIdentificacion').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleEstudiante(codigo) {

    $.ajax({
        url: '/Estudiante/VerDetalleEstudiante',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarEstudianteEstado").value = response.estado;
            document.getElementById("IDAgregarEstudianteNombre").value = response.nombreCompleto;
            document.getElementById("IDAgregarEstudianteCorreo").value = response.correoElectronico;
            document.getElementById("IDAgregarEstudianteIdentificacion").value = response.identificacion;
            document.getElementById("IDAgregarEstudianteCodigo").value = response.codigo;
            $('#modalAgregarEstudiante').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
