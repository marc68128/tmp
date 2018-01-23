using System.Collections.Generic;
using MusicTools.Domain;
using MusicTools.Domain.Enum;

namespace MusicTools.Service.Contracts
{
    public interface IIntervalService
    {
        IEnumerable<IntervalNumber> GetAllIntervalNumbers();
        IEnumerable<IntervalQuality> GetAllIntervalQualities();
        int GetHalfStepCountFromInterval(Interval interval);
        IEnumerable<Interval> GetIntervalsFromHalfStepCount(int halfStepCount);
    }
}