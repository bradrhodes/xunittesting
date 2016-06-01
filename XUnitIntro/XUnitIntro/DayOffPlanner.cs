using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XUnitIntro
{
	public class DayOffPlanner
	{
		private readonly ICheckTheWeather _weatherChecker;

		public DayOffPlanner(ICheckTheWeather weatherChecker)
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

	public class WeatherChecker : ICheckTheWeather
	{
		public bool IsItNiceOutside()
		{
			return false;
		}
	}

	public interface ICheckTheWeather
	{
		bool IsItNiceOutside();
	}

	public enum Activity
	{
		GoOutside,
		StayInside
	}
}
