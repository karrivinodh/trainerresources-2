using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiHandson.Models;

public partial class WebApiHandsonContext : DbContext
{
    public WebApiHandsonContext()
    {
    }

    public WebApiHandsonContext(DbContextOptions<WebApiHandsonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-FN225GT7\\SQLEXPRESS; DataBase=WebApiHandson ; Integrated Security=true ; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustId).HasName("PK__tblCusto__049E3AA9E1D7673F");

            entity.ToTable("tblCustomers");

            entity.Property(e => e.CustAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CustPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
