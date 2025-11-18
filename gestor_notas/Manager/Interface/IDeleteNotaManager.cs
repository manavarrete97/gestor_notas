using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
 public interface IDeleteNotaManager
 {
 Task<bool> DeleteNotaAsync(int idNota, int idProfesor);
 }
}