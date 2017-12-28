using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;
using MusicTools.Web.ViewModels.Chord;
using MusicTools.Web.ViewModels.ChordFinder;

namespace MusicTools.Web.Controllers
{
    public class ChordFinderController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IChordService _chordService;

        public ChordFinderController(INoteService noteService, IChordService chordService)
        {
            _noteService = noteService;
            _chordService = chordService;
        }
        public IActionResult Index()
        {
            var vm = new ChordFinderViewModel();
            vm.AllNotes = Enumerable.Range(0, 12).Select(n => _noteService.GetByHalfStepCount(new Note(Key.C), n).Aggregate((curMin, x) => curMin == null || Math.Abs((int)x.Alteration) < Math.Abs((int)curMin.Alteration) ? x : curMin)).ToList();
            return View(vm);
        }

        public IActionResult GetChords(Key key1, Alteration alteration1, Key key2, Alteration alteration2, Key key3, Alteration alteration3)
        {
            var chords = _chordService.GetChords(new Note(key1, alteration1), new Note(key2, alteration2), new Note(key3, alteration3)).ToList();
            return PartialView("_ChordList", chords.Select(c => new ChordViewModel()
            {
                Name = c.Name, 
                Notes = c.Notes.Select((n,i) => new NoteViewModel
                {
                    Note = n, 
                    Interval = c.ChordQuality.ChordQualityIntervals.Select(cq => cq.Interval).ElementAt(i)
                }).ToList()
            }).ToList());

        }
    }
}