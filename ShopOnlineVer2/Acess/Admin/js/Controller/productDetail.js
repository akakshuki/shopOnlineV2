detailProductController = {
    init: function () {
        detailProductController.registerEvent();
        detailProductController.loadTable();
    },
    registerEvent : function() {
        $('#btnAddNew').on('click',
            function() {
                $('#InputDetailModal').modal('show');
            });
        $('#color').change(function () {
            var colorVal = $('#color').val();
            $('#inputColor').val(colorVal);
        });
        $('#btnSubmit').off('click').on('click',
            function() {
                detailProductController.insertProduct();
            });

    },
    loadTable  : function() {
        var idProduct = $('#idProduct').val();
        $.ajax({
            url: "/Admin/Product/LoaddetailProduct/",
            type: 'GET',
            dataType: 'json',
            data: {
                id : idProduct
            }, success: function(response) {
                var data = response.data;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data,
                        function (i, item) {
                            html += Mustache.render(template,
                                {
                                    ID: item.ID,
                                    ProductName: item.ProductName,
                                    Color: item.Color,
                                    Size: item.Size,
                                    Price: item.Price,
                                    Status: item.Status == true
                                        ? "<span class=\"btn bg-success text-white\">Kích hoạt</span>"
                                        : "<span class=\"btn bg-danger text-white\" >Khóa</span>"
                                });
                        });
                    $('#dbTable').html(html);
                    detailProductController.registerEvent();
                
            },error : function(err) {
                alert(err.message);
            }

        });
    },
    insertProduct : function() {

        $.ajax({
            url: "/Admin/Product/InsertDetailProduct/",
            type: 'POST',
            dataType: 'json',
            data: {
                model: {
                    Color: $('#color').val(),
                    Size: $('#size').val(),
                    Price: $('#price').val(),
                    Status: $("#statusckb").is(":checked") ? "true" : "false",
                    ProductId: $('#idProduct').val()
    }
            },success: function(response) {
                if (response.status) {
                    location.reload();

                } else {
                    location.reload();
                }
            },error: function(err) {
                alert(err.message);
            }
        });
    }

}
detailProductController.init();


