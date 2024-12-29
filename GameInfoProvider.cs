using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Project_Testing_Games.interfaces;
using Project_Testing_Games.models;

namespace Project_Testing_Games
{
    public class GameInfoProvider : IGameInfo
    {
        private readonly HttpClient _httpClient;

        public GameInfoProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Game> GetGameInfo(string gameId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"game/{gameId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}, {response.ReasonPhrase}");
                }

                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Game>(content);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Failed to fetch game info for {gameId}: {ex.Message}", ex);
            }
        }
    }
}
