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
		private readonly IProvideTemperature _temperatureProvider;
		private readonly ICheckIfItsRaining _rainChecker;

		public WeatherChecker(IProvideTemperature temperatureProvider, ICheckIfItsRaining rainChecker)
		{
			if (temperatureProvider == null) throw new ArgumentNullException(nameof(temperatureProvider));
			if (rainChecker == null) throw new ArgumentNullException(nameof(rainChecker));
			_temperatureProvider = temperatureProvider;
			_rainChecker = rainChecker;
		}

		public bool IsItNiceOutside()
		{
			if (_temperatureProvider.GetTemperature() >= 30)
				return true;

			if (_rainChecker.IsItRaining())
				return false;

			return _temperatureProvider.GetTemperature() >= 20;
		}
	}

	public interface ICheckIfItsRaining
	{
		bool IsItRaining();
	}

	public interface IProvideTemperature
	{
		int GetTemperature();
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
