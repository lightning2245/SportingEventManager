using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingEventManager.Dtos
{	
	public class AgeRangeDto
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		
		[Required]
        [Display(Name = "Minimum Age")]
        public int? Min { get; set; }

		
		[Required]
        [Display(Name = "Maximum Age")]
        public int? Max { get; set; }

		[Display(Name = "Name")]
		public string Name
		{
			get	{ return Min.ToString() + " to " + Max.ToString(); }
		}

		//
		//public ICollection<CoachDto> Coaches { get; set; }
  //      [Display(Name = "Coaches")]
  //      public ICollection<int?> CoachesIds { get; set; }

		//
		//public ICollection<SportsEventDto> SportsEvents { get; set; }
  //      [Display(Name = "Sports Events")]
  //      public ICollection<int?> SportsEventsIds { get; set; }
    }
}