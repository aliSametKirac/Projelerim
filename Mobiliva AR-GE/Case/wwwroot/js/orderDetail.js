var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/OrderDetail/GetAll",
        },
        "columns": [
            { "data": "order.customerName", "textAlign": "center", "width": "25%" },
            { "data": "product.description", "text-align": "center", "width": "25%" },
            { "data": "unitPrice", "text-align": "center", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center" role="group">
                                <a href="/OrderDetail/Upsert?id=${data}}" class='btn btn-outline-success' style="width: 35%"> Düzenle </a>
                                &nbsp;
                                <a onclick=Delete("/OrderDetail/Delete/${data}") class="btn btn-outline-danger" style="width: 35%"> Sil </a>
                            </div>
                           `;
                }, "text-align": "center", "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    swal.fire({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}