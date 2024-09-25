var dataTable

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
       
        "ajax": { url: '/Admin/CertificationSlots/getall' },

        "columns": [
            { data: 'product.name', "width": "20%" },
            { data: 'date', "width": "20%" },
            { data: 'startTime', "width": "10%" },
            { data: 'endTime', "width": "10%" },
            { data: 'participantsMax', "width": "5%" },
            { data: 'participantsRegistered', "width": "5%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/certificationslots/upsert?id=${data}" class="btn btn-primary mx-2 rounded">
                        <i class="bi bi-pencil-square"></i>
                        Edit
                     </a>
                     <a href="/admin/certificationslots/delete?id=${data}" class="btn btn-danger mx-2 rounded">
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

