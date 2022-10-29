using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext dBContext;
        public PlatformRepo(AppDbContext db)
        {
            dBContext = db;
        }

        public bool CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            dBContext.Platforms.Add(platform);
            return SaveChanges();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return dBContext.Platforms.AsEnumerable<Platform>();
        }

        public Platform GetPlatform(int id)
        {
            return dBContext.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return dBContext.SaveChanges() > 0;
        }
    }
}