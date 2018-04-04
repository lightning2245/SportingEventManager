using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportingEventManager.Dtos
{	
	public class SportDto
    {		
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		
		[Required]
        [StringLength(100)]
        public string Name { get; set; }

		//
		//public ICollection<CoachDto> Coaches { get; set; }
  //      [Display(Name = "Coaches")]
		//
		//public ICollection<int?> CoachesIds { get; set; }
    }
}