using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MusicTools.Data;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service;

namespace MusicTools.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicToolsContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MusicTools ;Trusted_Connection=True;MultipleActiveResultSets=true");
            var context = new MusicToolsContext(optionsBuilder.Options);
            var chordService = new ChordService(new NoteService(new KeyService(), new IntervalService()),
                new ChordQualityService(context));

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var chords = chordService.GetChords(new Note(Key.D), new Note(Key.A, Alteration.Flat), new Note(Key.C)).ToList();

            Console.WriteLine($"{sw.ElapsedMilliseconds} ms");
            Console.Read();
        }
    }
}
