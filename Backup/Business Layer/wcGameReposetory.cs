using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace BusinessLayer
{
    public static class wcGameReposetory
    {
        //public void CreateGame()
        //{
        //    throw new System.NotImplementedException();
        //}


        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="doc"></param>
        public static wcGameCollection wcGetGameCollection(string name, XmlDocument doc, string xpath)
        {
            wcGameCollection games = new wcGameCollection(name);

            foreach (XmlNode node in doc.SelectNodes(xpath))
            {
                wcGame game = new wcGame(node);
                games.Add(game);
            }

            //Skapar de lag som är med i turneringen
            games.CreateTeams();

            //Spelar matcher
            foreach (wcGame game in games)
            {
                //game.Play();
                games.PlayGame(game);
            }

            //Sorterar
            games.Teams.Sort(wcGameCollection.PointComparison);

            return games;
        }
    }
}
