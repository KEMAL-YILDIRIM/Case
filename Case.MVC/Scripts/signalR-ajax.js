$(function () {
    // Declare a proxy to reference the hub.
    var notifications = $.connection.notificationHub;


    // Create a function that the hub can call to broadcast messages.
    notifications.client.updateMessages = function (serverResponse) {
        alert('Veritabaninda  ' + serverResponse + '  islemi uygulandi');
        getAll()

    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        getAll();
    }).fail(function (e) {
        alert(e);
    });
});


function getAll() {
    var table = $('#dataTable');
    $.ajax({
        url: '/home/GetData',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html'
    }).success(function (result) {
        table.empty().append(result);
    }).error(function () {

    });
}