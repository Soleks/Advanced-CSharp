using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class EmpContainer : IEnumerable, IEnumerator
    {
        private Base[] _obj;
        private Random _rnd;
        private int _i = -1;

        public EmpContainer()
        {
            _obj = new Base[30];
            _rnd = new Random();

            for (int i = 0; i < _obj.Length / 2; i++)
            {
                _obj[i] = new FixedPaymetEmp(_rnd.Next(50, 500));
            }

            for (int j = _obj.Length / 2; j < _obj.Length; j++)
            {
                _obj[j] = new HourlyPaymentEmp(_rnd.Next(50, 500));
            }
        }

        public object Current => _obj[_i];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_i == _obj.Length - 1)
            {
                Reset();

                return false;
            }

            _i++;

            return true;
        }

        public void Reset()
        {
            _i = -1;
        }
    }
}
