var selectedAlteration = 0;
var selectedKey, selectedChordQuality = null; 

$(".key-selector").on('click', function () {
    $('.key-selector').removeClass('selected');
    $(this).addClass('selected');

    selectedKey = $(this).attr("data-key");
    getChord();
});

$(".alteration-selector").on('click', function () {
    $('.alteration-selector').removeClass('selected');
    $(this).addClass('selected');

    selectedAlteration = $(this).attr("data-alteration");
    getChord();
});

$(".chordQuality-selector").on('click', function () {
    $('.chordQuality-selector').removeClass('selected');
    $(this).addClass('selected');

    selectedChordQuality = $(this).attr("data-chordQuality");
    getChord();
});

function getChord() {
    if (selectedKey == null || selectedChordQuality == null) 
        return;

    $.get("Chord/GetChord", { key : selectedKey, alteration : selectedAlteration, chordQuality : selectedChordQuality })
        .done(function (data) {
            $(".chord-block").remove();
            $(".content").append(data);
        });
}