using gestor_notas.DTO;
using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
    public class PostMateriaDAO : IPostMateriaDAO
    {
        public async Task<bool> AddMateriaAsync(NpgsqlConnection connection, MateriaDTO materia)
        {
            try
            {
                var query = "INSERT INTO materia (nombre, id_profesor) VALUES (@nombre, @id_profesor);";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", materia.Nombre);
                    command.Parameters.AddWithValue("@id_profesor", materia.IdProfesor);

                    var result = await command.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar la materia: {ex.Message}", ex);
            }
        }
    }
}