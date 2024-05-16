using CovadisAPI.Context;
using DemoCovadis.Entities;
using DemoCovadis.Shared;

namespace DemoCovadis.Services
{
    public class AutoService
    {
        private readonly LeenAutoDbContext dbContext;
        public AutoService(LeenAutoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
