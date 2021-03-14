
var initializeSchEscScheduler = function (elementId, entityId, beggingDate, numDates, jsonFile, urlGetEvents, urlViewEvent, urlOtherEvent, skipImportEvents, defaultActiveDate) {
    $("#" + elementId + "").empty();
    escScheduler.init({
        entityId: entityId,
        elementId: elementId, // id of a div
        jsonFile: jsonFile, // name of a json file
        beggingDate: beggingDate, // integer or a specific date (examples: -3, 0, 3, 2017-03-12)
        numDates: numDates, // positive integer
        width: "1500", // number in pixels or percentage (examples: 120px, 150px, 50%, 70%, auto, 120px - auto, 50% - auto)
        alignment: "center", // 'left', 'center' and 'right'
        enableArrows: true, // true/false
        colors: {
            overlay: "black", // 'black', 'green', 'blue', 'red', 'cyan', 'pink', 'purple' and 'orange'
            arrows: "black", // 'black', 'green', 'blue', 'red', 'cyan', 'pink', 'purple' and 'orange'
            defaultEventLine: "black" // any color in css format (name or hex value)
        },
        dateType: "both", // 'days', 'months' and 'both'
        flashSpaceInterval: "10", // positive integer
        localization: "en-US", // country ISO code
        differDateWithEvents: true, // true/false
        loadMousewheelPlugin: true, // true/false
        skipImportEvents: skipImportEvents,
        defaultActiveDate: defaultActiveDate == null || defaultActiveDate.length == 0 ? undefined : defaultActiveDate,
        urlGetEvents: urlGetEvents,
        urlViewEvent: urlViewEvent,
        urlOtherEvent: urlOtherEvent
    });
}

var triggerSchAjaxRequest = function (actionUrl, actionData, successCallBack, contentType, spinnerIntervalMs) {
    Framework.Spinner.Start(null, spinnerIntervalMs);

    var request = $.ajax({
        url: actionUrl,
        type: "POST",
        cache: false,
        traditional: true,
        data: actionData,
        contentType: contentType != null ? contentType : undefined,
        success: function (data) {
            Framework.Spinner.Stop();
            if (successCallBack != null) {
                setTimeout(function () {
                    successCallBack(data);
                }, 100);
            }
            return data;
        },
        error: function (data) {

        },
        fail: function (data) {
            window.location.href = "/account/login";
        }
    });
    return request.responseText;
};

