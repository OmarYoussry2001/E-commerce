const lang = document.documentElement.lang;
const titleColumnName = (lang === 'ar') ? 'titleAr' : 'titleEn';
const typeTitleColumnName = (lang === 'ar') ? 'typeTitleAr' : 'typeTitleEn';

$(document).ready(function () {
    $('#myTable').DataTable({
        serverSide: true,
        processing: true, 
        ajax: {
            url: '/Admin/Item/GetItemsDataTable',
            type: 'POST',
            dataSrc: 'data'
        },
        columns: [
            { data: "title", name: titleColumnName  },
            {
                data: "imagePathBackGround",
                name: "imagePathBackGround",
                render: function (data) {
                    return `<img src="/uploads/Images/${data}" alt="Image" style="width:80px; height:50px;" />`;
                },
                orderable: false,
                searchable: false
            },
            { data: "serialNo", name: "serialNo" },
            { data: "price", name: "price" },
            { data: "soldCount", name: "soldCount" },
            { data: "discountPercent", name: "discountPercent" },
            { data: "typeTitle", name: typeTitleColumnName  },
            {
                data: 'id',
                name: 'id',
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/Item/Edit?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i>
                            </a>
                            <a href="#" onClick="Delete('/admin/Item/Delete?id=${data}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i>
                            </a>
                        </div>
                    `;
                },
                orderable: false,
                searchable: false
            }
        ],
    
        columnDefs: [
            {
                targets: '_all',
                orderSequence: ["asc", "desc"] 
            }
        ]
    });
});


//datatable.buttons().container().appendTo("#datatable-buttons_wrapper .col-md-6:eq(0)");


