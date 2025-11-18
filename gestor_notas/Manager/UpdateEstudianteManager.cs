using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class UpdateEstudianteManager : IUpdateEstudianteManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IUpdateEstudianteDAO _updateEstudianteDAO;

        public UpdateEstudianteManager(IPostgresConnection postgresConnection, IUpdateEstudianteDAO updateEstudianteDAO)
        {
            _postgresConnection = postgresConnection;
            _updateEstudianteDAO = updateEstudianteDAO;
        }

        public async Task<bool> UpdateEstudianteAsync(EstudianteDTO estudiante)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _updateEstudianteDAO.UpdateEstudianteAsync(connection, estudiante);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el estudiante: {ex.Message}", ex);
            }
        }
    }
}