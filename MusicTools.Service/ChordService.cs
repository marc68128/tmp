using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class ChordService : IChordService
    {
        private readonly INoteService _noteService;

        public ChordService(INoteService noteService)
        {
            _noteService = noteService;
        }

        public Chord GetChord(Note fundamental, ChordQuality chordQuality)
        {
            return new Chord(chordQuality, fundamental, chordQuality.ChordQualityIntervals.Select(cqi => _noteService.GetByInterval(fundamental, cqi.Interval)).ToArray());           
        }

        public IEnumerable<Chord> GetChords(Note fundamental, IEnumerable<ChordQuality> chordQualities)
        {
            return chordQualities.Select(chordQuality => GetChord(fundamental, chordQuality));
        }
    }
}