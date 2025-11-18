using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
    public interface IDeleteMateriaDAO
    {
        Task<bool> DeleteMateriaAsync(NpgsqlConnection connection, int id);
    }
}