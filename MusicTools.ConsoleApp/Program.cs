using System;
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

            var chords = chordService.GetChords(new Note(Key.C), new Note(Key.E, Alteration.Flat), new Note(Key.G)).ToList();
            Console.WriteLine("Hello World!");
        }
    }
}
