using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDBContext _context;


        public CommandRepo(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformId;
            _context.Commands.Add(command);
        }

        public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentException(nameof(plat));
            }
            _context.Platforms.Add(plat);
        }

        public bool ExternalPlatformExists(int externalPlatformID)
        {
            return _context.Platforms.Any(p=> p.ExternalID == externalPlatformID); 
        }


        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Command? GetCommand(int platformId, int commandId)
        {
            return _context.Commands
                    .Where(c => c.PlatformId == platformId && c.PlatformId == commandId).FirstOrDefault();
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            return _context.Commands.Where(c => c.PlatformId == platformId).OrderBy(c=>c.Platform.Name).ToList(); 
        }

        public bool PlatformExists(int platformId)
        {
            return _context.Platforms.Any(c => c.Id == platformId);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

    }
}