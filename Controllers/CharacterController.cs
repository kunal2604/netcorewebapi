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
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetFirstCharacter()
        {
            return Ok(await _characterService.GetCharacterById(1));
        }

        [HttpGet]
        [Route("GetSecondCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetSecondCharacter()
        {
            return Ok(await _characterService.GetCharacterById(2));
        }

        [HttpGet("GetCharacterById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetCharacterById(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        } 

        // Combine route in the same line
        [HttpGet("GetAllCharacters")] 
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> GetAllCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());   
        }

        [HttpPost("AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> AddCharacter(AddCharacterRequestDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}