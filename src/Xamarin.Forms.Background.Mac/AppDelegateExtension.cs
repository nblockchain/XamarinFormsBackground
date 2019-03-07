
using Xamarin.Forms.Platform.MacOS;

namespace Xamarin.Forms.Background.Mac
{
    /// <summary>
    /// BackgroundAggregator
    /// </summary>
    public class BackgroundAggregator
    {
        /// <summary>
        /// Initializes the Background For Mac
        /// </summary>
        /// <param name="appDelegate"></param>
        public static void Init(FormsApplicationDelegate appDelegate)
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(appDelegate, nameof(StartLongRunningTask),
                message => { BackgroundSharedService.Instance.Start(); });
        }
    }
}
