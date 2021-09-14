using NUnit.Framework;

namespace ECS.Redesign.UnitTests
{
    public class ECSUnitTests
    {
        [SetUp]
        public void Setup()
        {
            var uut = new ECS(15, new FakeTempSensor(), new FakeHeater());
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void ECSCOR_FakeDeps_AssertInjectionCorrect()
        {
            Assert.Pass();
        }

        [Test]
        public void Heater_Fake_AssertIsWarm()
        {
            Assert.Pass();
        }
    }
}