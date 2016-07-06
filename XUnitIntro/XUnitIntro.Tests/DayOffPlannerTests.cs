using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Security.Policy;
using System.Text;
using FakeItEasy;
using IQ.Platform.TestUtilities;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;
using Xunit.Sdk;

namespace XUnitIntro.Tests
{
	public class NiceWeatherCustomization : ICustomization
	{
		public void Customize(IFixture fixture)
		{
			var weatherChecker = A.Fake<ICheckTheWeather>();

			A.CallTo(() => weatherChecker.IsItNiceOutside()).Returns(true);
			fixture.Inject(weatherChecker);
		}
	}

	public class DayOffPlannerTests
    {
	    public class WhenDecidingWhatToDo
	    {
		    public class AndTheWeatherIsNiceOutside
		    {
				//				[Theory, AutoFakeItEasyData(typeof(NiceWeatherCustomization))]
				[Fact]
				public void ItShouldTellMeToGoOutside(/*DayOffPlanner sut*/)
				{
					var fixture = new Fixture().Customize();
					fixture.CustomizeWithFakeItEasy(new NiceWeatherCustomization());

					var checker = fixture.Create<ICheckTheWeather>();
					var sut = fixture.Create<DayOffPlanner>();

//					var sut = new DayOffPlanner(weatherChecker);
					var result = sut.WhatShouldIDoToday();

					Assert.Equal(Activity.GoOutside, result);
				}
		    }

		    public class AndTheWeatherIsNotNiceOutside
		    {
			    [Theory, AutoFakeItEasyData]
			    public void ItShouldTellMeToStayInside([Frozen] ICheckTheWeather weatherChecker, int temp, DayOffPlanner sut)
			    {
					// arrange
					A.CallTo(() => weatherChecker.IsItNiceOutside()).Returns(false);

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
			[Theory]
			[InlineAutoData()]
			[InlineData(10, true, false)]
			[InlineData(10, false, false)]
			[InlineData(20, true, false)]
			[InlineData(20, false, true)]
			[InlineData(30, true, true)]
			[InlineData(30, false, true)]
			public void ItShouldReturnWhetherItIsNiceOutOrNot(int temp, bool isRaining, bool expectedResult)
			{
				// arrange
				var tempProvider = A.Fake<IProvideTemperature>();
				var rainChecker = A.Fake<ICheckIfItsRaining>();

				A.CallTo(() => tempProvider.GetTemperature()).Returns(temp);
				A.CallTo(() => rainChecker.IsItRaining()).Returns(isRaining);

				var sut = new WeatherChecker(tempProvider, rainChecker);

				// act
				var result = sut.IsItNiceOutside();

				Assert.Equal(expectedResult, result);
			}

			public class AndItIsOver30
			{
				[Fact]
				public void ItDoesntMatterIfItIsRaingingOrNot()
				{
					// arrange
					var fixture = new Fixture();

					var tempProvider = A.Fake<IProvideTemperature>();
					var rainChecker = A.Fake<ICheckIfItsRaining>();

					A.CallTo(() => tempProvider.GetTemperature()).Returns(30);
					A.CallTo(() => rainChecker.IsItRaining()).Returns(fixture.Create<bool>());

					var sut = new WeatherChecker(tempProvider, rainChecker);

					// act
					var result = sut.IsItNiceOutside();

					// assert
					Assert.True(result);
				}
			}
		}
	}
}
