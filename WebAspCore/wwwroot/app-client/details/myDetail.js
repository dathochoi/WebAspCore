var MyDetail = function () {
    this.init = function () {
        //console.log("my detail js");
        $('.priceView').hide();
        $('.priceView').first().show();
        $('.selectPrice').first().addClass('btn-success btnStyle');
        registerEvent();  

    }
    function registerEvent() {
        $('.selectPrice').on('click', function () {
            //$(this).removeClass('btn-secondary');
            $('.selectPrice').removeClass('btn-success');
            $('.selectPrice').removeClass('btnStyle');
            $(this).addClass('btn-success btnStyle');
            var index = $(this).data("index");
            $('.priceView').hide();
            //$('.priceView').find('[data-index =' + index + ']').show();
            $('.priceView').each(function (i, item) {
                if ($(item).attr('data-index') == index)
                    $(item).show();
            });
            console.log($('.priceView'));
            
            //console.log(index);
        });
    }


}

