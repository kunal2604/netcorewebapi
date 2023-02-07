namespace netcorewebapi.Dtos.Character
{
    public class UpdateCharacterRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Kunal";
        public int HitPoints {get; set;} = 100;
        public int Strength {get; set;} = 10;
        public int Defense {get; set;} = 10;
        public int Inteligence {get; set;} = 10;
        public RpgClass Class {get; set;} = RpgClass.Knight;
    }
}