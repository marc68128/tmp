using System.Collections.Generic;
using MusicTools.Domain;

namespace MusicTools.Service.Contracts
{
    public interface IIntervalService
    {
        int GetHalfStepCountFromInterval(Interval interval);
        IEnumerable<Interval> GetIntervalsFromHalfStepCount(int halfStepCount);
    }
}