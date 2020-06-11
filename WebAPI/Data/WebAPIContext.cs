using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext(DbContextOptions<WebAPIContext> opt) : base(opt) 
        {
            
        }

        public DbSet<Person> DbSetPerson { get; set; }

    }
}