using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infotrack.Models;

namespace Infotrack.Data
{
    public class DbInitializer
    {
        public static void Initialize(ScraperContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.ScraperData.Any())
            {
                return;   // DB has been seeded
            }

            var scraperdata = new ScraperModel[]
            {
                new ScraperModel{ID = 1, input = "infotrack" , position = 15, paid_ads = 3, date=DateTime.Parse("2005-09-01")},
                new ScraperModel{ID = 2, input = "infotrack" , position = 11, paid_ads = 1, date=DateTime.Parse("2005-09-01")},
                new ScraperModel{ID = 3, input = "infotrack" , position = 17, paid_ads = 6, date=DateTime.Parse("2005-09-01")},
                new ScraperModel{ID = 4, input = "infotrack" , position = 12, paid_ads = 3, date=DateTime.Parse("2005-09-01")},
                new ScraperModel{ID = 5, input = "infotrack" , position = 11, paid_ads = 3, date=DateTime.Parse("2005-09-01")},
                new ScraperModel{ID = 6, input = "infotrack" , position = 8, paid_ads = 3, date=DateTime.Parse("2005-09-01")},

            };
            foreach (ScraperModel s in scraperdata)
            {
                context.ScraperData.Add(s);
            }
            context.SaveChanges();

        }


    }
}
