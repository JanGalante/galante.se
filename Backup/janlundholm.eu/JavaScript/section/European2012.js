///<reference path="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
///<reference path="../jquery.js" />
/// <reference path="../knockout.js" />

$(document).ready(function() {   
    $('h2.group').on('click', function() {
        //$('#Grupp-A').toggle('blind');
        //$('#Grupp-A').hide();
        if ($(this).hasClass("visible")) {
            $(this).removeClass("visible").next().slideUp();
        } else {
            $("h2.group").removeClass("visible").next().slideUp();
            $(this).addClass("visible").next().slideDown();
        }
    });

//    $("div.section-head").click(function() {
//        if ($(this).hasClass("visible")) {
//            $(this).removeClass("visible").next().slideUp();
//        } else {
//            $("div.section-head").removeClass("visible").next().slideUp();
//            $(this).addClass("visible").next().slideDown();
//        }
//    }); 
    

    var documentId = getURLParameter('document');
    //Gör det möjligt att editera resultat
    MakeEditable();

    //Bygger slutspelsträd
    BuildFinalsTree();
    AddFinalsTreeTriggers();

    //Ser till att det är möjligt att spara sitt slutspelsträd
    $('input:submit#finals').on('click', function(event) {
        SaveFinals();
        return false;
    });

    //Hämtar excel
    $('input:submit#getExcel').on('click', function(event) {
        //GetExcel();
        downloadUrl = "/European2012.ashx?action=getExcel&document=" + documentId;
        location = downloadUrl;
        return false;
    });
});



function MakeEditable() {
    var documentId = getURLParameter('document');
    //$("div.game .editable").editable("http://localhost/European2012.ashx?action=saveResult&group=A&hometeam=Sydafrika&awayteam=Mexiko&homegoal=2&awaygoal=0", {
    $("div.game .editable").editable("/European2012.ashx?action=saveResult&document=" + documentId + "&group=A&hometeam=Sydafrika&awayteam=Mexiko&homegoal=2&awaygoal=0", {
        method: "PUT",
        id: "gameid",
        name: "result",
        callback: function(value, settings) {
            //         console.log(this);
            //         console.log(value);
            //         console.log(settings);

            var group = $(this).parent().parent().attr('rel');
            group = group.replace('Grupp-', '');
            //alert(group);

            //alert("dsfsdf");
            //$.getJSON('http://localhost/European2012.ashx?action=getGroup&group=' + group, function(data){
            $.getJSON('/European2012.ashx?action=getGroup&group=' + group + "&document=" + documentId, function(data) {

                //				$.each(data, function(key, val) {
                //					items.push('<li id="' + key + '">' + val + '</li>');
                //				});

                //				$.each(data, function(key, val) {
                //					response += ('<td>' + data.team + '</td>');
                //				});

                var response = '<tr class="header">' +
                                    '<td>&nbsp;</td>' +
                                    '<td class="numeric">Spelade</td>' +
                                    '<td class="numeric">Vinst</td>' +
                                    '<td class="numeric">Oavgjort</td>' +
                                    '<td class="numeric">Förlust</td>' +
                                    '<td class="numeric">Gjorda mål</td>' +
                                    '<td class="numeric">Insläpta mål</td>' +
                                    '<td class="numeric">Målskillnad</td>' +
                                    '<td class="numeric">Poäng</td>' +
                                '</tr>';
                for (i = 0; i < data.length; i++) {
                    response += ('<tr class="' + (i + 1) + '" class="game">');
                    response += ('<td class="name">' + data[i].name + '</td>');
                    response += ('<td class="numeric">' + data[i].gamesplayed + '</td>');
                    response += ('<td class="numeric">' + data[i].gameswon + '</td>');
                    response += ('<td class="numeric">' + data[i].gamesdraw + '</td>');
                    response += ('<td class="numeric">' + data[i].gameslost + '</td>');
                    response += ('<td class="numeric">' + data[i].goalsmade + '</td>');
                    response += ('<td class="numeric">' + data[i].goalsbackward + '</td>');
                    response += ('<td class="numeric">' + data[i].goaldifference + '</td>');
                    response += ('<td class="numeric">' + data[i].points + '</td>');
                    response += ('</tr>');
                }
                //Ersätter befintlig tabell
                $("#Grupp-" + group).html(response);
                
                //Uppdaterar slutspelsträd
                BuildFinalsTree();
            });
        }
    });
}

