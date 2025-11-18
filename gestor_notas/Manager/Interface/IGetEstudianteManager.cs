using gestor_notas.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
 public interface IGetEstudianteManager
 {
 Task<EstudianteDTO> GetEstudianteByIdAsync(int id);
 Task<List<EstudianteDTO>> GetAllEstudiantesAsync();
 }
}