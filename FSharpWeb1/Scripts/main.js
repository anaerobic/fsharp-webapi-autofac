$(function () {
    var uri = 'api/lifts';

    $.getJSON(uri)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<tr><td>' + (key + 1) + '</td><td>' + item.movement + '</td><td>' + item.destroys + '</td></tr>')
                    .appendTo($('#lifts tbody'));
            });
        });
});
