using Elmah;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace galante.se.Controllers
{
    public class LaundryRoomController : BaseController
    {
        //
        // GET: /LaundryRoom/
        //public CustomModelBinderAttribute

        public ActionResult Index()
        {
            ErrorSignal.FromCurrentContext().Raise(new NotSupportedException());
            return View();
        }

        [HttpPost]
        public FileContentResult Download(FormCollection formCollection)
        {
            //FileInfo fileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EM-tipset 2012 Mall.xlsx"));
            FileInfo fileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/laundry-room/schema-template.xlsx"));

            using (ExcelPackage p = new ExcelPackage())
            {
                ////Kontrollerar om filen finns
                //if (System.IO.File.Exists(fileInfo.FullName))
                //{
                //    //Skapar filen genom att kopiera mallen
                //    FileInfo templateFileInfo = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Documents/EM-tipset 2012 Mall.xlsx"));
                //    System.IO.File.Copy(templateFileInfo.FullName, fileInfo.FullName);
                //}

                FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.Open);

                p.Load(fileStream);
                fileStream.Close();

                //Create a sheet
                ExcelWorksheet ws = p.Workbook.Worksheets["Blad1"];

                //Manipulerar formuläret
                DateTime dummyDate;
                //DateTime? fromDate = DateTime.TryParse(formCollection["fromDate"], out dummyDate) ? (DateTime?)dummyDate : null;
                DateTime? fromDate = DateTime.TryParse(formCollection["fromDate"], out dummyDate) ? 
                    (DateTime?)DateTime.Parse(formCollection["fromDate"]) : null;
                DateTime? toDate = DateTime.TryParse(formCollection["toDate"], out dummyDate) ? 
                    (DateTime?)DateTime.Parse(formCollection["toDate"]) : null;

                ws.Cells[1, 3].Value = FirstCharToUpper(fromDate.Value.ToString("MMMM", this.CurrentCulture));

                int daysInMonth = DateTime.DaysInMonth(fromDate.Value.Year, fromDate.Value.Month);
                int rowNumber;
                DateTime schemaStartDate = new DateTime(fromDate.Value.Year, fromDate.Value.Month, 1);
                for (int i = 1; i <= 31; i++)
			    {
                    if (i <= daysInMonth)
                    {
                        rowNumber = i + 2;
                        ws.Cells[rowNumber, 1].Value = schemaStartDate.AddDays(i - 1).ToString("dddd", this.CurrentCulture);
                        ////Sätter bakgrundsfärg
                        ////http://stackoverflow.com/questions/1617049/calculate-the-number-of-business-days-between-two-dates
                        //ws.Cells[rowNumber, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        //ws.Cells[rowNumber, 1].Style.Fill.BackgroundColor.SetColor(Color.Aquamarine);
                    }
                    else
                    {
                        //Tar bort raden om dagen inte finns i månaden
                        ws.DeleteRow(daysInMonth + 3, 1);
                    }
			    }

                //for (int i = daysInMonth; i <= 31; i++)
                //{
                //    //Tar bort raden om dagen inte finns i månaden
                //    ws.DeleteRow(rowNumber, 1);
                //}

                //Generate A File with Random name
                Byte[] bin = p.GetAsByteArray();
                //System.IO.File.WriteAllBytes(fileInfo.FullName, bin);

                return File(bin, "application/octet-stream", "schema.xlsx");
            }
        }

        //
        // GET: /LaundryRoom/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /LaundryRoom/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LaundryRoom/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LaundryRoom/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /LaundryRoom/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LaundryRoom/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /LaundryRoom/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        private static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
    }
}
