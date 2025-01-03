using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class MusicDbContext: IdentityDbContext<ApplicationUser>
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<A> Genres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<>
    
    >
}