using System.Collections.Generic;
using MusicTools.Domain;

namespace MusicTools.Service.Contracts
{
    public interface IChordService
    {
        Chord GetChord(Note fundamental, ChordQuality chordQuality);
        IEnumerable<Chord> GetChords(Note fundamental, IEnumerable<ChordQuality> chordQuality);
        IEnumerable<Chord> GetChords(Note n1, Note n2, Note n3);
    }
}