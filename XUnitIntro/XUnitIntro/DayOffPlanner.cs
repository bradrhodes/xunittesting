using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitIntro
{
	public class DayOffPlanner
	{
		private readonly WeatherChecker _weatherChecker;

		public DayOffPlanner(WeatherChecker weatherChecker)
		{
			if (weatherChecker == null) throw new ArgumentNullException(nameof(weatherChecker));
			_weatherChecker = weatherChecker;
		}

		public Activity WhatShouldIDoToday()
		{
			if(_weatherChecker.IsItNiceOutside())
				return Activity.GoOutside;

			return Activity.StayInside;
		}
	}

	public class WeatherChecker
	{
		public bool IsItNiceOutside()
		{
			return false;
		}
	}

	public enum Activity
	{
		GoOutside,
		StayInside
	}
}
