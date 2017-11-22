var Admin = function() {
    var $modalGenerico = $("#modalGenerico");
    var showModalCliente = function (url) {
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'html',
            beforeSend: function () {
                App.blockUI();
            },
            complete: function () {
                App.unblockUI();
            },
            success: function (respuesta) {
                $modalGenerico.html(respuesta);
                $modalGenerico.modal();
            }
        });
    };
    var showModalNuevoPedido = function (url) {
        $.ajax({
            url: url,
            type: 'GET',
            dataType: 'html',
            beforeSend: function () {
                App.blockUI();
            },
            complete: function () {
                App.unblockUI();
            },
            success: function (respuesta) {
                $modalGenerico.html(respuesta);
                $modalGenerico.modal();
            }
        });
    };

    return {
        showModalCliente: function (url) {
            showModalCliente(url);
        },
        showModalNuevoPedido: function (url) {
            showModalNuevoPedido(url);
        }
    };
}();