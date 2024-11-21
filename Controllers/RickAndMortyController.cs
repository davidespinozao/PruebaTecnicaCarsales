using Microsoft.AspNetCore.Mvc;
using RickAndMortyBFF.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RickAndMortyBFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RickAndMortyController : ControllerBase
    {
        private readonly RickAndMortyService _rickAndMortyService;
        public RickAndMortyController(RickAndMortyService rickAndMortyService)
        {
            _rickAndMortyService = rickAndMortyService;
        }

        [HttpGet("characters")]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _rickAndMortyService.GetCharactersAsync();
            return Ok(characters);
        }

        [HttpGet("characters/{id}")]
        public async Task<IActionResult> GetCharacterById(int id)
        {
            var character = await _rickAndMortyService.GetCharacterByIdAsync(id);
            return Ok(character);
        }

        [HttpGet("episodes")]
        public async Task<IActionResult> GetEpisodes()
        {
            var episodes = await _rickAndMortyService.GetEpisodesAsync();
            return Ok(episodes);
        }

        [HttpGet("episodes/{id}")]
        public async Task<IActionResult> GetEpisodeById(int id)
        {
            var episode = await _rickAndMortyService.GetEpisodeByIdAsync(id);
            return Ok(episode);
        }
    }
}
