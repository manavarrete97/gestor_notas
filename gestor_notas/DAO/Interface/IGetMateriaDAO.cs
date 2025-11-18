using gestor_notas.DTO;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
    public interface IGetMateriaDAO
    {
        Task<MateriaDTO> GetMateriaByIdAsync(NpgsqlConnection connection, int id);
        Task<List<MateriaDTO>> GetAllMateriasAsync(NpgsqlConnection connection);
    }
}