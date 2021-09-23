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
            //Skab substitut
            fakeHeater = Substitute.For<IHeater>();
            fakeSensor = Substitute.For<ITempSensor>();
            //Opsæt Unit under test
            uut = new ECS(25, fakeSensor, fakeHeater);
        }

        [TestCase(0, 20)]
        [TestCase(25, 30)]
        public void ECSRegulate_TempAboveTreshhold_AssertHeaterOff(int threshold, int tempSensorTemp)
        {
            //arrange
            fakeSensor.GetTemp().Returns(tempSensorTemp);
            uut.SetThreshold(threshold);
            //Act
            uut.Regulate();
            //Assert
            fakeHeater.Received().TurnOff();
        }

        [TestCase(20,0)]
        [TestCase(30,25)]
        public void ECSRegulate_TempBelowTreshhold_AssertHeaterOn(int threshold, int tempSensorTemp)
        {
            //Arrange
            fakeSensor.GetTemp().Returns(tempSensorTemp);
            uut.SetThreshold(threshold);
            //Act
            uut.Regulate();
            //Assert
            fakeHeater.Received().TurnOn();
        }
    }
}