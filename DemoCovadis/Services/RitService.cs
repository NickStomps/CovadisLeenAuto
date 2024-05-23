using DemoCovadis.Entities;
using CovadisAPI.Context;
namespace DemoCovadis.Services
{
    public class RitService
    {
        private readonly LeenAutoDbContext dbContext;
        public RitService(LeenAutoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Rit> GetRitten()
        {
            return dbContext.Ritten.Select(x => new Rit
            {
                kilometerGereden = x.kilometerGereden,
                bestuurder = x.bestuurder,
                beginAdres = x.beginAdres,
                eindAdres = x.eindAdres,
                vertrekTijd = x.vertrekTijd,
                aankomstTijd = x.aankomstTijd
            });
        }

        public IEnumerable<Rit> CreateRit(Rit rit)
        {
            dbContext.Ritten.Add(rit);
            dbContext.SaveChanges();

            yield return new Rit
            {
                kilometerGereden = rit.kilometerGereden,
                bestuurder = rit.bestuurder,
                beginAdres = rit.beginAdres,
                eindAdres = rit.eindAdres,
                vertrekTijd = rit.vertrekTijd,
                aankomstTijd = rit.aankomstTijd
            };
        }
    }
}
