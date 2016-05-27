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
		    public void ItShouldTellMeToStayInside()
		    {
			    // arrange
				var sut = new DayOffPlanner();

				// act
			    var result = sut.WhatShouldIDoToday();

				// assert
				Assert.Equal(Activity.StayInside, result);
		    }
	    }
    }
}
