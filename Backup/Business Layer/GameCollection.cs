using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

using BusinessLayer.Enumerators;
using DataLayer.Specific;

namespace BusinessLayer
{
    /// <summary>
    /// Summary description for GameCollection
    /// </summary>
    [Serializable]
    public class GameCollection : ItemCollectionBase<Game>
    {
        private EnumConstants.GameType _gamesType = EnumConstants.GameType.Undefined;
        private DateTime _dateFilter = DateTime.MinValue;

        public EnumConstants.GameType GamesType
        {
            get { return _gamesType; }
            set { _gamesType = value; }
        }


        /// <summary>
        /// Deafault konstruktor. Denna kräver en konstruktor i
        /// ItemCollectionBase efftersom den implicit anropar  :base()
        /// </summary>
        public GameCollection() { }

        public GameCollection(EnumConstants.GameType gameType)
        {
            GameCollection games = new GameCollection();

            switch (gameType)
            {
                case EnumConstants.GameType.League:
                    //games = GameCollection.GetDynamoIndoorGames2008();
                    XmlDocument doc = new XmlDocument();
                    //doc.Load("~/Documents/Dynamo2008.xml"); //C:\Users\Don Quijote\Documents\Visual Studio 2008\Projects\Data Layer\DataSource\Dynamo2008.xml
                    doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Documents/Dynamo2008.xml"));
                    games = GameCollection.GetGames(doc);
                    break;
                //case EnumeratedConstants.GameType.WordChampionship:
                //    break;
                //case EnumeratedConstants.GameType.EuropeanChampionship:
                //    break;
                //default:
                //    break;
            }

            //Lägg denn i ItemCollectionBase
            //Lägger till matcherna till instansen av Games
            foreach (Game game in games)
            {
                this.Add(game);
            }

            this.GamesType = gameType;
        }

        private static GameCollection GetDynamoIndoorGames2008()
        {
            GameCollection games = new GameCollection();

            DataTable gameTable = GameData.GetDynamoIndoor2008();
            foreach (DataRow row in gameTable.Rows)
            {
                games.Add(new Game(row));
            }

            return games;
        }

        /// <summary>
        /// Hämtar GameCollection utifrån inskickat XmlDocument.
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        private static GameCollection GetGames(XmlDocument xml)
        {
            GameCollection games = new GameCollection();

            //foreach (XmlNode node in xml.ChildNodes)
            foreach (XmlNode node in xml.SelectNodes("tournament/round/game"))
            {
                //games.Add(new Game(row));

                Game g = new Game(node);
                games.Add(g);
            }

            return games;
        }



        public TeamCollection GetLeaugeTable()
        {
            //Kontrollera så att typen är League
            if (this.GamesType != EnumConstants.GameType.League)
            {
                throw new System.Exception("Går ej att skapa en serietabell. Matcherna är av fel typ.");
            }

            TeamCollection league = new TeamCollection();

            foreach (Game game in this)
            {
                //Lägg kod här
            }


            return league;
        }

        public bool FilterDelegate(Game g)
        {
            //return g.Date  <= DateTime.Parse("2008-11-30");
            return g.Date <= _dateFilter;
        }

        public void SetDateFilter(DateTime dt)
        {
            _dateFilter = dt;
            this.Filter = new ItemCollectionBase<Game>.FilteredCollectionDelegate(FilterDelegate);
        }
    } 
}
