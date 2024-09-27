var dataTable

$(document).ready(function () {
    loadDataTable();
    
});

function loadDataTable() {

    var dataTable = $('#tblData').DataTable({
       
        "ajax": { url: '/Admin/Categories/getall' },

        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'description', "width": "45%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/categories/upsert?id=${data}" class="btn btn-primary mx-2 rounded">
                        <i class="bi bi-pencil-square"></i>
                        Edit
                     </a>
                     <a href="/admin/categories/delete?id=${data}" class="btn btn-danger mx-2 rounded">
                        <i class="bi bi-trash-fill"></i>
                        Delete</a>
                    </div>`
                },
                "width": "25%"
            }

           
        ]
          
    });
}

