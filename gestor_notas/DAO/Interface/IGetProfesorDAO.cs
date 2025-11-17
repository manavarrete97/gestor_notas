using gestor_notas.DTO;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.DAO.Interface
{
    public interface IGetProfesorDAO
    {
        Task<ProfesorDTO> GetProfesorByIdAsync(NpgsqlConnection connection, int id);
        Task<List<ProfesorDTO>> GetAllProfesoresAsync(NpgsqlConnection connection);
    }
}
