var productCategoryController = function () {
    this.init = new function () {
        loadCategories();
        loadData();
        registerEvents();
    }

    function registerEvents() {
        $('#frmMaintainance').validate({
            errorClass: 'red',
            ignore: [],
            lang: 'en',
            rules: {
                txtNameM: { required: true },
                txtOrderM: { number: true },
                txtHomeOrderM: { number: true }
            }
        });

        $('#btnCreate').off('click').on('click', function () {
            //initTreeDropDownCategory();
            resetFormMaintainance();
            $('#modal-add-edit').modal('show');
        });
        $('#btnSelectImg').on('click', function () {
            $('#fileInputImage').click();
        });
        $("#fileInputImage").on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }
            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $('#txtImage').val(path);
                    lib.notify('Upload image succesful!', 'success');

                },
                error: function () {
                    lib.notify('There was error uploading files!', 'error');
                }
            });
        });
        $('body').on('click', '#btnEdit', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            $.ajax({
                type: "GET",
                url: "/Admin/ProductCategory/GetById",
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

                    $('#txtDescM').val(data.Description);

                    $('#txtImageM').val(data.ThumbnailImage);

                    $('#txtSeoKeywordM').val(data.SeoKeywords);
                    $('#txtSeoDescriptionM').val(data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.SeoPageTitle);
                    $('#txtSeoAliasM').val(data.SeoAlias);

                    $('#ckStatusM').prop('checked', data.Status == 1);
                    $('#ckShowHomeM').prop('checked', data.HomeFlag);
                    $('#txtOrderM').val(data.SortOrder);
                    $('#txtHomeOrderM').val(data.HomeOrder);

                    $('#modal-add-edit').modal('show');
                    lib.stopLoading();

                },
                error: function (status) {
                    lib.notify('Có lỗi xảy ra', 'error');
                    lib.stopLoading();
                }
            });
        });

        $('body').on('click', '#btnDelete', function (e) {
            e.preventDefault();
            var that = $('#hidIdM').val();
            lib.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "DELETE",
                    url: "/Admin/ProductCategory/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        lib.startLoading();
                    },
                    success: function (response) {
                        lib.notify('Deleted success', 'success');
                        lib.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        lib.notify('Has an error in deleting progress', 'error');
                        lib.stopLoading();
                    }
                });
            });
        });

        $('#btnSave').on('click', function (e) {
            if ($('#frmMaintainance').valid()) {
                e.preventDefault();
                var id = parseInt($('#hidIdM').val());
                var name = $('#txtNameM').val();
                var parentId = $('#ddlCategoryIdM').combotree('getValue');
                var description = $('#txtDescM').val();

                var image = $('#txtImageM').val();
                var order = parseInt($('#txtOrderM').val());
                var homeOrder = $('#txtHomeOrderM').val();

                var seoKeyword = $('#txtSeoKeywordM').val();
                var seoMetaDescription = $('#txtSeoDescriptionM').val();
                var seoPageTitle = $('#txtSeoPageTitleM').val();
                var seoAlias = $('#txtSeoAliasM').val();
                var status = $('#ckStatusM').prop('checked') == true ? 1 : 0;
                var showHome = $('#ckShowHomeM').prop('checked');

                $.ajax({
                    type: "POST",
                    url: "/Admin/ProductCategory/SaveEntity",
                    data: {
                        Id: id,
                        Name: name,
                        Description: description,
                        ParentId: parentId,
                        HomeOrder: homeOrder,
                        SortOrder: order,
                        HomeFlag: showHome,
                        Image: image,
                        Status: status,
                        SeoPageTitle: seoPageTitle,
                        SeoAlias: seoAlias,
                        SeoKeywords: seoKeyword,
                        SeoDescription: seoMetaDescription
                    },
                    dataType: "json",
                    beforeSend: function () {
                        lib.startLoading();
                    },
                    success: function (response) {
                        lib.notify('Update success', 'success');
                        $('#modal-add-edit').modal('hide');

                        resetFormMaintainance();

                        lib.stopLoading();
                        loadData(true);
                    },
                    error: function () {
                        lib.notify('Has an error in update progress', 'error');
                        lib.stopLoading();
                    }
                });
            }
            return false;

        });
    }



    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
       //initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtOrderM').val('');
        $('#txtHomeOrderM').val('');
        $('#txtImageM').val('');

        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        $('#ckStatusM').prop('checked', true);
        $('#ckShowHomeM').prop('checked', false);
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
    //            var arr = lib.unflattern(data);
    //            $('#ddlCategoryIdM').combotree({
    //                data: arr
    //            });
    //            if (selectedId != undefined) {
    //                $('#ddlCategoryIdM').combotree('setValue', selectedId);
    //            }
    //        }
    //    });
    //}
    //function loadData() {
    //    $.ajax({
    //        url: '/Admin/ProductCategory/GetAll',
    //        dataType: 'json',
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
    //            var treeArr = lib.unflattern(data);
    //            treeArr.sort(function (a, b) {
    //                return a.sortOrder - b.sortOrder;
    //            });
    //            //var $tree = $('#treeProductCategory');

    //            $('#treeProductCategory').tree({
    //                data: treeArr,
    //                dnd: true,
    //                onContextMenu: function (e, node) {
    //                    e.preventDefault();
    //                    // select the node
    //                    //$('#tt').tree('select', node.target);
    //                    $('#hidIdM').val(node.id);
    //                    // display context menu
    //                    $('#contextMenu').menu('show', {
    //                        left: e.pageX,
    //                        top: e.pageY
    //                    });
    //                },
    //                onDrop: function (target, source, point) {
    //                    console.log(target);
    //                    console.log(source);
    //                    console.log(point);
    //                    var targetNode = $(this).tree('getNode', target);
    //                    if (point === 'append') {
    //                        var children = [];
    //                        $.each(targetNode.children, function (i, item) {
    //                            children.push({
    //                                key: item.id,
    //                                value: i
    //                            });
    //                        });

    //                        //Update to database
    //                        $.ajax({
    //                            url: '/Admin/ProductCategory/UpdateParentId',
    //                            type: 'post',
    //                            dataType: 'json',
    //                            data: {
    //                                sourceId: source.id,
    //                                targetId: targetNode.id,
    //                                items: children
    //                            },
    //                            success: function (res) {
    //                                loadData();
    //                            }
    //                        });
    //                    }
    //                    else if (point === 'top' || point === 'bottom') {
    //                        $.ajax({
    //                            url: '/Admin/ProductCategory/ReOrder',
    //                            type: 'post',
    //                            dataType: 'json',
    //                            data: {
    //                                sourceId: source.id,
    //                                targetId: targetNode.id
    //                            },
    //                            success: function (res) {
    //                                loadData();
    //                            }
    //                        });
    //                    }
    //                }
    //            });

    //        }
    //    });
    //}
    function loadCategories() {
        $.ajax({
            type: 'GET',
            url: '/admin/product/GetAllCategories',
            dataType: 'json',
            success: function (response) {
                var render = "<option value=''>--Select category--</option>";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>"
                });
                $('#ddlCategorySearch').html(render);
            },
            error: function (status) {
                console.log(status);
                tedu.notify('Cannot loading product category data', 'error');
            }
        });
    }

    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: 'GET',
            data: {
                keyword: $('#txtKeyword').val(),
                page: lib.configs.pageIndex,
                pageSize: lib.configs.pageSize
            },

            url: 'Admin/ProducCategory/GetAllPaging',
            dataType: 'json',
            success: function (res) {
                console.log(res);
                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id = item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.Image + '" width=25 />',
                        CategoryName: item.ProductCategory.Name,
                        CategoryNameParent: item.ProductCategory.ProductCategory.Name,
                        CreatedData: lib.dataTimeFormatJson(item.DateCreate),
                        Status: lib.getStatus(item.Status)
                    });
                    $('#lblTotalRecords').text(response.RowCount);
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(response.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                });
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
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, p) {
                lib.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }
}
