//https://github.com/conartist6/splitflap

///strict

$(document).ready(function () {
    var intitialValue = 'FAMILIA GALANTE ';
    var header = $("#splitflap").text().toUpperCase();
    $("#splitflap").text('');

    var disp = $("#splitflap").splitflap({
        //initial: '                ',
        initial: intitialValue,
        glyphSet: [" ", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", "-", "?", "!", ",", "1", "2", "3"]
    });
    setTimeout(function () { disp.splitflap("value", header) }, 1900);

    var hasOriginalValue = true;
    $('#changeWord').on('click', function () {
        //alert(header);

        if (hasOriginalValue) {
            disp.splitflap("value", intitialValue);
            hasOriginalValue = false;
        }
        else {
            disp.splitflap("value", header);
            hasOriginalValue = true;
        }
    });




    CreateLeaderboard();
    
});


function CreateLeaderboard() {

    //alert($('#leaderboard').is(":visible"));
    var visibleDesktop = $('#visibleDesktop').is(":visible")

    var myGlyphSet = [" ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "p", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", ".", "-", "?", "!", ","]
    var initialLeaderboardValue = '             ';

    var competitors =
        [
            //{ name: 'Daniel', position: 1, points: 199 },
            //{ name: 'Denise', position: 2, points: 198 },
            //{ name: 'Gustav', position: 3, points: 190 },
            //{ name: 'Janne ', position: 4, points: 184 },
            //{ name: 'Peter ', position: 5, points: 172 }

            { name: 'Daniel', position: 3, points: 235 },
            { name: 'Denise', position: 4, points: 234 },
            { name: 'Gustav', position: 1, points: 242 },
            { name: 'Janne ', position: 5, points: 220 },
            { name: 'Peter ', position: 2, points: 236 }
        ]; 

    var dispLeaderboard = $('#leaderboard').splitflap({
        initial: 'LEADERBOARD  ',
        glyphSet: myGlyphSet
    });

    var dispEmpty = $('#empty').splitflap({
        initial: initialLeaderboardValue,
        glyphSet: myGlyphSet
    });

    //Daniel
    var dispDaniel = $('#daniel').splitflap({
        initial: GetSplitflapInitailValue(competitors[0], visibleDesktop, initialLeaderboardValue),
        glyphSet: myGlyphSet
    });
    if (visibleDesktop)
        setTimeout(function () { dispDaniel.splitflap("value", competitors[0].position + ' ' + competitors[0].name.toUpperCase() + ' ' + competitors[0].points + 'p') }, 1900);

    //Denise
    var dispDenise = $('#denise').splitflap({
        initial: GetSplitflapInitailValue(competitors[1], visibleDesktop, initialLeaderboardValue),
        glyphSet: myGlyphSet
    });
    if (visibleDesktop)
        setTimeout(function () { dispDenise.splitflap("value", competitors[1].position + ' ' + competitors[1].name.toUpperCase() + ' ' + competitors[1].points + 'p') }, 1900);

    //Gustav
    var dispGustav = $('#gustav').splitflap({
        initial: GetSplitflapInitailValue(competitors[2], visibleDesktop, initialLeaderboardValue),
        glyphSet: myGlyphSet
    });
    if (visibleDesktop)
        setTimeout(function () { dispGustav.splitflap("value", competitors[2].position + ' ' + competitors[2].name.toUpperCase() + ' ' + competitors[2].points + 'p') }, 1900);

    //Janne
    var dispJanne = $('#janne').splitflap({
        initial: GetSplitflapInitailValue(competitors[3], visibleDesktop, initialLeaderboardValue),
        glyphSet: myGlyphSet
    });
    if (visibleDesktop)
        setTimeout(function () { dispJanne.splitflap("value", competitors[3].position + ' ' + competitors[3].name.toUpperCase() + ' ' + competitors[3].points + 'p') }, 1900);

    //Peter
    var dispPeter = $('#peter').splitflap({
        initial: GetSplitflapInitailValue(competitors[4], visibleDesktop, initialLeaderboardValue),
        glyphSet: myGlyphSet
    });
    if (visibleDesktop)
        setTimeout(function () { dispPeter.splitflap("value", competitors[4].position + ' ' + competitors[4].name.toUpperCase() + ' ' + competitors[4].points + 'p') }, 1900);
}

//For competitors
function GetSplitflapInitailValue(competitor, visibleDesktop, defaultInitialLeaderboardValue)
{
    return visibleDesktop ?
        defaultInitialLeaderboardValue :
        competitor.position + ' ' + competitor.name.toUpperCase() + '  ' + competitor.points + 'p';
}