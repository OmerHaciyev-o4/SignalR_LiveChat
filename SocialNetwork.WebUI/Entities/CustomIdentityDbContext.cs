using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.WebUI.Entities
{
    public class CustomeIdentityDbContext : IdentityDbContext<CustomIdentityUser, CustomIdentityRole, string>
    {
        public CustomeIdentityDbContext(DbContextOptions<CustomeIdentityDbContext> options)
            : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<CustomIdentityUserRoom> CustomIdentityUserRooms { get; set; }
        public DbSet<MessageCloud> MessageClouds{ get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomIdentityUserRoom>()
                .HasKey(ur => new { ur.UserId, ur.RoomId });

            builder.Entity<CustomIdentityUserRoom>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.CustomIdentityUserRooms)
                .HasForeignKey(ur => ur.UserId);

            builder.Entity<CustomIdentityUserRoom>()
                .HasOne(ur => ur.Room)
                .WithMany(r => r.CustomIdentityUserRooms)
                .HasForeignKey(ur => ur.RoomId);

            base.OnModelCreating(builder);
        }
    }
}