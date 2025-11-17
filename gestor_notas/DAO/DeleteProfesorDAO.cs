using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using System;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO
{
 public class DeleteProfesorDAO : IDeleteProfesorDAO
 {
 public async Task<bool> DeleteProfesorAsync(NpgsqlConnection connection, int id)
 {
 try
 {
 var query = "DELETE FROM Profesor WHERE id = @id;";

 using (var command = new NpgsqlCommand(query, connection))
 {
 command.Parameters.AddWithValue("@id", id);

 var result = await command.ExecuteNonQueryAsync();
 return result > 0;
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al eliminar el profesor: {ex.Message}", ex);
 }
 }
 }
}