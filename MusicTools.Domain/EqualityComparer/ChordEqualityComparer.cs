using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MusicTools.Domain.EqualityComparer
{
    public class ChordEqualityComparer : IEqualityComparer<Chord>
    {
        public bool Equals(Chord x, Chord y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Chord obj)
        {
            return BitConverter.ToInt32(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(obj.Name)), 0);
        }
    }
}
