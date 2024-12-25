using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class FactoryL3 : IFactory
    {
        private float _a;
        private float _b;

        public FactoryL3(float a, float b)
        {
            _a = a;
            _b = b;
        }

        public IBonus getA(float cost1hour)
        {
            return new BonusA(cost1hour, _a, _b);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB(cost1hour, _a, _b, x);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC(cost1hour, _a, _b, x, y);
        }
    }
}

