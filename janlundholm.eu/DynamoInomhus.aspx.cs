using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BusinessLayer;
using BusinessLayer.Enumerators;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

public partial class DynamoInomhus : PageBase
{
    TeamCollection _teams = null;
    UrlBuilder _url = null;
    TeamCollection.SortBy _sortBy = TeamCollection.SortBy.NotDefined;

    /// <summary>
    /// Aktuell sortering.
    /// </summary>
    public TeamCollection.SortBy SortBy
    {
        get 
        {
            //Lazy loading
            if (_sortBy == TeamCollection.SortBy.NotDefined)
            {
                //Hämtar värdet i __EVENTTARGET. Där ligger värdet på kontrollen som
                //utförde PostBack. Obs, om det är en vanlig submit hittas värdet inte här.
                string[] temp = Page.Request.Params.Get("__EVENTTARGET") != null ?
                    Page.Request.Params.Get("__EVENTTARGET").Split('$') : null; //Ex. ctl00$Content$rptTeamsDiv6$ctl00$lbtnName
                if (IsPostBack == true && temp != null)
                {
                    //Hämtar id på kontroller som utförde postback:en och utför önskad sortering
                    string ctrlName = temp[temp.Length - 1]; //hämtar sista posten
                    switch (ctrlName)
                    {
                        case "lbtnName":
                            _sortBy = TeamCollection.SortBy.Name;
                            break;
                        case "lbtnGamesPlayed":
                            _sortBy = TeamCollection.SortBy.GamesPlayed;
                            break;
                        case "lbtnGamesWon":
                            _sortBy = TeamCollection.SortBy.GamesWon;
                            break;
                        case "lbtnGamesDraw":
                            _sortBy = TeamCollection.SortBy.GamesDraw;
                            break;
                        case "lbtnGamesLost":
                            _sortBy = TeamCollection.SortBy.GamesLost;
                            break;
                        case "lbtnGoalsMade":
                            _sortBy = TeamCollection.SortBy.GoalsMade;
                            break;
                        case "lbtnGoalsBackward":
                            _sortBy = TeamCollection.SortBy.GoalsBackward;
                            break;
                        case "lbtnGoalDifference":
                            _sortBy = TeamCollection.SortBy.GoalDifference;
                            break;
                        case "lbtnPoints":
                            _sortBy = TeamCollection.SortBy.Points;
                            break;
                        default:
                            _sortBy = TeamCollection.SortBy.Points;
                            break;
                    }
                }
                else
                {
                    _sortBy = TeamCollection.SortBy.Points;
                }
            }
            return _sortBy; 
        }
    }

    /// <summary>
    /// Kollektion med lag
    /// </summary>
    private TeamCollection Teams
    {
        get 
        {
            //Lazy loading
            if (_teams == null)
            {
                GameCollection games = new GameCollection(EnumConstants.GameType.League);
                TeamCollection teams = new TeamCollection(games);
                _teams = teams;
            }
            return _teams;
        }
    }

    /// <summary>
    /// Url för aktuell request
    /// </summary>
    public UrlBuilder Url
    {
        get 
        {
            //Lazy loading
            if (_url == null)
            {
                _url = new UrlBuilder(Request.Url.AbsoluteUri);
            }
            return _url; 
        }
    }

