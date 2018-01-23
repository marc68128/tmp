using Microsoft.AspNetCore.Mvc;
using MusicTools.Business;
using MusicTools.Domain.Enum;

namespace MusicTools.Web.Controllers
{
    [Route("api/[controller]")]
    public class ChordController : Controller
    {
        private readonly ChordBusiness _chordBusiness;

        public ChordController(ChordBusiness chordBusiness)
        {
            _chordBusiness = chordBusiness;
        }
        public JsonResult Index()
        {
            var viewModel = _chordBusiness.GetChordSelectorViewModel();
            return Json(viewModel);
        }

        [HttpGet]
        public JsonResult GetChord(Key key, Alteration alteration, string chordQuality)
        {
            var viewModel = _chordBusiness.GetChordViewModel(key, alteration, chordQuality);
            return Json(viewModel);
        }

        [HttpGet]
        public JsonResult GetChords(Key key1, Alteration alteration1, Key key2, Alteration alteration2, Key key3, Alteration alteration3)
        {
            var viewModel = _chordBusiness.GetChordsViewModels(key1, alteration1, key2, alteration2, key3, alteration3);
            return Json(viewModel);
        }
    }
}