using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using BusinessLayer;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OfficeOpenXml;
using BusinessLayer.ExcelMapper;

namespace janlundholm.eu.HttpHandlers
{
	/// <summary>
	/// Summary description for $codebehindclassname$
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class European2012 : IHttpHandler
	{
		private HttpContext Context { set; get; }
		private FileInfo _userFileInfo = null;

		public FileInfo UserFileInfo
		{
			get 
			{
				//Lazy loading
				if (this._userFileInfo == null)
				{
					_userFileInfo = this.Context.Request["document"] != null ?
						new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/" + this.Context.Request["document"] + ".xml")) : null;
				}
				return _userFileInfo; 
			}
		}

		public void ProcessRequest(HttpContext context)
		{
			this.Context = context;

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
			//FileInfo fileInfo = this.Context.Request["document"] != null ?
			//    new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/" + this.Context.Request["document"] + ".xml")) : null;

			//Kontrollerar att vi har en referens till fil
			if (this.UserFileInfo == null)
			{
				return;
			}

			string id = this.Context.Request["gameid"];
			string result = this.Context.Request["result"];
			string[] results = result.Trim().Split(new char[] { '-' });
			int homeGoal;
			int awayGoal;

			//Kontrollerar att två resultat angivits och att båda dessa är numeriska
			if (results == null || results.Length != 2 || !int.TryParse(results[0], out homeGoal) || !int.TryParse(results[1], out awayGoal))
			{
				//Om inte avsluta
				return;
			}
			
			//Hämtar upp dokument/xml
			XmlDocument doc = new XmlDocument();
			//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupNewUser.xml"));
			doc.Load(this.UserFileInfo.FullName);

			//Uppdaterar
			doc.SelectSingleNode("//game[@id='" + id + "']/result").Attributes["fulltime"]
				.InnerText = string.Format("{0}-{1}", homeGoal.ToString(), awayGoal.ToString());

			//Sparar Xml
			//doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupNewUser.xml"));
			doc.Save(this.UserFileInfo.FullName);

			string response = string.Format("{0} - {1}", homeGoal.ToString(), awayGoal.ToString());
			this.Context.Response.Write(response);
			this.Context.Response.End();
		}

		public void GetGroup()
		{
			//Kontrollerar att vi har en referens till fil
			if (this.UserFileInfo == null)
			{
				return;
			}

			string group = this.Context.Request["group"].ToUpper();
			StringBuilder sb = new StringBuilder();

			XmlDocument doc = new XmlDocument();
			//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupNewUser.xml"));
			doc.Load(this.UserFileInfo.FullName);

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

			var helloResponse = new
			{
				Id = 1,
				Name = string.Empty,
				HomeTeam = string.Empty,
				AwayTeam = string.Empty
			};

			
			//Bra exempel 
			//http://james.newtonking.com/projects/json/help/LINQtoJSON.html

			
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
			//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupNewUser.xml"));
			doc.Load(this.UserFileInfo.FullName);

			//Loopar alla slutspelsmatcher för att lägga in i xml-dokument
			foreach (wcGame game in games)
			{
				//Kontrollerar om vi har en referens
				if (doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']") == null)
				{
					continue;
				}

				//Uppdaterar xml				
				doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']").Attributes["homeTeam"]
				.InnerText = game.HomeTeam.Name;

				doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']").Attributes["awayTeam"]
				.InnerText = game.AwayTeam.Name;

				if (game.Results != null && game.Results[0] != null)
				{
					doc.SelectSingleNode("//game[@id='" + game.Id.ToString() + "']/result").Attributes["fulltime"]
					.InnerText = string.Format("{0}-{1}", game.Results[0].ResultHomeTeam, game.Results[0].ResultAwayTeam);
				}
			}

			//Sparar användarens dokument
			//doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupNewUser.xml"));
			doc.Save(this.UserFileInfo.FullName);


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

			//Kontrollerar att vi har en referens till fil
			if (this.UserFileInfo == null)
			{
				return;
			}


			using (ExcelPackage p = new ExcelPackage())
			{
				XmlDocument doc = new XmlDocument();
				//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCup.xml"));
				//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupNewUser.xml"));
				doc.Load(this.UserFileInfo.FullName);
				wcGameCollection games = wcGameReposetory.wcGetGameCollection("Grupp A", doc, "/tournement/group[@name='A']/game");
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp B", doc, "/tournement/group[@name='B']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp C", doc, "/tournement/group[@name='C']/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Grupp D", doc, "/tournement/group[@name='D']/game"));

				games.AddRange(wcGameReposetory.wcGetGameCollection("Kvartsfinal", doc, "/tournement/quarterfinals/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Semifinal", doc, "/tournement/semifinals/game"));
				games.AddRange(wcGameReposetory.wcGetGameCollection("Final", doc, "/tournement/final/game"));

				FileInfo fileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EM-tipset 2012.xlsx"));
				European2012ExcelMapper mapper = new European2012ExcelMapper(games, fileInfo);
				mapper.Save();

				this.Context.Response.Clear();
				this.Context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
				//this.Context.Response.ContentType = "application/vnd.ms-excel";
				this.Context.Response.ContentType = "application/octet-stream";
				this.Context.Response.AppendHeader("Content-disposition", "attachment; filename=my.xlsx");
				this.Context.Response.WriteFile(fileInfo.FullName);
				this.Context.Response.End();
			}
		}
	}
}
