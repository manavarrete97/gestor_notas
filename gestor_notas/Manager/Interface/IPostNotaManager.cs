using gestor_notas.DTO;
using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
 public interface IPostNotaManager
 {
 Task<bool> AddNotaAsync(NotaDTO nota);
 }
}