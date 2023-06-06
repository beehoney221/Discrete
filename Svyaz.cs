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
            int n; ;
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

            Console.WriteLine("Для ввода графа введите вершины и значение неориентированного графа (по матрице только элементы ниже/выше главной диагонали).\nДля выхода введите любое число, по значению большее, чем последняя вершина.");
            while (true)
            {
                int i;
                string reb = "";
                string k = Console.ReadLine();
                reb = k + " ";
                if (Convert.ToInt32(k) <= n) i = Convert.ToInt32(k);
                else break;
                int j = Convert.ToInt32(Console.ReadLine());
                reb += Convert.ToString(j);
                int zn = Convert.ToInt32(Console.ReadLine());
                nach[i, j] = zn;
                nach[j, i] = zn;
            }

            Console.Clear();

            Console.WriteLine("Матрица графа\n");
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (nach[i, j] == -1) Console.Write("inf\t");
                    else Console.Write(nach[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.Write("\nОтвет. ");

            List<int> ver = new List<int>();
            for (int a = 1; a <= n; a++)
            {
                ver.Add(a);
            }
            // заполнили матрицу

            List<List<int>> used = new List<List<int>>();

            while (ver.Count > 0)
            {
                int v = ver[0];
                bool T = true;
                foreach (var u in used)
                {
                    if (u[0] == v)
                    {
                        T = false;
                        for (int i = 1; i <= n; i++)
                        {
                            if (nach[v, i] > 0)
                            {
                                u.Add(i);
                            }
                        }
                        break;
                    }
                }

                if (T)
                {
                    List<int> u = new List<int>();
                    u.Add(v);
                    for (int i = 1; i <= n; i++)
                    {
                        if (nach[v, i] > 0)
                        {
                            u.Add(i);
                        }
                    }
                    used.Add(u);
                }

                foreach (var u in used)
                {
                    if (u[0] == v)
                    {
                        for (int i = 1; i < u.Count; i++)
                        {
                            for (int j = 1; j <= n; j++)
                            {
                                if ((nach[u[i], j] > 0) & !u.Contains(j))
                                {
                                    u.Add(j);
                                }
                            }
                            ver.Remove(u[i]);
                        }
                        break;
                    }
                }
                ver.Remove(v);
            }
            Console.WriteLine(used.Count);
        }
    }
}
