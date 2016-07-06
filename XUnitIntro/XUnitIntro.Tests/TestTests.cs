using System.Security.AccessControl;
using System.Xml.Serialization;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using Xunit;

namespace XUnitIntro.Tests
{
	public class TestTests
	{
		[Fact]
		public void Testsomething()
		{
			var fixture = new Fixture().Customize(new AutoFakeItEasyCustomization());
			fixture.Customize(new NumericSequencePerTypeCustomization());
//			fixture.Register<ICustomer>(() => fixture.Create<Customer>());

			var customers = fixture.CreateMany<ICustomer>();
//			var customers = fixture.CreateMany<Customer>();


		}
	}

	public class Customer : ICustomer
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public interface ICustomer
	{
		int Id { get;  }
		string Name { get; }
	}
}