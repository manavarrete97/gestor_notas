using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
 public interface IUpdateNotaManager
 {
 Task<bool> UpdateNotaAsync(int idNota, decimal valor, int idProfesor);
 }
}