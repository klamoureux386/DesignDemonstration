using DesignDemonstration.Entities;
using System.Diagnostics;

namespace DesignDemonstration.Data
{
    public static class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            // Look for any students.
            if (context.Examples.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Example[]
            {
                new Example{Id=1, Data="Example1"},
                new Example{Id=2, Data="Example2"},
                new Example{Id=3, Data="Example3"},
            };

            context.Examples.AddRange(students);
            context.SaveChanges();

        }
    }
}
