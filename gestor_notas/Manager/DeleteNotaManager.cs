using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
 public class DeleteNotaManager : IDeleteNotaManager
 {
 private readonly IPostgresConnection _postgresConnection;
 private readonly IDeleteNotaDAO _deleteNotaDAO;

 public DeleteNotaManager(IPostgresConnection postgresConnection, IDeleteNotaDAO deleteNotaDAO)
 {
 _postgresConnection = postgresConnection;
 _deleteNotaDAO = deleteNotaDAO;
 }

 public async Task<bool> DeleteNotaAsync(int idNota, int idProfesor)
 {
 try
 {
 using (var connection = _postgresConnection.GetConnection())
 {
 var isValid = await _deleteNotaDAO.ValidateProfesorForMateriaAsync(connection, idProfesor, idNota);
 if (!isValid)
 {
 throw new Exception("El profesor no está autorizado para esta materia.");
 }

 return await _deleteNotaDAO.DeleteNotaAsync(connection, idNota, idProfesor);
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al eliminar la nota: {ex.Message}", ex);
 }
 }
 }
}