using System.Windows.Input;
using CommandsService.Models;


namespace CommandsService.Data
{
    public static class PreDb
    {
        public static void PrePopulation(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                
            }
        }

        private static void SeedData(ICommandRepo repo, IEnumerable<Platform> platforms)
        {
            Console.WriteLine("Seeding new platforms...");

            foreach(var plat in platforms)
            {
                if(!repo.ExternalPlatformExists(plat.ExternalId))
                {
                    repo.CreatePlatform(plat);
                }
                repo.SaveChanges();
            }

        }
        
    }
}