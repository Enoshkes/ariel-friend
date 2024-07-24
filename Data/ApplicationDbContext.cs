using ariel_my_friend.Models;
using Microsoft.EntityFrameworkCore;

namespace ariel_my_friend.Data
{
    //Ariel: dependecy injection. the framewirk initiate the dbcontext
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<FriendModel> Friends { get; set; }
        public DbSet<ImageModel> Images { get; set; }

        // Ariel: set relations between entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendModel>()
                .HasMany(friend => friend.Images)
                .WithOne(images => images.Friend)
                .HasForeignKey(images => images.FriendId);
        }
    }
}
