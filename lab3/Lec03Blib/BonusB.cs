using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusB : IBonus
    {
        public float cost1hour { get; set; }
        private float _a;
        private float _b;
        private float _x;

        // Уровень 1
        public BonusB(float cost1hour, float x)
        {
            this.cost1hour = cost1hour;
            this._x = x;
        }

        // Уровень 2
        public BonusB(float cost1hour, float a, float x)
        {
            this.cost1hour = cost1hour;
            this._a = a;
            this._x = x;
        }

        // Уровень 3
        public BonusB(float cost1hour, float a, float b, float x)
        {
            this.cost1hour = cost1hour;
            this._a = a;
            this._b = b;
            this._x = x;
        }

        public float calc(float number_hours)
        {
            if (_a == 0 && _b == 0)
            {
                // Уровень 1: wH * cH * x
                return number_hours * cost1hour * _x;
            }
            else if (_b == 0)
            {
                // Уровень 2: (wH + a) * cH * x
                return (number_hours + _a) * cost1hour * _x;
            }
            else
            {
                // Уровень 3: (wH + a) * (cH + b) * x
                return (number_hours + _a) * (cost1hour + _b) * _x;
            }
        }
    }
}

