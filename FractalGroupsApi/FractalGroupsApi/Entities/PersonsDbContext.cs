using Microsoft.EntityFrameworkCore;

namespace FractalGroupsApi.Entities
{
    public class PersonsDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<PersonGroup> PersonGroups { get; set; }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options)
            : base(options)
        {

        }
    }
}
