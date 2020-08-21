using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;

using Repository.Entities;
using Repository.Entities.Lookups;

namespace EF_DB
{
	public class Context : DbContext
	{
		private static string _conStr;



		public static string ConnectionString
		{
			get => _conStr ?? throw new NullReferenceException("Cannot access database. Database connection string not set.");
			set => _conStr = value;
		}



		static Context() => Database.SetInitializer(new Initializer());

		public Context() : base(ConnectionString) { }



		public DbSet<Gender> Genders { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<TaskItem> Tasks { get; set; }



		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			StringPropertyConfiguration strProp;

			base.OnModelCreating(modelBuilder);

			Configuration.LazyLoadingEnabled = false;

			//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


			// ========================================================
			EntityTypeConfiguration<Gender> gender = modelBuilder.Entity<Gender>();

			strProp = gender.Property(g => g.Name);

			strProp.IsRequired();
			strProp.HasMaxLength(10);


			strProp = gender.Property(g => g.Anrede);

			strProp.IsRequired();
			strProp.HasMaxLength(10);

			gender.HasIndex(g => g.Name).IsUnique();
			gender.HasIndex(g => g.Anrede).IsUnique();


			// ========================================================
			EntityTypeConfiguration<User> user = modelBuilder.Entity<User>();

			user.Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			user.HasRequired(u => u.Gender).WithMany().WillCascadeOnDelete(false);

			strProp = user.Property(u => u.FirstName);
			strProp.IsRequired();
			strProp.HasMaxLength(30);

			strProp = user.Property(u => u.FamilyName);
			strProp.IsRequired();
			strProp.HasMaxLength(30);

			user.Property(u => u.CreatedAt).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed).HasColumnType("SMALLDATETIME");


			// ========================================================
			EntityTypeConfiguration<TaskItem> task = modelBuilder.Entity<TaskItem>();

			task.HasOptional(t => t.Assignee).WithMany(u => u.Tasks).WillCascadeOnDelete(false);

			strProp = task.Property(t => t.Name);

			strProp.IsRequired();
			strProp.HasMaxLength(200);
		}
	}
}
