using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class DeleteMateriaDAO : IDeleteMateriaDAO
    {
        public async Task<bool> DeleteMateriaAsync(NpgsqlConnection connection, int id)
        {
            try
            {
                var query = "DELETE FROM materia WHERE id = @id;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la materia: {ex.Message}", ex);
            }
        }
    }
}