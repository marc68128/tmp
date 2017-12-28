using System;
using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class NoteService : INoteService
    {
        private readonly IKeyService _keyService;
        private readonly IIntervalService _intervalService;

        public NoteService(IKeyService keyService, IIntervalService intervalService)
        {
            _keyService = keyService;
            _intervalService = intervalService;
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
            var targetHalfStepCount = _intervalService.GetHalfStepCountFromInterval(interval);
            var neededAlterationHalfStepCount = targetHalfStepCount - halfStepCountBetweenStartNoteAndTargetKey;
            var alteration = (Alteration)(neededAlterationHalfStepCount);
            return new Note(targetKey, alteration);
        }

        public IEnumerable<Note> GetByHalfStepCount(Note startNote, int halfStepCount)
        {
            var halfStepCountBetweenCAndTargetNote = (GetHalfStepCountBetween2Notes(new Note(Key.C), startNote) + halfStepCount) % 12;
            var keys = _keyService.GetAll().Where(k => Math.Min(Math.Abs((int)k - halfStepCountBetweenCAndTargetNote), Math.Abs(Math.Abs((int)k - halfStepCountBetweenCAndTargetNote) - 12)) < 4).ToList();
            foreach (var key in keys)
            {
                var halfStepCountBetweenStartNoteAndKey = _keyService.GetHalfStepCountBetweenTwoKey(startNote.Key, key) - (int)startNote.Alteration;
                var neededAlterationHalfStepCount = halfStepCountBetweenCAndTargetNote - halfStepCountBetweenStartNoteAndKey;
                if (Math.Abs(neededAlterationHalfStepCount) > 6)
                    neededAlterationHalfStepCount = (neededAlterationHalfStepCount + 12) % 12;

                var alteration = (Alteration)(neededAlterationHalfStepCount);
                yield return new Note(key, alteration);
            }
        }

        public int GetHalfStepCountBetween2Notes(Note note1, Note note2)
        {
            var halfStepCount = _keyService.GetHalfStepCountBetweenTwoKey(note1.Key, note2.Key);
            halfStepCount -= (int)note1.Alteration;
            halfStepCount += (int)note2.Alteration;
            return halfStepCount;
        }

        public IEnumerable<Interval> GetIntervalsBetween2Notes(Note note1, Note note2)
        {
            var halfStepCount = GetHalfStepCountBetween2Notes(note1, note2);
            return _intervalService.GetIntervalsFromHalfStepCount(halfStepCount);
        }

        public IEnumerable<Note> GetEquivalentNote(Note note)
        {
            var halfSetpCount = GetHalfStepCountBetween2Notes(new Note(Key.C), note);
            return GetByHalfStepCount(new Note(Key.C), halfSetpCount);
        }
    }
}