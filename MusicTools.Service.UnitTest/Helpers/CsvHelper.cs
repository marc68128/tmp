using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicTools.Service.UnitTest.Helpers
{
    public static class CsvHelper
    {
        public static IEnumerable<string[]> ReadCsv(string path)
        {
            var lines = File.ReadAllLines(path).Select(l => l.Split(';'));
            return lines;
        }
    }
}