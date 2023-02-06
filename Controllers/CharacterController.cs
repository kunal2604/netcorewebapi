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
        public IActionResult GetFirstCharacter()
        {
            return Ok(_characterService.GetCharacterById(1));
        }

        [HttpGet]
        [Route("GetSecondCharacter")]
        public IActionResult GetSecondCharacter()
        {
            return Ok(_characterService.GetCharacterById(2));
        }

        [HttpGet("GetCharacterById/{id}")]
        public ActionResult<Character> GetCharacterById(int id)
        {
            return Ok(_characterService.GetCharacterById(id));
        } 

        // Combine route in the same line
        [HttpGet("GetAllCharacters")] 
        public ActionResult<List<Character>> GetAllCharacters()
        {
            return Ok(_characterService.GetAllCharacters());   
        }

        [HttpPost("AddCharacter")]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}