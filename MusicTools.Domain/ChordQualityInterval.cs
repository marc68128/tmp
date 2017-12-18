using System;
using System.Collections.Generic;
using System.Text;

namespace MusicTools.Domain
{
    public class ChordQualityInterval
    {
        public string ChordQualityName { get; set; }
        public ChordQuality ChordQuality { get; set; }
        public int IntervalId { get; set; }
        public Interval Interval { get; set; }
    }
}
