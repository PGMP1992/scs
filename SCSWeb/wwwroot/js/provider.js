var dataTable

$(document).ready(function () {
    loadDataTable();
    
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
       
        "ajax": { url: '/Admin/Providers/getall' },

        "columns": [
            { data: 'name', "width": "20%" },
            { data: 'contactName', "width": "20%" },
            { data: 'contactEmail', "width": "15%" },
            { data: 'contactPhone', "width": "15%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/providers/upsert?id=${data}" class="btn btn-primary mx-2 rounded">
                        <i class="bi bi-pencil-square"></i>
                        Edit
                     </a>
                     <a href="/admin/providers/delete?id=${data}" class="btn btn-danger mx-2 rounded">
                        <i class="bi bi-trash-fill"></i>
                        Delete
                     </a>
                    </div>`
                },
                "width": "25%"
            }

           
        ]
          
    });
}

