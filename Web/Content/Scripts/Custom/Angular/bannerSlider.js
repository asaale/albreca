app.directive("bannerSlider", function () {
    return {
        templateUrl: '/Content/Partials/bannerSlider.html',
        restrict: 'E',
        link: function () {
            $('.rev-slider-fixed,.rev-slider-full').css('visibility', 'visible'),
            $('.rev-slider-banner-full').revolution({
                delay: 5000,
                startwidth: 1170,
                startheight: 500,
                onHoverStop: "on",
                thumbWidth: 100,
                thumbHeight: 50,
                thumbAmount: 3,
                hideThumbs: 0,
                navigationType: "none",
                navigationArrows: "solo",
                navigationStyle: "bullets",
                navigationHAlign: "center",
                navigationVAlign: "bottom",
                navigationHOffset: 30,
                navigationVOffset: 30,
                soloArrowLeftHalign: "left",
                soloArrowLeftValign: "center",
                soloArrowLeftHOffset: 20,
                soloArrowLeftVOffset: 0,
                soloArrowRightHalign: "right",
                soloArrowRightValign: "center",
                soloArrowRightHOffset: 20,
                soloArrowRightVOffset: 0,
                touchenabled: "on",
                stopAtSlide: -1,
                stopAfterLoops: -1,
                hideCaptionAtLimit: 0,
                hideAllCaptionAtLilmit: 0,
                hideSliderAtLimit: 0,
                fullWidth: "on",
                fullScreen: "off",
                fullScreenOffsetContainer: "#topheader-to-offset",
                shadow: 0

            });
        }
    };
});