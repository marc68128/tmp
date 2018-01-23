
using System.Collections.Generic;
using System.Linq;
using MusicTools.Business.ViewModels.Chord;
using MusicTools.Domain;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;

namespace MusicTools.Business
{
    public class ChordBusiness
    {
        private readonly IKeyService _keyService;
        private readonly IAlterationService _alterationService;
        private readonly IChordQualityService _chordQualityService;
        private readonly IChordService _chordService;
        private readonly INoteService _noteService;

        public ChordBusiness(IKeyService keyService, IAlterationService alterationService, IChordQualityService chordQualityService, IChordService chordService, INoteService noteService)
        {
            _keyService = keyService;
            _alterationService = alterationService;
            _chordQualityService = chordQualityService;
            _chordService = chordService;
            _noteService = noteService;
        }

        public ChordViewModel GetChordViewModel(Key key, Alteration alteration, string chordQuality)
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

            return vm;
        }

        public IEnumerable<ChordViewModel> GetChordsViewModels(Key key1, Alteration alteration1, Key key2, Alteration alteration2, Key key3, Alteration alteration3)
        {
            var chords = _chordService.GetChords(new Note(key1, alteration1), new Note(key2, alteration2), new Note(key3, alteration3)).ToList();
            return chords.Select(c => new ChordViewModel
            {
                Name = c.Name,
                Notes = c.Notes.Select((n, i) => new NoteViewModel
                {
                    Note = n,
                    Interval = c.ChordQuality.ChordQualityIntervals.Select(cq => cq.Interval).ElementAt(i)
                }).ToList()
            }).ToList();
        }

        public ChordSelectorViewModel GetChordSelectorViewModel()
        {
            var chordSelectorViewModel = new ChordSelectorViewModel();
            chordSelectorViewModel.Keys = _keyService.GetAll();
            chordSelectorViewModel.Alterations = _alterationService.GetAllAvailableForChord();
            chordSelectorViewModel.ChordQualities = _chordQualityService.GetAll();

            return chordSelectorViewModel;
        }
    }
}
