using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Data;
using MusicTools.Domain;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class ChordQualityService : IChordQualityService
    {
        private readonly MusicToolsContext _context;
        private readonly bool _shouldDisposeContext; 

        public ChordQualityService(MusicToolsContext context = null)
        {
            _context = context ?? new MusicToolsContext();
            _shouldDisposeContext = context == null; 
        }
        public IEnumerable<ChordQuality> GetAll()
        {
            return _context.ChordQualities;
        }

        ~ChordQualityService()
        {
            if (_shouldDisposeContext)
            {
                _context.Dispose();
            }
        }
    }
}
