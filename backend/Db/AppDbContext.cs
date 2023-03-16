namespace NetCoreDemo.Db;

using Microsoft.EntityFrameworkCore;
using NetCoreDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
    static AppDbContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    private readonly IConfiguration _config;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options) => _config = config;


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var connString = _config.GetConnectionString("DefaultConnection");
        optionsBuilder
            .UseNpgsql(connString)
            .AddInterceptors(new AppDbContextSaveChangesInterceptor())
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.HasPostgresEnum<Role>(); // will create a enum type called "role" inside database
        //     modelBuilder.Entity<User>(entity =>
        //     {
        //         entity.Property(e => e.Role).HasColumnType("role");
        //         entity.HasIndex(e => e.Email).IsUnique();
        //     }); // connect property "Role" to enum type "role"

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CartProduct>()
            .HasKey(p => new { p.CartId, p.ProductId });

        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name);

        modelBuilder.Entity<Product>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Product>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Category>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Category>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Image>()
            .Property(s => s.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        
        modelBuilder.Entity<Image>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Images)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .Navigation(p => p.Images)
            .AutoInclude();

        modelBuilder.AddIdentityConfig();
    }

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Image> Pictures { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<CartProduct> CartProducts { get; set; } = null!;


}