detailProductController = {
    init: function () {
        detailProductController.registerEvent();
        detailProductController.loadTable();
    },
    registerEvent : function() {
        
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
    }

}
detailProductController.init();