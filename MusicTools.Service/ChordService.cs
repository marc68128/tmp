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

        public IEnumerable<Chord> GetChords(Note n1, Note n2, Note n3)
        {
            var intevalsN1N2 = _noteService.GetIntervalsBetween2Notes(n1, n2).ToList();
            var intevalsN1N3 = _noteService.GetIntervalsBetween2Notes(n1, n3).ToList();

            foreach (var intervalN1N2 in intevalsN1N2)
            {
                foreach (var intervalN1N3 in intevalsN1N3)
                {
                     var chordQualities = _chordQualityService.GetAll().Where(cq =>
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervalN1N2) &&
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervalN1N3));

                    foreach (var chordQuality in chordQualities)
                    {
                        yield return GetChord(n1, chordQuality);
                    }
                }
            }

            var intevalsN2N1 = _noteService.GetIntervalsBetween2Notes(n2, n1).ToList();
            var intevalsN2N3 = _noteService.GetIntervalsBetween2Notes(n2, n3).ToList();

            foreach (var intervalN2N1 in intevalsN2N1)
            {
                foreach (var intervalN2N3 in intevalsN2N3)
                {
                    var chordQualities = _chordQualityService.GetAll().Where(cq =>
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervalN2N1) &&
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervalN2N3));

                    foreach (var chordQuality in chordQualities)
                    {
                        yield return GetChord(n1, chordQuality);
                    }
                }
            }

            var intevalsN3N1 = _noteService.GetIntervalsBetween2Notes(n3, n1).ToList();
            var intevalsN3N2 = _noteService.GetIntervalsBetween2Notes(n3, n2).ToList();

            foreach (var intervalN3N1 in intevalsN3N1)
            {
                foreach (var intervalN3N2 in intevalsN3N2)
                {
                    var chordQualities = _chordQualityService.GetAll().Where(cq =>
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervalN3N1) &&
                        cq.ChordQualityIntervals.Select(cqi => cqi.Interval).Contains(intervalN3N2));

                    foreach (var chordQuality in chordQualities)
                    {
                        yield return GetChord(n1, chordQuality);
                    }
                }
            }
        }
    }
}