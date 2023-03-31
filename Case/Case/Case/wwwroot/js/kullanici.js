var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Kullanici/GetAll",
        },
        "columns": [
            { "data": "tamAdi", "width": "15%;", },
            { "data": "eMail", "width": "15%" },
            { "data": "gorevi", "width": "15%" },
            { "data": "sirket.sirketAdi", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center" role="group">
                                <a href="/Kullanici/Upsert?id=${data}" class='btn btn-outline-success' style="width: 35%"> Düzenle </a>
                                &nbsp;
                                <a onclick=Delete("/Kullanici/Delete/${data}") class="btn btn-outline-danger" style="width: 35%"> Sil </a>
                            </div>
                           `;
                }, "width": "20%"
            }
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "Silmek istediğinize emin misiniz?",
        text: "Silme işleminden sonra geri dönüşü olmayacaktır!",
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