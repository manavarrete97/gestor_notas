using gestor_notas.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
 public interface IGetEstudianteDAO
 {
 Task<EstudianteDTO> GetEstudianteByIdAsync(NpgsqlConnection connection, int id);
 Task<List<EstudianteDTO>> GetAllEstudiantesAsync(NpgsqlConnection connection);
 }
}