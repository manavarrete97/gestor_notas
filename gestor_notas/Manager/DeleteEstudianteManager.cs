using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class DeleteEstudianteManager : IDeleteEstudianteManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IDeleteEstudianteDAO _deleteEstudianteDAO;

        public DeleteEstudianteManager(IPostgresConnection postgresConnection, IDeleteEstudianteDAO deleteEstudianteDAO)
        {
            _postgresConnection = postgresConnection;
            _deleteEstudianteDAO = deleteEstudianteDAO;
        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _deleteEstudianteDAO.DeleteEstudianteAsync(connection, id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el estudiante: {ex.Message}", ex);
            }
        }
    }
}