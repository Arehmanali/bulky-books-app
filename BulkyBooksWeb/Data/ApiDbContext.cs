using BulkyBooksWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace DbExploration.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {
    }

    public DbSet<Category> Categories { get; set; }
}