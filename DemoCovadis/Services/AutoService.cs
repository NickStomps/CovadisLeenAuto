using DemoCovadis.Context;
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
                laatsteBestuurderId = x.laatsteBestuurderId

            });
        }

        public IEnumerable<Auto> CreateAuto(Auto auto)
        {
            dbContext.Autos.Add(auto);
            dbContext.SaveChanges();

            yield return new Auto
            {
                Id = auto.Id,
                kenteken = auto.kenteken,
                kilometerStand = auto.kilometerStand,
                laatsteBestuurderId = auto.laatsteBestuurderId
            };
        }

        public void DeleteAuto(int id)
        {
            var auto = dbContext.Autos.FirstOrDefault(x => x.Id == id);
            if (auto != null)
            {
                dbContext.Autos.Remove(auto);
                dbContext.SaveChanges();
            }
        }
    }
}