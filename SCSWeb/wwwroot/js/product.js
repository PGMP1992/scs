var dataTable
$(document).ready(function () {
    loadDataTable();
    
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        
       "ajax": { url: '/admin/products/getall' },

        "columns": [
            { data: 'name', "width": "30%" },
            { data: 'category.name', "width": "10%" },
            { data: 'provider.name', "width": "10%" },
            { data: 'price', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/products/upsert?id=${data}" class="btn btn-primary mx-2 rounded">
                        <i class="bi bi-pencil-square"></i>
                        Edit
                     </a>
                     <a href="/admin/products/delete?id=${data}" class="btn btn-danger mx-2 rounded">
                        <i class="bi bi-trash-fill"></i>
                        Delete
                     </a>
                    </div>`
                },

                "width": "30%"
            }
           
        ]
    });
}


