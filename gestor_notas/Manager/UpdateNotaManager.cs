using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
 public class UpdateNotaManager : IUpdateNotaManager
 {
 private readonly IPostgresConnection _postgresConnection;
 private readonly IUpdateNotaDAO _updateNotaDAO;

 public UpdateNotaManager(IPostgresConnection postgresConnection, IUpdateNotaDAO updateNotaDAO)
 {
 _postgresConnection = postgresConnection;
 _updateNotaDAO = updateNotaDAO;
 }

 public async Task<bool> UpdateNotaAsync(int idNota, decimal valor, int idProfesor)
 {
 try
 {
 using (var connection = _postgresConnection.GetConnection())
 {
 var isValid = await _updateNotaDAO.ValidateProfesorForMateriaAsync(connection, idProfesor, idNota);
 if (!isValid)
 {
 throw new Exception("El profesor no está autorizado para esta materia.");
 }

 return await _updateNotaDAO.UpdateNotaAsync(connection, idNota, valor, idProfesor);
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al actualizar la nota: {ex.Message}", ex);
 }
 }
 }
}