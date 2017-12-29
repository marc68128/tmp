using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.Helpers;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest.TestDataProvider.Notes
{
    class NoteByIntervalProvider
    {
        public static IEnumerable<TestCaseData> GetData()
        {
            var csv = CsvHelper.ReadCsv("TestData/Notes/NoteByInterval.csv");
            foreach (var line in csv)
            {
                var inputNote = new Note(line[0].Parse<Key>(), line[1].Parse<Alteration>());
                var interval = new Interval{ Number = line[2].Parse<IntervalNumber>(), Quality = line[3].Parse<IntervalQuality>() };
                var expectedNote = new Note(line[4].Parse<Key>(), line[5].Parse<Alteration>());
                
                yield return new TestCaseData(inputNote, interval, expectedNote);
            }
        }
    }
}
