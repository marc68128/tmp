using System;
using System.Linq;
using MusicTools.Domain.Enum;
using MusicTools.Service.UnitTest.TestDataProvider.Keys;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest
{

    [TestFixture]
    class KeyServiceTest
    {
        private KeyService _keyService;

        [SetUp]
        public void SetUp()
        {
            _keyService = new KeyService();
        }

        [Test]
        [TestCase(Key.C, Key.D)]
        [TestCase(Key.D, Key.E)]
        [TestCase(Key.E, Key.F)]
        [TestCase(Key.F, Key.G)]
        [TestCase(Key.G, Key.A)]
        [TestCase(Key.A, Key.B)]
        [TestCase(Key.B, Key.C)]
        public void Test_GetNextKey(Key input, Key expectedOutput)
        {
            var output = _keyService.GetNextKey(input); 
            Assert.That(output, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase(Key.C, Key.B)]
        [TestCase(Key.D, Key.C)]
        [TestCase(Key.E, Key.D)]
        [TestCase(Key.F, Key.E)]
        [TestCase(Key.G, Key.F)]
        [TestCase(Key.A, Key.G)]
        [TestCase(Key.B, Key.A)]
        public void Test_GetPreviousKey(Key input, Key expectedOutput)
        {
            var output = _keyService.GetPreviousKey(input);
            Assert.That(output, Is.EqualTo(expectedOutput));
        }



        [TestCaseSource(typeof(HalfStepCountBetweenKeysProvider), nameof(HalfStepCountBetweenKeysProvider.GetData))]
        public void Test_GetHalfStepCountBetweenTwoKey(Key key1, Key key2, int expectedHalfStepCount)
        {
            var halfStepCount = _keyService.GetHalfStepCountBetweenTwoKey(key1, key2); 
            Assert.That(halfStepCount, Is.EqualTo(expectedHalfStepCount));
        }

        [TestCaseSource(typeof(KeyByIntervalNumberProvider), nameof(KeyByIntervalNumberProvider.GetData))]
        public void Test_GetByIntervalNumber(Key inputKey, IntervalNumber interval, Key expectedKey)
        {
            var key = _keyService.GetByIntervalNumber(inputKey, interval); 
            Assert.That(key, Is.EqualTo(expectedKey));
        }

        [Test]
        public void Test_GetAll()
        {
            var all = _keyService.GetAll();
            var expected = Enum.GetValues(typeof(Key)).Cast<Key>();
            Assert.That(all, Is.EquivalentTo(expected));
        }
    }
}
