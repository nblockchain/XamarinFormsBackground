
namespace Xamarin.Forms.Background.Gtk
{
    /// <summary>
    /// BackgroundAggregator
    /// </summary>
    public class BackgroundAggregator
    {
        private static readonly BackgroundGtkObject ObjBackgroundGtkObject = new BackgroundGtkObject();

        public static void Init()
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(ObjBackgroundGtkObject, nameof(StartLongRunningTask),
                message => { BackgroundSharedService.Instance.Start(); });
        }
    }
}
