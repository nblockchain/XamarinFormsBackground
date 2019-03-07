
namespace Xamarin.Forms.Background
{
    public class BackgroundSharedService
    {
        private static BackgroundSharedService _instance;

        static BackgroundSharedService()
        {
        }

        private BackgroundSharedService()
        {
        }

        /// <summary>
        /// Single Instance of BackgroundSharedService
        /// </summary>
        public static BackgroundSharedService Instance { get; } =
            _instance ?? (_instance = new BackgroundSharedService());


        /// <summary>
        /// Start the execution of background service
        /// </summary>
        public void Start()
        {
            BackgroundAggregatorService.Instance.Start();
        }
    }
}
