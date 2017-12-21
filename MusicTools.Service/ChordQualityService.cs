using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MusicTools.Data;
using MusicTools.Domain;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class ChordQualityService : IChordQualityService
    {
        private readonly MusicToolsContext _context;

        public ChordQualityService(MusicToolsContext context)
        {
            _context = context;
        }
        public IEnumerable<ChordQuality> GetAll()
        {
            return _context.ChordQualities.Include(cq => cq.ChordQualityIntervals).ThenInclude(cqi => cqi.Interval);
        }

        public ChordQuality GetByName(string name)
        {
            return GetAll().FirstOrDefault(cq => cq.Name == name);
        }

        public ChordQuality Add(ChordQuality chordQuality)
        {
            _context.Database.EnsureCreated();
            _context.Add(chordQuality);
            _context.SaveChanges();
            return chordQuality; 
        }
    }
}