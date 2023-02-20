using CVServices.Entities;
using Microsoft.EntityFrameworkCore;

namespace CVServices.Infrastructure.Context
{
    public class CVContext : DbContext
    {
        public CVContext(DbContextOptions<CVContext> options) : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
