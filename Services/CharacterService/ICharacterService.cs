namespace netcorewebapi.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();
        
        Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);

        Task<JObject> GetCharacterByIdObject(int id);

        Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter);

        Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto Character);

        Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetTopStrengthCharacters(int count);

        Task<ServiceResponse<JArray>> GetCharacterAddress(int id);

        Task<ServiceResponse<JObject>> GetCharacterDetails(int id);
    }
}