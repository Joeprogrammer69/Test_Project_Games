using Project_Testing_Games.interfaces;
using Project_Testing_Games.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Testing_Games
{
    public class GameInfoProvider
    {
        public Game GetGameInfo(string gameId)
        {
            
            return new Game
            {
                GameId = gameId,
                Name = "Super Fun Game",
                ReleaseYear = 2020,
                Userscore = 9
            };
        }
    }
}
