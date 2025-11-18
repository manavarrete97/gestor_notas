using gestor_notas.DTO;
using gestor_notas.Manager.Interface;
using gestor_notas.Common.Interface;
using gestor_notas.DAO.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager
{
    public class GetMateriaManager : IGetMateriaManager
    {
        private readonly IPostgresConnection _postgresConnection;
        private readonly IGetMateriaDAO _getMateriaDAO;

        public GetMateriaManager(IPostgresConnection postgresConnection, IGetMateriaDAO getMateriaDAO)
        {
            _postgresConnection = postgresConnection;
            _getMateriaDAO = getMateriaDAO;
        }

        public async Task<MateriaDTO> GetMateriaByIdAsync(int id)
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _getMateriaDAO.GetMateriaByIdAsync(connection, id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la materia por ID: {ex.Message}", ex);
            }
        }

        public async Task<List<MateriaDTO>> GetAllMateriasAsync()
        {
            try
            {
                using (var connection = _postgresConnection.GetConnection())
                {
                    return await _getMateriaDAO.GetAllMateriasAsync(connection);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la lista de materias: {ex.Message}", ex);
            }
        }
    }
}