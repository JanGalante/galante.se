using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;

namespace BusinessLayer.ExcelMapper
{
	public class European2012ExcelMapper
	{
		private wcGameCollection Games { get; set; }
		private FileInfo FileInfo { get; set; }

		public European2012ExcelMapper(wcGameCollection games, FileInfo excelFileInfo)
		{
			this.Games = games;
			this.FileInfo = excelFileInfo;
		}

		public void Save()
		{
			using (ExcelPackage p = new ExcelPackage())
			{
				//Kontrollerar om filen finns
				if (!File.Exists(this.FileInfo.FullName))
				{
					//Skapar filen genom att kopiera mallen
					FileInfo templateFileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EM-tipset 2012 Mall.xlsx"));
					File.Copy(templateFileInfo.FullName, this.FileInfo.FullName);
				}
					

				//FileInfo fileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/VM-tipset 2010 - Amigos.xlsx"));
				FileStream fileStream = new FileStream(this.FileInfo.FullName, FileMode.Open);

				p.Load(fileStream);
				fileStream.Close();

				//Here setting some document properties
				//p.Workbook.Properties.Author = "Zeeshan Umar";
				//p.Workbook.Properties.Title = "Office Open XML Sample";

				//Create a sheet
				//p.Workbook.Worksheets.Add("Sample WorkSheet");
				ExcelWorksheet ws = p.Workbook.Worksheets["Blad1"];

				int? homeGoals = null;
				int? awayGoals = null;
				//wcTeam winningTeam
				foreach (wcGame game in this.Games)
				{
					////Kontrollerar att resulat finns
					//if (game == null || game.Results == null || game.Results.Count == 0)
					//{
					//    continue;
					//}

					homeGoals = game == null || game.Results == null || game.Results.Count == 0 ?
						null : (int?)game.Results[0].ResultHomeTeam;
					awayGoals = game == null || game.Results == null || game.Results.Count == 0 ?
						null : (int?)game.Results[0].ResultAwayTeam;

					switch (game.Id)
					{
						//Grupp A
						case 1:
							ws.Cells[3, 7].Value = homeGoals;
							ws.Cells[3, 9].Value = awayGoals;
							break;
						case 2:
							ws.Cells[4, 7].Value = homeGoals;
							ws.Cells[4, 9].Value = awayGoals;
							break;
						case 9:
							ws.Cells[5, 7].Value = homeGoals;
							ws.Cells[5, 9].Value = awayGoals;
							break;
						case 10:
							ws.Cells[6, 7].Value = homeGoals;
							ws.Cells[6, 9].Value = awayGoals;
							break;
						case 17:
							ws.Cells[7, 7].Value = homeGoals;
							ws.Cells[7, 9].Value = awayGoals;
							break;
						case 18:
							ws.Cells[8, 7].Value = homeGoals;
							ws.Cells[8, 9].Value = awayGoals;
							break;
						//Grupp B
						case 3:
							ws.Cells[10, 7].Value = homeGoals;
							ws.Cells[10, 9].Value = awayGoals;
							break;
						case 4:
							ws.Cells[11, 7].Value = homeGoals;
							ws.Cells[11, 9].Value = awayGoals;
							break;
						case 11:
							ws.Cells[12, 7].Value = homeGoals;
							ws.Cells[12, 9].Value = awayGoals;
							break;
						case 12:
							ws.Cells[13, 7].Value = homeGoals;
							ws.Cells[13, 9].Value = awayGoals;
							break;
						case 19:
							ws.Cells[14, 7].Value = homeGoals;
							ws.Cells[14, 9].Value = awayGoals;
							break;
						case 20:
							ws.Cells[15, 7].Value = homeGoals;
							ws.Cells[15, 9].Value = awayGoals;
							break;
						//Grupp C
						case 5:
							ws.Cells[17, 7].Value = homeGoals;
							ws.Cells[17, 9].Value = awayGoals;
							break;
						case 6:
							ws.Cells[18, 7].Value = homeGoals;
							ws.Cells[18, 9].Value = awayGoals;
							break;
						case 13:
							ws.Cells[19, 7].Value = homeGoals;
							ws.Cells[19, 9].Value = awayGoals;
							break;
						case 14:
							ws.Cells[20, 7].Value = homeGoals;
							ws.Cells[20, 9].Value = awayGoals;
							break;
						case 21:
							ws.Cells[21, 7].Value = homeGoals;
							ws.Cells[21, 9].Value = awayGoals;
							break;
						case 22:
							ws.Cells[22, 7].Value = homeGoals;
							ws.Cells[22, 9].Value = awayGoals;
							break;
						//Grupp D
						case 7:
							ws.Cells[24, 7].Value = homeGoals;
							ws.Cells[24, 9].Value = awayGoals;
							break;
						case 8:
							ws.Cells[25, 7].Value = homeGoals;
							ws.Cells[25, 9].Value = awayGoals;
							break;
						case 15:
							ws.Cells[26, 7].Value = homeGoals;
							ws.Cells[26, 9].Value = awayGoals;
							break;
						case 16:
							ws.Cells[27, 7].Value = homeGoals;
							ws.Cells[27, 9].Value = awayGoals;
							break;
						case 23:
							ws.Cells[28, 7].Value = homeGoals;
							ws.Cells[28, 9].Value = awayGoals;
							break;
						case 24:
							ws.Cells[29, 7].Value = homeGoals;
							ws.Cells[29, 9].Value = awayGoals;
							break;
						//Lag till kvartsfinal
						case 25:
							//Hemmalaget denna kvartsfinal är 1:an i grupp A
							ws.Cells[3, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							//Bortalaget denna kvartsfinal är 2:an i grupp B
							ws.Cells[11, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;

							//Skriver även ut kvartsfinalmatchen i Excelen
							ws.Cells[32, 5].Value = string.Format("A1–B2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 26:
							//Hemmalaget denna kvartsfinal är 1:an i grupp B
							ws.Cells[10, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							//Bortalaget denna kvartsfinal är 2:an i grupp A
							ws.Cells[4, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;

							//Skriver även ut kvartsfinalmatchen i Excelen
							ws.Cells[33, 5].Value = string.Format("B1–A2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null, 
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 27:
							//Hemmalaget denna kvartsfinal är 1:an i grupp C
							ws.Cells[17, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							//Bortalaget denna kvartsfinal är 2:an i grupp D
							ws.Cells[25, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							
							//Skriver även ut kvartsfinalmatchen i Excelen
							ws.Cells[34, 5].Value = string.Format("C1–D2 {0}-{1}", 
								game.HomeTeam != null ? game.HomeTeam.Name : null, 
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 28:
							//Hemmalaget denna kvartsfinal är 1:an i grupp D
							ws.Cells[24, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							//Bortalaget denna kvartsfinal är 2:an i grupp C
							ws.Cells[18, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;

							//Skriver även ut kvartsfinalmatchen i Excelen
							ws.Cells[35, 5].Value = string.Format("D1–C2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						//Lag till semifinal
						case 29:
							ws.Cells[32, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[33, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							//Skriver även ut semifinalmatchen i Excelen
							ws.Cells[38, 5].Value = string.Format("Segrare match 25–27 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 30:
							ws.Cells[34, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[35, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							//Skriver även ut semifinalmatchen i Excelen
							ws.Cells[39, 5].Value = string.Format("Segrare match 26–28 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						//Lag till final
						case 31:
							ws.Cells[38, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[39, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							//Skriver även ut semifinalmatchen i Excelen
							ws.Cells[42, 5].Value = string.Format("Segrare match 29–30 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);

							//Skriver ut segraren av finalen
							if (game.Results != null && game.Results[0] != null && game.HomeTeam != null && game.AwayTeam != null)
							{
								wcResult result = game.Results[0];
								ws.Cells[42, 20].Value = result.ResultHomeTeam >= result.ResultAwayTeam ?
									game.HomeTeam.Name : game.AwayTeam.Name;
							}

							break;
						default:
							break;
					}
				}


				//Generate A File with Random name
				Byte[] bin = p.GetAsByteArray();
				File.WriteAllBytes(this.FileInfo.FullName, bin);
			}
		}
	}
}
