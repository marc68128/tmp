using System;
using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Domain.Exception;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class IntervalService : IIntervalService
    {
        public IEnumerable<IntervalNumber> GetAllIntervalNumbers()
        {
            return Enum.GetValues(typeof(IntervalNumber)).Cast<IntervalNumber>();
        }
        public IEnumerable<IntervalQuality> GetAllIntervalQualities()
        {
            return Enum.GetValues(typeof(IntervalQuality)).Cast<IntervalQuality>();
        }

        public int GetHalfStepCountFromInterval(Interval interval)
        {
            switch (interval.Number)
            {
                case IntervalNumber.Fundamental:
                    switch (interval.Quality)
                    {
                        case IntervalQuality.Perfect:
                            return 0;
                        case IntervalQuality.Augmented:
                            return 1;
                        case IntervalQuality.Diminished:
                            return 11;
                        case IntervalQuality.Major:
                        case IntervalQuality.Minor:
                            throw new NotExistingIntervalException(
                                $"Interval {interval.Number} {interval.Quality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(interval.Quality), interval.Quality, null);
                    }
                case IntervalNumber.Second:
                    switch (interval.Quality)
                    {
                        case IntervalQuality.Major:
                            return 2;
                        case IntervalQuality.Minor:
                            return 1;
                        case IntervalQuality.Augmented:
                            return 3;
                        case IntervalQuality.Diminished:
                            return 0;
                        case IntervalQuality.Perfect:
                            throw new NotExistingIntervalException($"Interval {interval.Number} {interval.Quality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(interval.Number), interval.Quality, null);
                    }
                case IntervalNumber.Third:
                    switch (interval.Quality)
                    {
                        case IntervalQuality.Major:
                            return 4;
                        case IntervalQuality.Minor:
                            return 3;
                        case IntervalQuality.Augmented:
                            return 5;
                        case IntervalQuality.Diminished:
                            return 2;
                        case IntervalQuality.Perfect:
                            throw new NotExistingIntervalException($"Interval {interval.Number} {interval.Quality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(interval.Quality), interval.Quality, null);
                    }
                case IntervalNumber.Fourth:
                    switch (interval.Quality)
                    {
                        case IntervalQuality.Perfect:
                            return 5;
                        case IntervalQuality.Augmented:
                            return 6;
                        case IntervalQuality.Diminished:
                            return 4;
                        case IntervalQuality.Major:
                        case IntervalQuality.Minor:
                            throw new NotExistingIntervalException($"Interval {interval.Number} {interval.Quality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(interval.Quality), interval.Quality, null);
                    }
                case IntervalNumber.Fifth:
                    switch (interval.Quality)
                    {
                        case IntervalQuality.Perfect:
                            return 7;
                        case IntervalQuality.Augmented:
                            return 8;
                        case IntervalQuality.Diminished:
                            return 6;
                        case IntervalQuality.Major:
                        case IntervalQuality.Minor:
                            throw new NotExistingIntervalException($"Interval {interval.Number} {interval.Quality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(interval.Quality), interval.Quality, null);
                    }
                case IntervalNumber.Sixth:
                    switch (interval.Quality)
                    {
                        case IntervalQuality.Major:
                            return 9;
                        case IntervalQuality.Minor:
                            return 8;
                        case IntervalQuality.Augmented:
                            return 10;
                        case IntervalQuality.Diminished:
                            return 7;
                        case IntervalQuality.Perfect:
                            throw new NotExistingIntervalException($"Interval {interval.Number} {interval.Quality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(interval.Quality), interval.Quality, null);
                    }
                case IntervalNumber.Seventh:
                    switch (interval.Quality)
                    {
                        case IntervalQuality.Major:
                            return 11;
                        case IntervalQuality.Minor:
                            return 10;
                        case IntervalQuality.Augmented:
                            return 0;
                        case IntervalQuality.Diminished:
                            return 9;
                        case IntervalQuality.Perfect:
                            throw new NotExistingIntervalException($"Interval {interval.Number} {interval.Quality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(interval.Quality), interval.Quality, null);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(interval.Number), interval.Number, null);
            }
        }

        public IEnumerable<Interval> GetIntervalsFromHalfStepCount(int halfStepCount)
        {
            switch ((halfStepCount + 12) % 12)
            {
                case 0:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Fundamental, Quality = IntervalQuality.Perfect},
                        new Interval{Number = IntervalNumber.Second, Quality = IntervalQuality.Diminished},
                        new Interval{Number = IntervalNumber.Seventh, Quality = IntervalQuality.Augmented}
                    };
                case 1:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Second, Quality = IntervalQuality.Minor},
                        new Interval{Number = IntervalNumber.Fundamental, Quality = IntervalQuality.Augmented}
                    };
                case 2:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Second, Quality = IntervalQuality.Major},
                        new Interval{Number = IntervalNumber.Third, Quality = IntervalQuality.Diminished}
                    };
                case 3:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Third, Quality = IntervalQuality.Minor},
                        new Interval{Number = IntervalNumber.Second, Quality = IntervalQuality.Augmented}
                    };
                case 4:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Third, Quality = IntervalQuality.Major},
                        new Interval{Number = IntervalNumber.Fourth, Quality = IntervalQuality.Diminished}
                    };
                case 5:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Third, Quality = IntervalQuality.Augmented},
                        new Interval{Number = IntervalNumber.Fourth, Quality = IntervalQuality.Perfect},
                        new Interval{Number = IntervalNumber.Sixth, Quality = IntervalQuality.Diminished}
                    };
                case 6:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Fourth, Quality = IntervalQuality.Augmented},
                        new Interval{Number = IntervalNumber.Fifth, Quality = IntervalQuality.Diminished}
                    };
                case 7:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Fifth, Quality = IntervalQuality.Perfect},
                        new Interval{Number = IntervalNumber.Sixth, Quality = IntervalQuality.Diminished}
                    };
                case 8:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Sixth, Quality = IntervalQuality.Minor},
                        new Interval{Number = IntervalNumber.Fifth, Quality = IntervalQuality.Augmented}
                    };
                case 9:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Sixth, Quality = IntervalQuality.Major},
                        new Interval{Number = IntervalNumber.Seventh, Quality = IntervalQuality.Diminished}
                    };
                case 10:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Seventh, Quality = IntervalQuality.Minor},
                        new Interval{Number = IntervalNumber.Sixth, Quality = IntervalQuality.Augmented}
                    };
                case 11:
                    return new List<Interval>
                    {
                        new Interval{Number = IntervalNumber.Seventh, Quality = IntervalQuality.Major},
                        new Interval{Number = IntervalNumber.Fundamental, Quality = IntervalQuality.Diminished}
                    };
            }

            throw new ArgumentException();
        }
    }
}