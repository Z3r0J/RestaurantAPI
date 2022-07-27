using RestaurantAPI.Core.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantAPI.Core.Domain.Entities;

namespace RestaurantAPI.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.Now;
                        entry.Entity.ModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }



        protected override void OnModelCreating(ModelBuilder builder) {
            //Fluent API

            builder.HasDefaultSchema("RestaurantAPI");
            #region Tables
            builder
                .Entity<Ingredients>()
                .ToTable("Ingredients");

            builder
                .Entity<Table>()
                .ToTable("Table");

            builder
                .Entity<TableStatus>()
                .ToTable("Table_Status");

            builder
                .Entity<Dish>()
                .ToTable("Dish");

            builder
                .Entity<DishCategory>()
                .ToTable("Dish_Category");
            
            builder
                .Entity<DishIngredient>()
                .ToTable("Dish_Ingredient");

            builder
                .Entity<Order>()
                .ToTable("Order");

           builder
                .Entity<OrderDish>()
                .ToTable("Order_Dish");

            builder
                .Entity<OrderStatus>()
                .ToTable("Order_Status");

            #endregion

            #region Primary Key

            builder
                .Entity<Dish>()
                .HasKey(x => x.Id);

            builder
                .Entity<DishCategory>()
                .HasKey(x => x.Id);

            builder
                .Entity<DishIngredient>()
                .HasKey(x => x.Id);

            builder
                .Entity<Ingredients>()
                .HasKey(x => x.Id);

            builder
                .Entity<Order>()
                .HasKey(x => x.Id);

            builder
                .Entity<OrderDish>()
                .HasKey(x => x.Id);

            builder
                .Entity<OrderStatus>()
                .HasKey(x => x.Id);

            builder
                .Entity<Table>()
                .HasKey(x => x.Id);

            builder
                .Entity<TableStatus>()
                .HasKey(x => x.Id);

            #endregion

            #region RelationShips

            builder.Entity<DishCategory>()
                .HasMany(x => x.Dishes)
                .WithOne(x => x.DishCategory)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Dish>()
                .HasMany(x => x.DishIngredients)
                .WithOne(x => x.Dish)
                .HasForeignKey(x => x.DishId);

            builder.Entity<Dish>()
                .HasMany(x => x.OrderDishes)
                .WithOne(x => x.Dish)
                .HasForeignKey(x => x.DishId);

            builder.Entity<Ingredients>()
                .HasMany(x => x.DishIngredients)
                .WithOne(x => x.Ingredient)
                .HasForeignKey(x => x.IngredientId);

            builder.Entity<OrderStatus>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.OrderStatus)
                .HasForeignKey(x => x.OrderStatusId);

            builder.Entity<Table>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Table)
                .HasForeignKey(x => x.TableId);

            builder.Entity<Order>()
                .HasMany(x => x.OrderDishes)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TableStatus>()
                .HasMany(x => x.Tables)
                .WithOne(x => x.TableStatus)
                .HasForeignKey(x => x.TableStatusId);

            #endregion

            #region Seeds

            builder.Entity<DishCategory>().HasData(new() {Id=1,Name="Entry Dish",Created=DateTime.UtcNow,CreatedBy="EF" }, 
                new() {Id=2,Name="Main Dish", Created = DateTime.UtcNow, CreatedBy = "EF" }, 
                new() {Id=3,Name="Dessert", Created = DateTime.UtcNow, CreatedBy = "EF" }, 
                new() {Id=4,Name="Beverage", Created = DateTime.UtcNow, CreatedBy = "EF" });

            builder.Entity<TableStatus>().HasData(new() {Id=1,Name="Available",Created=DateTime.UtcNow,CreatedBy="EF" }, 
                new() {Id=2,Name="In Process to service", Created = DateTime.UtcNow, CreatedBy = "EF" }, 
                new() {Id=3,Name="Serviced", Created = DateTime.UtcNow, CreatedBy = "EF" });

            builder.Entity<OrderStatus>().HasData(new() { Id = 1, Name = "In Process", Created = DateTime.UtcNow, CreatedBy = "EF" },
                new() { Id = 2, Name = "Completed", Created = DateTime.UtcNow, CreatedBy = "EF" });

            #endregion

            #region Properties

            builder.Entity<Dish>()
                .Property(x => x.CategoryId)
                .IsRequired();

            builder.Entity<Dish>()
                .Property(x => x.Price)
                .IsRequired();

            builder.Entity<Dish>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<DishCategory>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<DishIngredient>()
                .Property(x => x.DishId)
                .IsRequired();

            builder.Entity<DishIngredient>()
                .Property(x => x.IngredientId)
                .IsRequired();

            builder.Entity<Ingredients>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<Order>()
                .Property(x=>x.SubTotal)
                .IsRequired();

            builder.Entity<Order>()
                .Property(x=>x.TableId)
                .IsRequired();

            builder.Entity<Order>()
                .Property(x=>x.OrderStatusId)
                .IsRequired();

            builder.Entity<OrderDish>()
                .Property(x => x.OrderId)
                .IsRequired();

            builder.Entity<OrderDish>()
                .Property(x => x.DishId)
                .IsRequired();

            builder.Entity<OrderStatus>()
                .Property(x => x.Name)
                .IsRequired();

            builder.Entity<Table>()
                .Property(x => x.MaximumPeople)
                .IsRequired();

            builder.Entity<Table>()
                .Property(x => x.TableStatusId)
                .IsRequired();

            builder.Entity<Table>()
                .Property(x => x.Description)
                .IsRequired();

            builder.Entity<TableStatus>()
                .Property(x => x.Name)
                .IsRequired();


            #endregion

        }
    }
}
