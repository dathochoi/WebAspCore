var registerController = function () {
    this.init = function () {
        registerEvent();
    }

    function registerEvent() {
        $("#frmRegister").validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                txtEmail: {
                    required: true
                },
                txtName: {
                    required: true
                },
                txtPassword: {
                    required: true,
                    minlength: 6
                },
                txtPasswordRe: {
                    required: true,
                    minlength: 6,
                    equalTo: "#txtPassword"
                }
            }
            //message: {
            //    txtPasswordRe: "Mật khẩu chưa giống",
            //    txtPassword: "Mật khẩu chưa giống",
            //    txtEmail: "Chưa nhập email",
            //    txtName: "Chưa nhập password"
            //}
        });
        $("#btnRegister").on("click", function (e) {
            e.preventDefault();
            if ($("#frmRegister").valid()) {
                $.ajax({
                    type: 'POST',
                    data: {
                        Email: $("#txtEmail").val(),
                        Password: $("#txtPassword").val(),
                        ConfirmPassword: $("#txtPasswordRe").val(),
                        FullName: $("#txtName").val()

                    },
                    dataTyoe: 'json',
                    url: '/Admin/Login/Register',
                    success: function (res) {
                        //alert(res);
                        if (res.Success) {

                            window.location.href = '/Admin/Login';
                        }
                        else {
                            alert("Đăng kí thất bại");
                        }
                    }
                });
            }
        });
    }
}
