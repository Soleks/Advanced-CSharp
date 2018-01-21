using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class HourlyPaymentEmp : Base, IComparable
    {
        public HourlyPaymentEmp(double fixedRate) : base(fixedRate)
        {
        }

        public int CompareTo(object obj)
        {
            HourlyPaymentEmp temp = obj as HourlyPaymentEmp;

            if (temp != null)
            {
                return FixRate.CompareTo(temp.FixRate);
            }

            throw new Exception("Невозможно сравнить два объекта");
        }

        public override double Payment()
        {
            return 20.8 * 8 * FixRate;
        }
    }
}
