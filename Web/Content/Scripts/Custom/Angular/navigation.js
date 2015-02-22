app.directive("mainNavigation", function () {
    return {
        templateUrl: '/Content/Partials/navigation.html',
        restrict: 'E',
        link: function() {
            $('.navigation').AXMenu({
                showArrowIcon: true, // true for showing the menu arrow, false for hide them
                firstLevelArrowIcon: '',
                menuArrowIcon: ""
            });
        }
    };
});