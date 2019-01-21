
$.formObject = function ($form) {
    var obj = $form.serializeToJSON({});
    return JSON.stringify(obj);

}

function populateForm($form, data) {
    resetForm($form);
    $.each(data, function (key, value) {
        var $ctrl = $form.find('[name=' + key + ']');
        if ($ctrl.is('select')) {
            $('option', $ctrl).each(function () {
                if (this.value == value)
                    this.selected = true;
            });
        } else if ($ctrl.is('textarea')) {
            $ctrl.val(value);
        } else {
            switch ($ctrl.attr("type")) {
            case "text":
            case "hidden":
                $ctrl.val(value);
                break;
            case "checkbox":
                if (value == '1')
                    $ctrl.prop('checked', true);
                else
                    $ctrl.prop('checked', false);
                break;
            }
        }
    });
};
function resetForm($form) {
    $form.find('input:text, input:password, input:file, select, textarea').val('');
    $form.find('input:radio, input:checkbox').removeAttr('checked').removeAttr('selected');
}

function json2html_name_list(json, result, parent) {
    if (!result) result = {};
    if (!parent) parent = '';
    if ((typeof json) != 'object') {
        result[parent] = json;
    } else {
        for (var key in json) {
            var value = json[key];
            if (parent == '') var subparent = key;
            else var subparent = parent + '[' + key + ']';
            result = json2html_name_list(value, result, subparent);
        }
    }
    return result;
}


function creatoredit($method, $url,$data)
{
    $(".alert").hide();
    $.ajax({
        type: $method,
        url: $url,

        data:$data ,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
           
            location.reload();
            $(".alert-success").show();
        },
        error: function (errMsg) {
            $(".alert-danger").show();
        }
    });


}
