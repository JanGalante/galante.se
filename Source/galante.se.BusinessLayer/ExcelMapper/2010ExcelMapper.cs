using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OfficeOpenXml;

namespace BusinessLayer.ExcelMapper
{
	public class wc2010ExcelMapper
	{
		private wcGameCollection Games { get; set; }
		private FileInfo FileInfo { get; set; }

		public wc2010ExcelMapper(wcGameCollection games, FileInfo excelFileInfo)
		{
			this.Games = games;
			this.FileInfo = excelFileInfo;
		}

		public void Save()
		{
			using (ExcelPackage p = new ExcelPackage())
			{
				//FileInfo fileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/VM-tipset 2010 - Amigos.xlsx"));
				FileStream fileStream = new FileStream(this.FileInfo.FullName, FileMode.Open);

				p.Load(fileStream);
				fileStream.Close();

				//Here setting some document properties
				//p.Workbook.Properties.Author = "Zeeshan Umar";
				//p.Workbook.Properties.Title = "Office Open XML Sample";

				//Create a sheet
				//p.Workbook.Worksheets.Add("Sample WorkSheet");
				ExcelWorksheet ws = p.Workbook.Worksheets["Jan Lundholm"];

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
							ws.Cells[4, 7].Value = homeGoals;
							ws.Cells[4, 9].Value = awayGoals;
							break;
						case 2:
							ws.Cells[5, 7].Value = homeGoals;
							ws.Cells[5, 9].Value = awayGoals;
							break;
						case 17:
							ws.Cells[6, 7].Value = homeGoals;
							ws.Cells[6, 9].Value = awayGoals;
							break;
						case 18:
							ws.Cells[7, 7].Value = homeGoals;
							ws.Cells[7, 9].Value = awayGoals;
							break;
						case 33:
							ws.Cells[8, 7].Value = homeGoals;
							ws.Cells[8, 9].Value = awayGoals;
							break;
						case 34:
							ws.Cells[9, 7].Value = homeGoals;
							ws.Cells[9, 9].Value = awayGoals;
							break;
						//Grupp B
						case 3:
							ws.Cells[11, 7].Value = homeGoals;
							ws.Cells[11, 9].Value = awayGoals;
							break;
						case 4:
							ws.Cells[12, 7].Value = homeGoals;
							ws.Cells[12, 9].Value = awayGoals;
							break;
						case 19:
							ws.Cells[13, 7].Value = homeGoals;
							ws.Cells[13, 9].Value = awayGoals;
							break;
						case 20:
							ws.Cells[14, 7].Value = homeGoals;
							ws.Cells[14, 9].Value = awayGoals;
							break;
						case 35:
							ws.Cells[15, 7].Value = homeGoals;
							ws.Cells[15, 9].Value = awayGoals;
							break;
						case 36:
							ws.Cells[16, 7].Value = homeGoals;
							ws.Cells[16, 9].Value = awayGoals;
							break;
						//Grupp C
						case 5:
							ws.Cells[18, 7].Value = homeGoals;
							ws.Cells[18, 9].Value = awayGoals;
							break;
						case 6:
							ws.Cells[19, 7].Value = homeGoals;
							ws.Cells[19, 9].Value = awayGoals;
							break;
						case 22:
							ws.Cells[20, 7].Value = homeGoals;
							ws.Cells[20, 9].Value = awayGoals;
							break;
						case 23:
							ws.Cells[21, 7].Value = homeGoals;
							ws.Cells[21, 9].Value = awayGoals;
							break;
						case 37:
							ws.Cells[22, 7].Value = homeGoals;
							ws.Cells[22, 9].Value = awayGoals;
							break;
						case 38:
							ws.Cells[23, 7].Value = homeGoals;
							ws.Cells[23, 9].Value = awayGoals;
							break;
						//Grupp D
						case 7:
							ws.Cells[25, 7].Value = homeGoals;
							ws.Cells[25, 9].Value = awayGoals;
							break;
						case 8:
							ws.Cells[26, 7].Value = homeGoals;
							ws.Cells[26, 9].Value = awayGoals;
							break;
						case 21:
							ws.Cells[27, 7].Value = homeGoals;
							ws.Cells[27, 9].Value = awayGoals;
							break;
						case 24:
							ws.Cells[28, 7].Value = homeGoals;
							ws.Cells[28, 9].Value = awayGoals;
							break;
						case 39:
							ws.Cells[29, 7].Value = homeGoals;
							ws.Cells[29, 9].Value = awayGoals;
							break;
						case 40:
							ws.Cells[30, 7].Value = homeGoals;
							ws.Cells[30, 9].Value = awayGoals;
							break;
						//Grupp E
						case 9:
							ws.Cells[32, 7].Value = homeGoals;
							ws.Cells[32, 9].Value = awayGoals;
							break;
						case 10:
							ws.Cells[33, 7].Value = homeGoals;
							ws.Cells[33, 9].Value = awayGoals;
							break;
						case 25:
							ws.Cells[34, 7].Value = homeGoals;
							ws.Cells[34, 9].Value = awayGoals;
							break;
						case 26:
							ws.Cells[35, 7].Value = homeGoals;
							ws.Cells[35, 9].Value = awayGoals;
							break;
						case 43:
							ws.Cells[36, 7].Value = homeGoals;
							ws.Cells[36, 9].Value = awayGoals;
							break;
						case 44:
							ws.Cells[37, 7].Value = homeGoals;
							ws.Cells[37, 9].Value = awayGoals;
							break;
						//Grupp F
						case 11:
							ws.Cells[39, 7].Value = homeGoals;
							ws.Cells[39, 9].Value = awayGoals;
							break;
						case 12:
							ws.Cells[40, 7].Value = homeGoals;
							ws.Cells[40, 9].Value = awayGoals;
							break;
						case 27:
							ws.Cells[41, 7].Value = homeGoals;
							ws.Cells[41, 9].Value = awayGoals;
							break;
						case 28:
							ws.Cells[42, 7].Value = homeGoals;
							ws.Cells[42, 9].Value = awayGoals;
							break;
						case 41:
							ws.Cells[43, 7].Value = homeGoals;
							ws.Cells[43, 9].Value = awayGoals;
							break;
						case 42:
							ws.Cells[44, 7].Value = homeGoals;
							ws.Cells[44, 9].Value = awayGoals;
							break;
						//Grupp G
						case 13:
							ws.Cells[46, 7].Value = homeGoals;
							ws.Cells[46, 9].Value = awayGoals;
							break;
						case 14:
							ws.Cells[47, 7].Value = homeGoals;
							ws.Cells[47, 9].Value = awayGoals;
							break;
						case 29:
							ws.Cells[48, 7].Value = homeGoals;
							ws.Cells[48, 9].Value = awayGoals;
							break;
						case 30:
							ws.Cells[49, 7].Value = homeGoals;
							ws.Cells[49, 9].Value = awayGoals;
							break;
						case 45:
							ws.Cells[50, 7].Value = homeGoals;
							ws.Cells[50, 9].Value = awayGoals;
							break;
						case 46:
							ws.Cells[51, 7].Value = homeGoals;
							ws.Cells[51, 9].Value = awayGoals;
							break;
						//Grupp H
						case 15:
							ws.Cells[53, 7].Value = homeGoals;
							ws.Cells[53, 9].Value = awayGoals;
							break;
						case 16:
							ws.Cells[54, 7].Value = homeGoals;
							ws.Cells[54, 9].Value = awayGoals;
							break;
						case 31:
							ws.Cells[55, 7].Value = homeGoals;
							ws.Cells[55, 9].Value = awayGoals;
							break;
						case 32:
							ws.Cells[56, 7].Value = homeGoals;
							ws.Cells[56, 9].Value = awayGoals;
							break;
						case 47:
							ws.Cells[57, 7].Value = homeGoals;
							ws.Cells[57, 9].Value = awayGoals;
							break;
						case 48:
							ws.Cells[58, 7].Value = homeGoals;
							ws.Cells[58, 9].Value = awayGoals;
							break;
						//Lag till åttondelsfinal
						case 49:
							ws.Cells[61, 5].Value = string.Format("A1-B2 {0}-{1}", 
								game.HomeTeam != null ? game.HomeTeam.Name : null, 
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 50:
							ws.Cells[62, 5].Value = string.Format("C1-D2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 51:
							ws.Cells[63, 5].Value = string.Format("D1-C2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 52:
							ws.Cells[64, 5].Value = string.Format("B1-A2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 53:
							ws.Cells[65, 5].Value = string.Format("E1-F2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 54:
							ws.Cells[66, 5].Value = string.Format("G1-H2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 55:
							ws.Cells[67, 5].Value = string.Format("F1-E2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						case 56:
							ws.Cells[68, 5].Value = string.Format("H1-G2 {0}-{1}",
								game.HomeTeam != null ? game.HomeTeam.Name : null,
								game.AwayTeam != null ? game.AwayTeam.Name : null);
							break;
						//Lag till kvartsfinal
						case 57:
							ws.Cells[61, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name :null;
							ws.Cells[62, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							break;
						case 58:
							ws.Cells[63, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[64, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							break;
						case 59:
							ws.Cells[65, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[66, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							break;
						case 60:
							ws.Cells[67, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[68, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							break;
						//Lag till semifinal
						case 61:
							ws.Cells[71, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[72, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							break;
						case 62:
							ws.Cells[73, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[74, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
							break;
						//Lag till final
						case 63:
							ws.Cells[77, 20].Value = game.HomeTeam != null ? game.HomeTeam.Name : null;
							ws.Cells[78, 20].Value = game.AwayTeam != null ? game.AwayTeam.Name : null;
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
