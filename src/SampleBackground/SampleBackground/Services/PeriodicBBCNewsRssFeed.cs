using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Background;

namespace SampleBackground.Services
{
    public class PeriodicBBCNewsRssFeed : BaseRssFeed
    {
        public PeriodicBBCNewsRssFeed(int minutes) 
            : base(minutes, "http://feeds.bbci.co.uk/news/rss.xml")
        {
        }
    }
}
