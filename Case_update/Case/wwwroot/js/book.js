var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Book/GetAll",
        },
        "columns": [
            { "data": "title", "width": "30%;", "text-align": "center" },
            { "data": "author.name", "width": "25%"},
            { "data": "price", "width": "15%"},
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center" role="group">
                                <a href="/Book/Upsert?id=${data}}" class='btn btn-outline-success'>
                                   <i class="bi bi-pencil-square"></i> Düzenle
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Book/Delete/${data}") class='btn btn-outline-danger'>
                                    <i class="bi bi-trash"></i> Sil
                                </a>
                            </div>
                           `;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal.fire({
        title: "Silmek istediğinizden emin misiniz?",
        text: "Bu işlemi geri alamayacaksınız!",
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
                        dataTable.ajax.reload();
                        swal({
                            title: data.message,
                            text: "Silme işlemi başarılı!",
                            icon: "danger"
                        });
                    }
                    else {
                        swal({
                            title: data.message,
                            text: "Silme işlemi başarısız!",
                            icon: "error"
                        });
                    }
                }
            });
        }
    });
}