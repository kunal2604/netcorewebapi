namespace netcorewebapi.Data.DAO
{
    public class CharacterDAO : ICharacterDAO
    {
        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();
            string connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

            return connectionString;
        }

        public async Task<List<Character>> GetTopStrengthCharacters(int count)
        {
            List<Character> characters = new List<Character>();
            
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand()
                {
                    CommandText = "GetTopStrengthCharacters",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@count",
                    SqlDbType = SqlDbType.Int,
                    Value = count,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(param1);
                await connection.OpenAsync();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Character character = new Character();
                    character.Id = (int)dataReader["Id"];
                    character.Name = (string)dataReader["Name"];
                    character.HitPoints = (int)dataReader["HitPoints"];
                    character.Strength = (int)dataReader["Strength"];
                    character.Defense = (int)dataReader["Defense"];
                    character.Inteligence = (int)dataReader["Inteligence"];
                    character.Class = (RpgClass)dataReader["Class"];
                    characters.Add(character);
                }
            }

            return characters;
        }

        public async Task<JArray> GetCharacterAddress(int id)
        {
            JArray addrResponse = new JArray();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand()
                {
                    CommandText = "GetCharacterAddress",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter param1 = new SqlParameter()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(param1);
                await connection.OpenAsync();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string res = (string)dataReader[0];
                    addrResponse = JArray.Parse(res);
                }
            }

            return addrResponse;
        }   
    }
}
