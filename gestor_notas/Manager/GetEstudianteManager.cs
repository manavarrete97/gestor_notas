using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class GetEstudianteManager : IGetEstudianteManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IGetEstudianteDAO _getEstudianteDAO;

        public GetEstudianteManager(IPostgresConnection postgresConnection, IGetEstudianteDAO getEstudianteDAO)
        {
            _postgresConnection = postgresConnection;
            _getEstudianteDAO = getEstudianteDAO;
        }

        public async Task<EstudianteDTO> GetEstudianteByIdAsync(int id)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _getEstudianteDAO.GetEstudianteByIdAsync(connection, id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el estudiante por ID: {ex.Message}", ex);
            }
        }

        public async Task<List<EstudianteDTO>> GetAllEstudiantesAsync()
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _getEstudianteDAO.GetAllEstudiantesAsync(connection);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la lista de estudiantes: {ex.Message}", ex);
            }
        }
    }
}