using Android.Content;

namespace Xamarin.Forms.Background.Android
{
    public class BackgroundAggregator
    {
        public static void Init(ContextWrapper context)
        {
            MessagingCenter.Subscribe<StartLongRunningTask>(context, nameof(StartLongRunningTask), message =>
            {
                var intent = new Intent(context, typeof(BackgroundService));
                context.StartService(intent);
            });

            MessagingCenter.Subscribe<StopLongRunningTask>(context, nameof(StopLongRunningTask), message =>
            {
                var intent = new Intent(context, typeof(BackgroundService));
                context.StopService(intent);
            });
        }
    }
}
