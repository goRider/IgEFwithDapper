using System;
using IgWebTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IgWebTest.EFCore
{
    public partial class IgniteTestDatabaseContext : DbContext
    {
        public IgniteTestDatabaseContext()
        {
        }

        public IgniteTestDatabaseContext(DbContextOptions<IgniteTestDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<IgniteApplicationStatus> IgniteApplicationStatus { get; set; }
        public virtual DbSet<IgniteBusinessUnit> IgniteBusinessUnit { get; set; }
        public virtual DbSet<IgniteRole> IgniteRole { get; set; }
        public virtual DbSet<IgniteRoleClaim> IgniteRoleClaim { get; set; }
        public virtual DbSet<IgniteUser> IgniteUser { get; set; }
        public virtual DbSet<IgniteUserApplication> IgniteUserApplication { get; set; }
        public virtual DbSet<IgniteUserClaim> IgniteUserClaim { get; set; }
        public virtual DbSet<IgniteUserLocation> IgniteUserLocation { get; set; }
        public virtual DbSet<IgniteUserLogin> IgniteUserLogin { get; set; }
        public virtual DbSet<IgniteUserRole> IgniteUserRole { get; set; }
        public virtual DbSet<IgniteUserTitle> IgniteUserTitle { get; set; }
        public virtual DbSet<IgniteUserToken> IgniteUserToken { get; set; }
        public virtual DbSet<IgniteUserType> IgniteUserType { get; set; }
        public virtual DbSet<QuestionsToAnswer> QuestionsToAnswer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "ign");

                entity.Property(e => e.DepartmentId).ValueGeneratedNever();

                entity.Property(e => e.DepartmentName).HasMaxLength(40);
            });

            modelBuilder.Entity<IgniteApplicationStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK_ApplicationStatus");

                entity.ToTable("IgniteApplicationStatus", "ign");

                entity.Property(e => e.StatusId).ValueGeneratedNever();

                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<IgniteBusinessUnit>(entity =>
            {
                entity.HasKey(e => e.Buid);

                entity.ToTable("IgniteBusinessUnit", "ign");

                entity.Property(e => e.Buid)
                    .HasColumnName("BUID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusinessUnitName).HasMaxLength(50);
            });

            modelBuilder.Entity<IgniteRole>(entity =>
            {
                entity.ToTable("IgniteRole", "ign");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.NormalizedName).HasMaxLength(128);
            });

            modelBuilder.Entity<IgniteRoleClaim>(entity =>
            {
                entity.ToTable("IgniteRoleClaim", "ign");

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.ClaimType).HasMaxLength(128);

                entity.Property(e => e.ClaimValue).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.IgniteRoleClaim)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<IgniteUser>(entity =>
            {
                entity.HasKey(e => e.IgniteId);

                entity.ToTable("IgniteUser", "ign");

                entity.HasIndex(e => e.FkBuid)
                    .IsUnique();

                entity.HasIndex(e => e.FkDepartmentId)
                    .IsUnique();

                entity.HasIndex(e => e.FkIgniteUserTypeId)
                    .IsUnique();

                entity.HasIndex(e => e.FkLocationId)
                    .IsUnique();

                entity.HasIndex(e => e.FkTitleId)
                    .IsUnique();

                entity.HasIndex(e => e.IgniteEmail)
                    .IsUnique()
                    .HasFilter("([IgniteEmail] IS NOT NULL)");

                entity.HasIndex(e => e.NormalizedIgniteEmail)
                    .HasName("IgniteEmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.ApplicationApprovalDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.ConcurrencyStamp).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(70);

                entity.Property(e => e.FirstNameLastName).HasMaxLength(210);

                entity.Property(e => e.FkIgniteUserTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.HiredDate).HasColumnType("date");

                entity.Property(e => e.IgniteEmail).HasMaxLength(110);

                entity.Property(e => e.IgniteUserCreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName).HasMaxLength(70);

                entity.Property(e => e.MiddleName).HasMaxLength(70);

                entity.Property(e => e.NormalizedIgniteEmail).HasMaxLength(110);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(80);

                entity.Property(e => e.PasswordHash).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(21);

                entity.Property(e => e.SecurityStamp).HasMaxLength(200);

                entity.Property(e => e.TermDate).HasColumnType("date");

                entity.Property(e => e.UserName).HasMaxLength(80);

                entity.HasOne(d => d.FkBu)
                    .WithOne(p => p.IgniteUser)
                    .HasForeignKey<IgniteUser>(d => d.FkBuid);

                entity.HasOne(d => d.FkDepartment)
                    .WithOne(p => p.IgniteUser)
                    .HasForeignKey<IgniteUser>(d => d.FkDepartmentId);

                entity.HasOne(d => d.FkIgniteUserType)
                    .WithOne(p => p.IgniteUser)
                    .HasForeignKey<IgniteUser>(d => d.FkIgniteUserTypeId);

                entity.HasOne(d => d.FkLocation)
                    .WithOne(p => p.IgniteUser)
                    .HasForeignKey<IgniteUser>(d => d.FkLocationId);

                entity.HasOne(d => d.FkTitle)
                    .WithOne(p => p.IgniteUser)
                    .HasForeignKey<IgniteUser>(d => d.FkTitleId);
            });

            modelBuilder.Entity<IgniteUserApplication>(entity =>
            {
                entity.HasKey(e => e.ApplicationId);

                entity.ToTable("IgniteUserApplication", "ign");

                entity.HasIndex(e => e.FkApplicationStatusId)
                    .HasName("IX_IgniteUserApplication_FkApplicationStatusStatusId");

                entity.HasIndex(e => e.FkIgniteUserId);

                entity.Property(e => e.ApplicationCreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BuName).HasMaxLength(100);

                entity.Property(e => e.LocationName).HasMaxLength(240);

                entity.Property(e => e.ManagerName).HasMaxLength(130);

                entity.Property(e => e.ManagerStatusChangeDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.PreQualificationQuestionsCompletionDate).HasColumnType("datetime2(3)");

                entity.HasOne(d => d.FkApplicationStatus)
                    .WithMany(p => p.IgniteUserApplication)
                    .HasForeignKey(d => d.FkApplicationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IgniteUserApplication_FkApplicationStatusId");

                entity.HasOne(d => d.FkIgniteUser)
                    .WithMany(p => p.IgniteUserApplication)
                    .HasForeignKey(d => d.FkIgniteUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IgniteUserApplication_FkIgniteUserId");
            });

            modelBuilder.Entity<IgniteUserClaim>(entity =>
            {
                entity.ToTable("IgniteUserClaim", "ign");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.ClaimType).HasMaxLength(128);

                entity.Property(e => e.ClaimValue).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IgniteUserClaim)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_IgniteUserClaim_IgniteUser_IgniteId");
            });

            modelBuilder.Entity<IgniteUserLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("IgniteUserLocation", "ign");

                entity.Property(e => e.LocationId).ValueGeneratedNever();

                entity.Property(e => e.CityLocationName).HasMaxLength(80);

                entity.Property(e => e.CountryLocationName).HasMaxLength(80);

                entity.Property(e => e.StateLocationName).HasMaxLength(80);
            });

            modelBuilder.Entity<IgniteUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.ToTable("IgniteUserLogin", "ign");

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.ProviderDisplayName).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IgniteUserLogin)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<IgniteUserRole>(entity =>
            {
                entity.HasKey(e => new { e.IgniteUserRoleId, e.RoleId });

                entity.ToTable("IgniteUserRole", "ign");

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.IgniteUserRoleNavigation)
                    .WithMany(p => p.IgniteUserRole)
                    .HasForeignKey(d => d.IgniteUserRoleId)
                    .HasConstraintName("FK_IgniteUserRole_IgniteUser_IgniteId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.IgniteUserRole)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<IgniteUserTitle>(entity =>
            {
                entity.HasKey(e => e.TitleId);

                entity.ToTable("IgniteUserTitle", "ign");

                entity.Property(e => e.TitleId).ValueGeneratedNever();

                entity.Property(e => e.TitleName).HasMaxLength(80);
            });

            modelBuilder.Entity<IgniteUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.ToTable("IgniteUserToken", "ign");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Value).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.IgniteUserToken)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IgniteUserToken_IgniteUser");
            });

            modelBuilder.Entity<IgniteUserType>(entity =>
            {
                entity.ToTable("IgniteUserType", "ign");

                entity.Property(e => e.IgniteUserTypeId).ValueGeneratedNever();

                entity.Property(e => e.IgniteUserTypeName).HasMaxLength(40);
            });

            modelBuilder.Entity<QuestionsToAnswer>(entity =>
            {
                entity.HasKey(e => e.QuestionAnswerId)
                    .HasName("PK_QuestionToAnswers");

                entity.ToTable("QuestionsToAnswer", "ign");

                entity.HasIndex(e => e.FkIgniteApplicationId)
                    .IsUnique();

                entity.Property(e => e.CompletePreQualificationQuestionsDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.CompleteQualificationQuestionsDate).HasColumnType("datetime2(3)");

                entity.Property(e => e.FifthPreQualQuestion)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstPreQualAnswer)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstPreQualQuestion)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('Employee Title')");

                entity.Property(e => e.FirstQualAnswer)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FirstQualQuestion)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FourthPreQualAnswer)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FourthPreQualQuestion)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('Manager Name')");

                entity.Property(e => e.FourthQualAnswer)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FourthQualQuestion)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondPreQualAnswer)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondPreQualQuestion)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('Department')");

                entity.Property(e => e.SecondQualAnswer)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondQualQuestion)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SixthPreQualQuestion)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ThirdPreQualAnswer)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ThirdPreQualQuestion)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('BusinessUnit')");

                entity.Property(e => e.ThirdQualAnswer)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ThirdQualQuestion)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.FkIgniteApplication)
                    .WithOne(p => p.QuestionsToAnswer)
                    .HasForeignKey<QuestionsToAnswer>(d => d.FkIgniteApplicationId);
            });
        }
    }
}
