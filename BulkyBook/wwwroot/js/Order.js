var DataTable;
$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {

        loadDataTable("inprocess");
    }
    else {
        if (url.includes("pending")) {

            loadDataTable("pending");
        }
        else {
            if (url.includes("completed")) {

                loadDataTable("completed");
            }
            else {
               loadDataTable("all");
            
            }
        }
    }
});

function loadDataTable(status) {
    DataTable = $('#tableData').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetAll?status=" + status
        },
        "columns": [
            { "data": "id", "width": "15%" },
            { "data": "name", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
            { "data": "orderTotal", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `                                                                                                   
                        <div class=" text-center" >
                            <a href="/Admin/Order/Details?orderid=${data}" class="btn btn-warning me-2" > <i class="bi bi-pencil-square"></i> Details </a>
                           
                        </div>
                    `

                },

                "width": "15%"
            }
        ]
    });
}
