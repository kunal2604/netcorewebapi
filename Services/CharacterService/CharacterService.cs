namespace netcorewebapi.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>()
        {
            new Character(),
            new Character{ Name = "Trisha", Id = 1, Inteligence = 20, Class = RpgClass.Mage }
        };

        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
            return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = characters.FirstOrDefault(c => c.Id == id);

            if(character is not null)
                return character;
            else
                throw new Exception("Character not found with given id : " + id.ToString());
        }
    }
}