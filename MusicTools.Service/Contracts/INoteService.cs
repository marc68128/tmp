using System.Collections.Generic;
using MusicTools.Domain;

namespace MusicTools.Service.Contracts
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note GetByInterval(Note startNote, Interval interval);
        int GetHalfStepCountBetween2Notes(Note note1, Note note2);
    }
}