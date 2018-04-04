using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportingEventManager.Models;

namespace SportingEventManager.ViewModels
{
    public class SportsEventFormViewModel
    {
		private ICollection<AgeRange> _ageRanges;
		public virtual ICollection<AgeRange> AgeRanges
		{
			get { return this._ageRanges ?? (this._ageRanges = new HashSet<AgeRange>()); }
			set { this._ageRanges = value; }
		}

		private ICollection<Gender> _genders;
		public virtual ICollection<Gender> Genders
		{
			get { return this._genders ?? (this._genders = new HashSet<Gender>()); }
			set { this._genders = value; }
		}

		private ICollection<Location> _locations;
		public virtual ICollection<Location> Locations
		{
			get { return this._locations ?? (this._locations = new HashSet<Location>()); }
			set { this._locations = value; }
		}

		private ICollection<Organizer> _organizers;
		public virtual ICollection<Organizer> Organizers
		{
			get { return this._organizers ?? (this._organizers = new HashSet<Organizer>()); }
			set { this._organizers = value; }
		}

		private ICollection<Schedule> _schedules;
		public virtual ICollection<Schedule> Schedules
		{
			get { return this._schedules ?? (this._schedules = new HashSet<Schedule>()); }
			set { this._schedules = value; }
		}

		private ICollection<Coach> _coaches;
		public virtual ICollection<Coach> Coaches
		{
			get { return this._coaches ?? (this._coaches = new HashSet<Coach>()); }
			set { this._coaches = value; }
		}
		
		private ICollection<Player> _players;
		public virtual ICollection<Player> Players
		{
			get { return this._players ?? (this._players = new HashSet<Player>()); }
			set { this._players = value; }
		}

		private ICollection<Sport> _sports;
		public virtual ICollection<Sport> Sports
		{
			get { return this._sports ?? (this._sports = new HashSet<Sport>()); }
			set { this._sports = value; }
		}

		public SportsEvent SportsEvent { get; set; }

		//public AgeRange AgeRange { get; set; }


		//      //public AgeRange AgeRange { get; set; }

		//      //public ICollection<Coach> Coaches { get; set; }


		//      public Gender Gender { get; set; }


		//      public Location Location { get; set; }


		//      public Organizer Organizer { get; set; }


		//      //public ICollection<Player> Players { get; set; }


		//      public Schedule Schedule { get; set; }


		//      public Sport Sport { get; set; }


		//      public SportsEvent SportsEvent { get; set; }
	}
}