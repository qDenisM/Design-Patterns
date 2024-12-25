using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03LibN
{
    public class BonusC : IBonus
    {
        public float cost1hour { get; set; }
        private float _a;
        private float _b;
        private float _x;
        private float _y;

        // Уровень 1
        public BonusC(float cost1hour, float x, float y)
        {
            this.cost1hour = cost1hour;
            this._x = x;
            this._y = y;
        }

        // Уровень 2
        public BonusC(float cost1hour, float a, float x, float y)
        {
            this.cost1hour = cost1hour;
            this._a = a;
            this._x = x;
            this._y = y;
        }

        // Уровень 3
        public BonusC(float cost1hour, float a, float b, float x, float y)
        {
            this.cost1hour = cost1hour;
            this._a = a;
            this._b = b;
            this._x = x;
            this._y = y;
        }

        public float calc(float number_hours)
        {
            if (_a == 0 && _b == 0)
            {
                // wH * cH * x + y
                return number_hours * cost1hour * _x + _y;
            }
            else if (_b == 0)
            {
                // (wH + a) * cH * x + y
                return (number_hours + _a) * cost1hour * _x + _y;
            }
            else
            {
                // (wH + a) * (cH + b) * x + y
                return (number_hours + _a) * (cost1hour + _b) * _x + _y;
            }
        }
    }
}

