using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicTools.Business.ViewModels.Key;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;

namespace MusicTools.Business
{
    public class KeyBusiness
    {
        private readonly IKeyService _keyService;

        public KeyBusiness(IKeyService keyService)
        {
            _keyService = keyService;
        }

        public IEnumerable<KeyViewModel> GetAll()
        {
            return _keyService.GetAll().Select(k => new KeyViewModel { Name = k.ToString(), Value = (int)k });
        }

        public KeyViewModel Get(Key startKey, IntervalNumber intervalNumber)
        {
            return _keyService.GetByIntervalNumber(startKey, intervalNumber);
        }
    }
}
