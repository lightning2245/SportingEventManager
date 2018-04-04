using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportingEventManager.Models;

namespace SportingEventManager.ViewModels
{
    public class GuardianFormViewModel
    {
		private ICollection<Player> _players;
		public virtual ICollection<Player> Players
		{
			get { return this._players ?? (this._players = new HashSet<Player>()); }
			set { this._players = value; }
		}

		public Guardian Guardian { get; set; }
    }
}