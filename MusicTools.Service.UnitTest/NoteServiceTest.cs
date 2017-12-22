﻿using MusicTools.Domain;
using MusicTools.Domain.Enum;
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
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.C, Alteration.Flat, Key.D, Alteration.DoubleFlat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.C, Alteration.None, Key.D, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.C, Alteration.Sharp, Key.D, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.D, Alteration.Flat, Key.E, Alteration.DoubleFlat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.D, Alteration.None, Key.E, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.D, Alteration.Sharp, Key.E, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.E, Alteration.Flat, Key.F, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.E, Alteration.None, Key.F, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.E, Alteration.Sharp, Key.F, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.F, Alteration.Flat, Key.G, Alteration.DoubleFlat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.F, Alteration.None, Key.G, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.F, Alteration.Sharp, Key.G, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.G, Alteration.Flat, Key.A, Alteration.DoubleFlat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.G, Alteration.None, Key.A, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.G, Alteration.Sharp, Key.A, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.A, Alteration.Flat, Key.B, Alteration.DoubleFlat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.A, Alteration.None, Key.B, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.A, Alteration.Sharp, Key.B, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.B, Alteration.Flat, Key.C, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.B, Alteration.None, Key.C, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Minor, Key.B, Alteration.Sharp, Key.C, Alteration.Sharp)]

        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.C, Alteration.Flat, Key.D, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.C, Alteration.None, Key.D, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.C, Alteration.Sharp, Key.D, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.D, Alteration.Flat, Key.E, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.D, Alteration.None, Key.E, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.D, Alteration.Sharp, Key.E, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.E, Alteration.Flat, Key.F, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.E, Alteration.None, Key.F, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.E, Alteration.Sharp, Key.F, Alteration.DoubleSharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.F, Alteration.Flat, Key.G, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.F, Alteration.None, Key.G, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.F, Alteration.Sharp, Key.G, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.G, Alteration.Flat, Key.A, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.G, Alteration.None, Key.A, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.G, Alteration.Sharp, Key.A, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.A, Alteration.Flat, Key.B, Alteration.Flat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.A, Alteration.None, Key.B, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.A, Alteration.Sharp, Key.B, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.B, Alteration.Flat, Key.C, Alteration.None)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.B, Alteration.None, Key.C, Alteration.Sharp)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Major, Key.B, Alteration.Sharp, Key.C, Alteration.DoubleSharp)]

        [TestCase(IntervalNumber.Second, IntervalQuality.Diminished, Key.C, Alteration.None, Key.D, Alteration.DoubleFlat)]
        [TestCase(IntervalNumber.Second, IntervalQuality.Augmented, Key.B, Alteration.None, Key.C, Alteration.DoubleSharp)]

        [TestCase(IntervalNumber.Third, IntervalQuality.Diminished, Key.A, Alteration.None, Key.C, Alteration.Flat)]
        [TestCase(IntervalNumber.Third, IntervalQuality.Minor, Key.D, Alteration.None, Key.F, Alteration.None)]
        [TestCase(IntervalNumber.Third, IntervalQuality.Major, Key.E, Alteration.Flat, Key.G, Alteration.None)]
        [TestCase(IntervalNumber.Third, IntervalQuality.Augmented, Key.B, Alteration.Sharp, Key.D, Alteration.TripleSharp)]

        [TestCase(IntervalNumber.Fourth, IntervalQuality.Diminished, Key.A, Alteration.None, Key.D, Alteration.Flat)]
        [TestCase(IntervalNumber.Fourth, IntervalQuality.Perfect, Key.E, Alteration.Flat, Key.A, Alteration.Flat)]
        [TestCase(IntervalNumber.Fourth, IntervalQuality.Augmented, Key.B, Alteration.Sharp, Key.E, Alteration.DoubleSharp)]

        [TestCase(IntervalNumber.Fifth, IntervalQuality.Diminished, Key.A, Alteration.None, Key.E, Alteration.Flat)]
        [TestCase(IntervalNumber.Fifth, IntervalQuality.Perfect, Key.E, Alteration.Flat, Key.B, Alteration.Flat)]
        [TestCase(IntervalNumber.Fifth, IntervalQuality.Augmented, Key.B, Alteration.Sharp, Key.F, Alteration.TripleSharp)]

        [TestCase(IntervalNumber.Sixth, IntervalQuality.Diminished, Key.A, Alteration.None, Key.F, Alteration.Flat)]
        [TestCase(IntervalNumber.Sixth, IntervalQuality.Minor, Key.D, Alteration.None, Key.B, Alteration.Flat)]
        [TestCase(IntervalNumber.Sixth, IntervalQuality.Major, Key.E, Alteration.Flat, Key.C, Alteration.None)]
        [TestCase(IntervalNumber.Sixth, IntervalQuality.Augmented, Key.B, Alteration.Sharp, Key.G, Alteration.TripleSharp)]

        [TestCase(IntervalNumber.Seventh, IntervalQuality.Diminished, Key.A, Alteration.None, Key.G, Alteration.Flat)]
        [TestCase(IntervalNumber.Seventh, IntervalQuality.Minor, Key.D, Alteration.None, Key.C, Alteration.None)]
        [TestCase(IntervalNumber.Seventh, IntervalQuality.Major, Key.E, Alteration.Flat, Key.D, Alteration.None)]
        [TestCase(IntervalNumber.Seventh, IntervalQuality.Augmented, Key.B, Alteration.Sharp, Key.A, Alteration.TripleSharp)]
        public void Test_GetByInterval(IntervalNumber intervalNumber, IntervalQuality intervalQuality, Key inputKey, Alteration inputAlteration, Key expectedKey, Alteration expectedAlteration)
        {
            var result = _noteService.GetByInterval(new Note(inputKey, inputAlteration), new Interval { Number = intervalNumber, Quality = intervalQuality });
            Assert.That(result.Key, Is.EqualTo(expectedKey));
            Assert.That(result.Alteration, Is.EqualTo(expectedAlteration));
        }

        [TestCase(Key.C, Alteration.None, 4, Key.E, Alteration.None)]
        public void Test_GetByHalfStepCount(Key inputKey, Alteration inputAlteration, int halfStepCount, Key expectedKey, Alteration expectedAlteration)
        {
            var res = _noteService.GetByHalfStepCount(new Note(inputKey, inputAlteration), halfStepCount); 

        }

    }
}
