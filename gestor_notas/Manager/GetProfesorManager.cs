using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class GetProfesorManager : IGetProfesorManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IGetProfesorDAO _getProfesorDAO;

        public GetProfesorManager(IPostgresConnection postgresConnection, IGetProfesorDAO getProfesorDAO)
        {
            _postgresConnection = postgresConnection;
            _getProfesorDAO = getProfesorDAO;
        }

        public async Task<ProfesorDTO> GetProfesorByIdAsync(int id)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _getProfesorDAO.GetProfesorByIdAsync(connection, id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el profesor por ID: {ex.Message}", ex);
            }
        }

        public async Task<List<ProfesorDTO>> GetAllProfesoresAsync()
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _getProfesorDAO.GetAllProfesoresAsync(connection);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la lista de profesores: {ex.Message}", ex);
            }
        }
    }
}
