using MusicTools.Domain.Enum;
using MusicTools.Domain.Utils;

namespace MusicTools.Domain
{
    public class Note
    {
        public Note(Key key, Alteration alteration = Alteration.None)
        {
            Key = key; 
            Alteration = alteration;
        }
        public Key Key { get; set; }
        public Alteration Alteration { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Note;
            if (other != null)
                return this.Key == other.Key && this.Alteration == other.Alteration; 
            return base.Equals(obj);
        }

        public override string ToString()
        {
            if (Alteration == Alteration.None)
                return Key.ToString();
            return $"{Key}{Alteration.GetSymbol()}";
        }
    }
}