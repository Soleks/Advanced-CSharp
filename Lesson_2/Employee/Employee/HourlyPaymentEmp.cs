using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class HourlyPaymentEmp : Base
    {
        public HourlyPaymentEmp(double fixedRate) : base(fixedRate)
        {
        }

        public override double Payment()
        {
            return 20.8 * 8 * FixRate;
        }
    }
}
