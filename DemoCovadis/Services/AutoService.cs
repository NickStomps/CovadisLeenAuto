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

        public IEnumerable<Auto> GetAutos()
        {
            return dbContext.Autos.Select(x => new Auto
            {
                kenteken = x.kenteken,
                beginStandKm = x.beginStandKm,
                eindStandKm = x.eindStandKm,
                bestuurder = x.bestuurder,beginAdres = x.beginAdres,
                eindAdres = x.eindAdres,
                vertrekTijd = x.vertrekTijd, 
                aankomstTijd = x.aankomstTijd
            });

        }

    }
}
