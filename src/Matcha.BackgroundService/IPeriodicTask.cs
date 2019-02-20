using System.Threading.Tasks;

namespace Matcha.BackgroundService
{
    public interface IBackgroundTask
    {
        Task StartJob();
    }
}
