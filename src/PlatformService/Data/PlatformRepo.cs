using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDBContext _context;

        public PlatformRepo(AppDBContext context)
        {
            _context = context;

        }


        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            
            _context.Platforms.Add(platform);            
        }

        public void DeletePlatform(Platform platformItem)
        {
            if(platformItem == null)
            {
                throw new ArgumentNullException(nameof(platformItem));
            }
            _context.Platforms.Remove(platformItem);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
           return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
             return _context.Platforms.FirstOrDefault(p => p.Id == id);             
        }

        public Platform GetPlatformByIdAndName(int id, string name)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id && p.Name == name );             
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public Platform  UpdatePlatform(Platform platformItem)
        {                        
            // Retrieve the existing platform
            var existingPlatform = _context.Platforms.FirstOrDefault(p => p.Id == platformItem.Id);
        
            if(existingPlatform == null)
            {
                throw new Exception("Platform not found");
            }

            // Update fields
            existingPlatform.Name = platformItem.Name;
            existingPlatform.Cost = platformItem.Cost;     
            // Save changes in the context
            _context.SaveChanges();

            return existingPlatform;
        }
  
    }
}