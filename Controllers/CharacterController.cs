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
            new Character{ Name = "Trisha", Inteligence = 20, Class = RpgClass.Mage }
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
            return Ok(knight);
        }

        // Combine route in the same line
        [HttpGet("GetCharacters")] 
        public ActionResult<List<Character>> GetCharacters()
        {
            return Ok(characters);
        }
    }
}