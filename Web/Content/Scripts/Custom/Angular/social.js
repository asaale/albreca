app.directive("social", function () {
    return {
        templateUrl: '/Content/Partials/social.html',
        restrict: 'E',
        link: function() {
            $('.searchbox .searchbox-icon,.searchbox .searchbox-inputtext').bind('click', function () {
                var $search_tbox = $('.searchbox .searchbox-inputtext');
                $search_tbox.css('width', '120px');
                $search_tbox.focus();
                $('.searchbox', this).addClass('searchbox-focus');
            }),

            //Blur
            $('.top-bar .searchbox-inputtext,body').bind('blur', function () {
                var $search_tbox = $('.searchbox .searchbox-inputtext');
                $search_tbox.css('width', '0px');
                $('.searchbox', this).removeClass('searchbox-focus');
            });
        }
    };
});