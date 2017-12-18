using System;
using System.Collections.Generic;
using System.Text;

namespace MusicTools.Domain
{
    public class ChordQuality
    {
        public string Name { get; set; }
        public ICollection<ChordQualityInterval> ChordQualityIntervals { get; set; }
    }
}
