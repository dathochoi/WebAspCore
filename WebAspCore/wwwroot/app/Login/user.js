var UserController = function () {
    this.init = function () {
        registerEvent();
    }
    function registerEvent() {
        $("body").on('click', ".btnUpdate", function () {
            //console.log("Đã click: " + $(this).parent().parent().find(".ckUpdate").prop('checked'));
            $.ajax({
                type: "POST",
                url: "/Admin/UserManager/Update",
                data:
                {
                    UserName: $(this).data("id"),
                    IsClockOut: !$(this).parent().parent().find(".ckUpdate").prop('checked')
                },
                dataType: "json",
                beforeSend: function () {
                    lib.startLoading();
                },
                success: function (response) {
                    lib.notify('Đã cập nhật thành công', 'success');
                    lib.stopLoading();
                   
                },
                error: function (status) {
                    lib.notify('Cập nhật bị lỗi', 'error');
                    lib.stopLoading();
                }
            });
        });
    }
}