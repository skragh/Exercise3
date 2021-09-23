using NUnit.Framework;
using NSubstitute;

namespace ECS.Redesign.Nsub.UnitTests
{
    public class ECSUnitTests
    {
        private ECS uut;
        private IHeater fakeHeater;
        private ITempSensor fakeSensor;
        [SetUp]
        public void Setup()
        {
            fakeHeater = Substitute.For<IHeater>();
            fakeSensor = Substitute.For<ITempSensor>();
            uut = new ECS(25, fakeSensor, fakeHeater);
        }

        [TestCase(0, 20)]
        [TestCase(25, 30)]
        public void ECSRegulate_TempAboveTreshhold_AssertHeaterOn(int threshold, int tempSensorTemp)
        {
            fakeSensor.GetTemp().Returns(tempSensorTemp);
            uut.SetThreshold(threshold);
            uut.Regulate();
            fakeHeater.Received().TurnOff();
        }

        [TestCase(20,0)]
        [TestCase(30,25)]
        public void ECSRegulate_TempBelowTreshhold_AssertHeaterOn(int threshold, int tempSensorTemp)
        {
            fakeSensor.GetTemp().Returns(tempSensorTemp);
            uut.SetThreshold(threshold);
            uut.Regulate();
            fakeHeater.Received().TurnOn();
        }
    }
}