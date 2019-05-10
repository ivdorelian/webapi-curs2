using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curs_2_webapi.Models
{
    public static class FlowersDbSeeder
    {
        public static void Initialize(FlowersDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any flowers.
            if (context.Flowers.Any())
            {
                return;   // DB has been seeded
            }

            context.Flowers.AddRange(
                new Flower
                {
                    Name = "Rose",
                    Colors = "White, Yellow",
                    IsArtificial = false,
                    SmellLevel = 5
                },
                new Flower
                {
                    Name = "Daisy",
                    Colors = "Yellow, Red",
                    IsArtificial = true,
                    SmellLevel = 2
                }
            );
            context.SaveChanges(); // commit transaction
        }
    }

}
