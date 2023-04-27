$(document).ready(function () {
    var codigoCarrera;

    $('#CarrerasTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitosoCarrera").click(function () {
        $('#modalVentanaExitosa').modal('hide');
        limpiarCamposCarrera();
        location.reload();
    });

    $("#btnAgregarCarrera").click(function () {
        if (validarCamposCarrera()) {

            var codigoCarrera = document.getElementById("IDAgregarCarreraCodigo").value;

            if (codigoCarrera == "") {

                $.ajax({
                    url: '/Carrera/AgregarCarrera',
                    type: 'POST',
                    data: {
                        carrera: document.getElementById("IDAgregarCarreraCarrera").value,
                        sede: document.getElementById("IDAgregarCarreraSede").value,
                        cuatrimestres: document.getElementById("IDAgregarCarreraCuatrimestres").value,
                        idioma: document.getElementById("IDAgregarCarreraIdioma").value,
                        materiasMatriculadas: document.getElementById("IDAgregarCarreraMateriasMatriculadas").value,
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposCarrera();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                var e = document.getElementById("IDAgregarCarreraMateriasMatriculadas");
                var MateriasSelect = e.value;
                $.ajax({
                    url: '/Carrera/EditarCarrera',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarCarreraCodigo").value,
                        carrera: document.getElementById("IDAgregarCarreraCarrera").value,
                        sede: document.getElementById("IDAgregarCarreraSede").value,
                        cuatrimestres: document.getElementById("IDAgregarCarreraCuatrimestres").value,
                        idioma: document.getElementById("IDAgregarCarreraIdioma").value,
                        materiasMatriculadas: MateriasSelect
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposCarrera();
                        $('#modalVentanaExitosa').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarCarrera").click(function () {
        limpiarCamposCarrera();
    });


    $("a[name='btnEditarCarrera']").click(function () {

        codigoCarrera = $(this).data("id");
        var verDetalle = VerDetalleCarrera(codigoCarrera);

    });

    $("a[name='btnEliminarCarrera']").click(function () {

        codigoCarrera = $(this).data("id");
        $('#modalVentanaEliminarCarrera').modal('show');
    });

    $("#btnAbrirDialogAgregarCarrera").click(function () {
        $('#modalAgregarCarrera').modal('show');
    });

    $("#btnAceptarEliminarCarreraConfirmacion").click(function () {

        $.ajax({
            url: '/Carrera/EliminarCarrera',
            type: 'POST',
            data: {
                Codigo: codigoCarrera
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCamposCarrera();
                $('#modalVentanaEliminarCarrera').modal('hide');
                $('#modalVentanaExitosa').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarCarreraConfirmacion").click(function () {
        $('#modalVentanaEliminarCarrera').modal('hide');
        location.reload();
    });

    $("#textoBuscarCarrera").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#CarrerasTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCamposCarrera() {
    $('#modalAgregarCarrera').modal('hide');

    document.getElementById("IDAgregarCarreraCodigo").value = "";
    document.getElementById("IDAgregarCarreraCarrera").value = "";
    document.getElementById("IDAgregarCarreraSede").value = "";
    document.getElementById("IDAgregarCarreraCuatrimestres").value = "";
    document.getElementById("IDAgregarCarreraIdioma").value = "";
    document.getElementById("IDAgregarCarreraMateriasMatriculadas").value = "";

    $("IDAgregarCarreraCarrera").css('border', '1px solid #ced4da');
    $("IDAgregarCarreraSede").css('border', '1px solid #ced4da');
    $("IDAgregarCarreraCuatrimestres").css('border', '1px solid #ced4da');
    $("IDAgregarCarreraIdioma").css('border', '1px solid #ced4da');
    $("IDAgregarCarreraMateriasMatriculadas").css('border', '1px solid #ced4da');

}



function validarCamposCarrera() {
    var bandera = true;
    var agregarCarreraCarrera = document.getElementById("IDAgregarCarreraCarrera").value;
    var agregarCarreraSede = document.getElementById("IDAgregarCarreraSede").value;
    var agregarCarreraCuatrimestres = document.getElementById("IDAgregarCarreraCuatrimestres").value;
    var agregarCarreraIdioma = document.getElementById("IDAgregarCarreraIdioma").value;
    var agregarCarreraMateriasMatriculadas = document.getElementById("IDAgregarCarreraMateriasMatriculadas").value;


    if (agregarCarreraCarrera == "") {
        $("#IDAgregarCarreraCarrera").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarreraCarrera').css('border', '1px solid #ced4da');
    }

    if (agregarCarreraSede == "") {
        $("#IDAgregarCarreraSede").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarreraSede').css('border', '1px solid #ced4da');
    }

    if (agregarCarreraCuatrimestres == "") {
        $("#IDAgregarCarreraCuatrimestres").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarreraCuatrimestres').css('border', '1px solid #ced4da');
    }

    if (agregarCarreraIdioma == "") {
        $("#IDAgregarCarreraIdioma").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarCarreraIdioma').css('border', '1px solid #ced4da');
    }




    return bandera;

}

function VerDetalleCarrera(codigo) {

    $.ajax({
        url: '/Carrera/VerDetalleCarrera',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarCarreraCodigo").value = response.codigo;
            document.getElementById("IDAgregarCarreraCarrera").value = response.carrera;
            document.getElementById("IDAgregarCarreraSede").value = response.sede;
            document.getElementById("IDAgregarCarreraCuatrimestres").value = response.cuatrimestres;
            document.getElementById("IDAgregarCarreraIdioma").value = response.idioma;
            document.getElementById("IDAgregarCarreraMateriasMatriculadas").value = response.materiasMatriculadas;
            $('#modalAgregarCarrera').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
