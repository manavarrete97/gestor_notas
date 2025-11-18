using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class PostEstudianteManager : IPostEstudianteManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IPostEstudianteDAO _postEstudianteDAO;

        public PostEstudianteManager(IPostgresConnection postgresConnection, IPostEstudianteDAO postEstudianteDAO)
        {
            _postgresConnection = postgresConnection;
            _postEstudianteDAO = postEstudianteDAO;
        }

        public async Task<bool> AddEstudianteAsync(EstudianteDTO estudiante)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _postEstudianteDAO.AddEstudianteAsync(connection, estudiante);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el estudiante: {ex.Message}", ex);
            }
        }
    }
}