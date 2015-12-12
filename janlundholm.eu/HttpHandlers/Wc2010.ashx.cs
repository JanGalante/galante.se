using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml;
using BusinessLayer;
using System.Text;
using System.IO;
using BusinessLayer.Extensions.TypeExtension;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
using ExcelLibrary.SpreadSheet;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using BusinessLayer.ExcelMapper;

namespace janlundholm.eu.HttpHandlers
{
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class Wc2010 : IHttpHandler
	{
		private HttpContext Context { set; get; }

		public void ProcessRequest(HttpContext context)
		{
			//context.Response.ContentType = "text/plain";
			//context.Response.Write("Hello World");

			this.Context = context;

			//this.Context.Response.Write("jaaaaaaaa");
			//this.Context.Response.End();

			switch (this.Context.Request["action"])
			{
				case "saveResult":
					this.SaveResult();
					break;
				case "getGroup":
					this.GetGroup();
					break;
				case "saveFinals":
					this.SaveFinals();
					break;
				case "getExcel":
					this.GetExcel("userName");
					break;
				default:
					break;
			}
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// Sparar enskilda resultat i gruppspelet
		/// </summary>
		public void SaveResult()
		{
			////http://localhost/Wc2010.ashx?action=saveResult&group=A&hometeam=Sydafrika&awayteam=Mexiko&homegoal=5&awaygoal=4
			//string group = this.Context.Request["group"];
			//string homeTeam = this.Context.Request["hometeam"];
			//string awayTeam = this.Context.Request["awayteam"];

			//int homeGoal = int.Parse(this.Context.Request["homegoal"]);
			//int awayGoal = int.Parse(this.Context.Request["awaygoal"]);

			//XmlDocument doc = new XmlDocument();
			//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));
			
			//doc.SelectSingleNode("/tournement/group[@name='" + group + "']/game[@homeTeam='" + homeTeam + "'][@awayTeam='" + awayTeam + "']/result").Attributes["fulltime"]
			//    .InnerText = string.Format("{0}-{1}", homeGoal.ToString(), awayGoal.ToString());


			string id = this.Context.Request["gameid"];
			string result = this.Context.Request["result"];
			string[] results = result.Trim().Split(new char[]{'-'});
			int homeGoal;
			int awayGoal; 

			//Kontrollerar att två resultat angivits och att båda dessa är numeriska
			if (results == null || results.Length != 2 || !int.TryParse(results[0], out homeGoal) || !int.TryParse(results[1], out awayGoal))
			{
				//Om inte avsluta
				return;
			}

			XmlDocument doc = new XmlDocument();
			doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));

			doc.SelectSingleNode("//game[@id='" + id + "']/result").Attributes["fulltime"]
				.InnerText = string.Format("{0}-{1}", homeGoal.ToString(), awayGoal.ToString());




			//Hämtar upp resultat från XML
			//wcResultFullTime.Parse(doc.SelectSingleNode("/tournement/group[@name='" + group + "']/game[@homeTeam='" + homeTeam + "'][@awayTeam='" + 
			//    awayTeam + "']/result").Attributes["fulltime"].InnerText);
			//string[] xmlResult = doc.SelectSingleNode("/tournement/group[@name='" + group + "']/game[@homeTeam='" + homeTeam + "'][@awayTeam='" +
			//    awayTeam + "']/result").Attributes["fulltime"].InnerText.Split('-');
			//xmlResult[0];

			


			//XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));
			//var games = from game in doc.Descendants("group")
			//            where game.Attribute("homeTeam") == homeTeam //|| game.Attribute("homeTeam") == null
			//            select new
			//            {
			//                homeTeam = game.Attribute("homeTeam"),
			//                homegoals = game.Element("homeTeam").Attribute("fulltime")

			//            };

			//if (int.TryParse(this.Context.Request["homegoal"], out homeGoal))
			//{
			//    // Create an element with no content
			//    XElement root = new XElement("Root");

			//    // Add some name/value pairs.
			//    root.SetElementValue("Ele1", 1);
			//}




			//Sparar Xml
			doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));

			string response = string.Format("{0} - {1}", homeGoal.ToString(), awayGoal.ToString());
			this.Context.Response.Write(response);
			this.Context.Response.End();
		}

		public void GetGroup()
		{
			string group = this.Context.Request["group"].ToUpper();
			StringBuilder sb = new StringBuilder();


			XmlDocument doc = new XmlDocument();
			doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));

			wcGameCollection games = wcGameReposetory.wcGetGameCollection(null, doc, "/tournement/group[@name='" + group + "']/game");

			//sb.AppendFormat("{");
			sb.Append("[");


			foreach (wcTeam team in games.Teams)
			{
				sb.Append("{");
				sb.AppendFormat("{0}name{0}: {0}{1}{0},", "\"", team.Name);
				sb.AppendFormat("{0}gamesplayed{0}: {0}{1}{0},", "\"", team.GamesPlayed);
				sb.AppendFormat("{0}gameswon{0}: {0}{1}{0},", "\"", team.GamesWon.ToString());
				sb.AppendFormat("{0}gamesdraw{0}: {0}{1}{0},", "\"", team.GamesDraw.ToString());
				sb.AppendFormat("{0}gameslost{0}: {0}{1}{0},", "\"", team.GamesLost.ToString());
				sb.AppendFormat("{0}goalsmade{0}: {0}{1}{0},", "\"", team.GoalsMade.ToString());
				sb.AppendFormat("{0}goalsbackward{0}: {0}{1}{0},", "\"", team.GoalsBackward.ToString());
				sb.AppendFormat("{0}goaldifference{0}: {0}{1}{0},", "\"", team.GoalDifference.ToString());
				sb.AppendFormat("{0}points{0}: {0}{1}{0}", "\"", team.Points.ToString());
				sb.Append("},");
			}
			sb.Replace(",", string.Empty, sb.Length - 1, 1);

			sb.Append("]");


			this.Context.Response.Write(sb.ToString());
			this.Context.Response.End();
		}

		public void SaveFinals()
		{
			//GoogleSearchResults g1 = new GoogleSearchResults();
			//const string json = @"{""responseData"": {""results"":[{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.cheese.com/"",""url"":""http://www.cheese.com/"",""visibleUrl"":""www.cheese.com"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:bkg1gwNt8u4J:www.cheese.com"",""title"":""\u003cb\u003eCHEESE\u003c/b\u003e.COM - All about \u003cb\u003echeese\u003c/b\u003e!."",""titleNoFormatting"":""CHEESE.COM - All about cheese!."",""content"":""\u003cb\u003eCheese\u003c/b\u003e - everything you want to know about it. Search \u003cb\u003echeese\u003c/b\u003e by name, by types   of milk, by textures and by countries.""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://en.wikipedia.org/wiki/Cheese"",""url"":""http://en.wikipedia.org/wiki/Cheese"",""visibleUrl"":""en.wikipedia.org"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:n9icdgMlCXIJ:en.wikipedia.org"",""title"":""\u003cb\u003eCheese\u003c/b\u003e - Wikipedia, the free encyclopedia"",""titleNoFormatting"":""Cheese - Wikipedia, the free encyclopedia"",""content"":""\u003cb\u003eCheese\u003c/b\u003e is a food consisting of proteins and fat from milk, usually the milk of   cows, buffalo, goats, or sheep. It is produced by coagulation of the milk \u003cb\u003e...\u003c/b\u003e""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.ilovecheese.com/"",""url"":""http://www.ilovecheese.com/"",""visibleUrl"":""www.ilovecheese.com"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:GBhRR8ytMhQJ:www.ilovecheese.com"",""title"":""I Love \u003cb\u003eCheese\u003c/b\u003e!, Homepage"",""titleNoFormatting"":""I Love Cheese!, Homepage"",""content"":""The American Dairy Association\u0026#39;s official site includes recipes and information   on nutrition and storage of \u003cb\u003echeese\u003c/b\u003e.""},{""GsearchResultClass"":""GwebSearch"",""unescapedUrl"":""http://www.gnome.org/projects/cheese/"",""url"":""http://www.gnome.org/projects/cheese/"",""visibleUrl"":""www.gnome.org"",""cacheUrl"":""http://www.google.com/search?q\u003dcache:jvfWnVcSFeQJ:www.gnome.org"",""title"":""\u003cb\u003eCheese\u003c/b\u003e"",""titleNoFormatting"":""Cheese"",""content"":""\u003cb\u003eCheese\u003c/b\u003e uses your webcam to take photos and videos, applies fancy special effects   and lets you share the fun with others. It was written as part of Google\u0026#39;s \u003cb\u003e...\u003c/b\u003e""}],""cursor"":{""pages"":[{""start"":""0"",""label"":1},{""start"":""4"",""label"":2},{""start"":""8"",""label"":3},{""start"":""12"",""label"":4},{""start"":""16"",""label"":5},{""start"":""20"",""label"":6},{""start"":""24"",""label"":7},{""start"":""28"",""label"":8}],""estimatedResultCount"":""14400000"",""currentPageIndex"":0,""moreResultsUrl"":""http://www.google.com/search?oe\u003dutf8\u0026ie\u003dutf8\u0026source\u003duds\u0026start\u003d0\u0026hl\u003den-GB\u0026q\u003dcheese""}}, ""responseDetails"": null, ""responseStatus"": 200}";
			//g1 = JsonManager.Deserialise<GoogleSearchResults>(json);
			//Response.Write(g1.content);

			//Om att serialiera med kontrakt
			//http://msdn.microsoft.com/en-us/library/system.runtime.serialization.datamemberattribute.aspx

			//Om att skapa json utifrån egen klass
			//http://codereview.stackexchange.com/questions/3208/basic-simple-asp-net-jquery-json-example

			//Om .net datacontrat och serialisering av JSON
			//http://www.codeproject.com/Articles/37069/JSON-serialization-and-de-serialization-in-WCF-Dat

			//Deserialisera med anonyma klasser
			//http://blogs.msdn.com/b/alexghi/archive/2008/12/22/using-anonymous-types-to-deserialize-json-data.aspx
			//Ännu bättre
			//http://www.west-wind.com/weblog/posts/2007/Nov/15/Anonymous-Types-in-C-30

			//Skapar klass utifrån json
			//http://json2csharp.com/

			//Linq support for json
			//http://stackoverflow.com/questions/5017658/linq-to-json-for-c-sharp-net

			wcGameCollection games = new wcGameCollection();
			//Läser in json från Request.InputStream
			StreamReader sr = new StreamReader(this.Context.Request.InputStream);
			string json = sr.ReadToEnd();

			//games = JsonManager.Deserialise<wcGameCollection>(json);

			var helloResponse = new {
				Id = 1, 
				Name = string.Empty, 
				HomeTeam = string.Empty, 
				AwayTeam = string.Empty 
			};

			//var helloGames = JsonManager.Deserialise<helloResponse.GetType().ToType(helloResponse.GetType())>(json);
			//Type t = helloResponse.GetType();
			//var helloGames = JsonManager.Deserialise <t>(json);



			//T obj = Activator.CreateInstance<T>();
			//using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			//{
			//    DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
			//    obj = (T)serializer.ReadObject(ms);
			//    //return obj;
			//}



			//using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			//{
			//    //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
			//    //Person p2 = (Person)ser.ReadObject(stream1);
			//    Type t = helloResponse.GetType();
			//    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(helloResponse));
			//    helloResponse = (helloResponse.GetType().ToType(helloResponse.GetType()))ser.ReadObject(ms);
			//}



			//Bra exempel 
			//http://james.newtonking.com/projects/json/help/LINQtoJSON.html
			
			
			//JObject o = JObject.Parse(json);
			//string name = (string)jGames[0]["Name"];
			//string homeTeam = (string)jGames[0]["HomeTeam"];


			//string name = (string)o["Name"];
			//string homeTeam = (string)o["HomeTeam"];
			//string smallest = (string)sizes[0];

			
			//
			JObject o = JObject.Parse("{\"root\": " + json + "}");
			JArray jGames = (JArray)o["root"]; //Vi har skickat in en array

			int dummy;
			//foreach (JToken jGame in jGames)
			foreach (JToken token in jGames.Children())
			{
				wcGame game = new wcGame();
				if (int.TryParse((string)token["Id"], out dummy))
				{
					 game.Id = int.Parse((string)token["Id"]);
				}

				game.HomeTeam = new wcTeam((string)token["HomeTeam"]);
				game.AwayTeam = new wcTeam((string)token["AwayTeam"]);

				//game.WinningTeam = new wcTeam((string)token["WinningTeam"]);

				//Här måste man kolla om token["Results"] innehåller något
				//så att inte fel kastas
				//if (token["Result"] != null)
				if (!string.IsNullOrEmpty((string)token["Result"]))
				{
					game.Results = new List<wcResult>();
					game.Results.Add(new wcResultFullTime((string)token["Result"]));
				}

				games.Add(game);
			}


			//Hämtar användarens dokument
			XmlDocument doc = new XmlDocument();
			doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));

			//Loopar alla slutspelsmatcher för att lägga in i xml-dokument
			foreach (wcGame game in games)
			{
				//Kontrollerar om vi har en referens
				if (doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']") == null)
				{
					continue;
				}

				//Uppdaterar xml
				//doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']/result").Attributes["fulltime"]
				//.InnerText = string.Format("{0}-{1}", game.Results[0].ResultHomeTeam, game.Results[0].ResultAwayTeam);

				doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']").Attributes["homeTeam"]
				.InnerText = game.HomeTeam.Name;

				doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']").Attributes["awayTeam"]
				.InnerText = game.AwayTeam.Name;
			}			

			//Sparar användarens dokument
			doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));


			//this.GetExcel("userA");

			string jsonResponse = JsonConvert.SerializeObject(games);
			
			this.Context.Response.Write(string.Format("oki doki {0}", jsonResponse));
			//this.Context.Response.Write(string.Format("oki doki {0} {1}", "c", "dv"));
			this.Context.Response.End();

		}


		public void GetExcel(string userName)
		{
			//http://epplus.codeplex.com/
			//http://zeeshanumardotnet.blogspot.se/2010/08/creating-advanced-excel-2007-reports-on.html
						
			using (ExcelPackage p = new ExcelPackage())
			{
				XmlDocument doc = new XmlDocument();
				//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCup.xml"));
				doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));
				//wcGameCollection gamesGroupA = wcGameReposetory.wcGetGameCollection("Grupp A", doc, "/tournement/group[@name='A']/game");
				//wcGameCollection gamesGroupB = wcGameReposetory.wcGetGameCollection("Grupp B", doc, "/tournement/group[@name='B']/game");
				//wcGameCollection gamesGroupC = wcGameReposetory.wcGetGameCollection("Grupp C", doc, "/tournement/group[@name='C']/game");
				//wcGameCollection gamesGroupD = wcGameReposetory.wcGetGameCollection("Grupp D", doc, "/tournement/group[@name='D']/game");
				//wcGameCollection gamesGroupE = wcGameReposetory.wcGetGameCollection("Grupp E", doc, "/tournement/group[@name='E']/game");
				//wcGameCollection gamesGroupF = wcGameReposetory.wcGetGameCollection("Grupp F", doc, "/tournement/group[@name='F']/game");
				//wcGameCollection gamesGroupG = wcGameReposetory.wcGetGameCollection("Grupp G", doc, "/tournement/group[@name='G']/game");
				//wcGameCollection gamesGroupH = wcGameReposetory.wcGetGameCollection("Grupp H", doc, "/tournement/group[@name='H']/game");
				wcGameCollection games = wcGameReposetory.wcGetGameCollection("Grupp A", doc, "/tournement/group[@name='A']/game");
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp B", doc, "/tournement/group[@name='B']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp C", doc, "/tournement/group[@name='C']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp D", doc, "/tournement/group[@name='D']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp E", doc, "/tournement/group[@name='E']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp F", doc, "/tournement/group[@name='F']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp G", doc, "/tournement/group[@name='G']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp H", doc, "/tournement/group[@name='H']/game"));

				games.AddRange(wcGameReposetory.wcGetGameCollection("Åttondelsfinal", doc, "/tournement/eighth-finals/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Kvartsfinal", doc, "/tournement/quarterfinals/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Semifinal", doc, "/tournement/semifinals/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Final", doc, "/tournement/final/game"));

				FileInfo fileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/VM-tipset 2010 - Amigos.xlsx"));
				wc2010ExcelMapper mapper = new wc2010ExcelMapper(games, fileInfo);
				mapper.Save();

				
				////p.Load(new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/Documents/VM-tipset 2010 - Amigos.xlsx"), FileMode.Open));
				//FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open);
				//p.Load(fileStream);
				//fileStream.Close();

				////Here setting some document properties
				////p.Workbook.Properties.Author = "Zeeshan Umar";
				////p.Workbook.Properties.Title = "Office Open XML Sample";

				////Create a sheet
				////p.Workbook.Worksheets.Add("Sample WorkSheet");
				//ExcelWorksheet ws = p.Workbook.Worksheets["Jan Lundholm"];	
				////ws.Name = "Sample Worksheet"; //Setting Sheet's name
				////ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
				////ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet


				////DataTable dt = CreateDataTable(); //My Function which generates DataTable

				////Merging cells and create a center heading for out table
				//ws.Cells[100, 1].Value = "testar";
				//ws.Cells[100, 2].Value = 123;
												

				////Generate A File with Random name
				//Byte[] bin = p.GetAsByteArray();
				////string file = "d:\\" + Guid.NewGuid().ToString() + ".xlsx";
				////string file = System.Web.HttpContext.Current.Server.MapPath("~/Documents/EPPlus1.xlsx");
				////string file = System.Web.HttpContext.Current.Server.MapPath("~/Documents/VM-tipset 2010 - Amigos.xlsx");
				////string file = fileInfo.FullName;
				//File.WriteAllBytes(fileInfo.FullName, bin);

				//this.Context.Response.OutputStream.Write(bin, 0, bin.c
				//this.Context.Response.ContentType = "Application/x-msexcel";
				this.Context.Response.Clear();
				this.Context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
				//this.Context.Response.ContentType = "application/vnd.ms-excel";
				this.Context.Response.ContentType = "application/octet-stream";
				this.Context.Response.AppendHeader("Content-disposition", "attachment; filename=my.xlsx");
				this.Context.Response.WriteFile(fileInfo.FullName);
				this.Context.Response.End();
			}
		}



		///// <summary>
		///// Creates the data table.
		///// </summary>
		///// <returns>DataTable</returns>
		//private static DataTable CreateDataTable()
		//{
		//    DataTable dt = new DataTable();
		//    for (int i = 0; i < 10; i++)
		//    {
		//        dt.Columns.Add(i.ToString());
		//    }

		//    for (int i = 0; i < 10; i++)
		//    {
		//        DataRow dr = dt.NewRow();
		//        foreach (DataColumn dc in dt.Columns)
		//        {
		//            dr[dc.ToString()] = i;
		//        }

		//        dt.Rows.Add(dr);
		//    }
		//    return dt;
		//}
	
	}
}
