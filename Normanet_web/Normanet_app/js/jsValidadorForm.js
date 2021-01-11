function ValidarForm(gGrupo) {

    ListCamposNoValidos = [];

    $('[data-grupovalidar="' + gGrupo + '"]').each(function () {
        var Id = $(this).attr('id');
        var ctr = $find(Id)


        var title = $(this).attr('data-msgvalidar');
        var tipoctr = $(this).attr('data-tipovalidador');
        var dataformato = $(this).attr('data-formato');
        var dataplacement = $(this).attr('data-placement');
        var dataplacementalert = $(this).attr('data-placement-alert');
        var cssNotif;



        if (ctr == null) {
            ctr = $('#' + Id)
        }

        if (tipoctr == "rdtp") {
            Id = $(this).find('input').eq(0).attr("id");
            ctr = $find(Id);
        }


        if (dataplacement == undefined) {
            dataplacement = "top"
        }

        if (dataplacementalert == undefined) {
            dataplacementalert = "right"
            cssNotif = 'notifValidacion'
        } else if (dataplacementalert == 'left') {
            dataplacementalert = "left"
            cssNotif = 'notifValidacionLeft'
        }

        $(this).parent().css('position', 'relative');

        switch (tipoctr) {
            case "rcbo":
                $(this).siblings('.' + cssNotif).remove();

                if (ctr.get_enabled()) {
                    if (!validateRadComboBox(ctr)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }

                break;
            case "rcboondemand":
                $(this).siblings('.' + cssNotif).remove();
                if (ctr.get_enabled()) {
                    if (!validateRadComboBoxOnDemand(ctr)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }

                break;

            case "rtxt":

                var rtxt = ctr.get_value();
                $(this).siblings('.' + cssNotif).remove();

                if (ctr.get_enabled()) {

                    if (rtxt.trim().length == 0 || (dataformato == 'email' && !validarEmail(rtxt))) {

                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);

                    }

                }


                break;
            case "rnumtxt":

                var rtxt = ctr.get_value();
                $(this).siblings('.' + cssNotif).remove();

                if (!jQuery.isNumeric(rtxt)) {
                    $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                    jsonCampoNoValido = new Object();
                    jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                    ListCamposNoValidos.push(jsonCampoNoValido);
                }


                break;
            case "txt":


                var txt = ctr.val();
                $(this).siblings('.' + cssNotif).remove();

                if (ctr.attr('disabled')!='disabled' ) {
                    if (txt.trim().length == 0) {

                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);

                    }
                }


                break;
            case "rdtp":

                var rtxt = ctr.get_selectedDate()

                if (rtxt != null) {
                    rtxt = ctr.get_selectedDate().format('yyyy/MM/dd');
                }

                $(this).siblings('.' + cssNotif).remove();

                if (ctr.get_enabled()) {
                    if (!isValidDate(rtxt)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }


                break;
            case "rcboselmult":
                if (ctr.get_enabled()) {
                    $(this).siblings('.' + cssNotif).remove();
                    if (!validateRadComboBoxSeleccionMult(ctr)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }

                break;

            case "rgrdselmult":

                $(this).siblings('.' + cssNotif).remove();
                if (!validateRadGridSeleccionMult(ctr)) {
                    $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                    jsonCampoNoValido = new Object();
                    jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                    ListCamposNoValidos.push(jsonCampoNoValido);
                }

                break;

            case "dtp":

                var txt = Date.parse(ctr.datepicker('getDate'))

                //if (rtxt != null) {
                //    rtxt = ctr.get_selectedDate().format('yyyy/MM/dd');
                //}

                $(this).siblings('.' + cssNotif).remove();

                if (!ctr.find('input[type="text"]').prop('disabled')) {
                    if (!isValidDate(txt)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }


                break;

            case "raup":

                $(this).siblings('.' + cssNotif).remove();

                if (!validadateRadAsyncUpload(ctr)) {
                    $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                    jsonCampoNoValido = new Object();
                    jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                    ListCamposNoValidos.push(jsonCampoNoValido);
                }


                break;
            case "rlibcount":
                if (ctr.get_enabled()) {
                    $(this).siblings('.' + cssNotif).remove();
                    if (!validateRadListBoxCount(ctr)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }
                break;

            case "rlibcountcheck":
                if (ctr.get_enabled()) {
                    $(this).siblings('.' + cssNotif).remove();
                    if (!validateRadListBoxCountCheck(ctr)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }
                break;
                validateRadListBoxCount
            case "rtvwcount":
                if (ctr.get_enabled()) {
                    $(this).siblings('.' + cssNotif).remove();
                    if (!validateRadTreeViewCount(ctr)) {
                        $(this).parent().append('<img src="Imagenes/Formularios/Alert16.png" class="' + cssNotif + '" data-toggle="tooltip" data-placement="' + dataplacement + '" title="' + title + '" />');

                        jsonCampoNoValido = new Object();
                        jsonCampoNoValido.Nombre = $(this).attr('data-nombrecampo');
                        ListCamposNoValidos.push(jsonCampoNoValido);
                    }
                }
                break;


                validateRadTreeView
        }



    });

    if (ListCamposNoValidos.length > 0) {

        $('[data-toggle="tooltip"]').tooltip();
        return false;
    }
    else {
        return true;
    }


}

function ResetFormValidacion() {
    ListCamposNoValidos = [];

    $('body').find('.notifValidacion').remove();

}

function MostrarCamposNoValidos() {
    var shtmlCampos = "";
    var sIcon;


    for (var i = 0; i < ListCamposNoValidos.length; i++) {
        shtmlCampos = "<li class='NomCampoNoValido'>" + ListCamposNoValidos[i].Nombre + "</li>" + shtmlCampos
    }

    if (ListCamposNoValidos.length > 0) {
        //sIcon = '<img src="Imagenes/Formularios/Alert32.png" style="float:left; margin:5px;" />'
        sIcon = '';
        shtmlCampos = '<div style="width:100%;">' + sIcon + '<div style="text-align:center;color:#0066FF;font-weight:bold;">El o los siguientes campo(s) son requeridos</div><ul style="margin:5px 5px 5px 20px">' + shtmlCampos + '</ul><div style="clear:both;"></div></div>';

        $('#notCamposNovalidos').html(shtmlCampos);

        $('#diagNotificacion').modal('show');

    }

}

function validateRadComboBox(rcbo) {
    var text = rcbo.get_text();
    if (text.length < 1) {
        return false;
    }
    else {
        var node = rcbo.findItemByText(text);
        if (node) {
            var value = node.get_value();

            if (jQuery.isNumeric(value)) {
                if (parseInt(value) > 0) {
                    return true;
                }
            }
            else {
                if (value != '') {
                    return true;
                }
            }
        }
        else {
            return false;
        }
    }
}

function validateRadComboBoxOnDemand(rcbo) {
    var text = rcbo.get_text();
    if (text.length < 1) {
        return false;
    }
    else {
        var value = rcbo.get_value();

        if (jQuery.isNumeric(value)) {
            if (parseInt(value) > 0) {
                return true;
            } else {
                return false;
            }

        } else {
            return false;
        }

    }
}

function validateRadComboBoxSeleccionMult(rcbo) {
    var items = rcbo.get_checkedItems();

    if (items.length > 0) {
        return true;
    }
    else {
        return false;
    }

}

function validateRadGridSeleccionMult(rgrd) {
    var masterTableView = rgrd.get_masterTableView();
    var selectedItems = masterTableView.get_selectedItems();

    if (selectedItems.length > 0) {
        return true;
    }
    else {
        return false;
    }

}

function validateRadListBoxCount(rlib) {
    var items = rlib.get_items();
    
    if (items.get_count() > 0) {
        return true;
    }
    else {
        return false;
    }

}

function validateRadListBoxCountCheck(rlib) {
    var items = rlib.get_checkedItems();

    if (items.length > 0) {
        return true;
    }
    else {
        return false;
    }

}


function validateRadTreeViewCount(rtvw) {
    var items = rtvw.get_selectedNodes();

    if (items.length > 0) {

        var level = items[0].get_level();

        if (level > 0) {
            return true;
        }
        else {
            return false;
        }   
    }
    else {
        return false;
    }

}







function isDate(sDate) {
    var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/

    if (sDate != null) {

        if (re.test(sDate)) {
            var dArr = sDate.split("/");
            var d = new Date(dArr[2] + '/' + dArr[1] + '/' + dArr[0]);
            return d.getMonth() + 1 == dArr[1] && d.getDate() == dArr[0] && d.getFullYear() == dArr[2];
        }
        else {
            return false;
        }
    }
    else {
        return false;
    }


}

function isValidDate(date) {
    var formats = ['DD-MM-YYYY', 'DD/MM/YYYY']

    if (moment(date, formats).isValid()) {
        return true;
    } else {
        return false;
    }

}

  function validarEmail(valor) {
      if (/^(?:[^<>()[\].,;:\s@"]+(\.[^<>()[\].,;:\s@"]+)*|"[^\n"]+")@(?:[^<>()[\].,;:\s@"]+\.)+[^<>()[\]\.,;:\s@"]{2,63}$/i.test(valor)) {
        return true;
    } else {
        return false;
    }

}

function validadateRadAsyncUpload(raup) {
    return raup.getUploadedFiles().length != 0;
}

function ActivarCtrGrupo(bActivar) {
    $('[data-grupovalidar="' + gGrupo + '"]').each(function () {
        var Id = $(this).attr('id');
        var ctr = $find(Id)

        var title = $(this).attr('data-msgvalidar');
        var tipoctr = $(this).attr('data-tipovalidador');
        var dataplacement = $(this).attr('data-placement');
        var dataplacementalert = $(this).attr('data-placement-alert');


        if (ctr == null) {
            ctr = $('#' + Id)
        }

        if (tipoctr == "rdtp") {
            Id = $(this).find('input').eq(0).attr("id");
            ctr = $find(Id);
        }



    });
}