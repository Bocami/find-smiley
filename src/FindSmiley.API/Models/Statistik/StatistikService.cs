using System.Linq;

namespace FindSmiley.API.Models.Statistik
{
    public class StatistikService : IStatistikService
    {
        public dynamic Test1()
        {
            using (var context = new FindSmileyDbContext())
            {
                return (from k in context.Kontrolrapporter
                    group k by k.Resultat into g
                    select new { g.Key, Count = g.Count() })
                    .OrderBy(g => g.Key)
                    .ToArray();
            }
        }

        public dynamic Test2()
        {
            using (var context = new FindSmileyDbContext())
            {
                return (from k in context.Kontrolrapporter
                    group k by new { k.Kontroldato.Year, k.Kontroldato.Month } into g
                    select new 
                    { 
                        g.Key,
                        Resultat = g.Count(),
                        Resultat1 = g.Where(e => e.Resultat == 1).Count(),
                        Resultat2 = g.Where(e => e.Resultat == 2).Count(),
                        Resultat3 = g.Where(e => e.Resultat == 3).Count(),
                        Resultat4 = g.Where(e => e.Resultat == 4).Count()
                    })
                    .OrderByDescending(g => g.Key)
                    .ToArray();
            }
        }

        public dynamic Test3()
        {
            using (var context = new FindSmileyDbContext())
            {
                return (from k in context.Kontrolrapporter
                    group k by k.Resultat into g
                    select new { Resultat = g.Key, Antal = g.Count(), Procent = ((decimal)g.Count() / (decimal)context.Kontrolrapporter.Count()) * 100 })
                    .ToArray();
            }
        }
    }
}