using System;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Domain.Exception;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class NoteService : INoteService
    {
        private readonly KeyService _keyService; 

        public NoteService(KeyService keyService = null)
        {
            _keyService = keyService ?? new KeyService(); 
        }

        public Note GetByInterval(Note startNote, IntervalNumber intervalNumber, IntervalQuality intervalQuality)
        {
            var targetKey = _keyService.GetByInterval(startNote.Key, intervalNumber);
            var halfStepCountBetweenStartNoteAndTargetKey = (_keyService.GetHalfStepCountBetweenTwoKey(startNote.Key, targetKey) - (int)startNote.Alteration);
            var targetHalfStepCount = GetHalfStepCountFromInterval(intervalNumber, intervalQuality);
            var neededAlterationHalfStepCount = targetHalfStepCount - halfStepCountBetweenStartNoteAndTargetKey;
            var alteration = (Alteration)(neededAlterationHalfStepCount);
            return new Note(targetKey, alteration);
        }


        private int GetHalfStepCountFromInterval(IntervalNumber intervalNumber, IntervalQuality intervalQuality)
        {
            switch (intervalNumber)
            {
                case IntervalNumber.Second:
                    switch (intervalQuality)
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
                            throw new NotExistingIntervalException($"IntervalNumber {intervalNumber} {intervalQuality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(intervalQuality), intervalQuality, null);
                    }
                case IntervalNumber.Third:
                    switch (intervalQuality)
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
                            throw new NotExistingIntervalException($"IntervalNumber {intervalNumber} {intervalQuality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(intervalQuality), intervalQuality, null);
                    }
                case IntervalNumber.Fourth:
                    switch (intervalQuality)
                    {
                        case IntervalQuality.Perfect:
                            return 5;
                        case IntervalQuality.Augmented:
                            return 6;
                        case IntervalQuality.Diminished:
                            return 4;
                        case IntervalQuality.Major:
                        case IntervalQuality.Minor:
                            throw new NotExistingIntervalException($"IntervalNumber {intervalNumber} {intervalQuality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(intervalQuality), intervalQuality, null);
                    }
                case IntervalNumber.Fifth:
                    switch (intervalQuality)
                    {
                        case IntervalQuality.Perfect:
                            return 7;
                        case IntervalQuality.Augmented:
                            return 8;
                        case IntervalQuality.Diminished:
                            return 6;
                        case IntervalQuality.Major:
                        case IntervalQuality.Minor:
                            throw new NotExistingIntervalException($"IntervalNumber {intervalNumber} {intervalQuality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(intervalQuality), intervalQuality, null);
                    }
                case IntervalNumber.Sixth:
                    switch (intervalQuality)
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
                            throw new NotExistingIntervalException($"IntervalNumber {intervalNumber} {intervalQuality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(intervalQuality), intervalQuality, null);
                    }
                case IntervalNumber.Seventh:
                    switch (intervalQuality)
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
                            throw new NotExistingIntervalException($"IntervalNumber {intervalNumber} {intervalQuality} does not exist");
                        default:
                            throw new ArgumentOutOfRangeException(nameof(intervalQuality), intervalQuality, null);
                    }
                default:
                    throw new ArgumentOutOfRangeException(nameof(intervalNumber), intervalNumber, null);
            }
        }
    }
}
