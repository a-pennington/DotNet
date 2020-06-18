using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class WebAPI_Context : DbContext
    {
        public WebAPI_Context(DbContextOptions<WebAPI_Context> opt) : base(opt) {}
        public DbSet<Person> DbSetPerson { get; set; }
        public DbSet<Matrix> DbSetMatrix { get; set; }

    }
}