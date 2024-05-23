using CovadisAPI.Context;
using DemoCovadis.Entities;
using DemoCovadis.Shared;
using System.Threading;

namespace DemoCovadis.Services
{
    public class AutoService
    {
        private readonly LeenAutoDbContext dbContext;
        public AutoService(LeenAutoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Auto> GetAutos()
        {
            return dbContext.Autos.Select(x => new Auto
            {
                kenteken = x.kenteken,
                kilometerStand = x.kilometerStand,
                laatsteBestuurder = x.laatsteBestuurder

            });
        }

        public IEnumerable<Auto> CreateAuto(Auto auto)
        {
            dbContext.Autos.Add(auto);
            dbContext.SaveChanges();

            yield return new Auto
            {
                kenteken = auto.kenteken,
                kilometerStand = auto.kilometerStand,
                laatsteBestuurder = auto.laatsteBestuurder
            };
        }
    }
}