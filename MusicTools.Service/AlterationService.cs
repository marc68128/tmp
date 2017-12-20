using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicTools.Domain.Enum;
using MusicTools.Service.Contracts;

namespace MusicTools.Service
{
    public class AlterationService : IAlterationService
    {
        public IEnumerable<Alteration> GetAll()
        {
            return Enum.GetValues(typeof(Alteration)).Cast<Alteration>(); 
        }

        public IEnumerable<Alteration> GetAllAvailableForChord()
        {
            return GetAll().Where(a => Math.Abs((int) a) < 2);
        }
    }
}
