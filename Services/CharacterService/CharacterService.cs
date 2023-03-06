namespace netcorewebapi.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ICharacterDAO _characterDAO;

        public CharacterService(IMapper mapper, DataContext context, ICharacterDAO characterDAO)
        {
            _mapper = mapper;
            _context = context;
            _characterDAO = characterDAO;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            var dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

            //var dbCharacter = await _context.Characters.FindAsync(id);
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            
            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<JObject> GetCharacterByIdObject(int id)
        {
            var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

            return JObject.FromObject(dbCharacter);
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            _context.Characters.Add(_mapper.Map<Character>(newCharacter));
            await _context.SaveChangesAsync();
            return await GetAllCharacters();
        }

        public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
            try
            {
                var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
                if(dbCharacter is null)
                {
                    throw new Exception($"Character with Id '{updatedCharacter.Id}' not found !!");
                }
            
                dbCharacter.Name = updatedCharacter.Name;
                dbCharacter.HitPoints = updatedCharacter.HitPoints;
                dbCharacter.Inteligence = updatedCharacter.Inteligence;
                dbCharacter.Strength = updatedCharacter.Strength;
                dbCharacter.Defense = updatedCharacter.Defense;
                dbCharacter.Class = updatedCharacter.Class;
                
                await _context.SaveChangesAsync();
                return await GetCharacterById(updatedCharacter.Id);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            try
            {
                var dbCharacter = await _context.Characters.FindAsync(id);
                if(dbCharacter is null)
                {
                    throw new Exception($"Character with id '{id}' was not found !!");
                }
                _context.Characters.Remove(dbCharacter);
                await _context.SaveChangesAsync();
                return await GetAllCharacters();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetTopStrengthCharacters(int count)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
            var dbCharacters = await _characterDAO.GetTopStrengthCharacters(count);
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
            return serviceResponse;
        }

        private async Task<JArray> GetCharacterAddressFromDatabase(int id)
        {
            return await _characterDAO.GetCharacterAddress(id);
        }

        public async Task<ServiceResponse<JArray>> GetCharacterAddress(int id)
        {
            JArray res = await GetCharacterAddressFromDatabase(id);
            var serviceResponse = new ServiceResponse<JArray>();
            serviceResponse.Data = res;
            return serviceResponse;
        }

        public async Task<ServiceResponse<JObject>> GetCharacterDetails(int id)
        {
            var serviceResponse = new ServiceResponse<JObject>();
            JObject character = await GetCharacterByIdObject(id);
            JArray address = await GetCharacterAddressFromDatabase(id);

            JObject userDetails = new JObject();
            userDetails["Basic"] = character;
            userDetails["Address"] = address;
            serviceResponse.Data = userDetails;
            return serviceResponse;
        }
    }
}