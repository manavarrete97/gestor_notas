using gestor_notas.DTO;
using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
 public interface IUpdateProfesorManager
 {
 Task<bool> UpdateProfesorAsync(ProfesorDTO profesorDTO);
 }
}