$(document).ready(function () {
    var table = $('#example').DataTable({
        "processing": true,
        "serverSide": true,
        "responsive": true,
        "ajax": {
            "url": "/Production/SupervisorRequestList",
            "type": "POST"
        },
        "columns": [
            { "data": "requestId" },
            { "data": "status" },
            { "data": "title" },
            { "data": "priority" },
            { "data": "isolator" },
            { "data": "action" }
        ],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            },
            {
                className: "text-center",
                "targets": [5]
            }
        ]
    });

    var connection = new signalR.HubConnection("/productionhub");

    connection.on('ReloadRequest', function (sender, message) {
        console.log("reloaded");
        table.ajax.reload();
    });

    connection.start().then(function () {
        console.log("connection start");
    });

    var getSupervisorRequestDetail = function (requestId) {
        $.ajax({
            method: "POST",
            url: "/Production/GetSupervisorRequestDetail",
            data: {
                requestId: requestId
            },
            success: function (data, textStatus, jqXHR) {
                $('#modal-request').modal('show');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus);
            },
            complete: function (msg) {

            }
        });
    }

    var changeRequestStatus = function (id, aproved) {
        $.ajax({
            method: "POST",
            url: "/Production/ChangeRequestStatus",
            data: {
                requestId: id,
                isApproved: aproved
            },
            success: function (data, textStatus, jqXHR) {
                if (data.IsSuccess) {
                    connection.send('SendNotification', data.Extra);
                    toastr.success(data.Message);
                }
                else {
                    toastr.warning(data.Message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(textStatus);
            },
            complete: function (msg) {
                table.ajax.reload();
            }
        });
    }

    // Detail Request
    $('#example').on('click', 'a.request-detail', function (e) {
        e.preventDefault();
        var data = table.row($(this).parents('tr')).data();
        var requestId = data.requestId;

        getSupervisorRequestDetail(requestId);
    });

    // Approve Request
    $('#example').on('click', 'a.request-approve', function (e) {
        e.preventDefault();
        var data = table.row($(this).parents('tr')).data();
        var requestId = data.requestId;
        changeRequestStatus(requestId, true);
    });

    // Approve Request
    $('#example').on('click', 'a.request-decline', function (e) {
        e.preventDefault();
        var data = table.row($(this).parents('tr')).data();
        var requestId = data.requestId;
        changeRequestStatus(requestId, false);
    });

});