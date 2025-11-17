using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using System;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO
{
 public class UpdateProfesorDAO : IUpdateProfesorDAO
 {
 public async Task<bool> UpdateProfesorAsync(NpgsqlConnection connection, ProfesorDTO profesorDTO)
 {
 try
 {
 var query = "UPDATE Profesor SET nombre = @nombre WHERE id = @id;";

 using (var command = new NpgsqlCommand(query, connection))
 {
 command.Parameters.AddWithValue("@id", profesorDTO.Id);
 command.Parameters.AddWithValue("@nombre", profesorDTO.Nombre);

 var result = await command.ExecuteNonQueryAsync();
 return result > 0;
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al actualizar el profesor: {ex.Message}", ex);
 }
 }
 }
}