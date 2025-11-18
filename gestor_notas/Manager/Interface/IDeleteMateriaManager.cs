using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
    public interface IDeleteMateriaManager
    {
        Task<bool> DeleteMateriaAsync(int id);
    }
}