namespace netcorewebapi.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character{ Name = "Trisha", Id = 1, Inteligence = 20, Class = RpgClass.Mage }
        };

        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);
            var serviceResponse = new ServiceResponse<Character>();
            serviceResponse.Data = character;
            return serviceResponse;
        }
    }
}