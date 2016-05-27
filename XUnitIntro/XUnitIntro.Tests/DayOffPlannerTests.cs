using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitIntro.Tests
{
    public class DayOffPlannerTests
    {
	    public class WhenDecidingWhatToDo
	    {
		    [Fact]
		    public void ItShouldTellMeToGoOutside()
		    {
			    // arrange
				var weatherChecker = new WeatherChecker();
				var sut = new DayOffPlanner(weatherChecker);

				// act
			    var result = sut.WhatShouldIDoToday();

			    var weather = weatherChecker.IsItNiceOutside();

			    var expectedResult = weather ? Activity.GoOutside : Activity.StayInside;

				// assert
				Assert.Equal(expectedResult, result);
		    }
	    }
    }

	public class WeatherCheckerTests
	{
		public class WhenICheckTheWeather
		{
			public class AndItIsNotNiceOutside
			{
				[Fact]
				public void ItShouldReturnTrue()
				{
					// arrange
					var sut = new WeatherChecker();
					
					// act
					var result = sut.IsItNiceOutside();

					// assert
					Assert.False(result);
				}
			}
		}
	}
}
