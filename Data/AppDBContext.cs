using MahalliyMarket.Models;
using Microsoft.EntityFrameworkCore;

namespace MahalliyMarket.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*
        Under code‑first EF Core, if your entity class has navigation properties and 
        the entity class has matching FK scalar properties (e.g. category_id for category, 
        user_id for user), EF will automatically wire up one-to-many relationships 
        based on conventions—you don’t even need the fluent HasOne(...).WithMany(...) 
        configuration, unless you want custom behavior.
        */
    }

    public DbSet<Advertisement> advertisements { get; set; }
    public DbSet<Cancellation> cancellations { get; set; }
    public DbSet<Cart> carts { get; set; }
    public DbSet<CartItem> cart_items { get; set; }
    public DbSet<Category> categories { get; set; }
    public DbSet<DeliveryAddress> delivery_addresses { get; set; }
    public DbSet<DeliveryMethod> delivery_methods { get; set; }
    public DbSet<Order> orders { get; set; }
    public DbSet<OrderItem> order_items { get; set; }
    public DbSet<Payment> payments { get; set; }
    public DbSet<Product> products { get; set; }
    public DbSet<ProductFeedback> product_feedbacks { get; set; }
    public DbSet<ProductHot> product_hots { get; set; }
    public DbSet<ProductImage> product_images { get; set; }
    public DbSet<ProductSales> product_sales { get; set; }
    public DbSet<ProductSwiper> product_swipers { get; set; }
    public DbSet<ProductVideo> product_videos { get; set; }
    public DbSet<Refund> refunds { get; set; }
    public DbSet<Status> statuses { get; set; }
    public DbSet<User> users { get; set; }
}
