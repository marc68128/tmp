using System.Collections.Generic;
using System.Linq;
using MusicTools.Data;
using MusicTools.Domain;
using MusicTools.Domain.Enum;

namespace MusicTools.Service.Utils
{
    public static class DbInitializer
    {
        public static void Initialize(MusicToolsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any interval.
            if (context.Intervals.Any())
                return;   // DB has been seeded

            var intervals = new[]
            {
                new Interval {Number = IntervalNumber.Second, Quality = IntervalQuality.Diminished},
                new Interval {Number = IntervalNumber.Second, Quality = IntervalQuality.Minor},
                new Interval {Number = IntervalNumber.Second, Quality = IntervalQuality.Major},
                new Interval {Number = IntervalNumber.Second, Quality = IntervalQuality.Augmented},
                new Interval {Number = IntervalNumber.Third, Quality = IntervalQuality.Diminished},
                new Interval {Number = IntervalNumber.Third, Quality = IntervalQuality.Minor},
                new Interval {Number = IntervalNumber.Third, Quality = IntervalQuality.Major},
                new Interval {Number = IntervalNumber.Third, Quality = IntervalQuality.Augmented},
                new Interval {Number = IntervalNumber.Fourth, Quality = IntervalQuality.Diminished},
                new Interval {Number = IntervalNumber.Fourth, Quality = IntervalQuality.Perfect},
                new Interval {Number = IntervalNumber.Fourth, Quality = IntervalQuality.Augmented},
                new Interval {Number = IntervalNumber.Fifth, Quality = IntervalQuality.Diminished},
                new Interval {Number = IntervalNumber.Fifth, Quality = IntervalQuality.Perfect},
                new Interval {Number = IntervalNumber.Fifth, Quality = IntervalQuality.Augmented},
                new Interval {Number = IntervalNumber.Sixth, Quality = IntervalQuality.Diminished},
                new Interval {Number = IntervalNumber.Sixth, Quality = IntervalQuality.Minor},
                new Interval {Number = IntervalNumber.Sixth, Quality = IntervalQuality.Major},
                new Interval {Number = IntervalNumber.Sixth, Quality = IntervalQuality.Augmented},
                new Interval {Number = IntervalNumber.Seventh, Quality = IntervalQuality.Diminished},
                new Interval {Number = IntervalNumber.Seventh, Quality = IntervalQuality.Minor},
                new Interval {Number = IntervalNumber.Seventh, Quality = IntervalQuality.Major},
                new Interval {Number = IntervalNumber.Seventh, Quality = IntervalQuality.Augmented},
            };

            foreach (var interval in intervals)
                context.Intervals.Add(interval);

            context.SaveChanges();

            var chordQualities = new[]
            {
                new ChordQuality {Name = "Maj", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id}
                }},
                new ChordQuality {Name = "Min", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Minor).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id}
                }},
                new ChordQuality {Name = "Sus2", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Second && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id}
                }},
                new ChordQuality {Name = "Sus4", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fourth && i.Quality == IntervalQuality.Perfect).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id}
                }},
                new ChordQuality {Name = "MajB5", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Diminished).Id}
                }},
                new ChordQuality {Name = "Dim", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Minor).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Diminished).Id}
                }},
                new ChordQuality {Name = "Aug", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Augmented).Id}
                }},
                new ChordQuality {Name = "Maj6", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Sixth && i.Quality == IntervalQuality.Major).Id}
                }},
                new ChordQuality {Name = "Min6", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Minor).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Sixth && i.Quality == IntervalQuality.Major).Id}
                }},

                new ChordQuality {Name = "7", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Minor).Id}
                }},
                new ChordQuality {Name = "Maj7", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Major).Id}
                }},
                new ChordQuality {Name = "Min7", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Minor).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Minor).Id}
                }},
                new ChordQuality {Name = "7+5", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Augmented).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Minor).Id}
                }},
                new ChordQuality {Name = "dim7", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Minor).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Diminished).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Diminished).Id}
                }},
                new ChordQuality {Name = "7B5", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Diminished).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Minor).Id}
                }},
                new ChordQuality {Name = "min7B5", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Minor).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Diminished).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Minor).Id}
                }},
                new ChordQuality {Name = "9", ChordQualityIntervals = new List<ChordQualityInterval>
                {
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Third && i.Quality == IntervalQuality.Major).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Fifth && i.Quality == IntervalQuality.Perfect).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Seventh && i.Quality == IntervalQuality.Minor).Id},
                    new ChordQualityInterval{IntervalId = intervals.First(i => i.Number == IntervalNumber.Second && i.Quality == IntervalQuality.Major).Id}
                }},
            };

            foreach (var chordQuality in chordQualities)
                context.ChordQualities.Add(chordQuality);

            context.SaveChanges();


        }
    }
}
