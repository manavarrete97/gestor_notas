using gestor_notas.DTO;
using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class UpdateMateriaDAO : IUpdateMateriaDAO
    {
        public async Task<bool> UpdateMateriaAsync(NpgsqlConnection connection, MateriaDTO materia)
        {
            try
            {
                var query = "UPDATE materia SET nombre = @nombre, id_profesor = @id_profesor WHERE id = @id;";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", materia.Id);
                    command.Parameters.AddWithValue("@nombre", materia.Nombre);
                    command.Parameters.AddWithValue("@id_profesor", materia.IdProfesor);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la materia: {ex.Message}", ex);
            }
        }
    }
}