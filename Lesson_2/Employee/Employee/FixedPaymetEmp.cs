using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class FixedPaymetEmp : Base
    {
        public FixedPaymetEmp(double fixedRate) : base(fixedRate)
        {
        }

        public override double Payment()
        {
            return FixRate;
        }
    }
}
