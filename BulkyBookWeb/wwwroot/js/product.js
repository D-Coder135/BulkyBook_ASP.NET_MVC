var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a asp-controller="Category" asp-action="Edit" asp-route-id="@obj.Id" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a asp-controller="Category" asp-action="Delete" asp-route-id="@obj.Id" class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                    </div>
                        `
                },
                "width": "15%"
            },
        ]
    });
}