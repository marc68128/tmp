﻿using System.Collections.Generic;

namespace MusicTools.Business.ViewModels.Chord
{
    public class ChordViewModel
    {
        public string Name { get; set; }
        public List<NoteViewModel> Notes { get; set; }
    }
}