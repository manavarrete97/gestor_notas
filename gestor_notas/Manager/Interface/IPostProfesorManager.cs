using gestor_notas.DTO;
using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
    public interface IPostProfesorManager
    {
        Task<bool> AddProfesorAsync(ProfesorDTO profesorDTO);
    }
}
