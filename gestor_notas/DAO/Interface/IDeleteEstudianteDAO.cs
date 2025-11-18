using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
    public interface IDeleteEstudianteDAO
    {
        Task<bool> DeleteEstudianteAsync(NpgsqlConnection connection, int id);
    }
}