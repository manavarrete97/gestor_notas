using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class UpdateNotaDAO : IUpdateNotaDAO
    {
        public async Task<bool> UpdateNotaAsync(NpgsqlConnection connection, int idNota, decimal valor, int idProfesor)
        {
            try
            {
                var query = "UPDATE nota SET valor = @valor WHERE id = @idNota AND id_materia IN (SELECT id FROM materia WHERE id_profesor = @idProfesor);";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idNota", idNota);
                    command.Parameters.AddWithValue("@valor", valor);
                    command.Parameters.AddWithValue("@idProfesor", idProfesor);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la nota: {ex.Message}", ex);
            }
        }

        public async Task<bool> ValidateProfesorForMateriaAsync(NpgsqlConnection connection, int idProfesor, int idMateria)
        {
            try
            {
                var query = "SELECT COUNT(*) FROM materia WHERE id = @idMateria AND id_profesor = @idProfesor;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idMateria", idMateria);
                    command.Parameters.AddWithValue("@idProfesor", idProfesor);

                    var count = (long)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al validar el profesor para la materia: {ex.Message}", ex);
            }
        }
    }
}