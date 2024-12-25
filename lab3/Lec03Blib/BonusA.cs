using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusA : IBonus
    {
        public float cost1hour { get; set; }
        private float _a;
        private float _b;

        // Уровень 1
        public BonusA(float cost1hour)
        {
            this.cost1hour = cost1hour;
        }

        // Уровень 2
        public BonusA(float cost1hour, float a)
        {
            this.cost1hour = cost1hour;
            this._a = a;
        }

        // Уровень 3
        public BonusA(float cost1hour, float a, float b)
        {
            this.cost1hour = cost1hour;
            this._a = a;
            this._b = b;
        }

        public float calc(float number_hours)
        {
            if (_a == 0 && _b == 0)
            {
                // Уровень 1: wH * cH
                return number_hours * cost1hour;
            }
            else if (_b == 0)
            {
                // Уровень 2: (wH + a) * cH
                return (number_hours + _a) * cost1hour;
            }
            else
            {
                // Уровень 3: (wH + a) * (cH + b)
                return (number_hours + _a) * (cost1hour + _b);
            }
        }
    }
}

