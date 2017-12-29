using System.Collections.Generic;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.Helpers;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest.TestDataProvider.Notes
{
    class HalfStepCountBetweenTwoNotesProvider
    {
        public static IEnumerable<TestCaseData> GetData()
        {
            var csv = CsvHelper.ReadCsv("TestData/Notes/HalfStepCountBetweenTwoNotes.csv");
            foreach (var line in csv)
            {
                var note1 = new Note(line[0].Parse<Key>(), line[1].Parse<Alteration>());
                var note2 = new Note(line[2].Parse<Key>(), line[3].Parse<Alteration>());
                var expectedHalfStepCount = int.Parse(line[4]);
                yield return new TestCaseData(note1, note2, expectedHalfStepCount);
            }
        }
    }
}