using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class FactoryL2 : IFactory
    {
        private float _a;

        public FactoryL2(float a)
        {
            _a = a;
        }

        public IBonus getA(float cost1hour)
        {
            return new BonusA(cost1hour, _a);
        }

        public IBonus getB(float cost1hour, float x)
        {
            return new BonusB(cost1hour, _a, x);
        }

        public IBonus getC(float cost1hour, float x, float y)
        {
            return new BonusC(cost1hour, _a, x, y);
        }
    }
}

