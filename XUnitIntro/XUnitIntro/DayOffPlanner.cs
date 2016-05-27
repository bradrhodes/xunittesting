using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitIntro
{
	public class DayOffPlanner
	{
		public Activity WhatShouldIDoToday()
		{
			return Activity.StayInside;
		}
	}

	public enum Activity
	{
		GoOutside,
		StayInside
	}
}
