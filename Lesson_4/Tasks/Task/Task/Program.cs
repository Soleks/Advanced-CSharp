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
                    Console.WriteLine($"элементы int {item} встрчается {count} раз");
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
                    Console.WriteLine($"элементы Point {item} встрчается {count} раз");
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            //в)*используя Linq.

            var li = listInt.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { Element = y.Key, Counter = y.Count() })
                .ToList();

            //целые числа
            //var li = from lint in listInt
            //         group lint by lint into g
            //         where g.Count() > 1
            //         select new { Element = g.Key, Counter = g.Count() };

            foreach (var item in li)
            {
                Console.WriteLine($"элементы int {item}");
            }

            Console.WriteLine();
            Console.WriteLine();

            //объекты Point
            var lp = listPoint.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { Element = y.Key, Counter = y.Count() })
                .ToList();

            //var lp = from liPoint in listPoint
            //         group liPoint by liPoint into g
            //         where g.Count() > 1
            //         select new { Element = g.Key, Counter = g.Count() };

            foreach (var item in lp)
            {
                Console.WriteLine($"элементы Point {item}");
            }

            Console.WriteLine();
            Console.WriteLine();

   
            //3. * Дан фрагмент программы:

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            //а) Свернуть обращение к OrderBy с использованием лямбда - выражения

            var lambdaDict = dict.OrderBy(x => x.Value);

            foreach (var pair in lambdaDict)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.WriteLine();
            Console.WriteLine();

            //б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>.

            var delegateDict = dict.OrderBy(delegate (
                KeyValuePair<string, int> x) { return x.Value; });

            foreach (var pair in delegateDict)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Console.ReadKey();
        }    
    }
}
