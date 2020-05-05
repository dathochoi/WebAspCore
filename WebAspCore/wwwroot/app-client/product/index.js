var productController = function () {
    var hotFlag = false;
    var makeInId = 0;
    var oldsize = 0;
    this.initialize = function () {
        
       // loadCategories();
        loadData();
        registerEvent();
        //registerControls();
        
    }
    function registerEvent() {
        $('#hotFlag').on('click', function () {
            hotFlag = true;
            makeInId = 0;
            lib.configs.pageIndex = 1;
            loadData();
        });
        $('.makeIn').on('click', function () {
            hotFlag = false;
            makeInId = $(this).data('id');
            lib.configs.pageIndex = 1;
            loadData();
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

        $("body").on("click", ".btnCategory", function () {
            //console.log("clicked sidebar");
            console.log($(this).data("id"));
            lib.configs.pageIndex = 1;
            var template = $('#table-template').html();
            var render = "";
            $.ajax({
                type: "GET",
                data: {
                    categoryId: $(this).data("id"),
                    keyword: $('#txtKeyword').val(),
                    page: lib.configsClient.pageIndex,
                    pageSize: lib.configsClient.pageSize

                   
                },
                url: "/Product/GetAllPaging",
                dataType: 'json',
                success: function (res) {
                    console.log(res);
                    if (res.Results.length > 0) {
                        $.each(res.Results, function (i, item) {

                            render += Mustache.render(template, {
                                Id: item.Id,
                                Name: item.Name,
                                Image: item.Image == null ? '<img  class="img-fluid" src="/admin-side/images/user.png?w=300&h=350&autorotate=true&format=png&mode=pad"  />' : '<img class="img-fluid" src="' + item.Image + '" />',
                                MakeIn: item.MakeInName,
                                Price: formatNumber(item.Price),
                                Description: item.Description
                            });

                        });
                        if (render != '') {
                            $('#tbl-content').html(render);
                        }
                        wrapPaging(res.RowCount, function () {
                            loadData();
                        }, false);
                    }
                    else {
                            
                            $('#tbl-content').html("Không tìm thấy sản phẩm");

                    }
                },
                error: function (status) {
                    console.log(status);
                    lib.notify("Can't loading data", "error");
                }
            });
        });
    }
    function loadData(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: "GET",
            data: {
                categoryId: $('#ddlCategorySearch').val(),
                keyword: $('#txtKeyword').val(),
                page: lib.configsClient.pageIndex,
                pageSize: lib.configsClient.pageSize,
                hotFlag: hotFlag,

                makeInId: makeInId
            },
            url: "/Product/GetAllPaging",
            dataType: 'json',
            success: function (res) {
                console.log(res);
                if (res.Results.length > 0) {
                    $.each(res.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                            Image: item.Image == null ? '<img class="img-fluid" src="/admin-side/images/user.png?w=300&h=350&autorotate=true&format=png&mode=pad"  />' : '<img class="img-fluid" src="' + item.Image + '" />',
                            MakeIn: item.MakeInName,
                            Price: formatNumber(item.Price),
                            Description: item.Description
                        });

                    });
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(res.RowCount, function () {
                        loadData();
                    }, isPageChanged);
                }
                else {
                    $('#tbl-content').html("Không tìm thấy sản phẩm");
                }
            },
            error: function (status) {
                console.log(status);
                lib.notify("Can't loading data", "error");
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
                lib.configsClient.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }

    function formatNumber(num) {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    }

}