var loginController = function () {
    this.init = function () {
        //alert("init");
        registerEvents();
    }

    var registerEvents = function () {
        //alert("register");
        $('#frmLogin').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rules: {
                userName: {
                    required:true
                },
                password: {
                    required: true
                }
            }
        });
        $('#btnLogin').on('click', function (e) {
            if ($('#frmLogin').valid()) {
                e.preventDefault();
                var user = $('#txtUserName').val();
                var password = $('#txtPassword').val();
                login(user, password);
            }
        });
    }
    var login = function (user, pass) {
        //alert("login");
        $.ajax({
            type: 'POST',
            data: {
                UserName: user,
                Password: pass
            },
            dataTyoe: 'json',
            url: '/Admin/Login/Authen',
            success: function (res) {
                //alert(res);
                if (res.Success) {
                    
                    window.location.href = '/Admin/Home/Index';
                }
                else {
                    alert("Login fail");
                }
            }
        })
    }
}