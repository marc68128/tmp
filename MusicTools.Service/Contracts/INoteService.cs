using System.Collections.Generic;
using MusicTools.Domain;
using MusicTools.Domain.Enum;

namespace MusicTools.Service.Contracts
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note GetByInterval(Note startNote, Interval interval);
    }
}