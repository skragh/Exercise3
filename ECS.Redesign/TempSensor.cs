using System;

namespace ECS.Redesign
{
    public interface ITempSensor
    {
        int GetTemp();
        bool RunSelfTest();
    }
    public class TempSensor:ITempSensor
    {
        private Random gen = new Random();

        public int GetTemp()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
    public class FakeTempSensor : ITempSensor
    {
        private int _temp;
        public FakeTempSensor(int temp)
        {
            _temp = temp;
        }
        public int GetTemp()
        {
            return _temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}