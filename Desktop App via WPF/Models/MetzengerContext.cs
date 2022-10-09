using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MetzNenger44.Models
{
    public partial class MetzengerContext : DbContext
    {
        public MetzengerContext()
        {
        }

        public MetzengerContext(DbContextOptions<MetzengerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Access> Accesses { get; set; } = null!;
        public virtual DbSet<Archive> Archives { get; set; } = null!;
        public virtual DbSet<AttachedFile> AttachedFiles { get; set; } = null!;
        public virtual DbSet<Bookmark> Bookmarks { get; set; } = null!;
        public virtual DbSet<Channel> Channels { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<Consult> Consults { get; set; } = null!;
        public virtual DbSet<Invite> Invites { get; set; } = null!;
        public virtual DbSet<Meeting> Meetings { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:vps-fd1d117a.vps.ovh.net;Database=Metzenger;Encrypt=False;Persist Security Info=True;Trusted_Connection=False;User ID=olivier;Password=starlightextinction;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.ChannelId })
                    .HasName("PK__Access__E472A4D7DBC73107");

                entity.ToTable("Access");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.ChannelId).HasColumnName("channel_id");

                entity.Property(e => e.FirstConnection).HasColumnName("first_connection");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Accesses)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Access__account___412EB0B6");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Accesses)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Access__channel___4222D4EF");
            });

            modelBuilder.Entity<Archive>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.MessageId, e.BookmarkId })
                    .HasName("PK__Archive__35C0127BD8803C1D");

                entity.ToTable("Archive");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.BookmarkId).HasColumnName("bookmark_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archive__account__3C69FB99");

                entity.HasOne(d => d.Bookmark)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.BookmarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archive__bookmar__3E52440B");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archive__message__3D5E1FD2");
            });

            modelBuilder.Entity<AttachedFile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__Attached__07D884C6E69898DA");

                entity.ToTable("AttachedFile");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.FileHash)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("file_hash");

                entity.Property(e => e.FileName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("file_name");

                entity.Property(e => e.FileType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("file_type");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.AttachedFiles)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AttachedF__messa__35BCFE0A");
            });

            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.ToTable("Bookmark");

                entity.Property(e => e.BookmarkId).HasColumnName("bookmark_id");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("Channel");

                entity.HasIndex(e => e.ChannelName, "UQ__Channel__06D71C4189DA2E36")
                    .IsUnique();

                entity.Property(e => e.ChannelId).HasColumnName("channel_id");

                entity.Property(e => e.ChannelName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("channel_name");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__Classroo__FDF4798638186E4F");

                entity.ToTable("Classroom");

                entity.HasIndex(e => e.ClassName, "UQ__Classroo__7DC4C39DA5E2FB20")
                    .IsUnique();

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class_name");
            });

            modelBuilder.Entity<Consult>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.MessageId })
                    .HasName("PK__Consult__3619D42379B81A17");

                entity.ToTable("Consult");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.ReadingDate).HasColumnName("reading_date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Consults)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consult__account__38996AB5");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Consults)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consult__message__398D8EEE");
            });

            modelBuilder.Entity<Invite>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.MeetingId })
                    .HasName("PK__Invite__EAD9B3071D964324");

                entity.ToTable("Invite");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.MeetingTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("meeting_title");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invite__account___44FF419A");

                entity.HasOne(d => d.Meeting)
                    .WithMany(p => p.Invites)
                    .HasForeignKey(d => d.MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Invite__meeting___45F365D3");
            });

            modelBuilder.Entity<Meeting>(entity =>
            {
                entity.ToTable("Meeting");

                entity.Property(e => e.MeetingId).HasColumnName("meeting_id");

                entity.Property(e => e.MeetingDate).HasColumnName("meeting_date");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Body)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("body");

                entity.Property(e => e.ChannelId).HasColumnName("channel_id");

                entity.Property(e => e.Timestamping).HasColumnName("timestamping");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__account__31EC6D26");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK__Message__channel__32E0915F");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__UserAcco__46A222CD14D39FEE");

                entity.ToTable("UserAccount");

                entity.HasIndex(e => e.Email, "UQ__UserAcco__AB6E6164FF2A8642")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AdministrativeStatus)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("administrative_status");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsValidated).HasColumnName("is_validated");

                entity.Property(e => e.LastName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__UserAccou__class__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
