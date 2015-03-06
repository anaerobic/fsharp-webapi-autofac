$(function () {
    var uri = 'odata/Lifts';

    $.getJSON(uri)
        .done(function (data) {
            $.each(data.value, function (key, item) {
                $('<tr><td>' + item.Id + '</td><td>' + item.Movement + '</td><td>' + item.Destroys + '</td></tr>')
                    .appendTo($('#lifts tbody'));
            });
        });
});
