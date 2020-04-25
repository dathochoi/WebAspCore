var productController = function () {
    this.initialize = function () {
       // loadCategories();
        loadData();
        registerEvent();
        //registerControls();
    }
    function registerEvent() {
        $("body").on("click", ".btnCategory", function () {
            //console.log("clicked sidebar");
            console.log($(this).data("id"));
            var template = $('#table-template').html();
            var render = "";
            $.ajax({
                type: "GET",
                data: {
                    categoryId: $(this).data("id"),
                    keyword: $('txtKeyword').val(),
                    page: lib.configsClient.pageIndex,
                    pageSize: lib.configsClient.pageSize
                },
                url: "/Product/GetAllPaging",
                dataType: 'json',
                success: function (res) {
                    console.log(res);
                    $.each(res.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                            Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.Image + '" width=25 />',
                            //CategoryName: item.ProductCategory.Name == null ? item.ProductCategory.Name: string.empty,
                            //Price: item.PromotionPrice == 0 ? lib.formatNumber(item.Price, 0) : lib.formatNumber(item.PromotionPrice, 0),
                            //PromotionPrice: item.PromotionPrice == 0 ? " " : lib.formatNumber(item.PromotionPrice,0)
                            Price: item.Price,
                            PromotionPrice: item.PromotionPrice
                        });

                    });
                    if (render != '') {
                        $('#tbl-content').html(render);
                    }
                    wrapPaging(res.RowCount, function () {
                        loadData();
                    }, true);
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
                keyword: $('txtKeyword').val(),
                page: lib.configsClient.pageIndex,
                pageSize: lib.configsClient.pageSize
            },
            url: "/Product/GetAllPaging",
            dataType: 'json',
            success: function (res) {
                console.log(res);
                $.each(res.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image == null ? '<img src="/admin-side/images/user.png" width=25' : '<img src="' + item.Image + '" width=25 />',
                        //CategoryName: item.ProductCategory.Name == null ? item.ProductCategory.Name: string.empty,
                        //Price: item.PromotionPrice == 0 ? lib.formatNumber(item.Price, 0) : lib.formatNumber(item.PromotionPrice, 0),
                        //PromotionPrice: item.PromotionPrice == 0 ? " " : lib.formatNumber(item.PromotionPrice,0)
                        Price:item.Price,
                        PromotionPrice: item.PromotionPrice
                    });
                    
                });
                if (render != '') {
                    $('#tbl-content').html(render);
                }
                wrapPaging(res.RowCount, function () {
                    loadData();
                }, isPageChanged);
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
                lib.configsClient.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }


}