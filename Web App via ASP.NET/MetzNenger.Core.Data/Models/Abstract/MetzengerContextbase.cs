using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MetzNenger.Core.Data.Models
{
    public abstract partial class MetzengerContextBase : DbContext
    {
        public MetzengerContextBase()
        {
        }

        public MetzengerContextBase(DbContextOptions<MetzengerContextBase> options)
            : base(options)
        {
        }

        public virtual DbSet<Archive> Archives { get; set; } = null!;
        public virtual DbSet<AttachedFile> AttachedFiles { get; set; } = null!;
        public virtual DbSet<Bookmark> Bookmarks { get; set; } = null!;
        public virtual DbSet<Channel> Channels { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<Consult> Consults { get; set; } = null!;
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
            modelBuilder.Entity<Archive>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.MessageId, e.BookmarkId })
                    .HasName("PK__Archive__35C0127BCE72F6B5");

                entity.ToTable("Archive");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.BookmarkId).HasColumnName("bookmark_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archive__account__33D4B598");

                entity.HasOne(d => d.Bookmark)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.BookmarkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archive__bookmar__35BCFE0A");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Archives)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Archive__message__34C8D9D1");
            });

            modelBuilder.Entity<AttachedFile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK__Attached__07D884C685E70B54");

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
                    .HasConstraintName("FK__AttachedF__messa__3C69FB99");
            });

            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.ToTable("Bookmark");

                entity.Property(e => e.BookmarkId).HasColumnName("bookmark_id");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("Channel");

                entity.HasIndex(e => e.ChannelName, "UQ__Channel__06D71C416DCA86B0")
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
                    .HasName("PK__Classroo__FDF47986E5B6CBA8");

                entity.ToTable("Classroom");

                entity.HasIndex(e => e.ClassName, "UQ__Classroo__7DC4C39D7054F8C2")
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
                    .HasName("PK__Playback__3619D423226931AE");

                entity.ToTable("Consult");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.ReadingDate)
                    .HasColumnType("date")
                    .HasColumnName("reading_date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Consults)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Playback__accoun__3F466844");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Consults)
                    .HasForeignKey(d => d.MessageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Playback__messag__403A8C7D");
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

                entity.Property(e => e.IsFavorite).HasColumnName("is_favorite");

                entity.Property(e => e.Timestamping).HasColumnName("timestamping");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__account__300424B4");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK__Message__channel__30F848ED");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__UserAcco__46A222CD40ADBA3E");

                entity.ToTable("UserAccount");

                entity.HasIndex(e => e.Email, "UQ__UserAcco__AB6E6164BE7E9D3E")
                    .IsUnique();

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AdministrativeStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("administrative_status");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.IsValidated).HasColumnName("is_validated");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__UserAccou__class__2D27B809");

                entity.HasMany(d => d.Channels)
                    .WithMany(p => p.Accounts)
                    .UsingEntity<Dictionary<string, object>>(
                        "Access",
                        l => l.HasOne<Channel>().WithMany().HasForeignKey("ChannelId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Access__channel___398D8EEE"),
                        r => r.HasOne<UserAccount>().WithMany().HasForeignKey("AccountId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Access__account___38996AB5"),
                        j =>
                        {
                            j.HasKey("AccountId", "ChannelId").HasName("PK__Access__E472A4D71B90FC28");

                            j.ToTable("Access");

                            j.IndexerProperty<int>("AccountId").HasColumnName("account_id");

                            j.IndexerProperty<int>("ChannelId").HasColumnName("channel_id");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
