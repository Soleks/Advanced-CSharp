using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    abstract class Base : IComparable
    {
        private double fixedRate_;

        public double FixRate
        {
            get { return fixedRate_; }
        }

        protected Base()
        {
        }

        public int CompareTo(object obj)
        {
            Base temp = obj as Base;

            if (temp != null)
            {
                return FixRate.CompareTo(temp.FixRate);
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }
        }

        protected Base(double fixedRate)
        {
            fixedRate_ = fixedRate;
        }

        public abstract double Payment();
    }
}
