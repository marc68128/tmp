using System.Collections.Generic;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.Helpers;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest.TestDataProvider.Notes
{
    class NoteByHalfStepProvider
    {
        public static IEnumerable<TestCaseData> GetData()
        {
            var csv = CsvHelper.ReadCsv("TestData/Notes/NoteByHalfStep.csv");
            foreach (var line in csv)
            {
                var startNote = new Note(line[0].Parse<Key>(), line[1].Parse<Alteration>());
                var halfStepCount = int.Parse(line[2]);
                var expectedNotes = new List<Note>();
                for (int i = 3; i < line.Length; i+=2)
                {
                    if (!string.IsNullOrWhiteSpace(line[i]))
                        expectedNotes.Add(new Domain.Note(line[i].Parse<Key>(), line[i + 1].Parse<Alteration>()));
                }
                yield return new TestCaseData(startNote, halfStepCount, expectedNotes);
            }
        }
    }
}
