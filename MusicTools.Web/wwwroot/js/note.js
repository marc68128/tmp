$(".note").on('click', function () {
    $('.note').removeClass('selected'); 
    $(this).addClass('selected');

    var key = $(this).attr("data-key");
    var alteration = $(this).attr("data-alteration");


    $.get("Home/ChordBlock", { key, alteration })
        .done(function (data) {
            $(".chord-block").remove();
            $(".content").append(data);
        });
});