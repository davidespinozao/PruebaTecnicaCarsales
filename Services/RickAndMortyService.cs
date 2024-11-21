using System.Net.Http.Json;
using System.Text.Json;


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
            // Fetch the first page to get total pages
            var firstPageResponse = await _httpClient.GetAsync("episode");
            firstPageResponse.EnsureSuccessStatusCode();

            var firstPageJson = await firstPageResponse.Content.ReadAsStringAsync();
            var firstPageData = JsonSerializer.Deserialize<JsonElement>(firstPageJson);

            // Extract total pages from the "info" property
            var totalPages = firstPageData.GetProperty("info").GetProperty("pages").GetInt32();
            var episodes = new List<JsonElement>();

            // Prepare tasks to fetch all pages concurrently
            var fetchTasks = new List<Task<string>>();
            for (int i = 1; i <= totalPages; i++)
            {
                fetchTasks.Add(_httpClient.GetStringAsync($"episode?page={i}"));
            }

            // Wait for all tasks to complete
            var results = await Task.WhenAll(fetchTasks);

            // Parse and aggregate the results
            foreach (var result in results)
            {
                var pageData = JsonSerializer.Deserialize<JsonElement>(result);
                foreach (var episode in pageData.GetProperty("results").EnumerateArray())
                {

                    episodes.Add(episode);
                }
            }

            return episodes;
        }

        public async Task<dynamic> GetEpisodeByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"episode/{id}");
        }
    }
}
