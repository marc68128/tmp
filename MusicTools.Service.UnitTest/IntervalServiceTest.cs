using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Domain;
using MusicTools.Service.UnitTest.TestDataProvider.Intervals;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest
{
    [TestFixture]
    class IntervalServiceTest
    {
        private IntervalService _intervalService;

        [SetUp]
        public void SetUp()
        {
            _intervalService = new IntervalService();
        }


        [TestCaseSource(typeof(IntervalHalfStepCountProvider), nameof(IntervalHalfStepCountProvider.GetData))]
        public void Test_GetHalfStepCountFromInterval(Interval inputInterval, int expectedHalfStepCount)
        {
            var halfStepCount = _intervalService.GetHalfStepCountFromInterval(inputInterval);
            Assert.That(halfStepCount, Is.EqualTo(expectedHalfStepCount));
        }

        [TestCaseSource(typeof(IntervalHalfStepCountProvider), nameof(IntervalHalfStepCountProvider.GetData))]
        public void Test_GetIntervalsFromHalfStepCount(Interval expectedInterval, int inputHalfStepCount)
        {
            var intervals = _intervalService.GetIntervalsFromHalfStepCount(inputHalfStepCount);
            Assert.That(intervals, Has.One.EqualTo(expectedInterval));
        }

    }
}
