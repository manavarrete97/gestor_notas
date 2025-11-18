using gestor_notas.DTO;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
    public interface IPostMateriaDAO
    {
        Task<bool> AddMateriaAsync(NpgsqlConnection connection, MateriaDTO materia);
    }
}