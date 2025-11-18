using gestor_notas.DTO;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
 public interface IGetNotaDAO
 {
 Task<NotaDTO> GetNotaByEstudianteAndMateriaAsync(NpgsqlConnection connection, int idEstudiante, int idMateria);
 Task<List<NotaDTO>> GetNotasByMateriaAsync(NpgsqlConnection connection, int idMateria);
 Task<List<NotaDTO>> GetNotasByMateriaWithDetailsAsync(NpgsqlConnection connection, int idMateria);
 }
}