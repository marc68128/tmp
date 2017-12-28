using System.Collections.Generic;
using MusicTools.Domain;

namespace MusicTools.Service.Contracts
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note GetByInterval(Note startNote, Interval interval);
        int GetHalfStepCountBetween2Notes(Note note1, Note note2);
        IEnumerable<Note> GetByHalfStepCount(Note startNote, int halfStepCount);
        IEnumerable<Interval> GetIntervalsBetween2Notes(Note note1, Note note2);
        IEnumerable<Note> GetEquivalentNote(Note note);
    }
}