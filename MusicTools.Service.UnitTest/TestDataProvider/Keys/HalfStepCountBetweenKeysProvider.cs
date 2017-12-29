using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.Helpers;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest.TestDataProvider.Keys
{
    class HalfStepCountBetweenKeysProvider
    {
        public static IEnumerable<TestCaseData> GetData()
        {
            var csv = CsvHelper.ReadCsv("TestData/Keys/HalfStepCountBetweenKeys.csv");
            foreach (var line in csv)
            {
                yield return new TestCaseData(line[0].Parse<Key>(), line[1].Parse<Key>(), int.Parse(line[2]));
            }
        }
    }
}
