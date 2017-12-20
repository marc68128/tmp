using System.Collections.Generic;
using MusicTools.Domain;
using MusicTools.Domain.Enum;

namespace MusicTools.Web.ViewModels.Chord
{
    public class ChordViewModel
    {
        public IEnumerable<Key> Keys { get; set; }
        public IEnumerable<Alteration> Alterations { get; set; }
        public IEnumerable<ChordQuality> ChordQualities { get; set; }
    }
}
