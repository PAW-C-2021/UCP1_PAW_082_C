using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UTS_DataHadir.Models
{
    public partial class DataHadirContext : DbContext
    {
        public DataHadirContext()
        {
        }

        public DataHadirContext(DbContextOptions<DataHadirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Gajian> Gajians { get; set; }
        public virtual DbSet<Kehadiran> Kehadirans { get; set; }
        public virtual DbSet<KeteranganPembayaran> KeteranganPembayarans { get; set; }
        public virtual DbSet<Statushadir> Statushadirs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmp)
                    .HasName("PK__employee__D52A94EF4C887AC1");

                entity.ToTable("employee");

                entity.Property(e => e.IdEmp)
                    .ValueGeneratedNever()
                    .HasColumnName("id_emp");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("alamat");

                entity.Property(e => e.Nama)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.Property(e => e.Posisi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("posisi");
            });

            modelBuilder.Entity<Gajian>(entity =>
            {
                entity.HasKey(e => e.IdGaji)
                    .HasName("PK__gajian__0E81B3C23B7D9EF9");

                entity.ToTable("gajian");

                entity.Property(e => e.IdGaji)
                    .ValueGeneratedNever()
                    .HasColumnName("id_gaji");

                entity.Property(e => e.IdEmp).HasColumnName("id_emp");

                entity.Property(e => e.IdKehadiran).HasColumnName("id_kehadiran");

                entity.Property(e => e.IdKetBayar).HasColumnName("id_ketBayar");

                entity.Property(e => e.NominalGaji)
                    .HasColumnType("money")
                    .HasColumnName("nominal_gaji");

                entity.HasOne(d => d.IdEmpNavigation)
                    .WithMany(p => p.Gajians)
                    .HasForeignKey(d => d.IdEmp)
                    .HasConstraintName("FK__gajian__id_emp__412EB0B6");

                entity.HasOne(d => d.IdKehadiranNavigation)
                    .WithMany(p => p.Gajians)
                    .HasForeignKey(d => d.IdKehadiran)
                    .HasConstraintName("FK__gajian__id_kehad__4222D4EF");

                entity.HasOne(d => d.IdKetBayarNavigation)
                    .WithMany(p => p.Gajians)
                    .HasForeignKey(d => d.IdKetBayar)
                    .HasConstraintName("FK__gajian__id_ketBa__4316F928");
            });

            modelBuilder.Entity<Kehadiran>(entity =>
            {
                entity.HasKey(e => e.IdKehadiran)
                    .HasName("PK__kehadira__59B595E7FD3B954F");

                entity.ToTable("kehadiran");

                entity.Property(e => e.IdKehadiran)
                    .ValueGeneratedNever()
                    .HasColumnName("id_kehadiran");

                entity.Property(e => e.IdEmp).HasColumnName("id_emp");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.TanggalHadir)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal_hadir");

                entity.HasOne(d => d.IdEmpNavigation)
                    .WithMany(p => p.Kehadirans)
                    .HasForeignKey(d => d.IdEmp)
                    .HasConstraintName("FK__kehadiran__id_em__403A8C7D");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Kehadirans)
                    .HasForeignKey(d => d.IdStatus)
                    .HasConstraintName("FK__kehadiran__id_st__440B1D61");
            });

            modelBuilder.Entity<KeteranganPembayaran>(entity =>
            {
                entity.HasKey(e => e.IdKetBayar)
                    .HasName("PK__keterang__B773352FB700EB39");

                entity.ToTable("keterangan_pembayaran");

                entity.Property(e => e.IdKetBayar)
                    .ValueGeneratedNever()
                    .HasColumnName("id_ketBayar");

                entity.Property(e => e.KetBayar)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ket_bayar");
            });

            modelBuilder.Entity<Statushadir>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__statusha__5D2DC6E803F61BE5");

                entity.ToTable("statushadir");

                entity.Property(e => e.IdStatus)
                    .ValueGeneratedNever()
                    .HasColumnName("id_status");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("keterangan");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
