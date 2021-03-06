(function($, framework) {
    framework.PopupHelper = function() {
        var createInfoPopup = function(title, content, popupType, popupCss, callback, removeButtons, callBackOnLoad, btnText, headerCloseText) {

            new BootstrapDialog({
                type: popupType == null ? BootstrapDialog.TYPE_INFO : popupType,
                title: title,
                cssClass: popupCss == null ? 'modal-size-md' : popupCss,
                size: BootstrapDialog.SIZE_NORMAL,
                message: function() {
                    $(this).keypress(function(event) {
                        if (event.keyCode == 13) {
                            $(this).find('.modal-content').find(".modal-footer #btnOk").focus().trigger('click');
                        }
                    });
                    var contentHolder = $("<div class='row'></div>").append(content);
                    return contentHolder;
                },
                buttons: removeButtons == null
                    ? [
                        {
                            id: 'btnOk',
                            label: btnText == undefined ? 'OK' : btnText,
                            cssClass: "btn-primary",
                            action: function(dialog) {
                                if (callback != null) {
                                    callback();
                                }
                                dialog.close();
                            }
                        }
                    ]
                    : []
            }).open(headerCloseText);

            if (callBackOnLoad != undefined) {
                setTimeout(function() { callBackOnLoad(); }, 300);
            }
        };

        var createConfirmationPopup = function (title, content, callback, params, cancelCallback, cancelParams) {
            var confirmDialog = new BootstrapDialog({
                type: BootstrapDialog.TYPE_WARNING,
                size: BootstrapDialog.SIZE_NORMAL,
                cssClass: "file-embed-popup",
                title: title,
                id: "ConfirmationPopup",
                closable: false,
                message: function () {
                    var $message = content;
                    return $message;
                },
                buttons: [
                    {
                        id: 'btnConfirmDelete',
                        label: 'YES',
                        cssClass: "btn-success",
                        action: function (dialog) {
                            if (callback != null) {
                                callback(params);
                            }
                            dialog.close();
                        }
                    },
                    {
                        id: 'btnCancel',
                        label: 'Cancel',
                        cssClass: "btn-danger",
                        action: function (dialog) {
                            if (cancelCallback != null) {
                                cancelCallback(cancelParams);
                            }
                            dialog.close();
                        }
                    }
                ]
            });

            confirmDialog.open();
        };

        var createErrorPopup = function (title, text, removeButtons, callback) {
            new BootstrapDialog({
                type: BootstrapDialog.TYPE_DANGER,
                title: title,
                modal: true,
                id: "ErrorPopup",
                onhidden: function () {
                    if (callback != undefined) {
                        callback();
                    }
                },
                message: function () {
                    $(this).keypress(function (event) {
                        if (event.keyCode == 13) {
                            $(this).find('#ErrorPopup').find("#btnOk").focus().trigger('click');
                        }
                    });
                    var $container = $("<div>");
                    $container.append(text);
                    $container.append("<div class='clearfix'>");
                    return $container;
                },
                buttons: removeButtons ? [] : [
                    {
                        id: 'btnOk',
                        label: 'OK',
                        cssClass: "btn-primary",
                        action: function (dialog) {
                            dialog.close();
                        }
                    }
                ]
            }).open();
        };

        return {
            CreateConfirmationPopup: function (title, msgContent, callback, params, cancelCallback, cancelParams) {
                return createConfirmationPopup(title, msgContent, callback, params, cancelCallback, cancelParams);
            },
            CreateInfoPopup: function (title, text, popupType, popupCss, callback, removeButtons, onload, btnText, headerCloseButtonText) {
                createInfoPopup(title, text, popupType, popupCss, callback, removeButtons, onload, btnText, headerCloseButtonText);
            },
            CreateErrorPopup: function (title, text, removeButtons, callback) {
                createErrorPopup(title, text, removeButtons, callback);
            }
        }
    }

    framework.Popup = new framework.PopupHelper();
})(jQuery, Framework)