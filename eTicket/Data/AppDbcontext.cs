using Microsoft.EntityFrameworkCore;
using eTicket.Models;
namespace eTicket.Data;

public class AppDbcontext: DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor_Movie>().HasKey(am => new {
            am.ActorId,
            am.MovieId
        });

        modelBuilder.Entity<Actor_Movie>().HasOne(m=> m.Movie).WithMany(a => a.Actor_Movies)
        .HasForeignKey(m => m.MovieId);

        modelBuilder.Entity<Actor_Movie>().HasOne(a=> a.Actor).WithMany(m => m.Actor_Movies)
        .HasForeignKey(a => a.ActorId);


        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Actor> Actors  {get; set;}
    public DbSet<Actor_Movie> Actors_Movies  {get; set;}
    public DbSet<Cinema> Cinemas  {get; set;}
    public DbSet<Movie> Movies  {get; set;}
    public DbSet<Producer> Producers  {get; set;}
}
