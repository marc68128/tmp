using MusicTools.Domain;
using MusicTools.Domain.Enum;

namespace MusicTools.Service.Contracts
{
    public interface INoteService
    {
        Note GetByInterval(Note startNote, IntervalNumber intervalNumber, IntervalQuality intervalQuality);
    }
}