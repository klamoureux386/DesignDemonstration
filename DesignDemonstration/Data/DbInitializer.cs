using DesignDemonstration.Entities;
using System.Diagnostics;

namespace DesignDemonstration.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            
            var bands = AddBands(context);
            var musicians = AddMusicians(context, bands);

        }

        private static List<Band> AddBands(DataContext context) 
        {
            // Look for any Bands.
            if (context.Bands.Any())
            {
                return context.Bands.ToList();   // DB has been seeded
            }

            var bands = new List<Band>()
            {
                new Band{Id=1, Name="No Knife"},
                new Band{Id=2, Name="Rival Schools"},
                new Band{Id=3, Name="Shiner"},
            };

            context.Bands.AddRange(bands);
            context.SaveChanges();

            return bands;
        }

        private static List<Musician> AddMusicians(DataContext context, List<Band> bands)
        {
            // Look for any Bands.
            if (context.Musicians.Any())
            {
                return context.Musicians.ToList();   // DB has been seeded
            }

            var musicians = new List<Musician>()
            {
                new Musician{ Id = 1, FirstName = "Mitch", LastName = "Wilson", Bands = bands.Where(b => b.Name == "No Knife").ToList() },
                new Musician{ Id = 2, FirstName = "Brian", LastName = "Desjean", Bands = bands.Where(b => b.Name == "No Knife").ToList() },
                new Musician{ Id = 3, FirstName = "Ryan", LastName = "Ferguson", Bands = bands.Where(b => b.Name == "No Knife").ToList() },
            };

            context.Musicians.AddRange(musicians);
            context.SaveChanges();

            return musicians;
        }
    }
}
