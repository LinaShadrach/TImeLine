using Microsoft.EntityFrameworkCore;

namespace TimeLine.Models
{
    public class TimeLineContext : DbContext
    {
        public virtual DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TimeLine;integrated security=True");
           
        }
    }
}