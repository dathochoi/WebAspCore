var systemsController = function () {
    this.init = function () {
        registerEvent();
    }

    function registerEvent() {
        $("#sbICon").on("change", function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            console.log(fileUpload.files);
            var data = new FormData()

            console.log(files.length + " file upload do dai");
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            //images = [];
            $.ajax({
                type: 'POST',
                url: '/Admin/Upload/UploadIcon',
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    
                    $("#iconImage").attr("src", path);
                    $("#imageLogoHidden").val(path);
                },
                error: function () {
                    lib.notify('Tải icon lên thất bại', 'error');
                }
            });
        });

        $("#sbImageBG").on("change", function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            console.log(fileUpload.files);
            var data = new FormData()

            console.log(files.length + " file upload do dai");
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            //images = [];
            $.ajax({
                type: 'POST',
                url: '/Admin/Upload/UploadBG',
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    // clearFileInput($('#fileImage'));
                   
                    $("#imageBG").attr("src", path);
                    $("#imageBGHidden").val(path);
                },
                error: function () {
                    lib.notify('Tải ảnh bìa lên thất bại', 'error');
                }
            });
        });

    }
}