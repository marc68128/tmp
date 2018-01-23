using System.Collections.Generic;
using MusicTools.Domain;
using MusicTools.Domain.Enum;

namespace MusicTools.Business.ViewModels.Chord
{
    public class ChordSelectorViewModel
    {
        public IEnumerable<Domain.Enum.Key> Keys { get; set; }
        public IEnumerable<Alteration> Alterations { get; set; }
        public IEnumerable<ChordQuality> ChordQualities { get; set; }
    }
}
