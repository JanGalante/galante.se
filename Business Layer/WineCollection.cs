using System;
using System.Collections.Generic;
using System.Data;

using DataLayer.Specific;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for WineCollection
    /// </summary>
    public class WineCollection : ItemCollectionBase<Wine>
    {
        public WineCollection()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public static WineCollection GetAll()
        {
            //DataTable wineTable = WineData.GetAll();
            //foreach (DataRow row in wineTable.Rows)
            //{
            //   this.Add(new Wine(row));
            //}

            //return this;
            WineCollection wines = new WineCollection();

            DataTable wineTable = WineData.GetAll();
            foreach (DataRow row in wineTable.Rows)
            {
                wines.Add(new Wine(row));
            }

            return wines;
        }


    } 
}
