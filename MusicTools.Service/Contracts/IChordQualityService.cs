using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Domain;

namespace MusicTools.Service.Contracts
{
    public interface IChordQualityService
    {
        IEnumerable<ChordQuality> GetAll();
        ChordQuality Add(ChordQuality chordQuality);
    }
}
