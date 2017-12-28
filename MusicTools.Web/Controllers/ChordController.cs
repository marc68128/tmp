using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;
using MusicTools.Web.ViewModels.Chord;
using MusicTools.Web.ViewModels.ChordFinder;

namespace MusicTools.Web.Controllers
{
    public class ChordController : Controller
    {
        private readonly IKeyService _keyService;
        private readonly IAlterationService _alterationService;
        private readonly IChordQualityService _chordQualityService;
        private readonly IChordService _chordService;
        private readonly INoteService _noteService;

        public ChordController(IKeyService keyService, IAlterationService alterationService, IChordQualityService chordQualityService, IChordService chordService, INoteService noteService)
        {
            _keyService = keyService;
            _alterationService = alterationService;
            _chordQualityService = chordQualityService;
            _chordService = chordService;
            _noteService = noteService;
        }
        public IActionResult Index()
        {
            var chordViewModel = new ChordSelectorViewModel();
            chordViewModel.Keys = _keyService.GetAll();
            chordViewModel.Alterations = _alterationService.GetAllAvailableForChord();
            chordViewModel.ChordQualities = _chordQualityService.GetAll();
            return View(chordViewModel);
        }

        public IActionResult GetChord(Key key, Alteration alteration, string chordQuality)
        {
            var dbChordQuality = _chordQualityService.GetByName(chordQuality);
            var chord = _chordService.GetChord(new Note(key, alteration), dbChordQuality);

            var vm = new ChordViewModel();
            vm.Name = chord.Name;
            vm.Notes = chord.Notes.Select((n, i) => new NoteViewModel { Note = n, Interval = dbChordQuality.ChordQualityIntervals.ElementAt(i).Interval }).ToList();
            vm.Notes.Add(new NoteViewModel
            {
                Interval = new Interval { Number = IntervalNumber.Fundamental, Quality = IntervalQuality.Perfect },
                Note = chord.Fundamental
            });
            vm.Notes = vm.Notes.OrderBy(n => n.Interval.Number).ToList();

            return PartialView("_Chord", vm);
        }
    }
}