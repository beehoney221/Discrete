using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication38
{
    class Program
    {
        static void Main()
        {
            int n;
            Console.WriteLine("Введите количество вершин.");
            n = Convert.ToInt32(Console.ReadLine());
            int[,] nach = new int[n + 1, n + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    nach[i, j] = -1;
                    nach[i, i] = 0;
                }
            }
            for (int i = 0; i <= n; i++)
            {
                nach[i, 0] = i;
                nach[0, i] = i;
            }
            Console.WriteLine("Для ввода графа введите вершины и значение.\nЕсли граф неориентированный, то напишите 'N', иначе любое другое значение.\nДля выхода введите любое число, по значению большее, чем последняя вершина.");
            string abobus = Console.ReadLine();
            if (abobus != "N")
            {
                while (true)
                {
                    int i;
                    int k = Convert.ToInt32(Console.ReadLine());
                    if (k <= n) i = k;
                    else break;
                    int j = Convert.ToInt32(Console.ReadLine());
                    int zn = Convert.ToInt32(Console.ReadLine());
                    nach[i, j] = zn;
                }
            }
            else
            {
                while (true)
                {
                    int i;
                    int k = Convert.ToInt32(Console.ReadLine());
                    if (k <= n) i = k;
                    else break;
                    int j = Convert.ToInt32(Console.ReadLine());
                    int zn = Convert.ToInt32(Console.ReadLine());
                    nach[i, j] = zn;
                    nach[j, i] = zn;
                }
            }


            Console.Clear();
            Console.WriteLine("Начальная матрица\n");
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (nach[i,j] == -1) Console.Write("inf\t");
                    else Console.Write(nach[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nКонечный результат\n");

            // заполнили матрицу

            int[,] nach_k = new int[n + 1, n + 1];
            nach_k = nach;

            for (int k = 1; k <= n; k++)
            {
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if ((nach_k[i, k] == -1) | (nach_k[k, j] == -1)) nach_k[i, j] = nach_k[i, j];
                        else if (nach_k[i, j] == -1) nach_k[i, j] = nach_k[i, k] + nach_k[k, j];
                        else nach_k[i, j] = Math.Min(nach_k[i, k] + nach_k[k, j], nach_k[i, j]);
                    }
                }
            }

            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (nach[i,j] == -1) Console.Write("inf\t");
                    else Console.Write(nach[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
