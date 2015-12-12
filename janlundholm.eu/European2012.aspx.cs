using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Xml;
using System.IO;

namespace janlundholm.eu
{
	public partial class European2012 : PageBase
	{
		//Namn på de användarens excelducument
		private FileInfo _userFileInfo = null;
		private string _userName = null;

		public FileInfo UserFileInfo
		{
			get 
			{
				//Lazy loading
				if (this._userFileInfo == null)
				{
					this._userFileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/" + this.Request["document"] + ".xml"));
				}
				return this._userFileInfo;
			}
		}

		public string UserName
		{
			get
			{
				//Lazy loading
				if (this._userName == null)
				{
					this._userName = this.Request["user"];
				}
				return this._userName;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			this.Title = "EM 2012 | Jan Lundholm";

			//wc2010.MapToXml();
			//FileStream fileStream = new FileStream(System.Web.HttpContext.Current.Server.MapPath("~/Documents/" + this.DocumentName + ".xml"),
			//    FileMode.OpenOrCreate);
			
			//Kontrollerar om användarens fil finns.
			//Om inte skapas en fil utifrån mall.
			//FileInfo fileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/" + this.DocumentName + ".xml"));
			if (!this.UserFileInfo.Exists)
			{
				//this.UserFileInfo.Create();
				FileInfo templateInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupTemplate.xml"));
				templateInfo.CopyTo(UserFileInfo.FullName, true);
			}

			XmlDocument doc = new XmlDocument();
			//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EuropeanCupNewUser.xml"));
			doc.Load(this.UserFileInfo.FullName);
			wcGameCollection gamesGroupA = wcGameReposetory.wcGetGameCollection("Grupp A", doc, "/tournement/group[@name='A']/game");
			wcGameCollection gamesGroupB = wcGameReposetory.wcGetGameCollection("Grupp B", doc, "/tournement/group[@name='B']/game");
			wcGameCollection gamesGroupC = wcGameReposetory.wcGetGameCollection("Grupp C", doc, "/tournement/group[@name='C']/game");
			wcGameCollection gamesGroupD = wcGameReposetory.wcGetGameCollection("Grupp D", doc, "/tournement/group[@name='D']/game");

			List<wcGameCollection> tournament = new List<wcGameCollection>();
			tournament.Add(gamesGroupA);
			tournament.Add(gamesGroupB);
			tournament.Add(gamesGroupC);
			tournament.Add(gamesGroupD);

			rptTournament.DataSource = tournament;
			rptTournament.DataBind();

			wcGameCollection gamesQuarterfinals = wcGameReposetory.wcGetGameCollection("Kvartsfinal", doc, "/tournement/quarterfinals/game");
			rpQuarterfinals.DataSource = gamesQuarterfinals;
			rpQuarterfinals.DataBind();

			wcGameCollection gamesSemifinals = wcGameReposetory.wcGetGameCollection("Semifinal", doc, "/tournement/semifinals/game");
			rpSemiFinals.DataSource = gamesSemifinals;
			rpSemiFinals.DataBind();

			wcGameCollection gamesFinal = wcGameReposetory.wcGetGameCollection("Final", doc, "/tournement/final/game");
			rpFinal.DataSource = gamesFinal;
			rpFinal.DataBind();

			wcGame final = gamesFinal[0];
			//Skriver ut segraren av finalen
			if (final.Results != null && final.Results[0] != null && final.HomeTeam != null && final.AwayTeam != null)
			{
				wcResult result = final.Results[0];
				litWinner.Text = result.ResultHomeTeam >= result.ResultAwayTeam ?
					final.HomeTeam.Name : final.AwayTeam.Name;
			}

		}


		#region Metoder som används på aspx-sidan
		protected string GetHomeTeamName(object obj)
		{
			wcGame game = obj as wcGame;
			return game != null ? game.HomeTeam.Name : null;
		}

		protected string GetAwayTeamName(object obj)
		{
			wcGame game = obj as wcGame;
			return game != null ? game.AwayTeam.Name : null;
		}

		protected string GetResult(object obj)
		{
			wcGame game = obj as wcGame;
			if (game == null || game.Results == null || game.Results.Count == 0)
			{
				return null;
			}

			wcResult finalresult = game.Results[game.Results.Count - 1];
			return string.Format("{0} - {1}", finalresult.ResultHomeTeam, finalresult.ResultAwayTeam);
		}

		protected int? GetResultHomeTeam(object obj)
		{
			wcGame game = obj as wcGame;
			if (game == null || game.Results == null || game.Results.Count == 0)
			{
				return null;
			}

			wcResult finalresult = game.Results[game.Results.Count - 1]; //Hämar slutresultat
			return finalresult.ResultHomeTeam;
		}

		protected int? GetResultAwayTeam(object obj)
		{
			wcGame game = obj as wcGame;
			if (game == null || game.Results == null || game.Results.Count == 0)
			{
				return null;
			}

			wcResult finalresult = game.Results[game.Results.Count - 1]; //Hämar slutresultat
			return finalresult.ResultAwayTeam;
		}

		/// <summary>
		/// Metod som kontrollerar om det är sista machen i kollecto
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		protected bool IsLastGame(object obj)
		{

			return true;
		}

		protected string GetImageUrlHomeTeam(object obj)
		{
			wcGame game = obj as wcGame;
			if (game == null || game.HomeTeam == null || game.HomeTeam.Name == null)
			{
				return null;
			}

			return string.Format("/Bilder/VM_2010/{0}.png", game.HomeTeam.Name.ToLower());
		}

		protected string GetImageUrlAwayTeam(object obj)
		{
			wcGame game = obj as wcGame;
			if (game == null || game.AwayTeam == null || game.HomeTeam.Name == null)
			{
				return null;
			}

			return string.Format("/Bilder/VM_2010/{0}.png", game.AwayTeam.Name.ToLower());
		}

		protected string GetGroupName(object obj)
		{
			wcGameCollection games = obj as wcGameCollection;
			if (games == null)
			{
				return null;
			}

			return games.Name;
		}

		/// <summary>
		/// Kontrollerar om inskickad matchkollektion har en match som ska spelas idag
		/// </summary>
		protected bool HasPlayDay(object obj)
		{
			wcGameCollection games = obj as wcGameCollection;
			//Kontrollerar om vi har en referens
			//if (games == null)
			//{
			//    return false;
			//}

			//bool hasPlayDay = false;
			foreach (wcGame game in games)
			{
				if (DateTime.Now.ToString("d MMMM") ==  game.Date.ToString("d MMMM"))
				{
					return true;
				}
			}
			return false;
		}
		#endregion
	}
}
