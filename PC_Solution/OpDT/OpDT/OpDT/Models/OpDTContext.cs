using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpDT.Models
{
    public partial class OpDTContext : DbContext
    {
        public OpDTContext()
        {
        }

        public OpDTContext(DbContextOptions<OpDTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountManagement> AccountManagements { get; set; } = null!;
        public virtual DbSet<Function> Functions { get; set; } = null!;
        public virtual DbSet<GroupFunction> GroupFunctions { get; set; } = null!;
        public virtual DbSet<GroupManagement> GroupManagements { get; set; } = null!;
        public virtual DbSet<HangHoa> HangHoas { get; set; } = null!;
        public virtual DbSet<LoaiHangHoa> LoaiHangHoas { get; set; } = null!;
        public virtual DbSet<PhieuDatHang> PhieuDatHangs { get; set; } = null!;
        public virtual DbSet<PhieuGiaoHang> PhieuGiaoHangs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=OpDT;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountManagement>(entity =>
            {
                entity.HasKey(e => e.AccountUsername)
                    .HasName("PK__AccountM__EA4018343A7616F6");

                entity.ToTable("AccountManagement");

                entity.Property(e => e.AccountUsername).HasMaxLength(50);

                entity.Property(e => e.AccountPassword).HasMaxLength(50);

                entity.Property(e => e.GroupId)
                    .HasMaxLength(50)
                    .HasColumnName("GroupID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AccountManagements)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__AccountMa__Group__398D8EEE");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(e => e.FunctionId)
                    .HasMaxLength(50)
                    .HasColumnName("FunctionID");

                entity.Property(e => e.FunctionName).HasMaxLength(100);
            });

            modelBuilder.Entity<GroupFunction>(entity =>
            {
                entity.HasKey(e => new { e.FunctionId, e.GroupId })
                    .HasName("PK__GroupFun__80E256287D7B0C3C");

                entity.Property(e => e.FunctionId)
                    .HasMaxLength(50)
                    .HasColumnName("FunctionID");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(50)
                    .HasColumnName("GroupID");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.GroupFunctions)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupFunc__Funct__5165187F");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupFunctions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupFunc__Group__5070F446");
            });

            modelBuilder.Entity<GroupManagement>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PK__GroupMan__149AF30A5C2091CD");

                entity.ToTable("GroupManagement");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(50)
                    .HasColumnName("GroupID");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.Mahang)
                    .HasName("PK__HangHoa__97CCC9C9591AC8ED");

                entity.ToTable("HangHoa");

                entity.Property(e => e.Mahang)
                    .HasMaxLength(50)
                    .HasColumnName("mahang");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Donvitinh)
                    .HasMaxLength(100)
                    .HasColumnName("donvitinh");

                entity.Property(e => e.Hinh)
                    .HasMaxLength(100)
                    .HasColumnName("hinh");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(100)
                    .HasColumnName("maloai");

                entity.Property(e => e.Tenhang)
                    .HasMaxLength(100)
                    .HasColumnName("tenhang");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.HangHoas)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK__HangHoa__maloai__59063A47");
            });

            modelBuilder.Entity<LoaiHangHoa>(entity =>
            {
                entity.HasKey(e => e.Maloai)
                    .HasName("PK__LoaiHang__734B3AEA71BBF355");

                entity.ToTable("LoaiHangHoa");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(100)
                    .HasColumnName("maloai");

                entity.Property(e => e.Mansx)
                    .HasMaxLength(100)
                    .HasColumnName("mansx");
            });

            modelBuilder.Entity<PhieuDatHang>(entity =>
            {
                entity.HasKey(e => e.Mapdh)
                    .HasName("PK__PhieuDat__0AFE5029830B6890");

                entity.ToTable("PhieuDatHang");

                entity.Property(e => e.Mapdh)
                    .HasMaxLength(50)
                    .HasColumnName("mapdh");

                entity.Property(e => e.Diachigh)
                    .HasMaxLength(50)
                    .HasColumnName("diachigh");

                entity.Property(e => e.Makh)
                    .HasMaxLength(100)
                    .HasColumnName("makh");

                entity.Property(e => e.Ngaydh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaydh");

                entity.Property(e => e.Ngaygh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaygh");
            });

            modelBuilder.Entity<PhieuGiaoHang>(entity =>
            {
                entity.HasKey(e => new { e.Ngaygh, e.Diachigh })
                    .HasName("PK__PhieuGia__509BD9747FC0775E");

                entity.ToTable("PhieuGiaoHang");

                entity.Property(e => e.Ngaygh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaygh");

                entity.Property(e => e.Diachigh)
                    .HasMaxLength(50)
                    .HasColumnName("diachigh");

                entity.Property(e => e.Manv)
                    .HasMaxLength(50)
                    .HasColumnName("manv");

                entity.Property(e => e.Mapdh)
                    .HasMaxLength(50)
                    .HasColumnName("mapdh");

                entity.Property(e => e.Tennguoinhan)
                    .HasMaxLength(50)
                    .HasColumnName("tennguoinhan");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.PhieuGiaoHangs)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK__PhieuGiaoH__manv__5DCAEF64");

                entity.HasOne(d => d.MapdhNavigation)
                    .WithMany(p => p.PhieuGiaoHangs)
                    .HasForeignKey(d => d.Mapdh)
                    .HasConstraintName("FK__PhieuGiao__mapdh__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
