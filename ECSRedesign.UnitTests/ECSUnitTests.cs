using NUnit.Framework;
using System;

namespace ECS.Redesign.UnitTests
{
    public class ECSUnitTests
    {
        private ECS uut;
        private FakeHeater fakeHeater;
        private FakeTempSensor fakeSensor;
        private int universalThreshold = 25;
        [SetUp]
        public void Setup()
        {
            fakeHeater = new FakeHeater();
            fakeSensor = new FakeTempSensor(30);
            uut = new ECS(universalThreshold, fakeSensor,fakeHeater);
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

        [TestCase(30)]
        [TestCase(60)]
        [TestCase(-22)]
        public void ECS_Threshold_AssertValIsSetAndGet(int threshold)
        {
            uut.SetThreshold(threshold);
            int result = uut.GetThreshold();
            Assert.That(result == threshold);
        }

        [TestCase(-8)]
        [TestCase(69)]
        [TestCase(33)]
        public void ECS_Temperature_AssertTempHasChanged(int temp)
        {
            FakeTempSensor fakeSensor1 = new FakeTempSensor(temp);
            ECS uut1 = new ECS(universalThreshold, fakeSensor1, fakeHeater);
            double result = uut1.GetCurTemp();
            Assert.That(result == temp);
        }

        //Selftest
        [Test]
        public void ECS_SelfTest_AssertHeaterAndSensor()
        {
            bool result = uut.RunSelfTest();
            Assert.That(result == true);
        }
    }
}