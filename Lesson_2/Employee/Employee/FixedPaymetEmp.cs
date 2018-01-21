using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class FixedPaymetEmp : Base, IComparable
    {
        public FixedPaymetEmp(double fixedRate) : base(fixedRate)
        {
        }

        public int CompareTo(object obj)
        {
            FixedPaymetEmp temp = obj as FixedPaymetEmp;

            if (temp != null)
            {
                return FixRate.CompareTo(temp.FixRate);
            }
            else
            {
                throw new Exception("Невозможно сравнить два объекта");
            }
        }

        public override double Payment()
        {
            return FixRate;
        }
    }
}
