using gestor_notas.DTO;
using Npgsql;
using System.Threading.Tasks;

namespace gestor_notas.DAO.Interface
{
 public interface IUpdateProfesorDAO
 {
 Task<bool> UpdateProfesorAsync(NpgsqlConnection connection, ProfesorDTO profesorDTO);
 }
}