

using Windows.ApplicationModel.Background;

namespace Xamarin.Forms.Background.UWP
{
    public sealed class BackgrounService : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundAggregatorService.Instance.Start();
        }
    }
}
