using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {   
            //1.
            //Построить три класса(базовый и 2 потомка), описывающих некоторых работников с
            //почасовой оплатой(один из потомков) и фиксированной оплатой(второй потомок).

            //а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной
            //платы.Для «повременщиков» формула для расчета такова: «среднемесячная заработная
            //плата = 20.8 * 8 * почасовую ставку», для работников с фиксирован

            Base fixEmp = new FixedPaymetEmp(100);
            Base hourlyEmp = new HourlyPaymentEmp(100);

            Console.WriteLine("Fixed Payment {0}", fixEmp.Payment());
            Console.WriteLine("Hourly Payment {0}", hourlyEmp.Payment());
            Console.WriteLine("");
            Console.WriteLine("");

            //б) Создать на базе абстрактного класса массив сотрудников и заполнить его.

            Random rnd = new Random();
            Base[] obj = new Base[30];

            for (int i = 0; i < obj.Length/2; i++)
            {
                obj[i] = new FixedPaymetEmp(rnd.Next(50, 500));
            }

            for (int j = obj.Length/2; j < obj.Length; j++)
            {
                obj[j] = new HourlyPaymentEmp(rnd.Next(50, 500));
            }

            //в) **Реализовать интерфейсы для возможности сортировки массива используя Array.Sort().

            Array.Sort(obj);

            foreach (var g in obj)
            {
                if (g is HourlyPaymentEmp)
                {
                    Console.WriteLine("Fixed Payment {0}", g.Payment());

                }
            }

            foreach (var g in obj)
            {
                if (g is FixedPaymetEmp)
                {
                    Console.WriteLine("Hourly Payment {0}", g.Payment());
                }
            }

            Console.WriteLine("");
            Console.WriteLine("");

            //г) ***Создать класс содержащий массив сотрудников и реализовать возможность вывода
            //данных с использованием foreach.

            EmpContainer emp = new EmpContainer();

            foreach (var ec in emp )
            {
                if (ec is HourlyPaymentEmp)
                {
                    HourlyPaymentEmp hpe = ec as HourlyPaymentEmp;

                    if (hpe != null)
                    {
                        Console.WriteLine("HourlyPaymentEmp {0}", hpe.Payment());
                    }
                } else if (ec is FixedPaymetEmp)
                {
                    FixedPaymetEmp fpe = ec as FixedPaymetEmp;

                    if (fpe != null)
                    {
                        Console.WriteLine("FixedPaymetEmp {0}", fpe.Payment());
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
