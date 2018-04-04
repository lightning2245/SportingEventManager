using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Validation;
using SportingEventManager.Helpers;

namespace SportingEventManager.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Organizer> Organizers { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Guardian> Guardians { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<SportsEvent> SportsEvents { get; set; }
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
			//this.Configuration.ProxyCreationEnabled = false;
		}

		public override int SaveChanges()
		{
			try
			{
				return base.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				var newException = new FormattedDbEntityValidationException(e);
				throw newException;
			}
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