using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Matcha.BackgroundService
{
    public partial class BackgroundAggregatorService
    {
        private static BackgroundAggregatorService _instance;
        private static Dictionary<string, IBackgroundTask> _schedules = new Dictionary<string, IBackgroundTask>();

        static BackgroundAggregatorService()
        {
        }

        private BackgroundAggregatorService()
        {
        }

        public static void Add<T>(Func<T> schedule) where T: IBackgroundTask
        {
            var typeName = schedule.GetType().GetGenericArguments()[0]?.Name;

            if (typeName != null && !_schedules.ContainsKey(typeName))
                _schedules.Add(typeName, schedule());
        }

        public static void StartBackgroundService()
        {
            var message = new StartLongRunningTask();
            MessagingCenter.Send(message, nameof(StartLongRunningTask));
        }

        public static BackgroundAggregatorService Instance { get; } = _instance ?? (_instance = new BackgroundAggregatorService());

        public void Start()
        {
            foreach (var schedule in _schedules)
            {
                schedule.Value.StartJob();
            }
        }
    }
}
