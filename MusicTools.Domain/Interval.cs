using System.Collections.Generic;
using System.Reflection.Metadata;
using MusicTools.Domain.Enum;

namespace MusicTools.Domain
{
    public class Interval
    {
        public int Id { get; set; }
        public IntervalNumber Number { get; set; }
        public IntervalQuality Quality { get; set; }

        public ICollection<ChordQualityInterval> ChordQualityIntervals { get; set; }
    }
}
