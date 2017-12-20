using Microsoft.AspNetCore.Mvc;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;
using MusicTools.Web.ViewModels.Chord;

namespace MusicTools.Web.Controllers
{
    public class ChordController : Controller
    {
        private IKeyService _keyService;
        private IAlterationService _alterationService;
        private IChordQualityService _chordQualityService;

        public ChordController(IKeyService keyService, IAlterationService alterationService, IChordQualityService chordQualityService)
        {
            _keyService = keyService;
            _alterationService = alterationService;
            _chordQualityService = chordQualityService; 
        }
        public IActionResult Index()
        {
            var chordViewModel = new ChordViewModel();
            chordViewModel.Keys = _keyService.GetAll();
            chordViewModel.Alterations = _alterationService.GetAllAvailableForChord();
            chordViewModel.ChordQualities = _chordQualityService.GetAll();
            return View(chordViewModel);
        }

        public IActionResult GetChord(Key key, Alteration alteration, string chordQuality)
        {
            return null; 
        }
    }
}