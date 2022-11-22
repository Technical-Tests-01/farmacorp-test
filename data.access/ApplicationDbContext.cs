using System;
using activate_assurance.Models;
using Microsoft.EntityFrameworkCore;
using models;
using models.erp.module;
//using Microsoft.EntityFrameworkCore;
using static data.access.Utils;

namespace data.access
{
	public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductExpress> ProductExpresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<SaleExpress> SaleExpresses { get; set; }
        public DbSet<BarCode> BarCodes{ get; set; }
        public DbSet<ProductErp> ProductErps { get; set; }

        
        



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.categoryId);
                entity.HasOne(x => x.categoryParent)
                    .WithMany(x => x.categories)
                    .HasForeignKey(x => x.categoryParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ProductErp>().ToTable("ProducstErp");

            modelBuilder.Entity<ProductType>().HasQueryFilter(entity => entity.isDeleted == 0);
            modelBuilder.Entity<ProductExpress>().HasQueryFilter(entity => entity.isDeleted == 0);
            modelBuilder.Entity<Category>().HasQueryFilter(entity => entity.isDeleted == 0);
            modelBuilder.Entity<ProductCategory>().HasQueryFilter(entity => entity.isDeleted == 0);
            modelBuilder.Entity<SaleExpress>().HasQueryFilter(entity => entity.isDeleted == 0);
            modelBuilder.Entity<BarCode>().HasQueryFilter(entity => entity.isDeleted == 0);
            modelBuilder.Entity<ProductErp>().HasQueryFilter(entity => entity.isDeleted == 0);


        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            onBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            onBeforeSaving();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void onBeforeSaving()
        {
            var entries = ChangeTracker.Entries();

            var datetimeNow = DateTime.Now;

            foreach (var entry in entries)
            {
                // for entities that inherit from BaseEntity,
                // set UpdatedOn / CreatedOn appropriately
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            // set the updated date to "now"
                            trackable.lastUpdated = datetimeNow;

                            // mark property as "don't touch"
                            // we don't want to update on a Modify operation
                            entry.Property("createdAt").IsModified = false;
                            break;

                        case EntityState.Added:
                            // set both updated and created date to "now"
                            trackable.createdAt = datetimeNow;
                            trackable.lastUpdated = datetimeNow;
                            break;

                    }
                }
            }
        }
    }
}

