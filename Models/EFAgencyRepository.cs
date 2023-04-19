using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMission.Models
{
    public class EFAgencyRepository : IAgencyRepository
    {
        private EntertainmentAgencyExampleContext context { get; set; }

        public EFAgencyRepository(EntertainmentAgencyExampleContext temp)
        {
            context = temp;
        }

        public IQueryable<Entertainers> Entertainers => context.Entertainers;


        public void AddEntertainer(Entertainers entertainer)
        {
            context.Entertainers.Add(entertainer);
            context.SaveChanges();
        }

        public void UpdateEntertainer(Entertainers updatedEntertainer)
        {
            var existingEntertainer = context.Entertainers.FirstOrDefault(e => e.EntertainerId == updatedEntertainer.EntertainerId);

            //this is where the data gets populated during the updating method
            if(existingEntertainer != null)
            {
                existingEntertainer.EntStageName = updatedEntertainer.EntStageName;
                existingEntertainer.EntSsn = updatedEntertainer.EntSsn;
                existingEntertainer.EntStreetAddress = updatedEntertainer.EntStreetAddress;
                existingEntertainer.EntCity = updatedEntertainer.EntCity;
                existingEntertainer.EntState = updatedEntertainer.EntState;
                existingEntertainer.EntZipCode = updatedEntertainer.EntZipCode;
                existingEntertainer.EntPhoneNumber = updatedEntertainer.EntPhoneNumber;
                existingEntertainer.EntWebPage = updatedEntertainer.EntWebPage;
                existingEntertainer.EntEmailAddress = updatedEntertainer.EntEmailAddress;
                existingEntertainer.DateEntered = updatedEntertainer.DateEntered;

                context.SaveChanges();
            }
        }

        public void DeleteEntertainer(long entertainerId)
        {
            var entertainerToDelete = context.Entertainers.FirstOrDefault(e => e.EntertainerId == entertainerId);

            if (entertainerToDelete != null)
            {
                context.Entertainers.Remove(entertainerToDelete);
                context.SaveChanges();
            }
        }
    }
}