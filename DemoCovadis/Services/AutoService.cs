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
                beginStandKm = x.beginStandKm,
                eindStandKm = x.eindStandKm,
                bestuurder = x.bestuurder,
                beginAdres = x.beginAdres,
                eindAdres = x.eindAdres,
                vertrekTijd = x.vertrekTijd,
                aankomstTijd = x.aankomstTijd
            });
        }

        public IEnumerable<Auto> CreateAuto(Auto auto)
        {
            dbContext.Autos.Add(auto);
            dbContext.SaveChanges();

            yield return new Auto
            {
                kenteken = auto.kenteken,
                beginStandKm = auto.beginStandKm,
                eindStandKm = auto.eindStandKm,
                bestuurder = auto.bestuurder,
                beginAdres = auto.beginAdres,
                eindAdres = auto.eindAdres,
                vertrekTijd = auto.vertrekTijd,
                aankomstTijd = auto.aankomstTijd
            };
        }
    }
}