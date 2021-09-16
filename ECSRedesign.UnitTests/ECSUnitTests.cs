using NUnit.Framework;
using System;

namespace ECS.Redesign.UnitTests
{
    public class ECSUnitTests
    {
        private ECS uut;
        private FakeHeater fakeHeater;
        private FakeTempSensor fakeSensor;
        [SetUp]
        public void Setup()
        {
            fakeHeater = new FakeHeater();
            fakeSensor = new FakeTempSensor(30);
            uut = new ECS(25, fakeSensor,fakeHeater);
        }

        [Test]
        public void ECSRegulate_TempAboveThreshhold_AssertHeaterOff()
        {
            uut.Regulate();
            Assert.That(fakeHeater.TurnedOn is false);
        }


        [TestCase(25,20,true)]
        [TestCase(25, 30,false)]
        public void ECSRegulate_Temp_AssertHeaterCorrect(int threshold,int tempSensorTemp, bool heatOn)
        {
            ECS uut1 = new ECS(threshold, new FakeTempSensor(tempSensorTemp), fakeHeater);
            uut1.Regulate();
            Assert.That(fakeHeater.TurnedOn == heatOn);
        }

        //public void ECSRegulate_uut_Temp_AssertHeaterCorrect(int thresh)
        //{

        //}
    }
}