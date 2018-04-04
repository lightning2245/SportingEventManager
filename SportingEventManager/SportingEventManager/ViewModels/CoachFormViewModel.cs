using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportingEventManager.Models;

namespace SportingEventManager.ViewModels
{
    public class CoachFormViewModel
    {
		private ICollection<Location> _locations;
		public virtual ICollection<Location> Locations
		{
			get{return this._locations ?? (this._locations = new HashSet<Location>());}
			set	{ this._locations = value; }
		}

		private ICollection<Sport> _sports;
		public virtual ICollection<Sport> Sports
		{
			get{return this._sports ?? (this._sports = new HashSet<Sport>());}
			set{this._sports = value;}
		}

		private ICollection<Gender> _genders;
		public virtual ICollection<Gender> Genders
		{
			get{return this._genders ?? (this._genders = new HashSet<Gender>());}
			set{this._genders = value;}
		}

		private ICollection<AgeRange> _ageRanges;
		public virtual ICollection<AgeRange> AgeRanges
		{
			get{return this._ageRanges ?? (this._ageRanges = new HashSet<AgeRange>());}
			set{this._ageRanges = value;}
		}

		private ICollection<Schedule> _schedules;
		public virtual ICollection<Schedule> Schedules
		{
			get{return this._schedules ?? (this._schedules = new HashSet<Schedule>());}
			set{this._schedules = value;}
		}

		private ICollection<SportsEvent> _sportsEvents;
		public virtual ICollection<SportsEvent> SportsEvents
		{
			get{return this._sportsEvents ?? (this._sportsEvents = new HashSet<SportsEvent>());}
			set{this._sportsEvents = value;}
		}


		//public ICollection<Location> Locations { get; set; }
		//      public ICollection<Sport> Sports { get; set; }        
		//      public ICollection<Gender> Genders { get; set; }
		//      public ICollection<AgeRange> AgeRanges { get; set; }
		//      public ICollection<Schedule> Schedules { get; set; }
		//      public ICollection<SportsEvent> SportsEvents { get; set; }       

		public Coach Coach { get; set; }
    }
}