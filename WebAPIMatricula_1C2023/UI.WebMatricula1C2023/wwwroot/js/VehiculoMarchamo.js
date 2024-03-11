$(document).ready(function () {
    var codigoVehiculoMarchamo;

    $('#VehiculoMarchamosTabla').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copyHtml5',
            'excelHtml5',
            'csvHtml5',
            'pdfHtml5'
        ]
    });

    $("#btnMensajeExitosoVehiculoMarchamo").click(function () {
        $('#modalVentanaExitosaVehiculoMarchamo').modal('hide');
        limpiarCamposVehiculoMarchamo();
        location.reload();
    });

    $("#btnAgregarVehiculoMarchamo").click(function () {
        if (validarCamposVehiculoMarchamo()) {

            var codigoVehiculoMarchamo = document.getElementById("IDAgregarVehiculoMarchamoCodigo").value;

            if (codigoVehiculoMarchamo == "") {

                $.ajax({
                    url: '/VehiculoMarchamo/AgregarVehiculoMarchamo',
                    type: 'POST',
                    data: {
                        nombreCompleto: document.getElementById("IDAgregarVehiculoMarchamoNombreCompleto").value,
                        placaVehiculo: document.getElementById("IDAgregarVehiculoMarchamoPlacaVehiculo").value,
                        modeloVehiculo: document.getElementById("IDAgregarVehiculoMarchamoModeloVehiculo").value,
                        colorVehiculo: document.getElementById("IDAgregarVehiculoMarchamoColorVehiculo").value,
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposVehiculoMarchamo();
                        $('#modalVentanaExitosaVehiculoMarchamo').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }
            else {
                $.ajax({
                    url: '/VehiculoMarchamo/EditarVehiculoMarchamo',
                    type: 'POST',
                    data: {
                        codigo: document.getElementById("IDAgregarVehiculoMarchamoCodigo").value,
                        nombreCompleto: document.getElementById("IDAgregarVehiculoMarchamoNombreCompleto").value,
                        placaVehiculo: document.getElementById("IDAgregarVehiculoMarchamoPlacaVehiculo").value,
                        modeloVehiculo: document.getElementById("IDAgregarVehiculoMarchamoModeloVehiculo").value,
                        colorVehiculo: document.getElementById("IDAgregarVehiculoMarchamoColorVehiculo").value,
                    },
                    async: true,
                    cache: false,
                    //contentType: 'application/json',
                    success: function (result) {
                        limpiarCamposVehiculoMarchamo();
                        $('#modalVentanaExitosaVehiculoMarchamo').modal('show');
                    },
                    error: function (request, status, err) {
                    }
                });
            }

        }
    });

    $("#btnCancelarVehiculoMarchamo").click(function () {
        limpiarCamposVehiculoMarchamo();
    });


    $("a[name='btnEditarVehiculoMarchamo']").click(function () {

        codigoVehiculoMarchamo = $(this).data("id");
        var verDetalle = VerDetalleVehiculoMarchamo(codigoVehiculoMarchamo);

    });

    $("a[name='btnEliminarVehiculoMarchamo']").click(function () {

        codigoVehiculoMarchamo = $(this).data("id");
        $('#modalVentanaEliminarVehiculoMarchamo').modal('show');
    });

    $("#btnAbrirDialogAgregarVehiculoMarchamo").click(function () {
        $('#modalAgregarVehiculoMarchamo').modal('show');
    });

    $("#btnAceptarEliminarVehiculoMarchamoConfirmacion").click(function () {

        $.ajax({
            url: '/VehiculoMarchamo/EliminarVehiculoMarchamo',
            type: 'POST',
            data: {
                Codigo: codigoVehiculoMarchamo
            },
            async: true,
            dataType: 'json',
            cache: false,
            //contentType: 'application/json',
            success: function (result) {
                limpiarCamposVehiculoMarchamo();
                $('#modalVentanaEliminarVehiculoMarchamo').modal('hide');
                $('#modalVentanaExitosaVehiculoMarchamo').modal('show');
            },
            error: function (request, status, err) {
            }
        });
    });

    $("#btnCancelarEliminarVehiculoMarchamoConfirmacion").click(function () {
        $('#modalVentanaEliminarVehiculoMarchamo').modal('hide');
        location.reload();
    });

    $("#textoBuscarVehiculoMarchamo").on("keyup", function () {
        var value = $(this).val().toLowerCase();

        var value = $(this).val().toLowerCase();
        $("#VehiculoMarchamosTabla tr").filter(function () {
            $(this).toggle($(this).find('td:eq(0), td:eq(1), td:eq(2)').text().replace(/\s+/g, ' ').toLowerCase().indexOf(value) > -1)
        });
    });
});


function limpiarCamposVehiculoMarchamo() {
    $('#modalAgregarVehiculoMarchamo').modal('hide');

    document.getElementById("IDAgregarVehiculoMarchamoCodigo").value = "";
    document.getElementById("IDAgregarVehiculoMarchamoNombreCompleto").value = "";
    document.getElementById("IDAgregarVehiculoMarchamoPlacaVehiculo").value = "";
    document.getElementById("IDAgregarVehiculoMarchamoModeloVehiculo").value = "";
    document.getElementById("IDAgregarVehiculoMarchamoColorVehiculo").value = "";

    $("IDAgregarVehiculoMarchamoNombreCompleto").css('border', '1px solid #ced4da');
    $("IDAgregarVehiculoMarchamoPlacaVehiculo").css('border', '1px solid #ced4da');
    $("IDAgregarVehiculoMarchamoModeloVehiculo").css('border', '1px solid #ced4da');
    $("IDAgregarVehiculoMarchamoColorVehiculo").css('border', '1px solid #ced4da');

}



function validarCamposVehiculoMarchamo() {
    var bandera = true;
    var agregarVehiculoMarchamoNombreCompleto = document.getElementById("IDAgregarVehiculoMarchamoNombreCompleto").value;
    var agregarVehiculoMarchamoPlacaVehiculo = document.getElementById("IDAgregarVehiculoMarchamoPlacaVehiculo").value;
    var agregarVehiculoMarchamoModeloVehiculo = document.getElementById("IDAgregarVehiculoMarchamoModeloVehiculo").value;
    var agregarVehiculoMarchamoColorVehiculo = document.getElementById("IDAgregarVehiculoMarchamoColorVehiculo").value;


    if (agregarVehiculoMarchamoNombreCompleto == "") {
        $("#IDAgregarVehiculoMarchamoNombreCompleto").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarVehiculoMarchamoNombreCompleto').css('border', '1px solid #ced4da');
    }

    if (agregarVehiculoMarchamoPlacaVehiculo == "") {
        $("#IDAgregarVehiculoMarchamoPlacaVehiculo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarVehiculoMarchamoPlacaVehiculo').css('border', '1px solid #ced4da');
    }

    if (agregarVehiculoMarchamoModeloVehiculo == "") {
        $("#IDAgregarVehiculoMarchamoModeloVehiculo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarVehiculoMarchamoModeloVehiculo').css('border', '1px solid #ced4da');
    }

    if (agregarVehiculoMarchamoColorVehiculo == "") {
        $("#IDAgregarVehiculoMarchamoColorVehiculo").css("border", "1px solid red");
        bandera = false;
    } else {
        $('#IDAgregarVehiculoMarchamoColorVehiculo').css('border', '1px solid #ced4da');
    }

    return bandera;

}

function VerDetalleVehiculoMarchamo(codigo) {

    $.ajax({
        url: '/VehiculoMarchamo/VerDetalleVehiculoMarchamo',
        type: 'POST',
        data: {
            Codigo: codigo
        },
        dataType: 'json',
        async: true,
        cache: false,
        // contentType: 'application/json',
        success: function (response) {
            document.getElementById("IDAgregarVehiculoMarchamoCodigo").value = response.codigo;
            document.getElementById("IDAgregarVehiculoMarchamoNombreCompleto").value = response.nombreCompleto;
            document.getElementById("IDAgregarVehiculoMarchamoPlacaVehiculo").value = response.placaVehiculo;
            document.getElementById("IDAgregarVehiculoMarchamoModeloVehiculo").value = response.modeloVehiculo;
            document.getElementById("IDAgregarVehiculoMarchamoColorVehiculo").value = response.colorVehiculo;
            $('#modalAgregarVehiculoMarchamo').modal('show');
        },
        error: function (request, status, err) {
        }
    });
}
