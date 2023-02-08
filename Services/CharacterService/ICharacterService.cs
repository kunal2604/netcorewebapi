namespace netcorewebapi.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();
        
        Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);

        Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter);

        Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto Character);

        Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacterById(int id);
    }
}