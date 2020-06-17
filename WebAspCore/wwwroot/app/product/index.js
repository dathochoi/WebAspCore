var productController = function () {
    var imageManagement = new ImageManagement();
    var addRow = new AddRow();
    var oldsize = 0;
    var arrProductType;
    this.initialize = function () {
        loadCategories();
        loadMakeIns();
        //loadTags();
        loadData();
        registerEvent();
        registerControls();
        imageManagement.initialize();
        addRow.init();
    }

    function registerEvent() {
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'vi',
            rule: {
                txtNameM: { required: true },
                ddlCategoryIdM: { required: true },
                ddlTagIdM: { required: true },
                txtPriceM: {
                    required: true,
                    number: true
                }
            }
        });
        $('')
        $('#ddlShowPage').on('change', function () {
            lib.configs.pageSize = $(this).val();
            lib.configs.pageIndex = $(this).val();
            loadData(true);
        });
        $('#ddlMakeInSearch').on('change', function () {
            //lib.configs.pageSize = $(this).val();
            //lib.configs.pageIndex = $(this).val();
            //loadData(true);
        });

        $('#btnSearch').on('click', function () {
            lib.configs.pageIndex = 1;
            loadData();
        });
        

        $('#txtKeyword').on('keypress', function (e) {
            if (e.which === 13) {
                lib.configs.pageIndex = 1;
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
                    lib.notify("Upload ảnh thành công.", "success");
                },
                error: function () {
                    lib.notify("Upload ảnh thất bại!", "error");
                }
            });
        });
       // $("body").on("click", ".btn-edit", function (e) {
        $("body").on("click", ".btn-edit1", function (e) {
            //e.preventDefault();
            //console.log("edit enter");
            resetFormMaintainance();

            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Product/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    lib.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    //initTreeDropDownCategory(data.CategoryId);
                    $('#ddlCategoryIdM').val(data.CategoryId);
                    $('#ddlMakeInIdM').val(data.MakeInId);
                    $('ddlTagIdM').val(data.ta);
                    $('#txtDescM').val(data.Description);
                    //$('#txtUnitM').val(data.Unit);

                    //$('#txtPriceM').val(data.Price);
                    //$('#txtOriginalPriceM').val(data.OriginalPrice);
                    //$('#txtPromotionPriceM').val(data.PromotionPrice);

                    var myTab = document.getElementById('empTable');
                    for (row = 1; row < myTab.rows.length;row++) {
                        myTab.deleteRow(row);
                    }
                    
                    for (i = 0; i < data.ProductTypeList.length; i++) {
                        a = data.ProductTypeList[i].Name;
                        b = data.ProductTypeList[i].OriginPrice;
                        cf = data.ProductTypeList[i].Price;
                        d = data.ProductTypeList[i].SalePrice;
                        e = data.ProductTypeList[i].Status;

                        var empTab = document.getElementById('empTable');

                        var rowCnt = empTab.rows.length;   // table row count.
                        var tr = empTab.insertRow(rowCnt); // the table row.
                        // tr = empTab.insertRow(rowCnt);

                        for (var c = 0; c < 6; c++) {
                            var td = document.createElement('td'); // table definition.
                            td = tr.insertCell(c);

                            if (c == 0) {      // the first column.
                                // add a button in every new row in the first column.
                                var button = document.createElement('input');
                                button.setAttribute('class', 'btnremove btn btn-danger');
                                // set input attributes.
                                button.setAttribute('scope', 'row');
                                button.setAttribute('type', 'button');
                                button.setAttribute('value', 'Remove');

                                // add button's 'onclick' event.
                                //button.setAttribute('onclick', 'removeRow(this)');

                                td.appendChild(button);
                            }
                            else if (c == 1) {      // the first column.
                                // add a button in every new row in the first column.
                                var text = document.createElement('input');

                                // set input attributes.
                                text.setAttribute('class', 'form-control eleTableT');
                                text.setAttribute('type', 'text');
                                text.value = a;
                                td.appendChild(text);
                            }
                            else if (c == 5) {      // the first column.
                                // add a button in every new row in the first column.
                                var checkbox = document.createElement('input');

                                // set input attributes.
                                tr.setAttribute('style', 'text-align:center; vertical-align:middle;');
                                checkbox.setAttribute('type', 'checkbox');
                                //checkbox.setAttribute("checked", "checked");
                                checkbox.setAttribute('class', 'form-check-input eleTableC');
                                checkbox.checked = e;
                                td.appendChild(checkbox);
                            }
                            else {
                                // 2nd, 3rd and 4th column, will have textbox.
                                var ele = document.createElement('input');
                                ele.setAttribute('type', 'number');
                                //ele.setAttribute('value', '0');
                                ele.setAttribute('class', 'form-control eleTableN');
                                if (c == 2) {
                                    ele.setAttribute('value', b);
                                }
                                else if (c == 3) {
                                    ele.setAttribute('value', cf);
                                }
                                else {
                                        ele.setAttribute('value', d);  
                                }
                                td.appendChild(ele);
                            }
                        }

                    }
                    // $('#txtImageM').val(data.ThumbnailImage);

                    //$('#txtTagM').val(data.Tags);
                    //$('#txtMetakeywordM').val(data.SeoKeywords);
                    //$('#txtMetaDescriptionM').val(data.SeoDescription);
                    //$('#txtSeoPageTitleM').val(data.SeoPageTitle);
                    //$('#txtSeoAliasM').val(data.SeoAlias);
                   // console.log(data.ProductTypeList.length);
                    CKEDITOR.instances.txtContent.setData(data.Content);
                    $('#ckStatusM').prop('checked', data.Status == 1);
                    $('#ckHotM').prop('checked', data.HotFlag);
                    ////$('#ckShowHomeM').prop('checked', data.HomeFlag);

                    $('#modal-add-edit').modal('show');
                    lib.stopLoading();
                },
                error: function (status) {
                    lib.notify("Error", "error");
                    lib.stopLoading();
                }
            });
        });
        //$("body").on("click", ".btn-delete2", function (e) {
        //    console.log("delete enter 22222222222");
        //});
        $("body").on("click", ".btn-delete", function (e) {
            //e.preventDefault();
           // console.log("delete enter");
            var that = $(this).data("id");
            lib.confirm('Are you sure to delete?', function () {
                //console.log("delete enter click");
                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        lib.startLoading();
                    },
                    success: function (response) {
                        lib.notify('Đã xóa thành công', 'success');
                        lib.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        lib.notify('Xóa sản phẩm bị lỗi', 'error');
                        lib.stopLoading();
                    }
                });
            });
        });

        $("#btnSave").on("click", function () {
            //console.log("click save");
            //if ($('frmMaintainance').valid()) {
            if ($('frmMaintainance')) {
                //console.log("click valid");
               // e.preventDefault();
                var id = $("#hidIdM").val();
                var name = $('#txtNameM').val();

                var description = $("#txtDescM").val();
                var unit = $("#txtUnitM").val();
                var categoryId = $("#ddlCategoryIdM").val();
                var makeInId = $("#ddlMakeInIdM").val();


                
                submit()
                //var seoKeyword = $("#txtMetakeywordM").val();
                //var seoMetaDescription = $('#txtMetaDescriptionM').val();
                //var seoPageTitle = $('#txtSeoPageTitleM').val();
                //var seoAlias = $('#txtSeoAliasM').val();

                var content = CKEDITOR.instances.txtContent.getData();
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                var hot = $('#ckHotM').prop('checked');
                var showHome = $('#ckShowHomeM').prop('checked');


                //var categoryId = 1;
                //var price = $('#txtPriceM').val();
                ////var price = $('#txtPriceM').val();
                //var originalPrice = $('#txtOriginalPriceM').val();
                //var promotionPrice = $('#txtPromotionPriceM').val();
                //var tags = $('#txtTagM').val();

                //console.log("aasaaa");
                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/SaveEntity",
                    //contentType: 'application/json;',
                    //dataType: 'json',
                    data: {
                        Id: id,
                        Name: name,
                        CategoryId: categoryId,
                        Image: '',
                        //Price: price,
                        //OriginalPrice: originalPrice,
                        //PromotionPrice: promotionPrice,
                        Description: description,
                        Content: content,
                        HomeFlag: showHome,
                        HotFlag: hot,
                        //Tags: tags,
                        //Unit: unit,
                        Status: status,
                        MakeInId: makeInId,
                        ProductTypeList: arrProductType
                        //SeoPageTitle: seoPageTitle,
                        //SeoAlias: seoAlias,
                        //SeoKeywords: seoKeyword,
                        //SeoDescription: seoMetaDescription
                    },
                    dataType: "json",
                    before: function () {
                        lib.startLoading();
                    },

                    success: function (res) {
                        lib.notify("Lưu sản phẩm thành công", "successs");
                        $("#modal-add-edit").modal("hide");
                        //resetFrormMaintainnance();
                        lib.stopLoading();
                        loadData();
                    },
                    error: () => {
                        lib.notify("Sản phẩm lưu thất bại", "error");
                        lib.stopLoading();
                    }
                });
                return false;
            }
        });
    }

    //function addRow( a,  b,  c,  d, e) {
    //    var empTab = document.getElementById('empTable');

    //    var rowCnt = empTab.rows.length;   // table row count.
    //    var tr = empTab.insertRow(rowCnt); // the table row.
    //    // tr = empTab.insertRow(rowCnt);

    //    for (var c = 0; c < arrHead.length; c++) {
    //        var td = document.createElement('td'); // table definition.
    //        td = tr.insertCell(c);

    //        if (c == 0) {      // the first column.
    //            // add a button in every new row in the first column.
    //            var button = document.createElement('input');
    //            button.setAttribute('class', 'btnremove btn btn-danger');
    //            // set input attributes.
    //            button.setAttribute('scope', 'row');
    //            button.setAttribute('type', 'button');
    //            button.setAttribute('value', 'Remove');

    //            // add button's 'onclick' event.
    //            //button.setAttribute('onclick', 'removeRow(this)');

    //            td.appendChild(button);
    //        }
    //        else if (c == 1) {      // the first column.
    //            // add a button in every new row in the first column.
    //            var text = document.createElement('input');

    //            // set input attributes.
    //            text.setAttribute('class', 'form-control eleTableT');
    //            text.setAttribute('type', 'text');
    //            text.value = a;
    //            td.appendChild(text);
    //        }
    //        else if (c == 5) {      // the first column.
    //            // add a button in every new row in the first column.
    //            var checkbox = document.createElement('input');

    //            // set input attributes.
    //            tr.setAttribute('style', 'text-align:center; vertical-align:middle;');
    //            checkbox.setAttribute('type', 'checkbox');
    //            //checkbox.setAttribute("checked", "checked");
    //            checkbox.setAttribute('class', 'form-check-input eleTableC');
    //            checkbox.prop('checked', e);
    //            td.appendChild(checkbox);
    //        }
    //        else {
    //            // 2nd, 3rd and 4th column, will have textbox.
    //            var ele = document.createElement('input');
    //            ele.setAttribute('type', 'number');
    //            //ele.setAttribute('value', '0');
    //            ele.setAttribute('class', 'form-control eleTableN');
    //            if (c == 2) {
    //                ele.setAttribute('value', b);
    //            }
    //            else if (c == 3) {
    //                ele.setAttribute('value', c);
    //            }
    //            else {
    //                ele.setAttribute('value', d);
    //            }
    //            td.appendChild(ele);
    //        }
    //    }
    //}
    function submit() {
        var myTab = document.getElementById('empTable');
        //var arrValues = new Array();
         arrProductType = new Array();

        // loop through each row of the table.
        for (row = 1; row < myTab.rows.length ; row++) {
            // loop through each cell in a row.
            //for (c = 1; c < myTab.rows[row].cells.length; c++) {
                //var element = myTab.rows.item(row).cells[c];
                //if (element.childNodes[0].getAttribute('type') == 'number' || element.childNodes[0].getAttribute('checkbox')) {
                //    arrValues.push(element.childNodes[0].value);
                //}
            if (myTab.rows.item(row).cells[1].childNodes[0].value.trim() != "") {
                var element =  {
                    Name: myTab.rows.item(row).cells[1].childNodes[0].value,
                    OriginPrice: myTab.rows.item(row).cells[2].childNodes[0].value,
                    Price: myTab.rows.item(row).cells[3].childNodes[0].value,
                    SalePrice: myTab.rows.item(row).cells[4].childNodes[0].value,
                    Status: myTab.rows.item(row).cells[5].querySelector('input[type=checkbox]').checked
                }
                    
                arrProductType.push(element);
                
            }
        }
        //console.log("Aaa: " + arrProductType);
        //console.log(arrValues);
        // The final output.
        //document.getElementById('output').innerHTML = arrValues;
        //console.log (arrValues);   // you can see the array values in your browsers console window. Thanks :-) 
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
  
    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
       // initTreeDropDownCategory('');
        loadCategories();
        loadMakeIns();
        $('#txtDescM').val('');
        //$('#txtUnitM').val('');

        //$('#txtPriceM').val('0');
        //$('#txtOriginalPriceM').val('');
        //$('#txtPromotionPriceM').val('');
        //addRow.init();
        //$('#txtImageM').val('');

        $('#txtTagM').val('');
        //$('#txtMetakeywordM').val('');
        //$('#txtMetaDescriptionM').val('');
        //$('#txtSeoPageTitleM').val('');
        //$('#txtSeoAliasM').val('');
        CKEDITOR.instances['txtContent'].setData(" ");
        //CKEDITOR.instances.txtContentM.setData('');
        $('#ckStatusM').prop('checked', true);
        $('#ckHotM').prop('checked', false);
       // $('#ckShowHomeM').prop('checked', false);
        var myTab = document.getElementById('empTable');
        for (row = 2; row < myTab.rows.length; row++) {
            myTab.deleteRow(row);
        }
        $(".eleTableT").val('')
        $('.eleTableN').val('0');
        $('.eleTableC').prop('checked', true);
        
        //addRow.init();

    }

    function loadCategories() {
        $.ajax({
            type: "GET",
            url: "/Admin/product/GetAllCategories",
            dataType: 'json',
            success: function (res) {
                var render = "<option value=''> -- Danh mục --  </option>";
                $.each(res, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                $('#ddlCategorySearch').html(render);
                $('#ddlCategoryIdM').html(render);
            },
            error: function (status) {
                console.log(status);
                lib.notify("Không thể hiển thị danh sách sản phẩm", "error");
            }
        });
    }
    function loadMakeIns() {
        $.ajax({
            type: "GET",
            url: "/Admin/Product/GetAllMakeIns",
            dataType: 'json',
            success: function (res) {
                var render = "<option value=''> -- Xuất Xứ --  </option>";
                $.each(res, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                $('#ddlMakeInSearch').html(render);
                $('#ddlMakeInIdM').html(render);
            },
            error: function (status) {
                console.log(status);
                lib.notify("Không thể hiển thị danh sách xuất xứ", "error");
            }
        });
    }

    //function loadTags() {
    //    $.ajax({
    //        type: "GET",
    //        url: "/Admin/Product/GetAllTags",
    //        dataType: 'json',
    //        success: function (res) {
    //            var render = "";
    //            $.each(res, function (i, item) {
    //                render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
    //            });
    //            $('#ddlTagSearch').html(render);
    //            $('#ddlTagIdM').html(render);
    //        },
    //        error: function (status) {
    //            console.log(status);
    //            lib.notify("Không thể hiển thị xuất xứ sản phẩm", "error");
    //        }
    //    });
    //}


    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";

        var catelogryID = "";
        if ($('#ddlCategorySearch').val() != null) {
            catelogryID = $('#ddlCategorySearch').val();
        }
        var makeInID = "";
        if ($('#ddlMakeInSearch').val() != null) {
            makeInID = $('#ddlMakeInSearch').val();
        }
        $.ajax({
            type: "GET",
            data: {
                categoryId: catelogryID,
                keyword: $('#txtKeyword').val(),
                page: lib.configs.pageIndex,
                pageSize: lib.configs.pageSize,
                makeInId: makeInID
            },
            url: "/Admin/Product/GetAllPaging",
            dataType: 'json',
            success: function (res) {
                console.log(res);
                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                         Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25 />' : '<img src="' + item.Image + '" width=25 />',
                        CategoryName: item.CategoryId != "" ? item.ProductCategory.Name : " ",
                        //Price: lib.formatNumber(item.Price, 0),
                        CreatedDate: lib.dateTimeFormatJson(item.DateCreated),
                        Status: lib.getStatus(item.Status)
                    });
                    
                });
                $("#lblTotalRecords").text(res.RowCount);
                if (render != '') {
                    $('#tbl-content').html(render);
                }
               
               // $('#paginationUL').remove("a");
                wrapPaging(res.RowCount, function () {
                    loadData();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
                lib.notify("Khổng thể hiển thị sản phẩm", "error");
            }
        });
    }
   

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / lib.configs.pageSize);

        //Unbind pagination if it existed or click change pagesize
        if ($('#paginationUL a').length === 0 || changePageSize === true || totalsize != oldsize) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData("twbs-pagination");
            $('#paginationUL').unbind("page");
            oldsize = totalsize;
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
                lib.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }

}