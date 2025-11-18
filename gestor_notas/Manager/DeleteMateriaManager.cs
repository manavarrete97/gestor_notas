using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class DeleteMateriaManager : IDeleteMateriaManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IDeleteMateriaDAO _deleteMateriaDAO;

        public DeleteMateriaManager(IPostgresConnection postgresConnection, IDeleteMateriaDAO deleteMateriaDAO)
        {
            _postgresConnection = postgresConnection;
            _deleteMateriaDAO = deleteMateriaDAO;
        }

        public async Task<bool> DeleteMateriaAsync(int id)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _deleteMateriaDAO.DeleteMateriaAsync(connection, id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la materia: {ex.Message}", ex);
            }
        }
    }
}