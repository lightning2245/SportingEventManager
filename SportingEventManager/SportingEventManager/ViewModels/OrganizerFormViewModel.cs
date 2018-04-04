using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportingEventManager.Models;

namespace SportingEventManager.ViewModels
{
	public class OrganizerFormViewModel
	{
		private ICollection<SportsEvent> _sportsEvents;
		public virtual ICollection<SportsEvent> SportsEvents
		{
			get { return this._sportsEvents ?? (this._sportsEvents = new HashSet<SportsEvent>()); }
			set { this._sportsEvents = value; }
		}

		public Organizer Organizer { get; set; }
	}
}