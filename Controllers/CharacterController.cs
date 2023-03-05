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
            var response = await _characterService.GetCharacterById(2);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetCharacterById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetCharacterById(int id)
        {
            var response = await _characterService.GetCharacterById(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
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

        [HttpPut("UpdateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(await _characterService.UpdateCharacter(updatedCharacter));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponseDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacterById(id);
            if(response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetTopStrengthCharacters")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponseDto>>> GetTopStrengthCharacters(int count)
        {
            var response = await _characterService.GetTopStrengthCharacters(count);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);

        }
    }
}