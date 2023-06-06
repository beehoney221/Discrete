using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dis
{
    class Kruskala
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
                    nach[i, j] = 9999;
                }
            }
            for (int i = 0; i <= n; i++)
            {
                nach[i, 0] = i;
                nach[0, i] = i;
            }

            Console.WriteLine("Для ввода графа введите вершины и значение графа.\nЕсли граф неориентированный введите <n>, и вводите значения из матрицы выше главной диагонали. \nДля выхода введите 0.");
            string gr = Console.ReadLine();
            while (true)
            {
                int i;
                int k = Convert.ToInt32(Console.ReadLine());
                if (k > 0) i = k;
                else break;
                int j = Convert.ToInt32(Console.ReadLine());
                int zn = Convert.ToInt32(Console.ReadLine());
                nach[i, j] = zn;
                if (gr == "n") nach[j, i] = zn;
            }

            Console.Clear();

            Console.WriteLine("Матрица графа\n");
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (nach[i, j] == 9999) Console.Write("inf\t");
                    else Console.Write(nach[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Введите начальную вершину");
            int nv = Convert.ToInt32(Console.ReadLine());


            int[,] lyam = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                lyam[i, 0] = 9999;
                lyam[nv - 1, i] = 0;
            }

            // заполнили матрицу

            List<List<int>> used = new List<List<int>>();

            for (int k = 1; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i != nv-1)
                    {
                        int first = lyam[0, k - 1] + nach[1, i+1];
                        for (int j = 0; j < n; j++)
                        {
                            first = Math.Min(first, lyam[j, k - 1] + nach[j+1, i+1]);
                        }
                        lyam[i, k] = first;
                    }
                }
            }

            Console.WriteLine("От {0} ", nv);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("  до {0} - {1}", i + 1, lyam[i, n - 1]);
            }
        }
    }
}
