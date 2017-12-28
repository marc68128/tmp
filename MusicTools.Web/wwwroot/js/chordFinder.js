

$(".note").on('click', function () {
    //$('.note').removeClass('selected'); 
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
    } else {
        $(this).addClass('selected');
    }


    if ($(".selected").length > 2) {
        var data = null;
        var index = 1;
        $(".selected").each(function () {
            if (data == null) {
                data = {
                    key1: $(this).attr("data-key"),
                    alteration1: $(this).attr("data-alteration")
                };
                index = 2;
            } else {
                data["key" + index] = $(this).attr("data-key");
                data["alteration" + index] = $(this).attr("data-alteration");
                index++;
            }
        });

        console.log(data);

        $.get("ChordFinder/GetChords", data)
            .done(function (data) {
                $(".chord-list").remove();
                $(".chord-finder").append(data);
                //$(".content").append(data);
            });
    }

    $(".selected").each(function () {
        var audioo = document.createElement("audio");
        var key = $(this).attr("data-key-string");
        if ($(this).attr("data-alteration") == 0) {
            audioo.src = "sounds/" + key + ".mp3";
        } else if ($(this).attr("data-alteration") == 1) {
            audioo.src = "sounds/" + key + "Sharp.mp3";
        }
        audioo.play();
    });
});