using System;
using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.Helpers;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest.TestDataProvider.Notes
{
    class EquivalentNoteProvider
    {
        public static IEnumerable<TestCaseData> GetData()
        {
            var csv = CsvHelper.ReadCsv("TestData/Notes/EquivalentNotes.csv");
            foreach (var line in csv)
            {
                List<Domain.Note> equivalentNotes = new List<Domain.Note>();

                for (var index = 0; index < line.Length; index += 2)
                {
                    if (!string.IsNullOrWhiteSpace(line[index]))
                        equivalentNotes.Add(new Domain.Note(line[index].Parse<Key>(), line[index + 1].Parse<Alteration>()));
                }

                var combos = from note1 in equivalentNotes
                             from note2 in equivalentNotes
                             where !Equals(note1, note2)
                             select Tuple.Create(note1, note2);

                foreach (var combo in combos)
                {
                    yield return new TestCaseData(combo.Item1, combo.Item2);
                }

            }
        }
    }
}
