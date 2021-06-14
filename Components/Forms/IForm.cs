using System.Threading.Tasks;

namespace fan_07.Components.Forms
{
    public interface IForm
    {
        Task Invalid();
        Task Valid();
    }
}