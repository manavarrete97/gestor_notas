using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class PostProfesorManager : IPostProfesorManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IPostProfesorDAO _postProfesorDAO;

        public PostProfesorManager(IPostgresConnection postgresConnection, IPostProfesorDAO postProfesorDAO)
        {
            _postgresConnection = postgresConnection;
            _postProfesorDAO = postProfesorDAO;
        }

        public async Task<bool> AddProfesorAsync(ProfesorDTO profesorDTO)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _postProfesorDAO.PostProfesor(connection, profesorDTO);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding professor: {ex.Message}", ex);
            }
        }
    }
}
