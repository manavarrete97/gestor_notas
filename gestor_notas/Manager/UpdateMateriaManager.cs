using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class UpdateMateriaManager : IUpdateMateriaManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IUpdateMateriaDAO _updateMateriaDAO;

        public UpdateMateriaManager(IPostgresConnection postgresConnection, IUpdateMateriaDAO updateMateriaDAO)
        {
            _postgresConnection = postgresConnection;
            _updateMateriaDAO = updateMateriaDAO;
        }

        public async Task<bool> UpdateMateriaAsync(MateriaDTO materia)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _updateMateriaDAO.UpdateMateriaAsync(connection, materia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la materia: {ex.Message}", ex);
            }
        }
    }
}