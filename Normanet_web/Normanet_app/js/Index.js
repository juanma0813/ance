

/* BLOQUEA FORWARD NAVEGADOR */

    function nobackbutton() {
    
        window.location.hash = "#";    
        window.location.hash = "#ANCE" //chrome    
        window.onhashchange = function () { window.location.hash = "#"; }    
    }

    $(document).ready(
                      function () {
                          AjustaAreaRestringida();
                          $(window).resize(function () {
                              AjustaAreaRestringida();
                          });
                          $('.Bubble').bubbleInfo({ animHorz: false, top: -40, left: -270 });
                      });

    function AjustaAreaRestringida() {
        var ribbon = $find('rbbRibbon');
        
        if (!ribbon == null) {
            if (ribbon._element.className.indexOf("rrbMinimized") >= 0) {
                $('#AreaRestringida').height('93%');
                $('#rbbRibbon').width('100%');
            } else {
                $('#AreaRestringida').height('83vh');
                $('#rbbRibbon').width('100%');
            }
        } else {
            $('#AreaRestringida').height('83vh');
            $('#rbbRibbon').width('100%');
        }
            
    }


function IniTimerNotificaciones(Intervalo) {
    Intervalo = Intervalo * 60 * 1000

    setInterval(function () {
            NotificacionesUsuario();
    }, Intervalo);

}


    $(document).ready(function () {

        jQuery.browser = {};
        jQuery.browser.mozilla = /mozilla/.test(navigator.userAgent.toLowerCase()) && !/webkit    /.test(navigator.userAgent.toLowerCase());
        jQuery.browser.webkit = /webkit/.test(navigator.userAgent.toLowerCase());
        jQuery.browser.opera = /opera/.test(navigator.userAgent.toLowerCase());
        jQuery.browser.msie = /msie/.test(navigator.userAgent.toLowerCase());
        jQuery.browser.chrome = /chrome/.test(navigator.userAgent.toLowerCase());


        //if (jQuery.browser.webkit) {
        //    $('.rmLeftImage').css('margin-top', '4px');
        //}

    });


/* FIN BLOQUEA FORWARD NAVEGADOR */