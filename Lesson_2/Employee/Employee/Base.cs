using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    abstract class Base
    {
        private double fixedRate_;

        public double FixRate
        {
            get { return fixedRate_; }
        }

        protected Base()
        {
        }

        protected Base(double fixedRate)
        {
            fixedRate_ = fixedRate;
        }

        public abstract double Payment();
    }
}
