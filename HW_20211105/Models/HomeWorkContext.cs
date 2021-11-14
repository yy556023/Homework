using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HW_20211105.Models
{
    public partial class HomeWorkContext : DbContext
    {
        public HomeWorkContext()
        {
        }

        public HomeWorkContext(DbContextOptions<HomeWorkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblMeetingAppointment> TblMeetingAppointment { get; set; }
        public virtual DbSet<TblMeetingRoom> TblMeetingRoom { get; set; }
        public virtual DbSet<TblStaff> TblStaff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMeetingAppointment>(entity =>
            {
                entity.HasKey(e => e.MeetingId);

                entity.Property(e => e.EndDateTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDateTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMeetingRoom>(entity =>
            {
                entity.HasKey(e => e.RoomId);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblStaff>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
