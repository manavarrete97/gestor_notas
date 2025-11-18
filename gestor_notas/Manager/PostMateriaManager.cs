using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class PostMateriaManager : IPostMateriaManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IPostMateriaDAO _postMateriaDAO;

        public PostMateriaManager(IPostgresConnection postgresConnection, IPostMateriaDAO postMateriaDAO)
        {
            _postgresConnection = postgresConnection;
            _postMateriaDAO = postMateriaDAO;
        }

        public async Task<bool> AddMateriaAsync(MateriaDTO materia)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _postMateriaDAO.AddMateriaAsync(connection, materia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar la materia: {ex.Message}", ex);
            }
        }
    }
}