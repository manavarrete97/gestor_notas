using gestor_notas.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
    public interface IGetProfesorManager
    {
        Task<ProfesorDTO> GetProfesorByIdAsync(int id);
        Task<List<ProfesorDTO>> GetAllProfesoresAsync();
    }
}
