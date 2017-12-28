using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Domain.EqualityComparer;
using MusicTools.Service.Contracts;
using MusicTools.Service.Utils;

namespace MusicTools.Service
{
    public class ChordService : IChordService
    {
        private readonly INoteService _noteService;
        private readonly IChordQualityService _chordQualityService;

        public ChordService(INoteService noteService, IChordQualityService chordQualityService)
        {
            _noteService = noteService;
            _chordQualityService = chordQualityService;
        }

        public Chord GetChord(Note fundamental, ChordQuality chordQuality)
        {
            return new Chord(chordQuality, fundamental, chordQuality.ChordQualityIntervals.Select(cqi => _noteService.GetByInterval(fundamental, cqi.Interval)).ToArray());
        }

        public IEnumerable<Chord> GetChords(Note fundamental, IEnumerable<ChordQuality> chordQualities)
        {
            return chordQualities.Select(chordQuality => GetChord(fundamental, chordQuality));
        }

        public IEnumerable<Chord> GetChordsStrict(Note n1, Note n2, Note n3, List<ChordQuality> allChordQualities = null)
        {
            allChordQualities = allChordQualities ?? _chordQualityService.GetAll().ToList();

            if (Math.Abs((int)n1.Alteration) < 2)
            {
                var intervalsN1 = from a in _noteService.GetIntervalsBetween2Notes(n1, n2)
                                  from b in _noteService.GetIntervalsBetween2Notes(n1, n3)
                                  select new[] { a, b };

                foreach (var intervals in intervalsN1)
                {
                    var chordQualities = allChordQualities.Where(cq =>
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervals[0]) &&
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervals[1]));

                    foreach (var chordQuality in chordQualities)
                    {
                        yield return GetChord(n1, chordQuality);
                    }
                }
            }

            if (Math.Abs((int)n2.Alteration) < 2)
            {
                var intervalsN2 = from a in _noteService.GetIntervalsBetween2Notes(n2, n1)
                                  from b in _noteService.GetIntervalsBetween2Notes(n2, n3)
                                  select new[] { a, b };

                foreach (var intervals in intervalsN2)
                {
                    var chordQualities = allChordQualities.Where(cq =>
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervals[0]) &&
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervals[1]));

                    foreach (var chordQuality in chordQualities)
                    {
                        yield return GetChord(n2, chordQuality);
                    }
                }
            }

            if (Math.Abs((int)n3.Alteration) < 2)
            {
                var intervalsN3 = from a in _noteService.GetIntervalsBetween2Notes(n3, n1)
                                  from b in _noteService.GetIntervalsBetween2Notes(n3, n2)
                                  select new[] { a, b };

                foreach (var intervals in intervalsN3)
                {
                    var chordQualities = allChordQualities.Where(cq =>
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervals[0]) &&
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervals[1]));

                    foreach (var chordQuality in chordQualities)
                    {
                        yield return GetChord(n3, chordQuality);
                    }
                }
            }
        }

        public IEnumerable<Chord> GetChords(Note n1, Note n2, Note n3)
        {
            var notes1 = _noteService.GetEquivalentNote(n1);
            var notes2 = _noteService.GetEquivalentNote(n2);
            var notes3 = _noteService.GetEquivalentNote(n3);

            var allChordQualities = _chordQualityService.GetAll().ToList();

            var notes = from a in notes1
                        from b in notes2
                        from c in notes3
                        select new[] { a, b, c };

            return notes.SelectMany(note => GetChordsStrict(note[0], note[1], note[2], allChordQualities)).Distinct(new ChordEqualityComparer());
        }
    }
}