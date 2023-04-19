using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMission.Models
{
    public interface IAgencyRepository
    {
        IQueryable<Entertainers> Entertainers { get; }
        void AddEntertainer(Entertainers entertainer);
        void UpdateEntertainer(Entertainers updatedEntertainer);
        void DeleteEntertainer(long entertainerId);
    }
}
