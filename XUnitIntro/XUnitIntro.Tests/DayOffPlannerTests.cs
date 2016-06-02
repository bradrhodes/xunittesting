using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;
using System.Text;
using FakeItEasy;
using Xunit;

namespace XUnitIntro.Tests
{
    public class DayOffPlannerTests
    {
	    public class WhenDecidingWhatToDo
	    {
		    public class AndTheWeatherIsNiceOutside
		    {
					
				[Fact]
				public void ItShouldTellMeToGoOutside()
				{
					// arrange
					var weatherChecker = A.Fake<ICheckTheWeather>();
					A.CallTo(() => weatherChecker.IsItNiceOutside()).Returns(true);

					var sut = new DayOffPlanner(weatherChecker);

					// act
					var result = sut.WhatShouldIDoToday();

					Assert.Equal(Activity.GoOutside, result);
				}
		    }

		    public class AndTheWeatherIsNotNiceOutside
		    {
			    [Fact]
			    public void ItShouldTellMeToStayInside()
			    {
				    // arrange
				    var weatherChecker = A.Fake<ICheckTheWeather>();
				    A.CallTo(() => weatherChecker.IsItNiceOutside()).Returns(false);

					var sut = new DayOffPlanner(weatherChecker);

				    // act
				    var result = sut.WhatShouldIDoToday();


				    // assert
					Assert.Equal(Activity.StayInside, result);
			    }
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
