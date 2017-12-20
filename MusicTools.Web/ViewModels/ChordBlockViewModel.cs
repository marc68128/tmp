using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicTools.Domain;

namespace MusicTools.Web.ViewModels
{
    public class ChordBlockViewModel
    {
        public List<Domain.Chord> Chords { get; set; }
    }
}
