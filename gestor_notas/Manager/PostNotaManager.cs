using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class PostNotaManager : IPostNotaManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IPostNotaDAO _postNotaDAO;

        public PostNotaManager(IPostgresConnection postgresConnection, IPostNotaDAO postNotaDAO)
        {
            _postgresConnection = postgresConnection;
            _postNotaDAO = postNotaDAO;
        }

        public async Task<bool> AddNotaAsync(NotaDTO nota)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    var isValid = await _postNotaDAO.ValidateEstudianteAndMateriaExistAsync(connection, nota.IdEstudiante, nota.IdMateria);
                    if (!isValid)
                    {
                        throw new Exception("El estudiante o la materia no existen.");
                    }

                    return await _postNotaDAO.AddNotaAsync(connection, nota);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar la nota: {ex.Message}", ex);
            }
        }
    }
}