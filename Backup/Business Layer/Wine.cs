using System;
using System.Data;
using System.Collections.Generic;
using DataLayer.Constants;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for Wine
    /// </summary>
    public class Wine
    {
        private int _wineId;
        private string _name;
        private string _country;
        private string _district;
        private int? _vintage;
        private string _grapes;
        private decimal? _alcoholPercent;
        private int? _price;
        private string _usage;
        private string _color;
        private string _taste;
        private string _scent;
        private int? _systemArticleNr;
        private int? _systemFullness;
        private int? _systemAbrasiveness;
        private int? _systemFruitAcid;
        private string _other;


        public Wine()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Wine(DataRow row)
        {
            _wineId = (int)row[WineConstants.WineId];
            _name = row[WineConstants.Name] as string;
            _country = row[WineConstants.Country] as string;
            _district = row[WineConstants.District] as string;
            _vintage = row[WineConstants.Vintage] as int?;
            _grapes = row[WineConstants.Grapes] as string;
            _alcoholPercent = row[WineConstants.AlcoholPercent] as decimal?;
            _price = row[WineConstants.Price] as int?;
            _usage = row[WineConstants.Usage] as string;
            _color = row[WineConstants.Color] as string;
            _taste = row[WineConstants.Taste] as string;
            _scent = row[WineConstants.Scent] as string;
            _systemArticleNr = row[WineConstants.SystemArticleNr] as int?;
            _systemFullness = row[WineConstants.SystemFullness] as int?;
            _systemAbrasiveness = row[WineConstants.SystemAbrasiveness] as int?;
            _systemFruitAcid = row[WineConstants.SystemFruitAcid] as int?;
            _other = row[WineConstants.Other] as string;
        }

        //Properties
        public int WineId
        {
            get { return _wineId; }
            set { _wineId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string District
        {
            get { return _district; }
            set { _district = value; }
        }

        public int? Vintage
        {
            get { return _vintage; }
            set { _vintage = value; }
        }

        public string Grapes
        {
            get { return _grapes; }
            set { _grapes = value; }
        }

        public decimal? AlcoholPercent
        {
            get { return _alcoholPercent; }
            set { _alcoholPercent = value; }
        }

        public int? Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Usage
        {
            get { return _usage; }
            set { _usage = value; }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string Taste
        {
            get { return _taste; }
            set { _taste = value; }
        }

        public string Scent
        {
            get { return _scent; }
            set { _scent = value; }
        }

        public int? SystemArticleNr
        {
            get { return _systemArticleNr; }
            set { _systemArticleNr = value; }
        }

        public int? SystemFullness
        {
            get { return _systemFullness; }
            set { _systemFullness = value; }
        }

        public int? SystemAbrasiveness
        {
            get { return _systemAbrasiveness; }
            set { _systemAbrasiveness = value; }
        }

        public int? SystemFruitAcid
        {
            get { return _systemFruitAcid; }
            set { _systemFruitAcid = value; }
        }

        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }
    } 
}