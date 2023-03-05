using Microsoft.Data.SqlClient;
using netcorewebapi.Data.DAO.Interface;
using System.Data;

namespace netcorewebapi.Data.DAO
{
    public class CharacterDAO : ICharacterDAO
    {
        public async Task<List<Character>> GetTopStrengthCharacters(int count)
        {
            List<Character> characters = new List<Character>();
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();

            string connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");

            
            using (SqlConnection connection = new SqlConnection(connectionString))
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
    }
}
