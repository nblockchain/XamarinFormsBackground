
using Xamarin.Forms.Platform.Tizen;

namespace Xamarin.Forms.Background.Tizen
{
    public class BackgroundAggregator
    {
        public static void Init(FormsApplication appDelegate)
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(appDelegate, nameof(StartLongRunningTask),
                message => { BackgroundSharedService.Instance.Start(); });
        }
    }
}
