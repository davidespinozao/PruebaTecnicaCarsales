using System.Net.Http.Json;


namespace RickAndMortyBFF.Services
{

    public class RickAndMortyService
    {
        private readonly HttpClient _httpClient;

        public RickAndMortyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
        }

        public async Task<dynamic> GetCharactersAsync()
        {
            return await _httpClient.GetFromJsonAsync<dynamic>("character");
        }

        public async Task<dynamic> GetCharacterByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"character/{id}");
        }

        public async Task<dynamic> GetEpisodesAsync()
        {
            return await _httpClient.GetFromJsonAsync<dynamic>("episode");
        }

        public async Task<dynamic> GetEpisodeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"episode/{id}");
        }
    }
}
