$(function () {
    $(".pnlConfirm").dialog({
        autoOpen: false,
        modal: true,
        open: function (type, data) {
            $(this).parent().appendTo("form");
        }
    });
});

function openConfirm(SelectorID, titulo, btns) {

    if ($("#" + SelectorID).closest('.ui-dialog').find(".ui-zok").length == 0) {
        if (btns == null) {
            $("#" + SelectorID).dialog({ autoOpen: true, title: titulo });
        } else {
            var uiDialogButtonPane = $("<div>").addClass("ui-dialog-buttonpane ui-widget-content ui-helper-clearfix ui-zok").append($("<div>").addClass("ui-dialog-buttonset"));

            btns.forEach(function (item) {
                $(uiDialogButtonPane).closest(".ui-dialog-buttonpane").find(".ui-dialog-buttonset").append("&nbsp;&nbsp;").append($(item));
            });

            $("#" + SelectorID).dialog({ autoOpen: true, title: titulo }).closest(".ui-dialog").append($(uiDialogButtonPane));
        }
    } else {
        $("#" + SelectorID).dialog({ autoOpen: true, title: titulo })
    }

}
