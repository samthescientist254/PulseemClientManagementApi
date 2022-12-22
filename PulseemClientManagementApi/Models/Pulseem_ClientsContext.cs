using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PulseemClientManagementApi.Models
{
    public partial class Pulseem_ClientsContext : DbContext
    {
        public Pulseem_ClientsContext()
        {
        }

        public Pulseem_ClientsContext(DbContextOptions<Pulseem_ClientsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Trace> Traces { get; set; }

   /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Localhost;Initial Catalog=Pulseem_Clients;MultipleActiveResultSets=True;Persist Security Info=True;User ID=sa;Password=sam@3193#1;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cellphone).HasMaxLength(12);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.EmailStatus)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.LastUpdateTime).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SmsStatus)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datein)
                    .HasColumnType("datetime")
                    .HasColumnName("datein");

                entity.Property(e => e.Error).HasColumnName("error");
            });

            modelBuilder.Entity<Trace>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.DateIn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
