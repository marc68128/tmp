using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Domain.Enum;

namespace MusicTools.Domain.Utils
{
    public static class AlterationExtensions
    {
        public static string GetSymbol(this Alteration alteration)
        {
            switch (alteration)
            {
                case Alteration.None:
                    return "";
                case Alteration.Sharp:
                    return "♯";
                case Alteration.Flat:
                    return "♭";
                case Alteration.DoubleSharp:
                    return "♯♯";
                case Alteration.DoubleFlat:
                    return "♭♭";
                case Alteration.TripleSharp:
                    return "♯♯♯";
                case Alteration.TripleFlat:
                    return "♭♭♭";
                default:
                    throw new ArgumentOutOfRangeException(nameof(alteration), alteration, null);
            }
        }
    }
}
