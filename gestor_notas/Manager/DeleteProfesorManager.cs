using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
 public class DeleteProfesorManager : IDeleteProfesorManager
 {
 private readonly IPostgresConnection _postgresConnection;
 private readonly IDeleteProfesorDAO _deleteProfesorDAO;

 public DeleteProfesorManager(IPostgresConnection postgresConnection, IDeleteProfesorDAO deleteProfesorDAO)
 {
 _postgresConnection = postgresConnection;
 _deleteProfesorDAO = deleteProfesorDAO;
 }

 public async Task<bool> DeleteProfesorAsync(int id)
 {
 try
 {
 using (var connection = _postgresConnection.GetConnection())
 {
 return await _deleteProfesorDAO.DeleteProfesorAsync(connection, id);
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al eliminar el profesor: {ex.Message}", ex);
 }
 }
 }
}