using CS_Actions_WebApp.Infrastructures.Entity;
using CS_Actions_WebApp.Models;

using Microsoft.EntityFrameworkCore;

namespace CS_Actions_WebApp.Infrastructures.Context;
/// <summary>
/// データベースコンテキストクラス
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}