using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class PostEstudianteDAO : IPostEstudianteDAO
    {
        public async Task<bool> AddEstudianteAsync(NpgsqlConnection connection, EstudianteDTO estudiante)
        {
            try
            {
                var query = "INSERT INTO estudiante (nombre) VALUES (@nombre);";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", estudiante.Nombre);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el estudiante: {ex.Message}", ex);
            }
        }
    }
}