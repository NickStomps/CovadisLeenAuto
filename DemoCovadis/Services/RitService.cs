using DemoCovadis.Entities;
using DemoCovadis.Context;
using DemoCovadis.Shared.Dtos;
using DemoCovadis.Shared.Enums;
using DemoCovadis.Shared.Interfaces;

namespace DemoCovadis.Services
{
    public class RitService(LeenAutoDbContext dbContext, ICurrentUserContext userContext)
    {
        private readonly LeenAutoDbContext dbContext = dbContext;

        public IEnumerable<Rit> GetRitten()
        {
            return dbContext.Ritten.Select(x => new Rit
            {
                id = x.id,
                AutoId = x.AutoId,
                auto = x.auto,
                kilometerGereden = x.kilometerGereden,
                bestuurder = x.bestuurder,
                beginAdres = x.beginAdres,
                eindAdres = x.eindAdres,
                vertrekTijd = x.vertrekTijd,
                aankomstTijd = x.aankomstTijd
            });
        }

        public RitDto GetRitById(int id)
        {

            var rit = dbContext.Ritten.Find(id);

            if (rit == null)
            {
                return null;
            }

            return new RitDto
            {
                id = rit.id,
                AutoId = rit.AutoId,
                kilometerGereden = rit.kilometerGereden,
                beginAdres = rit.beginAdres,
                eindAdres = rit.eindAdres,
                vertrekTijd = rit.vertrekTijd,
                aankomstTijd = rit.aankomstTijd
            };
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
