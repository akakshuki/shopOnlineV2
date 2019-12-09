var tableConfig = {
    pageSize: 10,
    pageIndex: 1
};

var SubCategoryController = {
    init: function() {
        SubCategoryController.registerEvent();
        SubCategoryController.loadData();
    },
    registerEvent: function() {
        $('.btn-active').off('click').on('click',
            function(e) {
                e.preventDefault();
                SubCategoryController.changeStatus();
            });
        $('.btn-delete').off('click').on('click',
            function() {
                var id = $(this).data('id');
                SubCategoryController.deleteSubCategory(id);
            });
        $('.btn-edit').off('click').on('click',
            function() {
                $('#SubCategoryModal').modal('show');
                var id = $(this).data('id');
                SubCategoryController.loadDetail(id);


            });
        $('#btnSubmit').off('click').on('click',
            function() {
                SubCategoryController.insertData();
            });
    },
    insertData: function() {
        var status = $("#statusckb").is(":checked") ? "true" : "false";
        var data = {
            Name: $('#Nametxt').val(),
            CategoryId: $('#CategoryId').val(),
            Status: status
        }
        $.ajax({
            url: "/Admin/SubCategory/Insert",
            type: "POST",
            dataType: "json",
            data: {
                model: JSON.stringify(data)
            },
            success: function(response) {
                window.location.href = response.Url;
            },
            error: function(err) {
                alert(err.message);
            }
        });
    },
    formatForm: function() {
        $('#Nametxt').val('');
        $('#CategoryId').val(0);
    },
    deleteSubCategory: function(id) {
        $.ajax({
            url: "/Admin/SubCategory/DeleteSubCategory/",
            type: "POST",
            dataType: "json",
            data: {
                id: id
            },
            success: function(response) {
                if (response.status) {
                    location.reload();
                    alert("Xóa thành công");
                    SubCategoryController.loadData();
                } else {
                    alert("Xóa thất bại");
                }
            },
            error: function(err) {

                console.log(err);

            }
        });
    },
    loadDetail: function(id) {
        $.ajax({
            url: "/Admin/SubCategory/LoadDetail/",
            type: "GET",
            dataType: "json",
            data: {
                id: id
            },
            success: function(response) {
                if (response.status) {
                    var data = response.data;
                    $('#idNum').val(data.ID);
                    $('#Nametxt').val(data.Name);
                    $('#CategoryId').val(data.CategoryId);
                    if (data.Status) {
                        $('#statusckb').attr("checked", true);
                    } else {
                        $('#statusckb').attr("checked", false);
                    }
                } else {
                    alert(response.message);
                }
            }
        });
        },
        loadData: function () {
        $.ajax({
            url: "/Admin/SubCategory/LoadData/",
            type: 'GET',
            dataType: 'json',
            data: {
                pageNum: tableConfig.pageIndex,
                pageSize: tableConfig.pageSize
            },
            success: function (response) {
                var data = response.data;
                var html = '';
                var template = $('#data-template').html();
                $.each(data,
                    function (i, item) {
                        html += Mustache.render(template,
                            {
                                ID: item.ID,
                                Name: item.Name,
                                CategoryName: item.CategoryName,
                                Status: item.Status == true ? "<span class=\"btn bg-success text-white\" >Kích hoạt</span>" : "<span class=\"btn bg-danger text-white\" >Khóa</span>"
                            });
                    });
                $('#dbTable').html(html);
                SubCategoryController.pagination(response.total,
                    function () {
                        SubCategoryController.loadData();
                    });
                SubCategoryController.registerEvent();
            }
        });
    },
    pagination(totalRow, callback) {
        var totalPage = Math.ceil(totalRow / tableConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            onPageClick: function (event, page) {
                tableConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    },
    changeStatus: function () {
        var id = parseInt($(this).data('id'));
        var btn = $(this);
        $.ajax({
            url: "/Admin/SubCategory/ChangeStatus",
            data: { id: id },
            dataType: "json",
            type: "POST",
            success: function (response) {
                console.log(response);
                if (response.status == true) {
                    btn.text('Kích hoạt');
                } else {
                    btn.text('Bị khóa');
                }
            }
        });
    }
}
SubCategoryController.init();