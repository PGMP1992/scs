var dataTable
$(document).ready(function () {
    var url = window.location.search;
  
    if (url.includes("inprocess"))
    {
        loadDataTable("inprocess");
    }
    else
    {
        if (url.includes("completed"))
        {
            loadDataTable("completed");
        }
        else
        {
            if (url.includes("approved"))
            {
                loadDataTable("approved");
            }
            else
            {
                loadDataTable("all");
            }
        }
    }

});

function loadDataTable(status) {
   
        dataTable = $('#tblData').DataTable({
        //language: {
        //    search: "S\u00F6k:",
        //    lengthMenu: " _MENU_ per sida",
        //    info: "Visar _START_ - _END_ av _TOTAL_ poster",
        //    infoFiltered: "(filtrerat fr\u00E5n _MAX_ poster totalt)"
        //},
        //scrollY:400,
        "ajax": { url: '/admin/order/getall?status=' + status },

       "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "25%" },
            { data: 'email', "width": "20%" },
            { data: 'orderStatus', "width": "10%" },
            { data: 'orderTotal', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                    </div>`
                },
               
                "width": "10%"
            }
    ]
    });
}