    /// <summary>
    /// Aktuell omgång
    /// </summary>
    public int? CurrentRound
    {
        get
        {
            //string[] temp = Page.Request.Params.Get("__EVENTTARGET") != null ?
            //    Page.Request.Params.Get("__EVENTTARGET").Split('$') : null; //Ex. //ctl00$Content$rptRounds$ctl02$rptRound
            //if (IsPostBack == true && temp[temp.Length - 1] == "rptRound")
            //{
            //    string ctrlReapeterItemNr = temp[temp.Length - 2]; //hämtar näst sista posten
            //    int round = int.Parse(ctrlReapeterItemNr.Replace("ctl", ""));

            //    return round == 0 ? round + 1 : round / 2 + 1;
            //}            
            //return Teams.Round;

            int tempVal;
            return int.TryParse(Url.QueryString["round"], out tempVal) ? 
                (int?)tempVal : null;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Dynamo Filmhuser 2008/2009";
                
        //Skapar repeter med spelade omgångar
        this.BuildRoundRepeater();
        
        //Filtrerar this.Teams utifrån vilken omgång som är aktuell
        this.FilterTeamCollection();
        //Sorterar this.Team efter önskad sortering.
        this.Teams.PerformSort(this.SortBy);
        //this.Teams.PerformSort(TeamCollection.SortBy.Points);
        //Skapar repeater för serietabell.
        this.BuildlSerieTabel();


        //// Check to see if the client script is already registered.
        //ClientScriptManager cs = Page.ClientScript;
        //if (!cs.IsClientScriptIncludeRegistered(this.GetType(), "jquery.jl.em.js"))
        //{
        //    cs.RegisterClientScriptInclude(this.GetType(), "jquery.jl.em.js", "/JavaScript/jquery.jl.em.js");
        //}

        //Skapar diagram
        DataTable dt = this.CreateDiagramDataTable();

        Teams.Sort(Team.NameComparison);

        ////Omgång 1
        //Teams.SetGamesFilter(DateTime.Parse("2008-11-16"));
        //dt = this.AddDiagramTableDataRow(dt, Teams);
        ////Omgång 2
        //Teams.SetGamesFilter(DateTime.Parse("2008-11-23"));
        //dt = this.AddDiagramTableDataRow(dt, Teams);
        ////Omgång 3
        //Teams.SetGamesFilter(DateTime.Parse("2008-11-30"));
        //dt = this.AddDiagramTableDataRow(dt, Teams);
        ////Omgång 4
        //Teams.SetGamesFilter(DateTime.Parse("2008-12-07"));
        //dt = this.AddDiagramTableDataRow(dt, Teams);
        ////Omgång 5
        //Teams.SetGamesFilter(DateTime.Parse("2008-12-14"));
        //dt = this.AddDiagramTableDataRow(dt, Teams);
        //Omgång 1
        Teams.SetGamesFilter(DateTime.Parse("2009-11-22"));
        dt = this.AddDiagramTableDataRow(dt, Teams);
        //Omgång 2
        Teams.SetGamesFilter(DateTime.Parse("2009-11-29"));
        dt = this.AddDiagramTableDataRow(dt, Teams);
        //Omgång 3
        Teams.SetGamesFilter(DateTime.Parse("2009-12-06"));
        dt = this.AddDiagramTableDataRow(dt, Teams);
        //Omgång 4
        Teams.SetGamesFilter(DateTime.Parse("2009-12-13"));
        dt = this.AddDiagramTableDataRow(dt, Teams);
        //Omgång 5
        Teams.SetGamesFilter(DateTime.Parse("2009-12-20"));
        dt = this.AddDiagramTableDataRow(dt, Teams);



        this.CreateDiagram(dt);
    }


    private DataTable CreateDiagramDataTable()
    {
        //DataTable dt = new DataTable("Diagram");
        //dt.Columns.Add("Abelmans Specerier", typeof(String));
        //dt.Columns.Add("Barnes Utd", typeof(String));
        //dt.Columns.Add("Busslink Söderort", typeof(String));
        //dt.Columns.Add("Dinamo Södermalm", typeof(String));
        //dt.Columns.Add("Dynamo Filmhuset", typeof(String));
        //dt.Columns.Add("Hustomtar IF", typeof(String));
        //dt.Columns.Add("MSK C", typeof(String));
        //dt.Columns.Add("Sporting Söder", typeof(String));
        //return dt;

        this.Teams.Sort(Team.NameComparison);
        DataTable dt = new DataTable("Diagram");
        foreach (Team t in this.Teams)
        {
            dt.Columns.Add(t.Name, typeof(String));
        }
        return dt;
    }

    private DataTable AddDiagramTableDataRow(DataTable dt, TeamCollection teams)
    {
        //DataRow row = dt.NewRow();
        //row["Abelmans Specerier"] = teams.Find("Abelmans Specerier").Points;
        //row["Barnes Utd"] = teams.Find("Barnes Utd").Points;
        //row["Busslink Söderort"] = teams.Find("Busslink Söderort").Points;
        //row["Dinamo Södermalm"] = teams.Find("Dinamo Södermalm").Points;
        //row["Dynamo Filmhuset"] = teams.Find("Dynamo Filmhuset").Points;
        //row["Hustomtar IF"] = teams.Find("Hustomtar IF").Points;
        //row["MSK C"] = teams.Find("MSK C").Points;
        //row["Sporting Söder"] = teams.Find("Sporting Söder").Points;
        //dt.Rows.Add(row);
        //return dt;

        DataRow row = dt.NewRow();
        foreach (Team t in this.Teams)
        {
            switch (this.SortBy)
            {
                case TeamCollection.SortBy.GamesPlayed:
                    row[t.Name] = t.GamesPlayed;
                    break;
                case TeamCollection.SortBy.GamesWon:
                    row[t.Name] = t.GamesWon;
                    break;
                case TeamCollection.SortBy.GamesDraw:
                    row[t.Name] = t.GamesDraw;
                    break;
                case TeamCollection.SortBy.GamesLost:
                    row[t.Name] = t.GamesLost;
                    break;
                case TeamCollection.SortBy.GoalsMade:
                    row[t.Name] = t.GoalsMade;
                    break;
                case TeamCollection.SortBy.GoalsBackward:
                    row[t.Name] = t.GoalsBackward;
                    break;
                case TeamCollection.SortBy.GoalDifference:
                    row[t.Name] = t.GoalDifference;
                    break;
                case TeamCollection.SortBy.Points:
                case TeamCollection.SortBy.Name:
                case TeamCollection.SortBy.NotDefined:
                default:
                    row[t.Name] = t.Points;
                    break;
            }
        }

        dt.Rows.Add(row);
        return dt;
    }

    private void CreateDiagram(DataTable table)
    {
        List<StringCollection> diagramData = new List<StringCollection>();
        StringCollection lineData;// = new StringCollection();
        int rowNum;
        
        foreach (DataColumn column in table.Columns)
        {
            
            lineData = new StringCollection();
            rowNum = 0;
            foreach (DataRow row in table.Rows)
            {
                rowNum++;
                lineData.Add(string.Format("[{0},{1}]", rowNum, row[column]));
            }
            //Lägger till lineData
            diagramData.Add(lineData);
        }


        StringBuilder sb = new StringBuilder();
        foreach (DataColumn column in table.Columns)
        {

            //lineData = new StringCollection();
            sb.Append(string.Format("{{label: '{0}', data: [", column.Caption));
            rowNum = 0;
            foreach (DataRow row in table.Rows)
            {
                rowNum++;
                //lineData.Add(string.Format("[{0},{1}]", rowNum, row[column]));
                //Lägger till en punkt i linjen
                sb.Append(string.Format("[{0},{1}]", rowNum, row[column]));
            }
            //Lägger till lineData
            //diagramData.Add(lineData);
            sb.Append("]},");
        }
        //Tar bort sista kommatecknet
        sb.Remove(sb.Length - 1, 1);
        //Response.Write(sb.ToString());

        //string plot = string.Format("$(document).ready(function(){{ " +
        //   "alert('dsf');" + 
        //    "$.plot($('#emChart'), " +
        //        "[" +
        //            "{{ label: 'Daniel', data: [[0,0], [1,6], [2,12]] }}, " +
        //            "{{ label: 'Gustav', data: [[0,0], [1,3], [2,13]] }}, " +
        //        "], " +
        //        "{{ " +
        //            "grid: {{ color: '#D3D3D3', borderWidth: 0.5, tickColor: '#111111', hoverable: true }}, " +
        //            "legend: {{ position: 'nw' }} " +
        //        "}}" +
        //    ");" +
        //"}});");

        // Check to see if the client script is already registered.
        ClientScriptManager cs = Page.ClientScript;
        if (!cs.IsClientScriptIncludeRegistered(this.GetType(), "indoorDiagram2008.js"))
        //if (!cs.IsClientScriptBlockRegistered(this.GetType(), "indoorDiagram2008.js"))
        {
            cs.RegisterClientScriptInclude(this.GetType(), "indoorDiagram2008.js", "JavaScript/jquery.jl.em.js");
            //cs.RegisterClientScriptBlock(this.GetType(), "indoorDiagram2008.js", plot, true);
        }

        //string plot = string.Format("$(document).ready(function(){{ " +
        //   "alert('dsf');" +
        //"}});");

        //this.AddHeaderJavascriptMethod("CreateIndoorChart(" +
        //    "'[[0,0], [1,6], [2,12], [3,14], [4,19], [5,21], [6,23], [7,27], [8,33], [9,34], [10,37], [11,42], [12,43], [13,46], [14,48], [15,53], [16,56], [17,64], [18,64], [19,64], [20,64], [21,80], [22,80], [23,80]]', " +
        //    "'[[0,0], [1,3], [2,10], [3,11], [4,18], [5,21], [6,22], [7,23], [8,28], [9,28], [10,30], [11,34], [12,37], [13,38], [14,39], [15,42], [16,45], [17,53], [18,53], [19,53], [20,61], [21,77], [22,93], [23,125]]'" +
        //");");

        List<string[]> stringList = new List<string[]>();
        string[] temp;
        foreach (StringCollection sc in diagramData)
        {
            //Lägger till på nästa lediga post i listan
            //sc.CopyTo(stringList[stringList.Count], 0);
            temp = new string[sc.Count];
            sc.CopyTo(temp, 0);
            stringList.Add(temp);
        }

        //string[] tempArray = new string[diagramData[0].Count];
        //diagramData[0].CopyTo(tempArray, 0);
        //Response.Write(string.Format("[{0}]", string.Join(",", tempArray)));

        //litScript.Text = "<script type='text/javascript' language='javascript'>" +
        //"CreateIndoorChart(" +
        //    //"[[0,0], [1,6], [2,12], [3,14], [4,19], [5,21], [6,23], [7,27], [8,33], [9,34], [10,37], [11,42], [12,43], [13,46], [14,48], [15,53], [16,56], [17,64], [18,64], [19,64], [20,64], [21,80], [22,80], [23,80]], " +
        //    //"[[0,0], [1,3], [2,10], [3,11], [4,18], [5,21], [6,22], [7,23], [8,28], [9,28], [10,30], [11,34], [12,37], [13,38], [14,39], [15,42], [16,45], [17,53], [18,53], [19,53], [20,61], [21,77], [22,93], [23,125]]" +
        //    string.Format("[{0}]", string.Join(", ", stringList[0])) + "," +
        //    string.Format("[{0}]", string.Join(", ", stringList[1])) + "," +
        //    string.Format("[{0}]", string.Join(", ", stringList[2])) + "," +
        //    string.Format("[{0}]", string.Join(", ", stringList[3])) + "," +
        //    string.Format("[{0}]", string.Join(", ", stringList[4])) + "," +
        //    string.Format("[{0}]", string.Join(", ", stringList[5])) + "," +
        //    string.Format("[{0}]", string.Join(", ", stringList[6])) + "," +
        //    string.Format("[{0}]", string.Join(", ", stringList[7])) +
        //");" +
        //"</script>";


        litScript.Text = "<script type='text/javascript' language='javascript'>" +
        "CreateIndoorChart(";

        foreach (string[] stringArray in stringList)
        {
            litScript.Text += string.Format("[{0}]", string.Join(", ", stringArray)) + ",";
        }
        litScript.Text.TrimEnd(',');

        litScript.Text += ");" +
        "</script>";


        //$.plot($("#emChart"), [
        //        {label: "Daniel", data: dDaniel}, 
        //        {label: "Denise", data: dDenise, lines:{lineWidth: 4}}, 
        //        {label: "Gustav", data: dGustav}, 
        //        {label: "Janne", data: dJanne, lines:{fill: false, show: false}, bars: {show: false} }, //color: "rgb(255, 255, 203)"
        //        {label: "Rickard", data: dRickard, lines:{fill: false}}
        //    ],
        //    {grid: {color: "#D3D3D3", borderWidth: 0.5, tickColor: "#111111", hoverable: true},
        //     legend: {position: "nw"}
        //    }
        //);
    }


    /// <summary>
    /// Skapar repeater för spelade omgångar.
    /// </summary>
    private void BuildRoundRepeater()
    {
        //Skapar generisk lista för de omgångar som spelats
        List<int> intList = new List<int>();
        for (int i = 1; i <= Teams.Round; i++)
        {
            intList.Add(i);
        }
        
        rptRounds.DataSource = intList;
        rptRounds.DataBind();
    }

    /// <summary>
    /// Filtrerar this.Teams utifrån vilken omgång som är aktuell.
    /// </summary>
    private void FilterTeamCollection()
    {
        //Kontrollerar CurrentRound inte är null
        if (this.CurrentRound == null)
        {
            return;
        }

        //Filtrerar på datum utifrån aktuell omgång
        //switch (this.CurrentRound.Value)
        //{
        //    case 1:
        //        Teams.SetGamesFilter(DateTime.Parse("2008-11-16"));
        //        break;
        //    case 2:
        //        Teams.SetGamesFilter(DateTime.Parse("2008-11-23"));
        //        break;
        //    case 3:
        //        Teams.SetGamesFilter(DateTime.Parse("2008-11-30"));
        //        break;
        //    case 4:
        //        Teams.SetGamesFilter(DateTime.Parse("2008-12-07"));
        //        break;
        //    case 5:
        //        Teams.SetGamesFilter(DateTime.Parse("2008-12-14"));
        //        break;
        //    default:
        //        break;
        //}

        switch (this.CurrentRound.Value)
        {
            case 1:
                Teams.SetGamesFilter(DateTime.Parse("2009-11-22"));
                break;
            case 2:
                Teams.SetGamesFilter(DateTime.Parse("2009-11-29"));
                break;
            case 3:
                Teams.SetGamesFilter(DateTime.Parse("2009-12-06"));
                break;
            case 4:
                Teams.SetGamesFilter(DateTime.Parse("2009-12-13"));
                break;
            case 5:
                Teams.SetGamesFilter(DateTime.Parse("2009-12-20"));
                break;
            case 6:
                Teams.SetGamesFilter(DateTime.Parse("2010-01-17"));
                break;
            case 7:
                Teams.SetGamesFilter(DateTime.Parse("2010-01-24"));
                break;
            case 8:
                Teams.SetGamesFilter(DateTime.Parse("2010-01-31"));
                break;
            case 9:
                Teams.SetGamesFilter(DateTime.Parse("2010-02-07"));
                break;
            case 10:
                Teams.SetGamesFilter(DateTime.Parse("2010-02-14"));
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Skapar repeater för serietabell.
    /// </summary>
    private void BuildlSerieTabel()
    {
        rptTeamsDiv6.DataSource = Teams;
        rptTeamsDiv6.DataBind();
    }
    

    /// <summary>
    /// Skapar länk för spelad omgång.
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public string GetRoundLink(int i)
    {
        UrlBuilder linkUrl = new UrlBuilder(Url.Uri);
        linkUrl.QueryString["round"] = i.ToString();
        return linkUrl.ToString();
    }
}
