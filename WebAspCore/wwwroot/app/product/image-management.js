var ImageManagement = function () {
    var parent = parent;
    var images = [];
    this.initialize = function () {
        registerEvents();
    }
    function registerEvents() {
        $('body').on('click', '.btn-images', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#hidId').val(that);
           // clearFileInput($('#fileImage'));
            loadImages();
            $('#modal-image-manage').modal('show');
        });

        $('body').on('click', '.btn-delete-image', function (e) {
            e.preventDefault();
            $(this).closest('div').remove();
        });

        $('#fileImage').on('change',function(){
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            console.log(fileUpload.files);
            var data = new FormData()

            console.log(files.length +" file upload do dai");
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            //images = [];
            $.ajax({
                type: 'POST',
                url: '/Admin/Upload/UploadImage',
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                   // clearFileInput($('#fileImage'));
                    images.push(path);
                    $('#image-list').append('<div class="col-md-3"><img width="100" data-path="' + path + '"src="' + path + '"><br/><a href="#" class=""></a> <input type="checkbox"  class="form-check-input checkImage" >Ảnh chính</div>');
                    lib.notify('Đã tải ảnh lên thành công', 'success');
                },
                error: function () {
                    lib.notify('Tải ảnh lên thất bại', 'error');
                }
            });

        });

        $('#btnSaveImages').on('click', function () {
            var imageList = [];
            $.each($('#image-list').find('img'),  function (i, item) {
                //imageList.push($(this).data('path'));
                // console.log()
               // $(item).parent().find(".checkImage").attr('checked', 'checked');
                imageList.push(
                    {
                        Src : item.src,
                        Check: $(item).parent().find(".checkImage").prop('checked')
                    });
                //console.log($(this).next().children("input").attr("checked"));
                console.log($(item).parent().find(".checkImage").attr('checked'));
                //$(item).parent().find(".checkImage").attr('checked', 'checked');
                console.log(imageList[i].Check);

            });
            $.ajax({
                url: '/Admin/Product/SaveImages',
                data: {
                    productId: $('#hidId').val(),
                    images: imageList
                },
                type: 'POST',
                dataType: 'json',
                success: function (res) {
                    $('#modal-image-manage').modal('hide');
                    $('#image-list').html('');
                   // clearFileInput($("#fileImage"));
                },
            });
        });
    }

    function loadImages() {
       // images = [];
        $.ajax({
            url: '/Admin/Product/GetImages',
            data: {
                productId: $('#hidId').val()
            },
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                var render = '';
                $.each(res, function (i, item) {
                    var check = "";
                    console.log(item.Checked);
                    if (item.Checked == true) {
                        check = "checked";
                    }
                    render += '<div class="col-md-3"><img width="100" src="' + item.Path + '"><br/><a href="#" class="btn-delete-image">Xóa</a><input type="checkbox"  class="form-check-input checkImage" ' + check+'>Ảnh chính</div>';

                });
                $('#image-list').html(render);

            }
        });
    }
}