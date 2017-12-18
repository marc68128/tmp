using MusicTools.Domain.Enum;
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


        [Test]
        [TestCase(Key.C, Key.D, 2)]
        [TestCase(Key.D, Key.E, 2)]
        [TestCase(Key.E, Key.F, 1)]
        [TestCase(Key.F, Key.G, 2)]
        [TestCase(Key.G, Key.A, 2)]
        [TestCase(Key.A, Key.B, 2)]
        [TestCase(Key.B, Key.C, 1)]
        [TestCase(Key.C, Key.A, 9)]
        [TestCase(Key.C, Key.B, 11)]
        [TestCase(Key.C, Key.C, 0)]
        [TestCase(Key.C, Key.E, 4)]
        [TestCase(Key.C, Key.F, 5)]
        [TestCase(Key.C, Key.G, 7)]
        public void Test_GetInterval(Key key1, Key key2, int expectedInterval)
        {
            var interval = _keyService.GetHalfStepCountBetweenTwoKey(key1, key2); 
            Assert.That(interval, Is.EqualTo(expectedInterval));
        }
    }
}
