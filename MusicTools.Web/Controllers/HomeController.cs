using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;
using MusicTools.Web.ViewModels;

namespace MusicTools.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChordQualityService _chordQualityService;
        private readonly IChordService _chordService;
        private readonly INoteService _noteService;

        public HomeController(INoteService noteService, IChordQualityService chordQualityService, IChordService chordService)
        {
            _chordQualityService = chordQualityService;
            _chordService = chordService;
            _noteService = noteService;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.AllNotes = _noteService.GetAll().ToList();
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChordBlock(Key key, Alteration alteration)
        {
            var viewModel = new ChordBlockViewModel();
            viewModel.Chords = _chordService.GetChords(new Note(key, alteration), _chordQualityService.GetAll()).ToList();
            return PartialView("_ChordBlock", viewModel);
        }
    }
}
