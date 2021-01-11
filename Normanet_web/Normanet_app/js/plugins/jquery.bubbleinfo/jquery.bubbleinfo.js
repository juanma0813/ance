
(function ($) {


    $.fn.bubbleInfo = function (method) {


        if (methods[method]) {

            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));

        } else if ((typeof method === 'object') || (!method)) {

            return methods.init.apply(this, arguments);

        } else {

            $.error('Method ' + method + ' does not exist on jQuery.panel.');

        }


    }


    var methods = {

        init: function (options) {

            var defaults = {
                top: 2,
                left: 20,
                animHorz: true,
                IzqDer: true,
                ArribAbajo: true,
                distance: 10,
                time: 250,
                hideDelay: 500
            }

            var options = $.extend(defaults, options);


            this.each(function () {

                var distance = options.distance;
                var time = options.time;
                var hideDelay = options.hideDelay;
                var hideDelayTimer = null;
                var beingShown = false;
                var shown = false;


                var trigger = $(this).find('div').eq(0);
                var popup = $(this).find('div').eq(1);

                var animLeft;
                var animTop;

                popup.css('opacity', 0);

                if (!NavIECompatible()) {
                    popup.css('display', 'none');
                }

                if (NavIECompatible()) {
                    $(this).addClass('BubbleInfo');

                    $(trigger).addClass('trigger');
                    $(popup).addClass('Info');

                    $(trigger).mouseover(function () {
                        $(this).css('cursor', 'pointer');
                    });


                    if (options.animHorz) {
                        if (options.IzqDer) {
                            animLeft = '+=' + distance + 'px'
                            animTop = '+=0px'
                        }
                        else {
                            animLeft = '-=' + distance + 'px'
                            animTop = '+=0px'
                        }
                    }
                    else {
                        if (options.ArribAbajo) {
                            animTop = '+=' + distance + 'px'
                            animLeft = '+=0px'
                        }
                        else {
                            animTop = '-=' + distance + 'px'
                            animLeft = '+=0px'
                        }

                    }



                    $([trigger.get(0), popup.get(0)]).mouseover(function () {
                        if (hideDelayTimer) clearTimeout(hideDelayTimer);

                        if (beingShown || shown) {
                            return;
                        }
                        else {
                            $('.Info:visible').css('display', 'none');

                            beingShown = true;
                            popup.css({
                                top: options.top,
                                left: options.left,
                                display: 'block'
                            }).animate({
                                left: animLeft,
                                top: animTop,
                                opacity: 1
                            }, time, 'swing', function () {
                                beingShown = false;
                                shown = true;

                            });
                        }

                    }).mouseout(function () {

                        if (hideDelayTimer) clearTimeout(hideDelayTimer);

                        hideDelayTimer = setTimeout(function () {
                            hideDelayTimer = null;

                            popup.animate({
                                left: animLeft,
                                top: animTop,
                                opacity: 0
                            }, time, 'swing', function () {
                                shown = false;
                                popup.css('display', 'none');
                            });


                        }, hideDelay);

                    });

                }

            });


        },

        destroy: function () {

            return this.each(function () {

                $(this).unbind();

            })

        }


    }

    function NavIECompatible() {

        if (!$.support.boxModel) {
            return false;
        }
        else {
            return true;
        }

    }



})(jQuery);

