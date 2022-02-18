using Microsoft.EntityFrameworkCore;

namespace SpeakerSessions.Api.Models
{
    public class SpeakerSessionsDbContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public SpeakerSessionsDbContext(DbContextOptions<SpeakerSessionsDbContext> options)
        : base(options) {}


    }
}
