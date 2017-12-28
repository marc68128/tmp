using MusicTools.Domain.Enum;

namespace MusicTools.Domain
{
    public class Chord
    {
        public Chord(ChordQuality chordQuality, Note fundamental, params Note[] notes)
        {
            ChordQuality = chordQuality;
            Fundamental = fundamental; 
            Notes = notes;
        }

        public ChordQuality ChordQuality { get; }
        public Note Fundamental { get; }
        public Note[] Notes { get; }

        public ChordType ChordType => (ChordType) (Notes.Length + 1);
        public string Name => $"{Fundamental}{ChordQuality.Name}";

        public override bool Equals(object obj)
        {
            var other = obj as Chord;
            if (other != null)
                return this.Name == other.Name;
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}