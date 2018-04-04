using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Dtos
{	
	public class SportsEventDto
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
				
		[Required]
        [StringLength(255)]
		[Display(Name = "Event")]
		public string Name { get; set; }

		
		[Display(Name = "Age Range")]
		[ForeignKey("AgeRange"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? AgeRangeId { get; set; }		
		public virtual AgeRangeDto AgeRange { get; set; }

		[Display(Name = "Age Range")]
		public string AgeRangeName
		{
			get	{ return AgeRange == null ? "" : AgeRange.Name; }
		}

		//public ICollection<CoachDto> Coaches { get; set; }
		//[Display(Name = "Coaches")]

		//public ICollection<int?> CoachesIds { get; set; }

		[Display(Name = "Gender")]
		[ForeignKey("Gender"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? GenderId { get; set; }
		public virtual GenderDto Gender { get; set; }

		[Display(Name = "Gender")]
		public string GenderName
		{
			get { return Gender == null ? "" : Gender.Name; }
		}

		//private LocationDto _location;
		public virtual LocationDto Location { get; set; }
		//{
		//	get { return this._location ?? (this._location = new LocationDto()); }
		//	set { this._location = value; }
		//}

		[Display(Name = "Location")]
		[ForeignKey("Location"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? LocationId { get; set; }


		//private int? _locationId;
		//public virtual int? LocationId
		//{
		//	get { return this._location ?? (this._location = new LocationDto()); }
		//	set { this._location = value; }
		//}

		//[Display(Name = "Location")]
		//[ForeignKey("Location"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		//public virtual ICollection<AgeRange> AgeRanges
		//{
		//	get { return this._ageRanges ?? (this._ageRanges = new HashSet<AgeRange>()); }
		//	set { this._ageRanges = value; }
		//}


		//[Display(Name = "Location")]
		//[ForeignKey("Location"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		//public int? LocationId { get; set; }
		//public virtual LocationDto Location { get; set; }

		[Display(Name = "Location")]
		public string LocationName
		{
			get { return Location == null ? "" : Location.Name; }
		}

		[Display(Name = "Location")]
		public string LocationAddress
		{
			get	{ return Location == null ? "" : Location.City + ", " + Location.State + " " + Location.Street + " " + Location.Zip; }
		}
		

		[Display(Name = "Organizer")]
		[ForeignKey("Organizer"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? OrganizerId { get; set; }		
		public virtual OrganizerDto Organizer { get; set; }

		[Display(Name = "Organizer")]
		public string OrganizerName
		{
			get	{ return Organizer == null ? "" : Organizer.Name; }
		}

		//[Display(Name = "Players")]
		//public ICollection<int?> PlayersIds { get; set; }
		//public virtual ICollection<PlayerDto> Players { get; set; }

		[Display(Name = "Schedule")]
		[ForeignKey("Schedule"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? ScheduleId { get; set; }		
		public virtual ScheduleDto Schedule { get; set; }

		[Display(Name = "Schedule")]
		public string ScheduleName
		{
			get	{ return Schedule == null ? "" : Schedule.Name;	}
		}

		[Display(Name = "Sport")]
		[ForeignKey("Sport"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? SportId { get; set; }		
		public virtual SportDto Sport { get; set; }

		[Display(Name = "Sport")]
		public string SportName
		{
			get	{ return Sport == null ? "" : Sport.Name; }
		}

	}
}