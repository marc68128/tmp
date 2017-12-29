using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.Helpers;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest.TestDataProvider.Intervals
{
    class IntervalHalfStepCountProvider
    {
        public static IEnumerable<TestCaseData> GetData()
        {
            var csv = CsvHelper.ReadCsv("TestData/Intervals/IntervalHalfStepCount.csv");
            foreach (var line in csv)
            {
                var interval = new Interval() { Number = line[0].Parse<IntervalNumber>(), Quality = line[1].Parse<IntervalQuality>() };
                var halfStepCount = int.Parse(line[2]); 
                yield return new TestCaseData(interval, halfStepCount);
            }
        }
    }
}
