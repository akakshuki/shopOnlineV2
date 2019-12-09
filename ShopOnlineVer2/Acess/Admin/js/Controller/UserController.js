var user = {
    init: function() {
        user.registerEvent();
    },
    registerEvent: function() {
        $('.btn-active').off('click').on('click',
            function(e) {
                e.preventDefault();
                var id = parseInt($(this).data('id'));
                var btn = $(this);
                $.ajax({
                    url: "/Admin/User/ChangeStatus",
                    data: {id: id},
                    dataType: "json",
                    type: "POST",
                    success: function (response) {
                        console.log(response);  
                        if (response.status == true  ) {
                            btn.text('Kích hoạt');
                        } else {
                            btn.text('Bị khóa');
                        }
                    }
                })
            });
    }
}
user.init()