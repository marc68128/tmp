using System;
using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.TestDataProvider.Notes;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest
{
    [TestFixture]
    class NoteServiceTest
    {
        private NoteService _noteService;

        [SetUp]
        public void SetUp()
        {
            _noteService = new NoteService(new KeyService(), new IntervalService());
        }

        [Test]
        public void Test_GetAll()
        {
            var all = _noteService.GetAll();
            var expected = 
                from key in Enum.GetValues(typeof(Key)).Cast<Key>()
                from alteration in Enum.GetValues(typeof(Alteration)).Cast<Alteration>()
                select new Note(key, alteration);
            Assert.That(all, Is.EquivalentTo(expected));
        }

        [TestCaseSource(typeof(NoteByIntervalProvider), nameof(NoteByIntervalProvider.GetData))]
        public void Test_GetByInterval(Note inputNote, Interval interval, Note expectedNote)
        {
            var result = _noteService.GetByInterval(inputNote, interval);
            Assert.That(result, Is.EqualTo(expectedNote));
        }

        [TestCaseSource(typeof(NoteByHalfStepProvider), nameof(NoteByHalfStepProvider.GetData))]
        public void Test_GetByHalfStepCount(Note inputNote, int halfStepCount, IEnumerable<Note> expectedNotes)
        {
            var res = _noteService.GetByHalfStepCount(inputNote, halfStepCount);
            Assert.That(res, Is.EquivalentTo(expectedNotes));
        }

        [TestCaseSource(typeof(EquivalentNoteProvider), nameof(EquivalentNoteProvider.GetData))]
        public void Test_GetEquivalentNote(Note inputNote, Note expectedNote)
        {
            var res = _noteService.GetEquivalentNote(inputNote);
            Assert.Contains(expectedNote, res.ToList());
        }

        [TestCaseSource(typeof(HalfStepCountBetweenTwoNotesProvider), nameof(HalfStepCountBetweenTwoNotesProvider.GetData))]
        public void Test_GetHalfStepCountBetween2Notes(Note inputNote1, Note inputNote2, int expectedHalfStepCount)
        {
            var halfStepCount = _noteService.GetHalfStepCountBetween2Notes(inputNote1, inputNote2); 
            Assert.That(halfStepCount, Is.EqualTo(expectedHalfStepCount));
        }

        [TestCaseSource(typeof(NoteByIntervalProvider), nameof(NoteByIntervalProvider.GetData))]
        public void Test_GetIntervalsBetween2Notes(Note inputNote1, Interval expectedInterval, Note inputNote2)
        {
            var interval = _noteService.GetIntervalsBetween2Notes(inputNote1, inputNote2); 
            Assert.That(interval, Has.One.EqualTo(expectedInterval));
        }
    }
}