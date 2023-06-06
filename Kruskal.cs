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
            List<int> w = new List<int>(); // веса
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
                r_w.Add(reb, zn);
                w.Add(zn);
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
            List<List<int>> used = new List<List<int>>();
            List<int> d = new List<int>();
            w.Sort();

            string nf = "";
            List<int> l = new List<int>();
            while (w.Count > 0)
            {
                string two = "";
                foreach (var para in r_w)
                {
                    if (para.Value == w[0])
                    {
                        two = para.Key;
                        int i = Convert.ToInt32(two.Split()[0]);
                        int j = Convert.ToInt32(two.Split()[1]);
                        bool T = true;
                        foreach (var u in used)
                        {
                            if ((u.Contains(i) & !u.Contains(j)) | (!u.Contains(i) & u.Contains(j)))
                            {
                                if (u.Contains(i)) u.Add(j);
                                else u.Add(i);
                                way += w[0];
                                r_w.Remove(para.Key);
                                w.RemoveAt(0);
                                T = false;
                                break;
                            }
                            else if (u.Contains(i) & u.Contains(j))
                            {
                                r_w.Remove(para.Key);
                                w.RemoveAt(0);
                                T = false;
                                break;
                            }
                        }
                        if (T)
                        {
                            List<int> dop = new List<int>();
                            dop.Add(i);
                            dop.Add(j);
                            used.Add(dop);
                            way += w[0];
                        }
                        
                        for (int k = 0; k < used.Count; k++)
                        {
                            for (int m = k + 1; m < used.Count; m++)
                            {
                                for (int z = 0; z < used[k].Count; z++)
                                {
                                    if (used[m].Contains(used[k][z]))
                                    {
                                        for (int x = 0; x < used[m].Count; x++)
                                        {
                                            if (!used[k].Contains(used[m][x])) used[k].Add(used[m][x]);
                                        }
                                        used.Remove(used[m]);
                                        break;

                                    }
                                }
                            }
                        }
                        
                    }
                }
            }
            Console.WriteLine(way);
        }
    }
}
