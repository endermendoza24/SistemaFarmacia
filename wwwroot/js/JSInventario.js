var datatable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    datatable = $('#TblDatos').DataTable({
        "ajax": {
            "url": "/Inventario/MostrarTodos"
        },
        "columns": [
            { "data": "IdInventario", "width": "10%" },
            { "data": "FechaEntradaInventario", "width": "20%" },
            { "data": "NombreComercial", "width": "50%" },
            { "data": "StockInicial", "width": "10%" },
            { "data": "Entradas", "width": "20%" },
            { "data": "Salidas", "width": "50%" },
            { "data": "StockActual", "width": "10%" },
            { "data": "PrecioPreventa", "width": "20%" },
            { "data": "CostoPreventa", "width": "50%" },
            { "data": "IdPresentacionMed", "width": "10%" },
            { "data": "IdLaboratorio", "width": "20%" },
            { "data": "IdCompra", "width": "50%" },
            {
                "data": "estado",
                "render": function (data) {
                    if (data == true) {
                        return "Activo";
                    }
                    else {
                        return "Inactivo";
                    }
                }, "width": "10%",
            }
        ]
    });
}