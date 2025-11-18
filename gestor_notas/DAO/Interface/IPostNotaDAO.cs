using gestor_notas.DTO;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
 public interface IPostNotaDAO
 {
 Task<bool> AddNotaAsync(NpgsqlConnection connection, NotaDTO nota);
 Task<bool> ValidateEstudianteAndMateriaExistAsync(NpgsqlConnection connection, int idEstudiante, int idMateria);
 }
}