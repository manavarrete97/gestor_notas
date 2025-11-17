using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using System;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO
{
    public class PostProfesorDAO : IPostProfesorDAO
    {
        public async Task<bool> PostProfesor(NpgsqlConnection npgsqlConnection, ProfesorDTO profesorDTO)
        {
            try
            {
                var query = "INSERT INTO Profesor (nombre) VALUES (@nombre);";

                using (var command = new NpgsqlCommand(query, npgsqlConnection))
                {
                    command.Parameters.AddWithValue("@nombre", profesorDTO.Nombre);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                Console.WriteLine($"❌ Error en la base de datos: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error inesperado: {ex.Message}");
                throw;
            }
        }
    }
}
