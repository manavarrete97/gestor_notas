using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
 public class UpdateProfesorManager : IUpdateProfesorManager
 {
 private readonly IPostgresConnection _postgresConnection;
 private readonly IUpdateProfesorDAO _updateProfesorDAO;

 public UpdateProfesorManager(IPostgresConnection postgresConnection, IUpdateProfesorDAO updateProfesorDAO)
 {
 _postgresConnection = postgresConnection;
 _updateProfesorDAO = updateProfesorDAO;
 }

 public async Task<bool> UpdateProfesorAsync(ProfesorDTO profesorDTO)
 {
 try
 {
 using (var connection = _postgresConnection.GetConnection())
 {
 return await _updateProfesorDAO.UpdateProfesorAsync(connection, profesorDTO);
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al actualizar el profesor: {ex.Message}", ex);
 }
 }
 }
}