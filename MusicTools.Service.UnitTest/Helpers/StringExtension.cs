using System;
using System.Collections.Generic;
using System.Text;

namespace MusicTools.Service.UnitTest.Helpers
{
    public static class StringExtension
    {
        public static T Parse<T>(this string s)
            where T : struct, IConvertible
        {
            try
            {
                return Enum.Parse<T>(s);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
