using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication38
{
    class Prima
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
            Dictionary<string, int> r_w = new Dictionary<string, int>(); // ребро - вес
            Console.WriteLine("Для ввода графа введите вершины и значение неориентированного графа\n(по матрице только элементы ниже/выше главной диагонали).\nДля выхода введите любое число, по значению большее, чем последняя вершина.");
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
                r_w.Add(reb, zn);
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

            // заполнили матрицу

            int way = 0;
            List<int> used = new List<int>();
            Random x = new Random();
            int i_v = x.Next(1, n+1);
            used.Add(i_v);
            while (used.Count < 7)
            {
                List<int> ves = new List<int>(); // веса рассматриваемых ребер
                List<string> rebra = new List<string>();
                foreach (var para in r_w)
                {
                    int iz = Convert.ToInt32(para.Key.Split()[0]);
                    int v = Convert.ToInt32(para.Key.Split()[1]);
                    foreach (int versh in used)
                    {
                        if (((iz == versh) & (!used.Contains(v))) | ((v == versh) & (!used.Contains(iz))))
                        {
                            ves.Add(para.Value);
                            rebra.Add(para.Key);
                        }
                    }
                }
                ves.Sort();
                int weight = ves[0];
                foreach (string r in rebra)
                {
                    if (r_w[r] == weight)
                    {
                        way += weight;
                        Console.WriteLine(weight + " + " + way);
                        int iz = Convert.ToInt32(r.Split()[0]);
                        int v = Convert.ToInt32(r.Split()[1]);
                        if (used.Contains(iz)) i_v = v;
                        else if (used.Contains(v)) i_v = iz;
                        break;
                    }
                }
                used.Add(i_v);
            }
            Console.WriteLine(way);
        }
    }
}
