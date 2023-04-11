using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
                    nach[i, j] = 9999;
                }
            }
            for (int i = 0; i <= n; i++)
            {
                nach[i, 0] = i;
                nach[0, i] = i;
                nach[i, i] = 0;
            }
            Console.WriteLine("Для ввода графа введите вершины и значения. Для выхода введите '0'.");
            while (true)
            {
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 0) break;
                int j = Convert.ToInt32(Console.ReadLine());
                int znach = Convert.ToInt32(Console.ReadLine());
                nach[i, j] = znach;
            }
            Console.Clear();
            //заполнили матрицу

            Console.WriteLine("Начальная матрица\n");
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if ((nach[i, j] == 9999) & (i != j))
                    {
                        Console.Write("inf\t");
                    }
                    else Console.Write(nach[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // заполнили матрицу
            Console.WriteLine("\nВведите начальную и конечную вершины.");
            int nv = Convert.ToInt32(Console.ReadLine());
            int kv = Convert.ToInt32(Console.ReadLine());
            Console.Write("Минимальный путь {0} -> {1} равен: ", nv, kv);
            int max = 9999, min = 0; //наибольшее значение (бесконечность); находит минимум в строке для дальнейшего перехода
            int[] minimim = { 0, max, max, max, max, max, max, max, max, max }; //массив с минимальными значениями по столбцам, будет обновляться при необходимости
            List<int> used = new(); //список с использованными вершинами
            int weight = 0, way = 0; //вес, который будет прибавляться; путь по прямой
            
            //алгоритм
            while (used.IndexOf(kv) < 0)
            {
                int next = 0;
                min = max;
                used.Add(nv);
                for (int j = 1; j <= n; j++)
                {
                    if (nv != j)
                    {
                        nach[nv, j] += weight;
                        if (nach[nv, j] <= minimim[j]) minimim[j] = nach[nv, j];
                        else if (nach[nv, j] > minimim[j]) nach[nv, j] = minimim[j];
                        if ((j == kv) & (nach[nv, j] < max)) { way = nach[nv, j]; Console.WriteLine(way); Environment.Exit(0); }
                        if ((nach[nv, j] <= min) & (used.IndexOf(j) == -1))
                        {
                            min = nach[nv, j];
                            next = j;
                        }
                    }
                }
                nv = next;
                weight = min;
            }

            Console.WriteLine(min); //ответ
        }
    }
}
