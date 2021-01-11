$(function () {
    $(".dlgWindows").dialog({
        show: { effect: 'blind', duration: 1000 },
        hide: { effect: 'explode', duration: 1000 },
        autoOpen: false,
        open: function (type, data) {
            $(this).parent().appendTo("form");
        }
    });
});

function OpenWindow(Id, Title, Ancho, Largo) {
    $("#" + Id).dialog({
        title: Title,
        width: Ancho,
        height: Largo,
        autoOpen: true
    });
}

function Dialogo(url, Title, iWidth, iHeight) {
    var objDialogo = $("<div></div>");
    var iFrame = $("<iframe></iframe>");

    $(iFrame).attr({ "src": url, scrolling: "no" }).css({ width: "100%", "min-height": "100%", height: "100%", border: "2px solid #8BA0BC" });
    $(objDialogo).attr({ title: Title }).css({ "overflow": "hidden" });
    $(objDialogo).append(iFrame);
    $(objDialogo)
		.windows({ width: iWidth, height: iHeight, closeOnEscape: false })
		.windowsExt({"dblclick" : "maximize"})
		.parent().draggable({ containment: "#AreaRestringida", opacity: 0.70 });
    return false;
}