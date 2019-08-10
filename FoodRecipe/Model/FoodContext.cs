using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FoodRecipe.Model
{
    public partial class FoodContext : DbContext
    {
        public FoodContext()
        {
        }

        public FoodContext(DbContextOptions<FoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:foodlove.database.windows.net,1433;Initial Catalog=Food;Persist Security Info=False;User ID=jungsup;Password=Kimyc072;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(e => e.Ingredients).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.Restaurant1)
                    .HasName("PK__Restaura__D243E9EFE3251907");

                entity.Property(e => e.Names).IsUnicode(false);

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Restaurant)
                    .HasForeignKey(d => d.FoodId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FoodId");
            });
        }
    }
}
