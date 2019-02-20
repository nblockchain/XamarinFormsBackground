
namespace Matcha.BackgroundService
{
    public class MatchaBackgroundSharedService
    {
        private static MatchaBackgroundSharedService _instance;

        static MatchaBackgroundSharedService()
        {
        }

        private MatchaBackgroundSharedService()
        {
        }

        /// <summary>
        /// Single Instance of MatchaBackgroundService
        /// </summary>
        public static MatchaBackgroundSharedService Instance { get; } =
            _instance ?? (_instance = new MatchaBackgroundSharedService());


        /// <summary>
        /// Start the execution of background service
        /// </summary>
        public void Start()
        {
            BackgroundAggregatorService.Instance.Start();
        }
    }
}
