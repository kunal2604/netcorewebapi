namespace netcorewebapi.Data.DAO.Interface
{
    public interface ICharacterDAO
    {
        Task<List<Character>> GetTopStrengthCharacters(int count);
    }
}
