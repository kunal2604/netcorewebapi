using Microsoft.AspNetCore.Mvc;


namespace netcorewebapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character knight = new Character();
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character{ Name = "Trisha", Id = 1, Inteligence = 20, Class = RpgClass.Mage }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(knight);
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get2()
        {
            return Ok(characters[2]);
        }

        [HttpGet("GetCharacterById/{id}")]
        public ActionResult<Character> GetCharacterById(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        } 

        // Combine route in the same line
        [HttpGet("GetCharacters")] 
        public ActionResult<List<Character>> GetCharacters()
        {
            return Ok(characters);
        }

        [HttpPost("AddCharacter")]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }
    }
}