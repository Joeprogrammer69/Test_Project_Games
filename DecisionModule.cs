using Project_Testing_Games.interfaces;
using System;
using System.Threading.Tasks;

namespace Project_Testing_Games
{
    public class DecisionModule
    {
        private readonly IGameInfo _gameInfo;

        public DecisionModule(IGameInfo gameInfoProvider)
        {
            _gameInfo = gameInfoProvider;
        }

        public async Task<string> DecideDiscount(string gameId)
        {
            
            var gameInfo = await _gameInfo.GetGameInfo(gameId);

            if (gameInfo == null)
                throw new ArgumentException("Game not found");

            
            if (gameInfo.ReleaseYear < DateTime.Now.Year - 2 || gameInfo.Userscore > 8)
                return "Apply Discount";

            return "No Discount";
        }
    }
}
