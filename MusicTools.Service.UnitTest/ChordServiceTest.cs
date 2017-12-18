using MusicTools.Domain;
using MusicTools.Domain.Enum;
using NUnit.Framework;

namespace MusicTools.Service.UnitTest
{
    [TestFixture]
    class ChordServiceTest
    {
        private ChordService _chordService;

        [SetUp]
        public void SetUp()
        {
            _chordService = new ChordService();
        }

        //[Test]
        //[TestCase(Key.C, Alteration.None, ChordQuality.Maj, Key.E, Alteration.None, Key.G, Alteration.None)]
        //[TestCase(Key.D, Alteration.Sharp, ChordQuality.Min, Key.F, Alteration.Sharp, Key.A, Alteration.Sharp)]
        //[TestCase(Key.E, Alteration.Flat, ChordQuality.Aug, Key.G, Alteration.None, Key.B, Alteration.None)]
        //[TestCase(Key.F, Alteration.None, ChordQuality.Dim, Key.A, Alteration.Flat, Key.C, Alteration.Flat)]
        //[TestCase(Key.G, Alteration.Sharp, ChordQuality.MajB5, Key.B, Alteration.Sharp, Key.D, Alteration.None)]
        //[TestCase(Key.A, Alteration.Flat, ChordQuality.Sus2, Key.B, Alteration.Flat, Key.E, Alteration.Flat)]
        //[TestCase(Key.B, Alteration.None, ChordQuality.Sus4, Key.E, Alteration.None, Key.F, Alteration.Sharp)]
        //public void Test_GetChordTriade(Key fundamental, Alteration fundamentalAlteration, ChordQuality chordQuality, 
        //    Key expectedNoteKey1, Alteration expectedNoteAlteration1, 
        //    Key expectedNoteKey2, Alteration expectedNoteAlteration2)
        //{
        //    var chord = _chordService.GetChord(new Note(fundamental, fundamentalAlteration), chordQuality);
        //    var expectedNotes = new []
        //    {
        //        new Note(expectedNoteKey1, expectedNoteAlteration1),
        //        new Note(expectedNoteKey2, expectedNoteAlteration2)
        //    };
        
        //    Assert.That(chord.Notes.Length, Is.EqualTo(expectedNotes.Length));

        //    Assert.That(chord.Fundamental.Key, Is.EqualTo(fundamental));
        //    Assert.That(chord.Fundamental.Alteration, Is.EqualTo(fundamentalAlteration));

        //    foreach (var expectedNote in expectedNotes)
        //    {
        //        Assert.Contains(expectedNote, chord.Notes);
        //    }
        //}
    }
}