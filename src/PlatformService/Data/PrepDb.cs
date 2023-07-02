namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        private static void SeedData(AppDBContext context)
        {
                if(!context.Platforms.Any())
                {
                    Console.WriteLine("Have data");

                    context.Platforms.AddRange(
                        new Models.Platform(){Name="Dot net",Publisher="Microsoft",Cost="Free"},
                        new Models.Platform(){Name="Sql Server Express",Publisher="Microsfot",Cost="Free"},
                        new Models.Platform(){Name="Kubernets",Publisher="Cloud Native Computing Fundation",Cost="Free"}
                    );
                    
                    context.SaveChanges();

                }else
                {
                    Console.WriteLine("Have data");
                        
                }
        }

    }
}