namespace netcorewebapi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character,GetCharacterResponseDto>();
            CreateMap<AddCharacterRequestDto,Character>();
            CreateMap<UpdateCharacterRequestDto,Character>();
        }
    }
}