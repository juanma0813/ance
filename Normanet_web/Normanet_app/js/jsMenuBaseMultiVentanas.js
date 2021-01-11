function datepicker() {
    $(".datepicker").datepicker();
}

function spinner() {
    $(".spinner").spinner({ min: 0, max: 10, step: 1 });
}

$(function () {
    $("#tabs").tabs();
});

$(function () {
    spinner();
});

$(function () {
    datepicker();
});

function SoloNumeros() {
    $(".validar").keydown(function (event) {
        if (event.keyCode == 46 || event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 27 ||
            (event.keyCode == 65 && event.ctrlKey === true) || (event.keyCode >= 35 && event.keyCode <= 39) || (event.keyCode == 110 || event.keyCode == 190)) {
            return;
        }
        else {

            if ((event.keyCode < 48 || event.keyCode > 57) && (event.keyCode < 96 || event.keyCode > 105)) {
                event.preventDefault();
            }
        }
    });
}

$(function () {
    SoloNumeros();
});