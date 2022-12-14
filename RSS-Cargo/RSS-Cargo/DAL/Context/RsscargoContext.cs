// <copyright file="RsscargoContext.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_cargo.DAL.Context
{
    using System.Configuration;
    using Microsoft.EntityFrameworkCore;
    using RSS_cargo.DAL.Models;

    /// <summary>
    /// Reperesents database.
    /// </summary>
    public class RsscargoContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RsscargoContext"/> class.
        /// </summary>
        public RsscargoContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RsscargoContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public RsscargoContext(DbContextOptions<RsscargoContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets cargos.
        /// </summary>
        public virtual DbSet<Cargo> Cargos { get; set; }

        /// <summary>
        /// Gets or sets cargos feeds.
        /// </summary>
        public virtual DbSet<CargoFeed> CargoFeeds { get; set; }

        /// <summary>
        /// Gets or sets users.
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets user cargos.
        /// </summary>
        public virtual DbSet<UserCargo> UserCargos { get; set; }

        /// <summary>
        /// Gets or sets usser feeds.
        /// </summary>
        public virtual DbSet<UserFeed> UserFeeds { get; set; }

        /// <summary>
        /// Handels config.
        /// </summary>
        /// <param name="optionsBuilder">Options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MainDataBase"].ToString();
            optionsBuilder.UseNpgsql(connectionString);
        }

        /// <summary>
        /// Handels creation.
        /// </summary>
        /// <param name="modelBuilder">Builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("cargos_pk");

                entity.ToTable("cargos");

                entity.HasIndex(e => e.Name, "cargos_name_index").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(512)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CargoFeed>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("cargo_feeds_pk");

                entity.ToTable("cargo_feeds");

                entity.HasIndex(e => new { e.CargoId, e.RssFeed }, "cargo_feeds_rss_feed_index").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.CargoId).HasColumnName("cargo_id");
                entity.Property(e => e.RssFeed)
                    .HasMaxLength(2048)
                    .HasColumnName("rss_feed");

                entity.HasOne(d => d.Cargo).WithMany(p => p.CargoFeeds)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("cargo_feeds_cargo_id_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pk");

                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_index").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .HasColumnName("email");
                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("password");
                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserCargo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("user_cargos_pk");

                entity.ToTable("user_cargos");

                entity.HasIndex(e => new { e.UserId, e.CargoId }, "user_cargos_cargo_id_index").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.CargoId).HasColumnName("cargo_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Cargo).WithMany(p => p.UserCargos)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("user_cargos_cargo_id_fk");

                entity.HasOne(d => d.User).WithMany(p => p.UserCargos)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_cargos_user_id_fk");
            });

            modelBuilder.Entity<UserFeed>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("user_feeds_pk");

                entity.ToTable("user_feeds");

                entity.HasIndex(e => new { e.UserId, e.RssFeed }, "user_feeds_rss_feed_index").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.RssFeed)
                    .HasMaxLength(2048)
                    .HasColumnName("rss_feed");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User).WithMany(p => p.UserFeeds)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("user_cargos_user_id_fk");
            });
        }
    }
}