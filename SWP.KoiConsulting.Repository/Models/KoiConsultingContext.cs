using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SWP.KoiConsulting.Repository.Models;

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

    public virtual DbSet<Element> Elements { get; set; }

    public virtual DbSet<ElementCalculator> ElementCalculators { get; set; }

    public virtual DbSet<ElementKoi> ElementKois { get; set; }

    public virtual DbSet<ElementPond> ElementPonds { get; set; }

    public virtual DbSet<ElementSpec> ElementSpecs { get; set; }

    public virtual DbSet<KoiAttribute> KoiAttributes { get; set; }

    public virtual DbSet<KoiAttributeGroup> KoiAttributeGroups { get; set; }

    public virtual DbSet<KoiType> KoiTypes { get; set; }

    public virtual DbSet<NewAndBlog> NewAndBlogs { get; set; }

    public virtual DbSet<OrderPackage> OrderPackages { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.AddressDetail).HasMaxLength(150);
            entity.Property(e => e.City).HasMaxLength(50);
        });

        modelBuilder.Entity<Element>(entity =>
        {
            entity.ToTable("Element");

            entity.Property(e => e.Name).HasMaxLength(50);
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
            entity.ToTable("ElementKoi");

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Element).WithMany(p => p.ElementKois)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_ElementKoi_Element");

            entity.HasOne(d => d.Koi).WithMany(p => p.ElementKois)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK_ElementKoi_KoiType");
        });

        modelBuilder.Entity<ElementPond>(entity =>
        {
            entity.ToTable("ElementPond");

            entity.HasOne(d => d.Element).WithMany(p => p.ElementPonds)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_ElementPond_Element");

            entity.HasOne(d => d.Pond).WithMany(p => p.ElementPonds)
                .HasForeignKey(d => d.PondId)
                .HasConstraintName("FK_ElementPond_Pond");
        });

        modelBuilder.Entity<ElementSpec>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ElementKoiDetail_1");

            entity.ToTable("ElementSpec");

            entity.Property(e => e.Detail).HasColumnType("text");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Element).WithMany(p => p.ElementSpecs)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_ElementSpec_Element");

            entity.HasOne(d => d.ElementKoi).WithMany(p => p.ElementSpecs)
                .HasForeignKey(d => d.ElementKoiId)
                .HasConstraintName("FK_ElementSpec_ElementKoi");

            entity.HasOne(d => d.Koi).WithMany(p => p.ElementSpecs)
                .HasForeignKey(d => d.KoiId)
                .HasConstraintName("FK_ElementKoiDetail_KoiType");
        });

        modelBuilder.Entity<KoiAttribute>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("KoiAttribute");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Origin).HasMaxLength(50);
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubName).HasMaxLength(50);

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasPrincipalKey(p => p.AttributeId)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KoiAttribute_KoiType");
        });

        modelBuilder.Entity<KoiAttributeGroup>(entity =>
        {
            entity.HasKey(e => new { e.KoiId, e.AttributeId });

            entity.ToTable("KoiAttributeGroup");

            entity.HasIndex(e => e.AttributeId, "IX_KoiAttributeGroup").IsUnique();

            entity.HasOne(d => d.Koi).WithMany(p => p.KoiAttributeGroups)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KoiAttributeGroup_KoiType");
        });

        modelBuilder.Entity<KoiType>(entity =>
        {
            entity.ToTable("KoiType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<NewAndBlog>(entity =>
        {
            entity.ToTable("NewAndBlog");

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasColumnType("text");
            entity.Property(e => e.Img).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.NewAndBlogs)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_NewAndBlog_User");
        });

        modelBuilder.Entity<OrderPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrderPackage_1");

            entity.ToTable("OrderPackage");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.DetailNavigation).WithMany(p => p.OrderPackages)
                .HasForeignKey(d => d.Detail)
                .HasConstraintName("FK_OrderPackage_Package");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.OrderPackage)
                .HasPrincipalKey<Post>(p => p.OrderId)
                .HasForeignKey<OrderPackage>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPackage_Post");

            entity.HasOne(d => d.Id1).WithOne(p => p.OrderPackage)
                .HasPrincipalKey<Payment>(p => p.OrderPackageId)
                .HasForeignKey<OrderPackage>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPackage_Payment");

            entity.HasOne(d => d.User).WithMany(p => p.OrderPackages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderPackage_User");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PackagePost");

            entity.ToTable("Package");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.HasIndex(e => e.OrderPackageId, "IX_Payment").IsUnique();

            entity.Property(e => e.OrderPackageId).IsRequired();
            entity.Property(e => e.Time).HasColumnType("datetime");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.ToTable("Pond");

            entity.Property(e => e.Direction).HasMaxLength(50);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.HasIndex(e => e.OrderId, "UQ_ColumnName").IsUnique();

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasColumnType("text");
            entity.Property(e => e.ExpTime).HasColumnType("datetime");
            entity.Property(e => e.OrderId).IsRequired();
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Post_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Address).WithMany(p => p.Users)
                .HasForeignKey(d => d.AddressId)
                .HasConstraintName("FK_User_Address");

            entity.HasOne(d => d.Element).WithMany(p => p.Users)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_User_Element");
        });

        modelBuilder.Entity<WishList>(entity =>
        {
            entity.ToTable("WishList");

            entity.HasOne(d => d.Post).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_WishList_Post");

            entity.HasOne(d => d.User).WithMany(p => p.WishLists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_WishList_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
