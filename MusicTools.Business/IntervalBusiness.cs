using System.Collections.Generic;
using System.Linq;
using MusicTools.Business.ViewModels.Interval;
using MusicTools.Service.Contracts;

namespace MusicTools.Business
{
    public class IntervalBusiness
    {
        private readonly IIntervalService _intervalService;

        public IntervalBusiness(IIntervalService intervalService)
        {
            _intervalService = intervalService;
        }

        public IEnumerable<IntervalNumberViewModel> GetAllIntervalNumbers()
        {
            return _intervalService.GetAllIntervalNumbers().Select(intervalNumber =>
                new IntervalNumberViewModel
                {
                    Name = intervalNumber.ToString(),
                    Value = (int)intervalNumber
                });
        }

        public IEnumerable<IntervalQualityViewModel> GetAllIntervalQualities()
        {
            return _intervalService.GetAllIntervalQualities().Select(intervalQuality =>
                new IntervalQualityViewModel
                {
                    Name = intervalQuality.ToString(),
                    Value = (int)intervalQuality
                });
        }
    }
}