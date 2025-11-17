using gestor_notas.DTO;
using Npgsql;

namespace gestor_notas.DAO.Interface
{
    public interface IPostProfesorDAO
    {
        Task<bool> PostProfesor(NpgsqlConnection npgsqlConnection, ProfesorDTO postProfesorDTO);
    }
}