function BuildFinalsTree() {
    //1:an grupp A
    $('.quarterfinals #25.game .team .name:first').text( 
		$('#Grupp-A tr.1 .name').text());
    //2:an grupp B
    $('.quarterfinals #25.game .team .name:last').text(
		$('#Grupp-B tr.2 .name').text());

    //1:an grupp B
    $('.quarterfinals #26.game .team .name:first').text(
		$('#Grupp-B tr.1 .name').text());
    //2:an grupp A
    $('.quarterfinals #26.game .team .name:last').text(
		$('#Grupp-A tr.2 .name').text());

    //1:an grupp C
    $('.quarterfinals #27.game .team .name:first').text(
		$('#Grupp-C tr.1 .name').text());
    //2:an grupp D
    $('.quarterfinals #27.game .team .name:last').text(
		$('#Grupp-D tr.2 .name').text());

    //1:an grupp D
    $('.quarterfinals #28.game .team .name:first').text(
		$('#Grupp-D tr.1 .name').text());
    //2:an grupp C
    $('.quarterfinals #28.game .team .name:last').text(
		$('#Grupp-C tr.2 .name').text());
}

function AddFinalsTreeTriggers() {
    //Gör det möjligt att välja vilka lag som går till semifinal
//    $('.quarterfinals #25.game .team .name').on('click', function(event) {
//        $('.semifinals #29.game .team .name:first').text($(this).text());
//    });
//    $('.quarterfinals #26.game .team .name').on('click', function(event) {
//        $('.semifinals #29.game .team .name:last').text($(this).text());
//    });

//    $('.quarterfinals #27.game .team .name').on('click', function(event) {
//        $('.semifinals #30.game .team .name:first').text($(this).text());
//    });
//    $('.quarterfinals #28.game .team .name').on('click', function(event) {
//        $('.semifinals #30.game .team .name:last').text($(this).text());
    //    });
    $('.quarterfinals #25.game .team .name').on('click', function(event) {
        $('.semifinals #29.game .team .name:first').text($(this).text());
    });
    $('.quarterfinals #27.game .team .name').on('click', function(event) {
        $('.semifinals #29.game .team .name:last').text($(this).text());
    });
    
    $('.quarterfinals #26.game .team .name').on('click', function(event) {
        $('.semifinals #30.game .team .name:first').text($(this).text());
    });
    $('.quarterfinals #28.game .team .name').on('click', function(event) {
        $('.semifinals #30.game .team .name:last').text($(this).text());
    });

    //Gör det möjligt att välja vilka lag som går till final
    $('.semifinals #29.game .team .name').on('click', function(event) {
        $('.final #31.game .team .name:first').text($(this).text());
    });
    $('.semifinals #30.game .team .name').on('click', function(event) {
        $('.final #31.game .team .name:last').text($(this).text());
    });

    //Gör det möjligt att välja vilka lag som vinner EM
    $('.final #31.game .team .name').on('click', function(event) {
        $('.prize-giving .team .name:first').text($(this).text());
    });

    
    //När användare byter lag som går vidare, måste koll göras att det 
    //bortbytta laget inte finns längre ner i slutspelsträdet
    $('.quarterfinals .game .team .name').on('click', function(event) {
        var proceedTeam = $(this).text(); //Laget som klickats är det som ska gå vidare
        var gameNode = $(this).parent().parent(); //Ställer oss på för själva matchen ('.game')
        var knockoutTeam = //Laget som inte klickats är det som åker ut
			proceedTeam != gameNode.find('.team .name:first').text() ?
			gameNode.find('.team .name:first').text() :
			gameNode.find('.team .name:last').text();

        //Kontrollerar att det utslagna laget inte har valts 
        //vidare till semifinal eller final sedan tidigare
        $('.final .game .team .name, .prize-giving .game .team .name').each(function() {
            if ($(this).text() == knockoutTeam) {
                $(this).text('');
            }
        });
    });

    //När användare byter lag som går vidare, måste koll göras att det 
    //bortbytta laget inte finns längre ner i slutspelsträdet
    $('.semifinals .game .team .name').on('click', function(event) {
        var proceedTeam = $(this).text(); //Laget som klickats är det som ska gå vidare
        var gameNode = $(this).parent().parent(); //Ställer oss på för själva matchen ('.game')
        var knockoutTeam = //Laget som inte klickats är det som åker ut
			proceedTeam != gameNode.find('.team .name:first').text() ?
			gameNode.find('.team .name:first').text() :
			gameNode.find('.team .name:last').text();

        //Kontrollerar att det utslagna laget inte har valts 
        //vidare till semifinal eller final sedan tidigare
        $('.prize-giving .game .team .name').each(function() {
            if ($(this).text() == knockoutTeam) {
                $(this).text('');
            }
        });
    });

    //Sätter resultatet 1-0 till det lag som användaren valt som vinnare
    $('.game .team .name').on('click', function(event) {
        var proceedTeam = $(this); //Laget som klickats är det som ska gå vidare
        var gameNode = $(this).parent().parent(); //Ställer oss på för själva matchen ('.game')
        var knockoutTeam = //Laget som inte klickats är det som åker ut
			proceedTeam.text() != gameNode.find('.team .name:first').text() ?
			gameNode.find('.team .name:first') :
			gameNode.find('.team .name:last');

        //Sätter resultatet 1-0 till det lag som användaren valt som vinnare
        var proceedResult = proceedTeam.parent().find('.result');
        var knockoutResult = knockoutTeam.parent().find('.result');
        proceedResult.text('1');
        knockoutResult.text('0');
    });
}


