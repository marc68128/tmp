using System;
using System.Collections.Generic;
using System.Text;
using MusicTools.Domain.Enum;

namespace MusicTools.Service.Contracts
{
    public interface IAlterationService
    {
        IEnumerable<Alteration> GetAll();
        IEnumerable<Alteration> GetAllAvailableForChord(); 
    }
}
