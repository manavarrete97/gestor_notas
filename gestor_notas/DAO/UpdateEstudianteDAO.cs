using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class UpdateEstudianteDAO : IUpdateEstudianteDAO
    {
        public async Task<bool> UpdateEstudianteAsync(NpgsqlConnection connection, EstudianteDTO estudiante)
        {
            try
            {
                var query = "UPDATE estudiante SET nombre = @nombre WHERE id = @id;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", estudiante.Id);
                    command.Parameters.AddWithValue("@nombre", estudiante.Nombre);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el estudiante: {ex.Message}", ex);
            }
        }
    }
}