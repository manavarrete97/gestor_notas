using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
 public class GetNotaManager : IGetNotaManager
 {
 private readonly IPostgresConnection _postgresConnection;
 private readonly IGetNotaDAO _getNotaDAO;

 public GetNotaManager(IPostgresConnection postgresConnection, IGetNotaDAO getNotaDAO)
 {
 _postgresConnection = postgresConnection;
 _getNotaDAO = getNotaDAO;
 }

 public async Task<NotaDTO> GetNotaByEstudianteAndMateriaAsync(int idEstudiante, int idMateria)
 {
 try
 {
 using (var connection = _postgresConnection.GetConnection())
 {
 return await _getNotaDAO.GetNotaByEstudianteAndMateriaAsync(connection, idEstudiante, idMateria);
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al obtener la nota: {ex.Message}", ex);
 }
 }

 public async Task<List<NotaDTO>> GetNotasByMateriaAsync(int idMateria)
 {
 try
 {
 using (var connection = _postgresConnection.GetConnection())
 {
 return await _getNotaDAO.GetNotasByMateriaAsync(connection, idMateria);
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al obtener las notas: {ex.Message}", ex);
 }
 }

 public async Task<List<NotaDTO>> GetNotasByMateriaWithDetailsAsync(int idMateria)
 {
 try
 {
 using (var connection = _postgresConnection.GetConnection())
 {
 return await _getNotaDAO.GetNotasByMateriaWithDetailsAsync(connection, idMateria);
 }
 }
 catch (Exception ex)
 {
 throw new Exception($"Error al obtener las notas con detalles: {ex.Message}", ex);
 }
 }
 }
}