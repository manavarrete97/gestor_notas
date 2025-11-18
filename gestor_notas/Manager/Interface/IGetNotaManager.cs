using gestor_notas.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
 public interface IGetNotaManager
 {
 Task<NotaDTO> GetNotaByEstudianteAndMateriaAsync(int idEstudiante, int idMateria);
 Task<List<NotaDTO>> GetNotasByMateriaAsync(int idMateria);
 Task<List<NotaDTO>> GetNotasByMateriaWithDetailsAsync(int idMateria);
 }
}