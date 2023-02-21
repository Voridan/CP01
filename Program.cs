using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CP01
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Task 1");
            Console.WriteLine("Введіть число від 0 до 1 у десятковій формі:");
            decimal inputNum = Decimal.Parse(Console.ReadLine());
            Console.WriteLine($"Число {inputNum} в 16-ковій формі: {Task1(inputNum, 16)}");
            Console.WriteLine("Task 2");
            Console.WriteLine("Введіть x:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть y:");
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Введіть z:");
            double z = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {Task2(x, y, z)}");
            Console.WriteLine("Task 3");
            Console.WriteLine($"Номер максимального елемента вектора: {Task3()}");

        }
        static string Task1(decimal dec, short numericSys)
        {
            Dictionary<int, string> decToHex = new Dictionary<int, string>()
            {
                [10] = "A",
                [11] = "B",
                [12] = "C",
                [13] = "D",
                [14] = "E",
                [15] = "F"
            };
            decimal num = dec;
            decimal fractPart;  // fraction part
            int intPart;
            string result = "0.";
            for (int i = 0; i < 6; i++)
            {
                num *= numericSys;
                fractPart = num % 1.0m;
                intPart = (int)num;
                if (fractPart == 0)
                {
                    result += decToHex.ContainsKey(intPart) ? decToHex[intPart] : intPart.ToString();
                    break;
                }
                num = fractPart;
                result += decToHex.ContainsKey(intPart) ? decToHex[intPart] : intPart.ToString();
            }
            return result;
        }
        static double Task2(double x, double y, double z)
        {
            double a; double b; double c;
            double zDiv3 = (z * z * z) / 6;
            double sqrt = Math.Sqrt(4 * x * x + y * y);
            a = sqrt + zDiv3;
            b = 1d / sqrt + 5;
            c = zDiv3 * x;
            Console.WriteLine($"a = {a}\nb = {b}\nc = {c}");
            double result = Math.Min(Math.Pow(Math.Max(a, b), 2), Math.Pow(c, 2));
            return result;
        }
        /*  Дано матрицю B:76. Утворити і надрукувати вектор c, елементами якого є 
         *  кількості додатніх елементів стовпців матриці B. Знайти номер максимального 
         *  елемента вектора c.
         */
        static int Task3()
        {
            int[,] matrix = new int[5, 7]
            {
                {1,-6,4,-5,-8,-9,3},
                {67,96,34,-2,-74,-78,-15},
                {3,5,7,9,-34,12,-13},
                {-89,-34,-25,75,-90,12,-99},
                {3, 2, -5,-7, 3, -4, -5}
            };
            List<int> c = new List<int>();
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int counter = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    counter += matrix[j, i] > 0 ? 1 : 0;
                }
                c.Add(counter);
            }
            Console.WriteLine("Елементи вектора:");
            foreach (int item in c)
            {
                Console.Write($"{item}  ");
            }
            Console.WriteLine();
            int maxEl = c.Max();
            return c.IndexOf(maxEl) + 1;
        }
    }
}