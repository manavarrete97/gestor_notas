using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
 public interface IDeleteNotaDAO
 {
 Task<bool> DeleteNotaAsync(NpgsqlConnection connection, int idNota, int idProfesor);
 Task<bool> ValidateProfesorForMateriaAsync(NpgsqlConnection connection, int idProfesor, int idMateria);
 }
}