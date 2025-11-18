using System.Threading.Tasks;

namespace gestor_notas.Manager.Interface
{
    public interface IDeleteEstudianteManager
    {
        Task<bool> DeleteEstudianteAsync(int id);
    }
}