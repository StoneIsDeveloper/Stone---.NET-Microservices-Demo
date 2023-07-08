using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo   
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        
        Platform GetPlatformById(int id);

        void CreatePlatform(Platform platform);
        void DeletePlatform(Platform platformItem);
        Platform GetPlatformByIdAndName(int id, string name);
        Platform UpdatePlatform(Platform platformItem);
    }
}