using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Dtos
{	
	public class CoachDto
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		 public int Id { get; set; }
		
		[Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
         public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
         public string LastName { get; set; }

		[Display(Name = "Name")]
		public string Name
		{
			get	{ return FirstName + " " + LastName; }
		}

		[Required]
        [StringLength(75)]
         public string City { get; set; }

        [Required]
        [StringLength(75)]
         public string State { get; set; }

		[Required]
		[StringLength(20)]
		public string Zip { get; set; }


		[StringLength(75)]
		public string Street { get; set; }

		//[StringLength(75)]
		//public string Street
		//{
		//	get
		//	{
		//		return Street == null ? "" : Street;
		//	}
		//	set { Street = value; }
		//}

		[Display(Name = "Address")]
		public string Address
		{
			get{return City + ", " + State + " " + Street == null ? "" : Street + " " + Zip;}
		}

		// public ICollection<LocationDto> Locations { get; set; }
		//[Display(Name = "Locations")]
		// public ICollection<int?> LocationsIds { get; set; }

		// public ICollection<SportDto> Sports { get; set; }
		//[Display(Name = "Sports")]
		// public ICollection<int?> SportsIds { get; set; }

		// public ICollection<GenderDto> Genders { get; set; }
		//[Display(Name = "Genders")]
		// public ICollection<int?> GendersIds { get; set; }

		// public ICollection<AgeRangeDto> AgeRanges { get; set; }
		//[Display(Name = "Age Ranges")]
		// public ICollection<int?> AgeRangesIds { get; set; }

		// public ICollection<ScheduleDto> Schedules { get; set; }
		//[Display(Name = "Schedules")]
		// public ICollection<int?> SchedulesIds { get; set; }

		// public ICollection<SportsEventDto> SportsEvent { get; set; }
		//[Display(Name = "Sports Events")]
		// public ICollection<int?> SportsEventIds { get; set; }
	}
}