using gestor_notas.DTO;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
    public interface IUpdateMateriaDAO
    {
        Task<bool> UpdateMateriaAsync(NpgsqlConnection connection, MateriaDTO materia);
    }
}