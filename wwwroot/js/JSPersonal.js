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
            { "data": "Id_Personal", "width": "10%" },
            { "data": "nombre", "width": "20%" },
            { "data": "primerApellido", "width": "50%" },
            { "data": "segundoApellido", "width": "10%" },
            { "data": "direccion", "width": "20%" },
            { "data": "telefono", "width": "50%" },
            { "data": "email", "width": "10%" }
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