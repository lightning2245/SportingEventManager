using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingEventManager.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Organizer> Organizers { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Guardian> Guardians { get; set; }
		public DbSet<Coach> Coaches { get; set; }
		public DbSet<Sport> Sports { get; set; }
		public DbSet<Location> Locations { get; set; }
		public DbSet<AgeRange> AgeRanges { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Schedule> Schedules { get; set; }
		public DbSet<SportsEvent> SportsEvents { get; set; }


		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
			this.Configuration.ProxyCreationEnabled = false;
		}

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		//}


		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{

		//	//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

		//	//modelBuilder.Entity<Organizer>()
		//	//   .HasRequired(f => f.Status)
		//	//   .WithRequiredDependent()
		//	//   .WillCascadeOnDelete(false);

		//	//modelBuilder.Entity<AgeRange>()
		//	//   .HasRequired(f => f.Status)
		//	//   .WithRequiredDependent()
		//	//   .WillCascadeOnDelete(false);

		//}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}