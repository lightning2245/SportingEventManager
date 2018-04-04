using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportingEventManager.Models;

namespace SportingEventManager.ViewModels
{
    public class PlayerFormViewModel
    {
        private ICollection<Guardian> _guardians;
		public virtual ICollection<Guardian> Guardians
		{
			get { return this._guardians ?? (this._guardians = new HashSet<Guardian>()); }
			set { this._guardians = value; }
		}

		private ICollection<SportsEvent> _sportsEvents;
		public virtual ICollection<SportsEvent> SportsEvents
		{
			get { return this._sportsEvents ?? (this._sportsEvents = new HashSet<SportsEvent>()); }
			set { this._sportsEvents = value; }
		}

		private ICollection<Gender> _genders;
		public virtual ICollection<Gender> Genders
		{
			get { return this._genders ?? (this._genders = new HashSet<Gender>()); }
			set { this._genders = value; }
		}

		public Player Player { get; set; }
    }
}