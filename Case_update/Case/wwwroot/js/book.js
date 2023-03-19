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
            { "data": "title", "width": "20%" },
            { "data": "author.name", "width": "20%" },
            { "data": "author.name", "width": "20%" },
            { "data": "price", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/book/upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                                    Düzenle
                                </a>
                                &nbsp;
                                <a onclick=Delete("/book/delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:70px;'>
                                    Sil
                                </a>
                            </div>
                           `;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "Kitap Bulunamadı"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Kitabı Silmek Üzeresiniz!",
        text: "Kitabı Silmek İstediğinize Emin misiniz?",
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