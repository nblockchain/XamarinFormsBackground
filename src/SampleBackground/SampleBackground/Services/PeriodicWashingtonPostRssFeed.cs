using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Background;

namespace SampleBackground.Services
{
    public class PeriodicWashingtonPostRssFeed : BaseRssFeed
    {
        public PeriodicWashingtonPostRssFeed(int minutes) 
            : base(minutes, "http://feeds.washingtonpost.com/rss/world")
        {
        }
    }
}
