using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class DeleteEstudianteDAO : IDeleteEstudianteDAO
    {
        public async Task<bool> DeleteEstudianteAsync(NpgsqlConnection connection, int id)
        {
            try
            {
                var query = "DELETE FROM estudiante WHERE id = @id;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el estudiante: {ex.Message}", ex);
            }
        }
    }
}