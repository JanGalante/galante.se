using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using BusinessLayer;
using System.Xml;
using ExcelLibrary.SpreadSheet;
using QiHe.CodeLib;

//using BusinessLayer.Enumerators;
using BusinessLayer.Extensions.EnumExtension;
using BusinessLayer.Extensions.CountryEnumExtension;

namespace janlundholm.eu
{
    public partial class wc2010 : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			this.Title = "VM 2010 | Jan Lundholm";
			
			//wc2010.MapToXml();
			litTest.Text = BusinessLayer.Enumerators.EnumConstants.Country.Polen.GetStringValue();
			litTest.Text = BusinessLayer.Enumerators.EnumConstants.Country.Grekland.GetCountryCode();


            XmlDocument doc = new XmlDocument();
			//doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCup.xml"));
			doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupNewUser.xml"));
            //wcGameCollection coll = new wcGameCollection(doc);
            wcGameCollection gamesGroupA = wcGameReposetory.wcGetGameCollection("Grupp A", doc, "/tournement/group[@name='A']/game");
            wcGameCollection gamesGroupB = wcGameReposetory.wcGetGameCollection("Grupp B", doc, "/tournement/group[@name='B']/game");
			wcGameCollection gamesGroupC = wcGameReposetory.wcGetGameCollection("Grupp C", doc, "/tournement/group[@name='C']/game");
			wcGameCollection gamesGroupD = wcGameReposetory.wcGetGameCollection("Grupp D", doc, "/tournement/group[@name='D']/game");
			wcGameCollection gamesGroupE = wcGameReposetory.wcGetGameCollection("Grupp E", doc, "/tournement/group[@name='E']/game");
			wcGameCollection gamesGroupF = wcGameReposetory.wcGetGameCollection("Grupp F", doc, "/tournement/group[@name='F']/game");
			wcGameCollection gamesGroupG = wcGameReposetory.wcGetGameCollection("Grupp G", doc, "/tournement/group[@name='G']/game");
			wcGameCollection gamesGroupH = wcGameReposetory.wcGetGameCollection("Grupp H", doc, "/tournement/group[@name='H']/game");

            List<wcGameCollection> tournament = new List<wcGameCollection>();
            tournament.Add(gamesGroupA);
            tournament.Add(gamesGroupB);
            tournament.Add(gamesGroupC);
            tournament.Add(gamesGroupD);
            tournament.Add(gamesGroupE);
            tournament.Add(gamesGroupF);
            tournament.Add(gamesGroupG);
            tournament.Add(gamesGroupH);

            rptTournament.DataSource = tournament;
            rptTournament.DataBind();

			wcGameCollection gamesEighthFinals = wcGameReposetory.wcGetGameCollection("Åttondelsfinal", doc, "/tournement/eighth-finals/game");
			rpEightFinals.DataSource = gamesEighthFinals;
			rpEightFinals.DataBind();

			wcGameCollection gamesQuarterfinals = wcGameReposetory.wcGetGameCollection("Kvartsfinal", doc, "/tournement/quarterfinals/game");
			rpQuarterfinals.DataSource = gamesQuarterfinals;
			rpQuarterfinals.DataBind();

			wcGameCollection gamesSemifinals = wcGameReposetory.wcGetGameCollection("Semifinal", doc, "/tournement/semifinals/game");
			rpSemiFinals.DataSource = gamesSemifinals;
			rpSemiFinals.DataBind();

			wcGameCollection gamesFinal = wcGameReposetory.wcGetGameCollection("Final", doc, "/tournement/final/game");
			rpFinal.DataSource = gamesFinal;
			rpFinal.DataBind();
        }




		private static void MapToXml()
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupTemplate.xml"));

			//http://code.google.com/p/excellibrary/

			////create new xls file
			//string file = "C:\\newdoc.xls";
			//Workbook workbook = new Workbook();
			//Worksheet worksheet = new Worksheet("First Sheet");
			//worksheet.Cells[0, 1] = new Cell((short)1);
			//worksheet.Cells[2, 0] = new Cell(9999999);
			//worksheet.Cells[3, 3] = new Cell((decimal)3.45);
			//worksheet.Cells[2, 2] = new Cell("Text string");
			//worksheet.Cells[2, 4] = new Cell("Second string");
			//worksheet.Cells[4, 0] = new Cell(32764.5, "#,##0.00");
			//worksheet.Cells[5, 1] = new Cell(DateTime.Now, @"YYYY\-MM\-DD");
			//worksheet.Cells.ColumnWidth[0, 1] = 3000;
			//workbook.Worksheets.Add(worksheet);
			//workbook.Save(file);


			// open xls file
			string filePath = System.Web.HttpContext.Current.Server.MapPath("~/Documents/VM-tipset 2010 - Amigos.xls");
			Workbook book = Workbook.Load(filePath);
			Worksheet sheet = book.Worksheets[1];

			//// traverse cells
			//foreach (Pair<Pair<int, int>, Cell> cell in sheet.Cells)
			//{
			//    dgvCells[cell.Left.Right, cell.Left.Left].Value = cell.Right.Value;
			//}

			//// traverse rows by Index
			//for (int rowIndex = sheet.Cells.FirstRowIndex;
			//       rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
			//{
			//    Row row = sheet.Cells.GetRow(rowIndex);
			//    for (int colIndex = row.FirstColIndex;
			//       colIndex <= row.LastColIndex; colIndex++)
			//    {
			//        Cell cell = row.GetCell(colIndex);
			//    }
			//}


			//Cell cell = sheet.Cells.GetRow(4).GetCell(4);
			//lblExcelValue.Text = cell.StringValue;

			//XmlAttribute attr = doc.SelectSingleNode("/tournement/group[@name='A']/game[@homeTeam='Sydafrika']/result]").Attributes["fulltime"];
			//XmlNodeList attr = doc.SelectNodes("/tournement/group[@name='A']/game[@homeTeam='Sydafrika'][@awayTeam='Mexiko']/result");,
			//doc.SelectSingleNode("/tournement/group[@name='A']/game[@homeTeam='Sydafrika'][@awayTeam='Mexiko']/result").Attributes["fulltime"].InnerText = "2-2";
			
			doc.SelectSingleNode("/tournement/group[@name='A']/game[@homeTeam='Sydafrika'][@awayTeam='Mexiko']/result").Attributes["fulltime"]
				.InnerText = string.Format("{0}-{1}", sheet.Cells.GetRow(3).GetCell(11).StringValue, sheet.Cells.GetRow(3).GetCell(13).StringValue);
			
			
			//Sparar Xml
			doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/Documents/WorldCupDenise.xml"));
			
		
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
		#endregion
    }
}
