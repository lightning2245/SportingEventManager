﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportingEventManager.Models;

namespace SportingEventManager.ViewModels
{
    public class ScheduleFormViewModel
    {
		private ICollection<Coach> _coaches;
		public virtual ICollection<Coach> Coaches
		{
			get { return this._coaches ?? (this._coaches = new HashSet<Coach>()); }
			set { this._coaches = value; }
		}

		public Schedule Schedule { get; set; }
    }
}