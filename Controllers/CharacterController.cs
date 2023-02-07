using Microsoft.AspNetCore.Mvc;
using netcorewebapi.Services.CharacterService;

namespace netcorewebapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Character>>> GetFirstCharacter()
        {
            return Ok(await _characterService.GetCharacterById(1));
        }

        [HttpGet]
        [Route("GetSecondCharacter")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetSecondCharacter()
        {
            return Ok(await _characterService.GetCharacterById(2));
        }

        [HttpGet("GetCharacterById/{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        } 

        // Combine route in the same line
        [HttpGet("GetAllCharacters")] 
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());   
        }

        [HttpPost("AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> AddCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}