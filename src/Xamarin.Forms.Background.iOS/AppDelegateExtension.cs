
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Forms.Background.iOS
{
    public class BackgroundAggregator
    {
        public static void Init(FormsApplicationDelegate appDelegate)
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(appDelegate, nameof(StartLongRunningTask),
                message => { BackgroundService.Instance.Start(); });
        }
    }
}