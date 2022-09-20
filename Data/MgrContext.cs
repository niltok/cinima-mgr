using Microsoft.EntityFrameworkCore;

namespace cinima_mgr.Data;

public class MgrContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<DiscountTicket> DiscountTickets { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<RoomTemplate> RoomTemplates { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<SessionState> Sessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={Path.Join(Environment.CurrentDirectory, "app.db")}");
}