using Project_Testing_Games.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Testing_Games.interfaces
{
    public interface IGameInfo
    {
        Game GetGameInfo(string gameId);
    }
}
