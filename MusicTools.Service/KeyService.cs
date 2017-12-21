using System;
using System.Collections.Generic;
using System.Linq;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class KeyService : IKeyService
    {
        public Key GetNextKey(Key key)
        {
            if (key == Key.B)
                return Key.C;

            return Enum.GetValues(typeof(Key)).Cast<Key>().First(k => (int)k > (int)key);
        }
        public Key GetPreviousKey(Key key)
        {
            if (key == Key.C)
                return Key.B;

            return Enum.GetValues(typeof(Key)).Cast<Key>().OrderByDescending(k => (int)k).First(k => (int)k < (int)key);
        }

        public Key GetByIntervalNumber(Key startKey, IntervalNumber intervalNumber)
        {
            var outKey = startKey; 
            for (int i = 0; i < (int)intervalNumber; i++)
            {
                outKey = GetNextKey(outKey);
            }
            return outKey; 
        }

        public int GetHalfStepCountBetweenTwoKey(Key k1, Key k2)
        {
            int key1 = (int) k1;
            int key2 = (int) k2;

            if (key2 < key1)
            {
                key2 += 12;
            }

            return key2 - key1;
            //return (12 + ((int)k2 - (int)k1)) % 12;
        }

        public IEnumerable<Key> GetAll()
        {
            return Enum.GetValues(typeof(Key)).Cast<Key>();
        }
    }
}