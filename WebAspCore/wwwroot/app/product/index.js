var productController = function () {
    this.initialize = function () {
        loadCategories();
        loadData();
        registerEvent();
        registerControls();
    }

    function registerEvent() {
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rule: {
                txtNameM: { required: true },
                ddlCategoryIdM: { required: true },
                txtPriceM: {
                    required: true,
                    number: true
                }
            }
        });

        $('#ddlShowPage').on('change', function () {
            tedu.configs.pageSize = $(this).val();
            tedu.configs.pageIndex = $(this).val();
            loadData(true);
        });

        $('btnSearch').on('click', function () {
            loadData();
        });
        $('#txtKeyword').on('click', function () {
            if (e.which === 13) {
                loadData();
            }
        });

        $("#btnCreate").on("click", function () {
            resetFormMaintainance();
            //initTreeDropDownCategory();
            $('#modal-add-edit').modal('show')
        });

        $("#btnSelectImag").on("change", function () {
            $("#fileInputImage").click();
        });


        $("#fileInputImage").on("change", function () {
            var fileUpload = $(this).get(0);
            var file = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < file.length; i++) {
                data.append(files[i].name.files[i]);

            }
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $("#txtImage").val(path);
                    tedu.notify("Upload image successful!", "success");
                },
                error: function () {
                    tedu.notify("Threr war error upload files!", "error");
                }
            });
        });
       // $("body").on("click", ".btn-edit", function (e) {
        $("body").on("click", ".btn-edit1", function (e) {
            //e.preventDefault();
            console.log("edit enter");
            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Product/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    tedu.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    //initTreeDropDownCategory(data.CategoryId);

                    $('#txtDescM').val(data.Description);
                    $('#txtUnitM').val(data.Unit);

                    $('#txtPriceM').val(data.Price);
                    $('#txtOriginalPriceM').val(data.OriginalPrice);
                    $('#txtPromotionPriceM').val(data.PromotionPrice);

                    // $('#txtImageM').val(data.ThumbnailImage);

                    $('#txtTagM').val(data.Tags);
                    $('#txtMetakeywordM').val(data.SeoKeywords);
                    $('#txtMetaDescriptionM').val(data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.SeoPageTitle);
                    $('#txtSeoAliasM').val(data.SeoAlias);

                    CKEDITOR.instances.txtContent.setData(data.Content);
                    $('#ckStatusM').prop('checked', data.Status == 1);
                    $('#ckHotM').prop('checked', data.HotFlag);
                    $('#ckShowHomeM').prop('checked', data.HomeFlag);

                    $('#modal-add-edit').modal('show');
                    tedu.stopLoading();
                },
                error: function (status) {
                    tedu.notify("Error", "error");
                    tedu.stopLoading();
                }
            });
        });
        //$("body").on("click", ".btn-delete2", function (e) {
        //    console.log("delete enter 22222222222");
        //});
        $("body").on("click", ".btn-delete", function (e) {
            //e.preventDefault();
            console.log("delete enter");
            tedu.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        tedu.startLoading();
                    },
                    success: function (response) {
                        tedu.notify('Delete successful', 'success');
                        tedu.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        tedu.notify('Has an error in delete progress', 'error');
                        tedu.stopLoading();
                    }
                });
            });
        });

        $("#btnSave").on("click", function () {
            console.log("click save");
            //if ($('frmMaintainance').valid()) {
            if ($('frmMaintainance')) {
                console.log("click valid");
               // e.preventDefault();
                var id = $("#hidIdM").val();
                var name = $('#txtNameM').val();

                var description = $("txtDescM").val();
                var unit = $("txtUnitM").val();


                var seoKeyword = $("#txtMetakeywordM").val();
                var seoMetaDescription = $('#txtMetaDescriptionM').val();
                var seoPageTitle = $('#txtSeoPageTitleM').val();
                var seoAlias = $('#txtSeoAliasM').val();

                var content = CKEDITOR.instances.txtContent.getData();
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                var hot = $('#ckHotM').prop('checked');
                var showHome = $('#ckShowHomeM').prop('checked');


                var categoryId = 1;
                var price = $('#txtPriceM').val();
                var price = $('#txtPriceM').val();
                var originalPrice = $('#txtOriginalPriceM').val();
                var promotionPrice = $('#txtPromotionPriceM').val();
                var tags = $('#txtTagM').val();

                console.log("aasaaa");
                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        CategoryId: categoryId,
                        Image: '',
                        Price: price,
                        OriginalPrice: originalPrice,
                        PromotionPrice: promotionPrice,
                        Description: description,
                        Content: content,
                        HomeFlag: showHome,
                        HotFlag: hot,
                        Tags: tags,
                        Unit: unit,
                        Status: status,
                        SeoPageTitle: seoPageTitle,
                        SeoAlias: seoAlias,
                        SeoKeywords: seoKeyword,
                        SeoDescription: seoMetaDescription
                    },
                    dataType: "json",
                    before: function () {
                        tedu.startLoading();
                    },

                    success: function (res) {
                        tedu.notify("Upload product successful", "successs");
                        $("#modal-add-edit").modal("hide");
                        resetFrormMaintainnance();
                        tedu.stopLoading();
                        loadData(true);
                    },
                    error: () => {
                        tedu.notify("Error in save product progress", "error");
                        tedu.stopLoading();
                    }
                });
                return false;
            }
        });
        
    }

    function registerControls() {
        CKEDITOR.replace("txtContent", {});
        //Fix: cannot click on element ck in modal
        $.fn.modal.Constructor.prototype.enforceFocus = function () {
            $(document)
                .off('focusin.bs.modal') // guard against infinite focus loop
                .on('focusin.bs.modal', $.proxy(function (e) {
                    if (
                        this.$element[0] !== e.target && !this.$element.has(e.target).length
                        // CKEditor compatibility fix start.
                        && !$(e.target).closest('.cke_dialog, .cke').length
                        // CKEditor compatibility fix end.
                    ) {
                        this.$element.trigger('focus');
                    }
                }, this));
        };

    }
    //function initTreeDropDownCategory(selectedId) {
    //    $.ajax({
    //        url: "/Admin/ProductCategory/GetAll",
    //        type: 'GET',
    //        dataType: 'json',
    //        async: false,
    //        success: function (response) {
    //            var data = [];
    //            $.each(response, function (i, item) {
    //                data.push({
    //                    id: item.Id,
    //                    text: item.Name,
    //                    parentId: item.ParentId,
    //                    sortOrder: item.SortOrder
    //                });
    //            });
    //            var arr = tedu.unflattern(data);
    //            $('#ddlCategoryIdM').combotree({
    //                data: arr
    //            });
    //            if (selectedId != undefined) {
    //                $('#ddlCategoryIdM').combotree('setValue', selectedId);
    //            }
    //        }
    //    });
    //}
    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        //initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtUnitM').val('');

        $('#txtPriceM').val('0');
        $('#txtOriginalPriceM').val('');
        $('#txtPromotionPriceM').val('');

        //$('#txtImageM').val('');

        $('#txtTagM').val('');
        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        //CKEDITOR.instances.txtContentM.setData('');
        $('#ckStatusM').prop('checked', true);
        $('#ckHotM').prop('checked', false);
        $('#ckShowHomeM').prop('checked', false);
    }

    function loadCategories() {
        $.ajax({
            type: "GET",
            url: "/Admin/product/GetAllCategories",
            dataType: 'json',
            success: function (res) {
                var render = "<option value=''>--Select category--</option>";
                $.each(res, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                $('#ddlCategorySearch').html(render);
            },
            error: function (status) {
                console.log(status);
                tedu.notify("Can't loading product category data", "error");
            }
        });
    }
    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: "GET",
            data: {
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('txtKeyword').val(),
                page: tedu.configs.pageIndex,
                pageSize: tedu.configs.pageSize
            },
            url: "/Admin/Product/GetAllPaging",
            dataType: 'json',
            success: function (res) {
                console.log(res);
                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.Image + '" width=25 />',
                        //CategoryName: item.ProductCategory.Name == null ? item.ProductCategory.Name: string.empty,
                        Price: tedu.formatNumber(item.Price, 0),
                        CreatedDate: tedu.dateTimeFormatJson(item.DateCreated),
                        Status: tedu.getStatus(item.Status)
                    });
                    $("#lblTotalRecords").text(res.RowCount);
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(res.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
            },
            error: function (status) {
                console.log(status);
                tedu.notify("Can't loading data", "error");
            }
        });
    }

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / tedu.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
        }
        //Bind Pagination Event
        $('#paginationUL').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'First',
            prev: 'Previous',
            next: 'Next',
            last: 'End',
            onPageClick: function (event, p) {
                tedu.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }

}