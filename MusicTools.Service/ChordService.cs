using System;
using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain;
using MusicTools.Domain.Enum;

namespace MusicTools.Service
{
    public class ChordService
    {
        private NoteService _noteService;

        public ChordService(NoteService noteService = null)
        {
            _noteService = noteService ?? new NoteService();
        }

        public Chord GetChord(Note fundamental, ChordQuality chordQuality)
        {
            return new Chord(chordQuality, fundamental, chordQuality.ChordQualityIntervals.Select(cqi => _noteService.GetByInterval(fundamental, cqi.Interval.Number, cqi.Interval.Quality)).ToArray());           
        }

        public IEnumerable<Chord> GetChords(Note fundamental)
        {
            return Enum.GetValues(typeof(ChordQuality)).Cast<ChordQuality>().Select(chordQulity => GetChord(fundamental, chordQulity));
        }
    }
}
