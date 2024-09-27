using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
namespace KoiConsulting.Repository.Models;

public partial class KoiConsultingContext : DbContext
{
    public KoiConsultingContext()
    {
    }

    public KoiConsultingContext(DbContextOptions<KoiConsultingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<ElementCalculator> ElementCalculators { get; set; }

    public virtual DbSet<ElementKoi> ElementKois { get; set; }

    public virtual DbSet<ElementKoiDetail> ElementKoiDetails { get; set; }

    public virtual DbSet<ElementPond> ElementPonds { get; set; }

    public virtual DbSet<KoiAttribute> KoiAttributes { get; set; }

    public virtual DbSet<KoiType> KoiTypes { get; set; }

    public virtual DbSet<NewAndBlog> NewAndBlogs { get; set; }

    public virtual DbSet<OrderPackage> OrderPackages { get; set; }

    public virtual DbSet<OrderPackageDetail> OrderPackageDetails { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public static string GetConnectionString(string connectionStringName)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connectionString = config.GetConnectionString(connectionStringName);
        return connectionString;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString("DefaultConnection"));

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=TIENTRONG\\TIENTRONG;Initial Catalog=KoiConsulting;Persist Security Info=True;User ID=sa;Password=12345;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddressDetail).HasMaxLength(150);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.ToTable("Element");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ElementCalculator>(entity =>
        {
            entity.HasKey(e => new { e.ElementId, e.Number });

            entity.ToTable("ElementCalculator");

            entity.Property(e => e.Number).HasColumnName("number");

            entity.HasOne(d => d.Element).WithMany(p => p.ElementCalculators)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementCalculator_Element");
        });

        modelBuilder.Entity<ElementKoi>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ElementId }).HasName("PK_ElementKoi_1");

            entity.ToTable("ElementKoi");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.Element).WithMany(p => p.ElementKois)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementKoi_Element");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.ElementKois)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementKoi_ElementKoiDetail");

            entity.HasOne(d => d.Koi).WithMany(p => p.ElementKois)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementKoi_KoiType");
        });

        modelBuilder.Entity<ElementKoiDetail>(entity =>
        {
            entity.HasKey(e => e.ElementKoiId).HasName("PK_ElementKoiDetail_1");

            entity.ToTable("ElementKoiDetail");

            entity.Property(e => e.ElementKoiId).ValueGeneratedNever();
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Koi).WithMany(p => p.ElementKoiDetails)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElementKoiDetail_KoiType");
        });

        modelBuilder.Entity<ElementPond>(entity =>
        {
            entity.ToTable("ElementPond");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");

            entity.HasOne(d => d.Element).WithMany(p => p.ElementPonds)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_ElementPond_Element");

            entity.HasOne(d => d.Pond).WithMany(p => p.ElementPonds)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_ElementPond_Pond");
        });

        modelBuilder.Entity<KoiAttribute>(entity =>
        {
            entity.HasKey(e => new { e.KoiId, e.SubName, e.Color });

            entity.ToTable("KoiAttribute");

            entity.Property(e => e.SubName).HasMaxLength(50);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Origin)
                .HasMaxLength(50)
                .HasColumnName("origin");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("size");

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiAttributes)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KoiAttribute_KoiType");
        });

        modelBuilder.Entity<KoiType>(entity =>
        {
            entity.ToTable("KoiType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<NewAndBlog>(entity =>
        {
            entity.ToTable("NewAndBlog");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .HasColumnName("img");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Author).WithMany(p => p.NewAndBlogs)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_NewAndBlog_Admin");
        });

        modelBuilder.Entity<OrderPackage>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.UserId });

            entity.ToTable("OrderPackage");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.OrderPackages)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPackage_OrderPackageDetail");

            entity.HasOne(d => d.Id1).WithMany(p => p.OrderPackages)
                .HasPrincipalKey(p => p.OrderId)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPackage_Post");

            entity.HasOne(d => d.Package).WithMany(p => p.OrderPackages)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_OrderPackage_Package");

            entity.HasOne(d => d.User).WithMany(p => p.OrderPackages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPackage_User");
        });

        modelBuilder.Entity<OrderPackageDetail>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("OrderPackageDetail");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");

            entity.HasOne(d => d.Payment).WithMany(p => p.OrderPackageDetails)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK_OrderPackageDetail_Payment");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PackagePost");

            entity.ToTable("Package");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Exp).HasColumnName("exp");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Time)
                .HasColumnType("datetime")
                .HasColumnName("time");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.ToTable("Pond");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Direction)
                .HasMaxLength(50)
                .HasColumnName("direction");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.UserId }).HasName("PK_AdPost");

            entity.ToTable("Post");

            entity.HasIndex(e => e.OrderId, "UQ_ColumnName").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Detail)
                .HasColumnType("text")
                .HasColumnName("detail");
            entity.Property(e => e.ExpTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Post_User");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.ToTable("Profile");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Yob).HasColumnName("yob");

            entity.HasOne(d => d.Element).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_Profile_Element");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Profile_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_User_Address");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
