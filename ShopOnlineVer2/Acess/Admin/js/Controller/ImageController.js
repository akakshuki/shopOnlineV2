
var imageString = "";

function encodeImageFileAsURL(element) {
    var file = element.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        var data = reader.result;
        var b64 = data.replace(/^data:image.+;base64,/, '');
        imageString = b64;
    }
    reader.readAsDataURL(file);
}




var ImageController = {

    init: function () {
        ImageController.LoadData();
        ImageController.registerEvent();
    },
    registerEvent: function() {
        var idProduct = $('#idProduct').val();
        $('#btnAddNew').on('click',
            function() {
                $('#InputImageModal').modal('show');
            });
        $('.btn-delete').on('click',
            function () {
                var id = $(this).data('id');
                ImageController.deleteImage(id);
            });
        $('#statusckb').change(function () {
            if (this.checked)
                $('#statusckb').val(true);
            else
                $('#statusckb').val(false);
        });
        $('#btnSubmit').off('click').on('click',
            function() {
                ImageController.SaveImage(idProduct);
            });
        //$('#Image').on('change',
        //    function encodeImageFileAsURL(element) {
        //        var file = element.files[0];
        //        var reader = new FileReader();
        //        reader.onloadend = function() {
        //            console.log('RESULT', reader.result)
        //        }
        //        reader.readAsDataURL(file);
        //    });
    },

    deleteImage : function(id) {
        $.ajax({
            url: "/Admin/Product/DeleteImageProduct/",
            type: 'POST',
            dataType: 'json',
            data: {
                id: id
            },success : function(response) {
                if (response.status) {
                    location.reload();
                } else {
                    location.reload();
                }
            }
        });
    },

    SaveImage: function (idProduct) {

        $.ajax({
            url: "/Admin/Product/InsertMoreImage/",
            type: 'POST',
            dataType: 'json',
            data: {
                model : {
                ProductId: idProduct,
                Name: imageString,
                Status: $("#statusckb").is(":checked") ? "true" : "false"
            }
            },
            success : function(response) {
                if (response.status) {
                    location.reload();
                    alert("Thêm ảnh thành công");
                } else {
                  location.reload();
                    alert("thêm ảnh thất bại");
                }
            },error: function(err) {
                alert(err.message);
            }
        });
    },

    LoadData: function () {
        var idProduct = $('#idProduct').val();
        $.ajax({
            url: "/Admin/Product/LoadProductImages/",
            type: 'GET',
            dataType: 'json',
            data: {
                id : idProduct
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
                                ProductName: item.ProductName,
                                ImageProduct: item.Name,
                                Status: item.Status == true
                                    ? "<span class=\"btn bg-success text-white\">Kích hoạt</span>"
                                    : "<span class=\"btn bg-danger text-white\" >Khóa</span>"
                            });
                    });
                $('#dbTable').html(html);
                ImageController.registerEvent();

            },error: function(error) {
                alert(error.message);
            }

        });


    }


}
ImageController.init();