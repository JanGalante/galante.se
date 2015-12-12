///<reference path="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" />
///<reference path="../jquery.js" />
/// <reference path="../knockout.js" />

$(document).ready(function() {
    //Gör det möjligt att editera resultat
    MakeEditable();

    //Bygger slutspelsträd
    BuildFinalsTree();

    //Ser till att det är möjligt att spara sitt slutspelsträd
    $('input:submit#finals').on('click', function(event) {
        SaveFinals();
        return false;
    });

    //Hämtar excel
    $('input:submit#getExcel').on('click', function(event) {
    //GetExcel();
        downloadUrl = "/Wc2010.ashx?action=getExcel";
        location = downloadUrl;
        return false;
    });
});


function MakeEditable()
{
//    $("div.game .result-hometeam").each(function (){
//		//alert($(this).text());
//		$("div.game .editable").editable("http://localhost/Wc2010.ashx?action=saveResult&group=A&hometeam=Sydafrika&awayteam=Mexiko&homegoal=2&awaygoal=0", { 
//			method : "PUT",
//			id   : 'homeGoal',
//			name : 'newvalue'
//		});
//    });
    
//    $("div.game .editable").editable("http://localhost/Wc2010.ashx?action=saveResult&group=A&hometeam=Sydafrika&awayteam=Mexiko&homegoal=2&awaygoal=0", { 
//		method : "PUT",
//		id   : 'homeGoal',
//        name : 'newvalue'
//	});


//$("div.game .editable").editable("http://localhost/Wc2010.ashx?action=saveResult&group=A&hometeam=Sydafrika&awayteam=Mexiko&homegoal=2&awaygoal=0", { 
//		method  : "PUT"
//	});

	$("div.game .editable").editable("http://localhost/Wc2010.ashx?action=saveResult&group=A&hometeam=Sydafrika&awayteam=Mexiko&homegoal=2&awaygoal=0", { 
		method		: "PUT",
		id			: "gameid",
		name		: "result",
		callback : function(value, settings) {
//         console.log(this);
//         console.log(value);
//         console.log(settings);
			
			var group = $(this).parent().parent().attr('rel');
			group = group.replace('Grupp-', '');
			//alert(group);
			
			//alert("dsfsdf");
			$.getJSON('http://localhost/Wc2010.ashx?action=getGroup&group=' + group, function(data){
				
//				$.each(data, function(key, val) {
//					items.push('<li id="' + key + '">' + val + '</li>');
//				});
				
//				$.each(data, function(key, val) {
//					response += ('<td>' + data.team + '</td>');
//				});
				
				var response = '<tr><td>&nbsp;</td><td>P</td><td>W</td><td>D</td><td>L</td><td>F</td><td>A</td><td>+-</td><td>P</td></tr>';
				for(i=0;i<data.length;i++){
					response += ('<tr class="' + (i+1) + '" class="game">');
					response += ('<td class="name">' + data[i].name + '</td>');
					response += ('<td>' + data[i].gamesplayed + '</td>');
					response += ('<td>' + data[i].gameswon + '</td>');
					response += ('<td>' + data[i].gamesdraw + '</td>');
					response += ('<td>' + data[i].gameslost + '</td>');
					response += ('<td>' + data[i].goalsmade + '</td>');
					response += ('<td>' + data[i].goalsbackward + '</td>');
					response += ('<td>' + data[i].goaldifference + '</td>');
					response += ('<td>' + data[i].points + '</td>');
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


function BuildFinalsTree()
{
//	alert('tree');
	//var team = $('#Grupp-A tr.1 .name').text();
	//$('.eightfinals #49.game .team .name').text('sfds');
	
	//1:an grupp A
	$('.eightfinals #49.game .team .name:first').text(
		$('#Grupp-A tr.1 .name').text());
	//2:an grupp B
	$('.eightfinals #49.game .team .name:last').text(
		$('#Grupp-B tr.2 .name').text());
		
	//1:an grupp C
	$('.eightfinals #50.game .team .name:first').text(
		$('#Grupp-C tr.1 .name').text());
	//2:an grupp D
	$('.eightfinals #50.game .team .name:last').text(
		$('#Grupp-D tr.2 .name').text());
		
	//1:an grupp D
	$('.eightfinals #51.game .team .name:first').text(
		$('#Grupp-D tr.1 .name').text());
	//2:an grupp C
	$('.eightfinals #51.game .team .name:last').text(
		$('#Grupp-C tr.2 .name').text());
		
	//1:an grupp B
	$('.eightfinals #52.game .team .name:first').text(
		$('#Grupp-B tr.1 .name').text());
	//2:an grupp A
	$('.eightfinals #52.game .team .name:last').text(
		$('#Grupp-A tr.2 .name').text());
		
	//1:an grupp E
	$('.eightfinals #53.game .team .name:first').text(
		$('#Grupp-E tr.1 .name').text());
	//2:an grupp F
	$('.eightfinals #53.game .team .name:last').text(
		$('#Grupp-F tr.2 .name').text());
		
	//1:an grupp G
	$('.eightfinals #54.game .team .name:first').text(
		$('#Grupp-G tr.1 .name').text());
	//2:an grupp H
	$('.eightfinals #54.game .team .name:last').text(
		$('#Grupp-H tr.2 .name').text());
		
	//1:an grupp F
	$('.eightfinals #55.game .team .name:first').text(
		$('#Grupp-F tr.1 .name').text());
	//2:an grupp E
	$('.eightfinals #55.game .team .name:last').text(
		$('#Grupp-E tr.2 .name').text());
	
	//1:an grupp H
	$('.eightfinals #56.game .team .name:first').text(
		$('#Grupp-H tr.1 .name').text());
	//2:an grupp G
	$('.eightfinals #56.game .team .name:last').text(
		$('#Grupp-G tr.2 .name').text());
	
	

	
	
	//Gör det möjligt att välja vilka lag som går till kvartsfinal
	$('.eightfinals #49.game .team .name').on('click', function(event) {
	    $('.quarterfinals #57.game .team .name:first').text($(this).text());

	    if ($('.eightfinals #49.game .team .name:first').text() == $(this).text())
	    {
	        $('.eightfinals #49.game .team .result:first').text('1');
	        $('.eightfinals #49.game .team .result:last').text('0');
	    }
	    else
	    {
	        $('.eightfinals #49.game .team .result:first').text('0');
	        $('.eightfinals #49.game .team .result:last').text('1');
	    }
	});
	$('.eightfinals #50.game .team .name').on('click', function(event){
		$('.quarterfinals #57.game .team .name:last').text( $(this).text() );
	});
	
	$('.eightfinals #51.game .team .name').on('click', function(event){
		$('.quarterfinals #58.game .team .name:first').text( $(this).text() );
	});
	$('.eightfinals #52.game .team .name').on('click', function(event){
		$('.quarterfinals #58.game .team .name:last').text( $(this).text() );
	});
	
	$('.eightfinals #53.game .team .name').on('click', function(event){
		$('.quarterfinals #59.game .team .name:first').text( $(this).text() );
	});
	$('.eightfinals #54.game .team .name').on('click', function(event){
		$('.quarterfinals #59.game .team .name:last').text( $(this).text() );
	});
	
	$('.eightfinals #55.game .team .name').on('click', function(event){
		$('.quarterfinals #60.game .team .name:first').text( $(this).text() );
	});
	$('.eightfinals #56.game .team .name').on('click', function(event){
		$('.quarterfinals #60.game .team .name:last').text( $(this).text() );
	});
	
	
	//Gör det möjligt att välja vilka lag som går till semifinal
	$('.quarterfinals #57.game .team .name').on('click', function(event){
		$('.semifinals #61.game .team .name:first').text( $(this).text() );
	});
	$('.quarterfinals #58.game .team .name').on('click', function(event){
		$('.semifinals #61.game .team .name:last').text( $(this).text() );
	});
	
	$('.quarterfinals #59.game .team .name').on('click', function(event){
		$('.semifinals #62.game .team .name:first').text( $(this).text() );
	});
	$('.quarterfinals #60.game .team .name').on('click', function(event){
		$('.semifinals #62.game .team .name:last').text( $(this).text() );
	});
	
	//Gör det möjligt att välja vilka lag som går till final
	$('.semifinals #61.game .team .name').on('click', function(event){
		$('.final #63.game .team .name:first').text( $(this).text() );
	});
	$('.semifinals #62.game .team .name').on('click', function(event){
		$('.final #63.game .team .name:last').text( $(this).text() );
	});
	
	
	//När användare byter lag som går vidare, måste koll göras att det 
	//bortbytta laget inte finns längre ner i slutspelsträdet
	$('.eightfinals .game .team .name').on('click', function(event){
		var proceedTeam = $(this).text(); //Laget som klickats är det som ska gå vidare
		var gameNode = $(this).parent().parent(); //Ställer oss på för själva matchen ('.game')
		var knockoutTeam = //Laget som inte klickats är det som åker ut
			proceedTeam != gameNode.find('.team .name:first').text() ?
			gameNode.find('.team .name:first').text() : 
			gameNode.find('.team .name:last').text();
		
		//Kontrollerar att det utslagna laget inte har valts 
		//vidare till semifinal eller final sedan tidigare
		$('.semifinals .game .team .name, .final .game .team .name').each(function(){
			if ($(this).text() == knockoutTeam)
			{
				$(this).text('');
			}
		});
	});
	
	//När användare byter lag som går vidare, måste koll göras att det 
	//bortbytta laget inte finns längre ner i slutspelsträdet
	$('.quarterfinals .game .team .name').on('click', function(event){
		var proceedTeam = $(this).text(); //Laget som klickats är det som ska gå vidare
		var gameNode = $(this).parent().parent(); //Ställer oss på för själva matchen ('.game')
		var knockoutTeam = //Laget som inte klickats är det som åker ut
			proceedTeam != gameNode.find('.team .name:first').text() ?
			gameNode.find('.team .name:first').text() : 
			gameNode.find('.team .name:last').text();
		
		//Kontrollerar att det utslagna laget inte har valts 
		//vidare till semifinal eller final sedan tidigare
		$('.final .game .team .name').each(function(){
			if ($(this).text() == knockoutTeam)
			{
				$(this).text('');
			}
		});
	});
}


function SaveFinals()
{
	//Loopar igenom alla matchet i slutspelsträdet och lägger i en array
	var games = new Array();
	//$('.eightfinals .game, .quarterfinals .game, .semifinals .game, .final .game').each(function(){
	$('.eightfinals .game, .quarterfinals .game, .semifinals .game, .final .game').each(function() {
	    var id = $(this).attr('id');
	    var homeTeam = $(this).find('.team .name:first').text();
	    var awayTeam = $(this).find('.team .name:last').text();
	    var homeGoals = $(this).find('.team .result:first').text();
	    var awayGoals = $(this).find('.team .result:last').text();
	    var result = "";

	    if (homeGoals.legth > 0 && awayGoals.length > 0) {
	        result = homeGoals + " - " + awayGoals;
	    }
	    //games.push(new Game(id, homeTeam, awayTeam, homeGoals, awayGoals));
	    games.push(new Game(id, homeTeam, awayTeam, result));
	});
	
	
	//var jsonText = JSON.stringify(games, null, 2);
	//var jsonText = JSON.stringify(games);
	var jsonData = ko.toJSON(games);
	alert(jsonData);
	
	//Sparar i databasen
	$.ajax("/Wc2010.ashx?action=saveFinals", {
        data: jsonData,
        type: "post", 
        contentType: "application/json",
        //contentType: "application/json;charset=utf-8",
        success: function(result) { alert(result) }
    });
}

//function GetExcel() {
//    location = downloadUrl
//}



//function Game(id, homeTeam, awayTeam, homeGoals, awayGoals)
function Game(id, homeTeam, awayTeam, result)
{
    this.Id = id;
    this.Name = "testinggggg";
    this.HomeTeam = homeTeam;
    this.AwayTeam = awayTeam;
    this.Result = result;
//    this.HomeGoals = homeGoals;
//    this.AwayGoals = awayGoals;
}


/////////////////////////
function Team(data) {
//function Team(name, gamesplayed, gameswon, gamesdraw, gameslost, goalsmade, goalsbackward, goaldifference, points) {
    var self = this;
    self.name = ko.observable(data.name);
    self.gamesplayed = ko.observable(data.gamesplayed);
    self.gameswon = ko.observable(data.gameswon);
    self.gamesdraw = ko.observable(data.gamesdraw);
    self.gameslost = ko.observable(data.gameslost);
    self.goalsmade = ko.observable(data.goalsmade);
    self.goalsbackward = ko.observable(data.goalsbackward);
    self.goaldifference = ko.observable(data.goaldifference);
    self.points = ko.observable(data.points);
	
//	var self = this;
//    self.name = name;
//    self.gamesplayed = gamesplayed;
//    self.gameswon = gameswon;
//    self.gamesdraw = gamesdraw;
//    self.gameslost = gameslost;
//    self.goalsmade = goalsmade;
//    self.goalsbackward = goalsbackward;
//    self.goaldifference = goaldifference;
//    self.points = points;
}




// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
function TeamListViewModel() {
    var self = this;
    self.teams = ko.observableArray([]);
    
     // Load initial state from server, convert it to Task instances, then populate self.tasks
    $.getJSON("/Wc2010.ashx?action=getGroup&group=a", function(allData) {
        var mappedTeams = $.map(allData, function(item) { return new Team(item) });
        self.teams(mappedTeams);
    });
    
    // Operations
//    self.Update = function() {
//         // Load initial state from server, convert it to Task instances, then populate self.tasks
//		$.getJSON("/Wc2010.ashx?action=getGroup&group=a", function(allData) {
//			var mappedTeams = $.map(allData, function(item) { return new Team(item) });
//			self.teams(mappedTeams);
//		});
//    }

}

// Activates knockout.js
$(document).ready(function(){
	ko.applyBindings(new TeamListViewModel());
});
