(function ($) {

    // Change "revapi1" below to your slider's unique "API" variable:
    var api = revapi,

        // enter the "Grid Width" of your slider here
        // if not entered, script will attempt to obtain these values automatically
        // see #8 here: http://themepunch.com/revolution/documentation/assets/images/image_262.jpg
        gridWidth = 0,

        // the class name or ID of your element you wish to scale up
        zoomSelector = '.zoom-this',

        // CSS transformOrigin: http://www.w3schools.com/cssref/css3_pr_transform-origin.asp
        scaleFrom = 'left top',

        // if slider is scaled below "firstScaleCheck" value, 
        // and above "secondScaleCheck" value, 
        // zoom element by "firstScaleAmount" value
        firstScaleCheck = 0.5
        , firstScaleAmount = 0.35,

        // if slider is scaled below "secondScaleCheck" number, 
        // zoom element by "secondScaleAmount" value
        secondScaleCheck = 0.25
        , secondScaleAmount = 0.75,

        // no need to edit anything below
        slider = $('#revslider');
    if (!slider.length) return;

    var temp = slider[0].style
        , transform = 'transform' in temp ? 'transform' :
        'WebkitTransform' in temp ? 'WebkitTransform' :
        'MozTransform' in temp ? 'MozTransform' :
        'msTransform' in temp ? 'msTransform' :
        'OTransform' in temp ? 'OTransform' : null;

    if (!gridWidth) {

        var script = slider.closest('#revslider').find('script').text();
        if (script) gridWidth = parseInt(script.split('startwidth:')[1].split(',')[0], 10);

    }

    if (!gridWidth || !transform) return;

    var plus
        , origin = 'transformOrigin' in temp ? 'transformOrigin' :
        'WebkitTransformOrigin' in temp ? 'WebkitTransformOrigin' :
        'MozTransformOrigin' in temp ? 'MozTransformOrigin' :
        'msTransformOrigin' in temp ? 'msTransformOrigin' :
        'OTransformOrigin' in temp ? 'OTransformOrigin' : null,

        items = slider.find(zoomSelector).each(function () {
            this.style[origin] = scaleFrom;
        });
    api.on('revolution.slide.onloaded', function () {

        sizer();
        $(window).on('resize', sizer);

    });

    function sizer() {

        var scaled = Math.min(slider.width() / gridWidth, 1).toFixed(2);
        plus = scaled < 1 ? (1 - parseFloat(scaled)) + 1 : 1;

        if (scaled < firstScaleCheck) {
            plus = scaled > secondScaleCheck ? plus + firstScaleAmount : plus + secondScaleAmount;
        }

        items.each(sizeEach);

    }

    function sizeEach() {

        this.style.display = 'inline-block';
        this.style[transform] = 'scale(' + plus + ', ' + plus + ')';

    }

})(jQuery);