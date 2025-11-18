using gestor_notas.DTO;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
    public interface IUpdateEstudianteDAO
    {
        Task<bool> UpdateEstudianteAsync(NpgsqlConnection connection, EstudianteDTO estudiante);
    }
}