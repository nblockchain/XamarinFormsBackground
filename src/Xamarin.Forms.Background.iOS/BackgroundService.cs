using System;
using UIKit;

namespace Xamarin.Forms.Background.iOS
{
    public class BackgroundService
    {
        private static nint _taskId;
        private static BackgroundService _instance;
        private static bool _isRunning;

        static BackgroundService()
        {
        }

        private BackgroundService()
        {
        }

        /// <summary>
        /// Single Instance of BackgroundService
        /// </summary>
        public static BackgroundService Instance { get; } =
            _instance ?? (_instance = new BackgroundService());

        /// <summary>
        /// Start the execution of background service
        /// </summary>
        public void Start()
        {
            if(_isRunning) return;

            //We only have 3 minutes in the background service as per iOS 9
            _taskId = UIApplication.SharedApplication.BeginBackgroundTask(nameof(StartLongRunningTask), Stop);
            BackgroundAggregatorService.Instance.Start();

            _isRunning = true;
        }

        public void Stop()
        {
        }
    }
}