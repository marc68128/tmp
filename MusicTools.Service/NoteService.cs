using System;
using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Domain.Exception;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class NoteService : INoteService
    {
        private readonly IKeyService _keyService; 

        public NoteService(IKeyService keyService)
        {
            _keyService = keyService; 
        }

        public IEnumerable<Note> GetAll()
        {
            foreach (var key in Enum.GetValues(typeof(Key)).Cast<Key>())
            {
                foreach (var alteration in Enum.GetValues(typeof(Alteration)).Cast<Alteration>())
                {
                    yield return new Note(key, alteration);
                }
            }
        }

        public Note GetByInterval(Note startNote, Interval interval)
        {
            var targetKey = _keyService.GetByIntervalNumber(startNote.Key, interval.Number);
            var halfStepCountBetweenStartNoteAndTargetKey = (_keyService.GetHalfStepCountBetweenTwoKey(startNote.Key, targetKey) - (int)startNote.Alteration);
            var targetHalfStepCount = GetHalfStepCountFromInterval(interval);
            var neededAlterationHalfStepCount = targetHalfStepCount - halfStepCountBetweenStartNoteAndTargetKey;
            var alteration = (Alteration)(neededAlterationHalfStepCount);
            return new Note(targetKey, alteration);
        }

        private int GetHalfStepCountFromInterval(Interval interval)
        {
            switch (interval.Number)
            {
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
                            return 12;
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
    }
}
