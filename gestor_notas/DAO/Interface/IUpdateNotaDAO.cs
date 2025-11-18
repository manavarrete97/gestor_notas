using gestor_notas.DTO;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
 public interface IUpdateNotaDAO
 {
 Task<bool> UpdateNotaAsync(NpgsqlConnection connection, int idNota, decimal valor, int idProfesor);
 Task<bool> ValidateProfesorForMateriaAsync(NpgsqlConnection connection, int idProfesor, int idMateria);
 }
}