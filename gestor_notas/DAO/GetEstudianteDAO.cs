using gestor_notas.DTO;
using gestor_notas.DAO.Interface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.DAO
{
 public class GetEstudianteDAO : IGetEstudianteDAO
 {
 public async Task<EstudianteDTO> GetEstudianteByIdAsync(NpgsqlConnection connection, int id)
 {
 try
 {
 var query = "SELECT id, nombre FROM estudiante WHERE id = @id;";

 using (var command = new NpgsqlCommand(query, connection))
 {
 command.Parameters.AddWithValue("@id", id);

 using (var reader = await command.ExecuteReaderAsync())
 {
 if (await reader.ReadAsync())
 {
 return new EstudianteDTO
 {
 Id = reader.GetInt32(0),
 Nombre = reader.GetString(1)
 };
 }
 }
 }
 return null;
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al obtener el estudiante por ID: {ex.Message}", ex);
 }
 }

 public async Task<List<EstudianteDTO>> GetAllEstudiantesAsync(NpgsqlConnection connection)
 {
 try
 {
 var query = "SELECT id, nombre FROM estudiante;";

 using (var command = new NpgsqlCommand(query, connection))
 {
 using (var reader = await command.ExecuteReaderAsync())
 {
 var estudiantes = new List<EstudianteDTO>();

 while (await reader.ReadAsync())
 {
 estudiantes.Add(new EstudianteDTO
 {
 Id = reader.GetInt32(0),
 Nombre = reader.GetString(1)
 });
 }

 return estudiantes;
 }
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al obtener la lista de estudiantes: {ex.Message}", ex);
 }
 }
 }
}