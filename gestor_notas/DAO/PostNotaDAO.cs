using gestor_notas.DTO;
using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
 public class PostNotaDAO : IPostNotaDAO
 {
 public async Task<bool> AddNotaAsync(NpgsqlConnection connection, NotaDTO nota)
 {
 try
 {
 var query = "INSERT INTO nota (nombre, id_materia, id_estudiante, valor) VALUES (@nombre, @idMateria, @idEstudiante, @valor);";

 using (var command = new NpgsqlCommand(query, connection))
 {
 command.Parameters.AddWithValue("@nombre", nota.Nombre);
 command.Parameters.AddWithValue("@idMateria", nota.IdMateria);
 command.Parameters.AddWithValue("@idEstudiante", nota.IdEstudiante);
 command.Parameters.AddWithValue("@valor", nota.Valor);

 var result = await command.ExecuteNonQueryAsync();
 return result >0;
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al agregar la nota: {ex.Message}", ex);
 }
 }

 public async Task<bool> ValidateEstudianteAndMateriaExistAsync(NpgsqlConnection connection, int idEstudiante, int idMateria)
 {
 try
 {
 var query = "SELECT COUNT(*) FROM estudiante e, materia m WHERE e.id = @idEstudiante AND m.id = @idMateria;";

 using (var command = new NpgsqlCommand(query, connection))
 {
 command.Parameters.AddWithValue("@idEstudiante", idEstudiante);
 command.Parameters.AddWithValue("@idMateria", idMateria);

 var count = (long)await command.ExecuteScalarAsync();
 return count >0;
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al validar estudiante y materia: {ex.Message}", ex);
 }
 }
 }
}