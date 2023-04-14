$(document).ready(function () {
    var codigoCurso;

    $('#CursosTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitosoCurso").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCamposCurso();
        location.reload();
    });

    $("#btnAgregarCurso").click(function () {
        if (validarCamposCurso()) {

            var codigoCurso = document.getElementById("IDAgregarCursoCodigo").value;

            if (codigoCurso == "") {

                $.ajax({
                    url: '/Curso/AgregarCurso',
                    type: 'POST',
                    data: {
                        Nombre: document.getElementById("IDAgregarCursoNombre").value,
                        Creditos: parseInt(document.getElementById("IDAgregarCursoCreditos").value, 10),
                        Horario: document.getElementById("IDAgregarCursoHorario").value,
                        Cupo: parseInt(document.getElementById("IDAgregarCursoCupo").value, 10),
                        Estado: document.getElementById("IDAgregarCursoEstado").value

                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposCurso();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarCursoEstado");
                var estadoSelect = e.value;
                $.ajax({
                    url: '/Curso/EditarCurso',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarCursoCodigo").value,
                        Nombre: document.getElementById("IDAgregarCursoNombre").value,
                        Creditos: document.getElementById("IDAgregarCursoCreditos").value,
                        Horario: document.getElementById("IDAgregarCursoHorario").value,
                        Cupo: document.getElementById("IDAgregarCursoCupo").value,
                        estado: estadoSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposCurso();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarCurso").click(function () {
        limpiarCamposCurso();
    });


    $("a[name='btnEditarCurso']").click(function () {

        codigoCurso = $(this).data("id");
        var verDetalle = VerDetalleCurso(codigoCurso);

    });

    $("a[name='btnEliminarCurso']").click(function () {

        codigoCurso = $(this).data("id");
        $('#modalVentanaEliminarCurso').modal('show');
    });

    $("#btnAbrirDialogAgregarCurso").click(function () {
        $('#modalAgregarCurso').modal('show');
    });

    $("#btnAceptarEliminarCursoConfirmacion").click(function () {

        $.ajax({
            url: '/Curso/EliminarCurso',
            type: 'POST',
            data: {
                Codigo: codigoCurso
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCamposCurso();
                $('#modalVentanaEliminarCurso').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarCursoConfirmacion").click(function () {
        $('#modalVentanaEliminarCurso').modal('hide');
        location.reload();
    });

    $("#textoBuscarCurso").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#CursosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCamposCurso() {
    $('#modalAgregarCurso').modal('hide');
    
    document.getElementById("IDAgregarCursoCodigo").value = "";
    document.getElementById("IDAgregarCursoNombre").value = "";
    document.getElementById("IDAgregarCursoCreditos").value = "";
    document.getElementById("IDAgregarCursoHorario").value = "";
    document.getElementById("IDAgregarCursoCupo").value = "";
    document.getElementById("IDAgregarCursoEstado").value = "";

    $("IDAgregarCursoNombre").css('border', '1px solid #ced4da');
    $("IDAgregarCursoCreditos").css('border', '1px solid #ced4da');
    $("IDAgregarCursoHorario").css('border', '1px solid #ced4da');
    $("IDAgregarCursoCupo").css('border', '1px solid #ced4da');
    $("IDAgregarCursoEstado").css('border', '1px solid #ced4da');
    
}



function validarCamposCurso() {
    var bandera = true;
    var agregarCursoNombre = document.getElementById("IDAgregarCursoNombre").value;
    var agregarCursoCreditos = document.getElementById("IDAgregarCursoCreditos").value;
    var agregarCursoHorario = document.getElementById("IDAgregarCursoHorario").value;
    var agregarCursoCupo = document.getElementById("IDAgregarCursoCupo").value;
    var agregarCursoEstado = document.getElementById("IDAgregarCursoEstado").value;


    if (agregarCursoNombre == "") {
        $("#IDAgregarCursoNombre").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoNombre').css('border', '1px solid #ced4da');
    }

    if (agregarCursoCreditos == "") {
        $("#IDAgregarCursoCreditos").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoCreditos').css('border', '1px solid #ced4da');
    }

    if (agregarCursoHorario == "") {
        $("#IDAgregarCursoHorario").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoHorario').css('border', '1px solid #ced4da');
    }

    if (agregarCursoCupo == "") {
        $("#IDAgregarCursoCupo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCursoCupo').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleCurso(codigo) {

    $.ajax({
        url: '/Curso/VerDetalleCurso',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarCursoEstado").value = response.estado;
            document.getElementById("IDAgregarCursoNombre").value = response.nombre;
            document.getElementById("IDAgregarCursoCreditos").value = response.creditos;
            document.getElementById("IDAgregarCursoHorario").value = response.horario;
            document.getElementById("IDAgregarCursoCupo").value = response.cupo;
            document.getElementById("IDAgregarCursoCodigo").value = response.codigo;
            $('#modalAgregarCurso').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
