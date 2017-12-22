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

        public override bool Equals(object obj)
        {
            var other = obj as Interval;
            if (other != null)
                return this.Number == other.Number && this.Quality == other.Quality;
            return base.Equals(obj);
        }
    }
}
