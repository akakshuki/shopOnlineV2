var categoryConfig = {
    pageSize: 10,
    pageIndex: 1

};
var categoryController = {

    init: function () {

        categoryController.loadData();
        categoryController.registerEvent();
    },
    registerEvent: function () {
        //$('.txtProfile').off('keypress').on('keypress',
        //    function (e) {
        //        if (e.which == 13) {
        //            var id = $(this).data('id');
        //            var val = $(this).val();
        //            categoryController.updateData(id, val);
        //        }
        //    });
        $('.btn-edit').off('click').on('click',
            function () {
                $("#categoryModal").modal('show');
                var id = $(this).data('id');
                categoryController.loadDetail(id);
            });
        $('#btnAddNew').off('click').on('click',
            function () {
                $("#categoryModal").modal('show');

            });
        $('#saveBtn').off('click').on('click',
            function () {
                categoryController.saveData();

            });
    },
    loadData: function () {
        $.ajax({
            url: "/Admin/Category/LoadData/",
            type: 'GET',
            dataType: 'json',
            data: {
                pageNum: categoryConfig.pageIndex,
                pageSize: categoryConfig.pageSize
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
                                Status: item.Status,

                            });
                    });
                $('#dbTable').html(html);
                categoryController.pagination(response.total,
                    function () {
                        categoryController.loadData();
                    });
                categoryController.registerEvent();

            }
        });

    },
    pagination(totalRow, callback) {
        var totalPage = Math.ceil(totalRow / categoryConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            onPageClick: function (event, page) {
                categoryConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: "/Admin/Category/LoadDetail/",
            type: "GET",
            dataType: "json",
            data: {
                id: id
            },
            success: function (response) {
                if (response.status) {
                    var data = response.data;

                    var idperson = response.id;

                    $('#nametxt').val(data.name);

                    $('#profiletxt').val(data.profile);
                }
            }



        });
    }
}
categoryController.init(); var categoryConfig = {
    pageSize: 5,
    pageIndex: 1

};
var categoryController = {

    init: function () {

        categoryController.loadData();
        categoryController.registerEvent();
    },
    registerEvent: function () {
        //$('.txtProfile').off('keypress').on('keypress',
        //    function (e) {
        //        if (e.which == 13) {
        //            var id = $(this).data('id');
        //            var val = $(this).val();
        //            categoryController.updateData(id, val);
        //        }
        //    });
        $('.btn-edit').off('click').on('click',
            function () {
                $("#categoryModal").modal('show');
                var id = $(this).data('id');
                categoryController.loadDetail(id);
            });
        $('.btn-delete').off('click').on('click',
            function () {
                var id = $(this).data('id');
                categoryController.deleteCategory(id);

            });
        $('#btnAddNew').off('click').on('click',
            function () {
                $("#insertCategoryModal").modal('show');
             

            });
        $('#btnSubmit').off('click').on('click',
            function () {
                categoryController.insertData();
                });

        $('#btnSave').off('click').on('click',
            function () {
                categoryController.saveData();

            });
    },
    loadData: function () {
        $.ajax({
            url: "/Admin/Category/LoadData/",
            type: 'GET',
            dataType: 'json',
            data: {
                pageNum: categoryConfig.pageIndex,
                pageSize: categoryConfig.pageSize
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
                                Status: item.Status,

                            });
                    });
                $('#dbTable').html(html);
                categoryController.pagination(response.total,
                    function () {
                        categoryController.loadData();
                    });
                categoryController.registerEvent();

            }
        });

    },
    pagination(totalRow, callback) {
        var totalPage = Math.ceil(totalRow / categoryConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            onPageClick: function (event, page) {
                categoryConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    },
    loadDetail: function (id) {
        $.ajax({
            url: "/Admin/Category/LoadDetail/",
            type: "GET",
            dataType: "json",
            data: {
                id: id
            },
            success: function (response) {
                if (response.status) {
                    var data = response.data;
                    $('#idNum').val(data.ID);
                    $('#Nametxt').val(data.Name);
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
    deleteCategory: function(id) {
        $.ajax({
            url: "/Admin/Category/DeleteCategory/",
            type: "POST",
            dataType: "json",
            data: {
                id: id
            }, success: function (response) {
                if (response.status) {
                    alert("Xóa thành công");
                    categoryController.loadData();
                } else {
                    alert("Xóa thất bại");
                }
            }, error: function (err) {

                console.log(err);

            }
        });
    },
    insertData: function() {
      var status =  $("#ckbStatus").is(":checked") ? "true" : "false";
        var categoryData = {
            Name: $('#txtName').val(),
            Status : status
    }
        $.ajax({
            url: "/Admin/Category/InsertCategory/",
            type: "POST",
            dataType: "json",
            data: {
                model: JSON.stringify(categoryData)
            }, success: function(response) {
                if (response.status) {
                    categoryController.loadData();
                    $("#insertCategoryModal").modal('hide');
                    categoryController.formatForm();
                    alert("Thêm thành công ");

                } else {
                    alert("Thêm thất bại");
                }
            },error: function(err) {
                alert(err.message );
            }

    });
    },
    formatForm: function() {
        $('#Nametxt').val('');
    },
    saveData: function() {
        var status = $("#statusckb").is(":checked") ? "true" : "false"; 
        var data = {
            ID: $('#idNum').val(),
            Name: $('#Nametxt').val(),
            Status: status
        }

        $.ajax({
            url: "/Admin/Category/UpdateCategory/",
            type: "POST", 
            dataType: "json",
            data: {
                model: JSON.stringify(data)
            },
            success: function(response) {
                if (response.status) {
                    categoryController.loadData();
                    $("#categoryModal").modal('hide');
                    alert("Sửa thành công");
                 
                } else {
                    alert("Sửa thất bại")
                }
            }, error: function (err) {

                console.log(err);

            }
        });

    }
}
categoryController.init();