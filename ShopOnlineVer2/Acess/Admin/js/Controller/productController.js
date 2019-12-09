var pageConfig = {
    pageSize: 10,
    pageIndex: 1

};

var edt = CKEDITOR.replace('Detail', { toolbar: 'Basic' });
CKFinder.setupCKEditor(edt, '/ckfinder/');

customConfig: '/Acess/Admin/js/plugins/ckeditor/config.js';
var ProductController = {
    init: function() {
        ProductController.registerEvent();
        ProductController.LoadData();
    },
    registerEvent : function() {
        $('.btn-edit').off('click').on('click',
            function() {
                $('#editModal').modal('show');
                var id = $(this).data('id');
                ProductController.loadDetail(id);
            });
        $('.btn-delete').off('click').on('click',
            function () {
                var id = $(this).data('id');
                ProductController.Delete(id);
            });

        $('.btn-images').off('click').on('click',
            function () {
                var id = $(this).data('id');
                ProductController.LoadMoreImagePages(id);
            });
        $('.btn-detail').off('click').on('click',
            function () {
                var id = $(this).data('id');
                ProductController.loadDetaiProduct(id);
            });

        $("#CategoryId").change(function () {
            $("#SubCategoryId").empty();
            $.get("/Product/setViewBagSubCategory",
                { idCategory: $("#CategoryId").val() },
                function (data) {
                    $.each(data,
                        function (index, row) {
                            $("#SubCategoryId").append("<option value='" +
                                row.SubCategoryId +
                                "'>" +
                                row.SubCategoryName +
                                "</option>");
                        });
                });
        });
        $('#statusckb').change(function () {
            if ($('#statusckb').attr("checked")) {
                $('#statusckb').val(true);
            } else {
                $('#statusckb').val(true);
            }

        });
        

    },


    loadDetaiProduct : function(id) {
        window.location.href = '/Admin/Product/DetailProduct/' + id;
    },

    LoadMoreImagePages: function (id) {
        window.location.href ='/Admin/Product/MoreImage/' + id;
    
    },


    Delete: function(id) {
        $.ajax({
            url: "/Admin/Product/Delete/",
            type: "POST",
            dataType: "json",
            data: {
                id: id
            },
            success: function (response) {
                if (response.status) {
                    location.reload();
                    SubCategoryController.loadData();
                } else {
                    location.reload();
                    alert("Xóa thất bại");
                }
            },
            error: function (err) {

                console.log(err);

            }
        });
    },

    loadDetail: function(id) {
        $.ajax({
            url: "/Admin/Product/LoadDetail/",
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
                    $('#ImagePreviewBox').attr('src', '/Acess/Admin/img/product/' + data.Image);



                  
                    var t =  data.Detail;
                    CKEDITOR.instances.Detail.setData(t);



                    $('#CategoryId').val(data.CategoryId);
                    $('#SubCategoryId').val(data.SubCategoryId);
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

   


        LoadData: function() {
        $.ajax({
            url: "/Admin/Product/LoadData/",
            type: 'GET',
            dataType: 'json',
            data: {
                pageNum: pageConfig.pageIndex,
                pageSize: pageConfig.pageSize
            },
            success: function(response) {
                var data = response.data;
                var html = '';
                var template = $('#data-template').html();
                $.each(data,
                    function(i, item) {
                        html += Mustache.render(template,
                            {
                                ID: item.ID,
                                Name: item.Name,
                                CategoryName: item.CategoryName,
                                SubCategoryName: item.SubCategoryName,
                                ImageProduct: item.Image,
                                Status: item.Status == true
                                    ? "<span class=\"btn bg-success text-white\">Kích hoạt</span>"
                                    : "<span class=\"btn bg-danger text-white\" >Khóa</span>"
                            });
                    });
                $('#dbTable').html(html);
                ProductController.pagination(response.total,
                    function() {
                        ProductController.LoadData();
                    });
                ProductController.registerEvent();

            }

        });


    },
    pagination(totalRow, callback) {
        var totalPage = Math.ceil(totalRow / pageConfig.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 10,
            onPageClick: function (event, page) {
                pageConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    },
}
ProductController.init();