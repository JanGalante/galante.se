
$(document).ready(function(){
    SetupEditThickbox();
});

function SetupEditThickbox()
{
    //Kontrollerar om elementet finns
    if($("#ctl00_Content_DetailsView1 tr").length < 1)
    {
        return; //Går ur funktionen
    }
    
    //Skapar och lägger till länk, med clas=thickbox samt korrekt href-attribut
    var anchorElem = $("<a id='PlayerEditThickbox' class='thickbox editThickbox' href='#TB_inline?height=155&width=300&inlineId=ctl00_Content_DetailsView1&modal=false'>klick</a>");
    //anchorElem.click(alert("klickkk"));
    anchorElem.click(function()
        {
            $("#ctl00_Content_DetailsView1").css("display", "inline");
        });
    $("body").prepend(anchorElem);
    
    alert("SetupEditThickbox");
}