function SaveFinals() {
    var documentId = getURLParameter('document');
    //Loopar igenom alla matchet i slutspelsträdet och lägger i en array
    var games = new Array();
    //$('.eightfinals .game, .quarterfinals .game, .semifinals .game, .final .game').each(function(){
    $('.eightfinals .game, .quarterfinals .game, .semifinals .game, .final .game').each(function() {
        var id = $(this).attr('id');
        var homeTeam = $(this).find('.team .name:first').text();
        var awayTeam = $(this).find('.team .name:last').text();
        var homeGoals = $(this).find('.team .result:first').text();
        var awayGoals = $(this).find('.team .result:last').text();
        var result = homeGoals != "" && awayGoals != "" ? homeGoals + "-" + awayGoals : "";

        if (homeGoals.legth > 0 && awayGoals.length > 0) {
            result = homeGoals + " - " + awayGoals;
        }
        //games.push(new Game(id, homeTeam, awayTeam, homeGoals, awayGoals));
        games.push(new Game(id, homeTeam, awayTeam, result));
    });


    //var jsonText = JSON.stringify(games, null, 2);
    //var jsonText = JSON.stringify(games);
    var jsonData = ko.toJSON(games);
    //alert(jsonData);

    //Sparar i databasen
    $.ajax("/European2012.ashx?action=saveFinals&document=" + documentId, {
        data: jsonData,
        type: "post",
        contentType: "application/json",
        //contentType: "application/json;charset=utf-8",
        success: function(result) { /*alert(result)*/ alert('Slutspelsträdet har sparats') },
        error: function(result) { /*alert(result)*/ alert('Mysslyckades med att spara') }
//        complete function(result) { /*alert(result)*/ }
        
    });
}

//function Game(id, homeTeam, awayTeam, homeGoals, awayGoals)
function Game(id, homeTeam, awayTeam, result) {
    this.Id = id;
    this.Name = "testinggggg";
    this.HomeTeam = homeTeam;
    this.AwayTeam = awayTeam;
    this.Result = result;
    //    this.HomeGoals = homeGoals;
    //    this.AwayGoals = awayGoals;
}


/////////////////////////
//function Team(data) {
//    var self = this;
//    self.name = ko.observable(data.name);
//    self.gamesplayed = ko.observable(data.gamesplayed);
//    self.gameswon = ko.observable(data.gameswon);
//    self.gamesdraw = ko.observable(data.gamesdraw);
//    self.gameslost = ko.observable(data.gameslost);
//    self.goalsmade = ko.observable(data.goalsmade);
//    self.goalsbackward = ko.observable(data.goalsbackward);
//    self.goaldifference = ko.observable(data.goaldifference);
//    self.points = ko.observable(data.points);
//}




//// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
//function TeamListViewModel() {
//    var self = this;
//    self.teams = ko.observableArray([]);

//    // Load initial state from server, convert it to Task instances, then populate self.tasks
//    $.getJSON("/European2012.ashx?action=getGroup&group=a", function(allData) {
//        var mappedTeams = $.map(allData, function(item) { return new Team(item) });
//        self.teams(mappedTeams);
//    });

//}

//// Activates knockout.js
//$(document).ready(function() {
//    ko.applyBindings(new TeamListViewModel());
//});

//Metod som returnerar värde tillhörande den querystring-parameter som skickats in
function getURLParameter(name) {
    return decodeURI(
        (RegExp(name + '=' + '(.+?)(&|$)').exec(location.search) || [, null])[1]
        );
}