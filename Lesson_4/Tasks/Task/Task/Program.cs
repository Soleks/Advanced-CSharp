using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    //2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции.

    class Program
    {
        static void Main(string[] args)
        {
            //а) для целых чисел;

            List<int> listInt = new List<int>
            {
                1,
                1,
                1,
                2,
                2,
                3,
                4,
                5
            };

            foreach (var item in listInt)
            {
                int count = listInt.Count((i) => i == item);

                if (count > 1)
                {
                    Console.WriteLine($"элемент {item} встрчается {count} раз");
                }
            }

            //б) для обобщенной коллекции;

            List<Point> listPoint = new List<Point>
            {
                new Point(1, 1),
                new Point(1, 1),
                new Point(1, 1),
                new Point(2, 2),
                new Point(2, 2),
                new Point(3, 3),
                new Point(3, 3),
                new Point(2, 3),
                new Point(2, 1)
            };


            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in listPoint)
            {
                int count = listPoint.Count((i) => i.X == item.Y && i.Y == item.X);

                if (count > 1)
                {
                    Console.WriteLine($"элемент {item} встрчается {count} раз");
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            //в)*используя Linq.

            //3. * Дан фрагмент программы:

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            //а) Свернуть обращение к OrderBy с использованием лямбда - выражения

            var s = dict.OrderBy(x => x.Value);

            foreach (var pair in s)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }    
    }
}
