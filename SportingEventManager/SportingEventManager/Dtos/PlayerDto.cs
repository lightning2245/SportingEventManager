using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Dtos
{	
	public class PlayerDto
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

		[Display(Name = "Gender")]
		[ForeignKey("Gender"), DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int? GenderId { get; set; }
		public virtual GenderDto Gender { get; set; }

		[Display(Name = "Gender")]
		public string GenderName
		{
			get	{ return Gender == null ? "" : Gender.Name; }
		}

		[Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
		
		[Required]
        [StringLength(75)]
        public string City { get; set; }

		
		[Required]
        [StringLength(75)]
        public string State { get; set; }


		//[StringLength(75)]
		//public string Street
		//{
		//	get
		//	{
		//		return Street == null ? "" : Street;
		//	}
		//	set { Street = value; }
		//}

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
			get	{ return City + ", " + State + " " + Street == null ? "" : Street + " " + Zip; }
		}

		[Required]
        [StringLength(75)]
        public string Zip { get; set; }

		
		//
		//public ICollection<GuardianDto> Guardians { get; set; }
		//      [Display(Name = "Guardians")]
		//
		//public IEnumerable<int?> GuardiansIds { get; set; }

		//
		//public ICollection<SportsEventDto> SportsEvents { get; set; }
		//      [Display(Name = "Sports Events")]
		//
		//public IEnumerable<int?> SportsEventsIds { get; set; }
	}
}