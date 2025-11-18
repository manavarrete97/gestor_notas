using gestor_notas.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
    public interface IGetMateriaManager
    {
        Task<MateriaDTO> GetMateriaByIdAsync(int id);
        Task<List<MateriaDTO>> GetAllMateriasAsync();
    }
}