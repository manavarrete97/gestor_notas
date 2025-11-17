using gestor_notas.DTO;
using Npgsql;
using System.Threading.Tasks;

namespace gestor_notas.DAO.Interface
{
 public interface IDeleteProfesorDAO
 {
 Task<bool> DeleteProfesorAsync(NpgsqlConnection connection, int id);
 }
}