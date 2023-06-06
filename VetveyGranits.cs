using System.Collections;
using System.Collections.Generic;

namespace Kommi
{
    class Programm
    {

        static void changing_size(ref List<List<int>> branches, ref int max_zero,ref string max_zero_str)
        {
            for (int i = 1; i < branches.Count; i++)
            {
                if (    (branches[i][0]== Convert.ToInt32(max_zero_str.Split(" ")[0]))    )
                {
                    branches.Remove(branches[i]);
                }
            }
            int index_remove_stol = 0;
            for (int i = 1; i < branches[0].Count; i++)
            {
                if ((branches[0][i] == Convert.ToInt32(max_zero_str.Split(" ")[1])))
                {
                    index_remove_stol = i;
                }
            }
            Console.WriteLine("Номер индекса");
            Console.WriteLine(index_remove_stol);
            for (int i = 0; i < branches.Count; i++)
            {
                branches[i].Remove(branches[i][index_remove_stol]);
            }
            Console.WriteLine("max_zero_str");
            Console.WriteLine(max_zero_str);
            for (int i = 1; i < branches.Count; i++)
            {
                for (int j = 1; j < branches[i].Count; j++)
                {
                    if ((branches[i][0] == Convert.ToInt32(max_zero_str.Split(" ")[1])) && (branches[0][j] == Convert.ToInt32(max_zero_str.Split(" ")[0])))
                    {
                        branches[i][j] = -1;
                    }
                }
                Console.WriteLine();
            }
            
            
            Console.WriteLine();

        }

        static void changing_branches(ref List<List<int>> branches, ref int branches_cnt)
        {
            int min_value = 1000000000;
            for (int i = 1; i < branches.Count; i++)
            {
                for (int j = 1; j < branches[i].Count; j++)
                {
                    if ((branches[i][j] < min_value) && (branches[i][0] != branches[0][j]) && (branches[i][j]!=-1))
                    {
                        min_value = branches[i][j];
                    }

                }
                
                for (int j = 1; j < branches[i].Count; j++)
                {
                    if ((branches[i][0]!= branches[0][j]) && (branches[i][j] != -1) )
                    {
                        branches[i][j] -= min_value;
                    }
                }
                branches_cnt += min_value;
                Console.WriteLine("Мин значеник");
                Console.WriteLine(min_value);
                min_value = 1000000000;
            }

            
            for (int i = 0; i < branches.Count; i++)
            {
                for (int j = 0; j < branches[i].Count; j++)
                {
                    Console.Write(branches[i][j] + "\t");
                }
                Console.WriteLine();
            }
            min_value = 1000000000;

            for (int i = 1; i < branches.Count; i++)
            {
                for (int j = 1; j < branches[i].Count; j++)
                {
                    if ((branches[j][i] < min_value) && (branches[j][i] != -1) && (branches[j][0] != branches[0][i]))
                    {
                        min_value = branches[j][i];
                    }

                }
                for (int j = 1; j < branches[i].Count; j++)
                {
                    if (branches[j][i]!=-1)
                    {
                        branches[j][i] -= min_value;
                    }
                }
                
                branches_cnt += min_value;
                min_value = 1000000000;
            }
            

        }

        static void found_zero(ref List<List<int>> branches) 
        {
            Dictionary <string, int> zero_dict = new Dictionary<string, int> ();
            for (int i = 1; i < branches.Count; i++)
            {
                for (int j = 1; j < branches[i].Count; j++)
                {
                    if ((branches[i][j] == 0))
                    {
                        zero_dict.Add(branches[i][0].ToString()+ " " + branches[0][j].ToString() , branches[i][j]);
                    }
                }
            }
            ICollection c = (ICollection)zero_dict.Keys;
            foreach (string str in c)
            {
                int min_value = 1000000000;

                for (int i = 1; i < branches.Count; i++)
                {

                    if (branches[i][0] == Convert.ToInt32(str.Split(" ")[0]))
                    {
                        for (int j = 1; j < branches[i].Count; j++)
                        {
                            if ((branches[i][j] < min_value) && (branches[i][j] != -1) && (Convert.ToInt32(str.Split(" ")[1]) != branches[0][j]) && (Convert.ToInt32(str.Split(" ")[0]) != branches[i][0]))
                            {
                                min_value = branches[i][j];
                            }
                        }
                    }
                    
                    
                }
                if (min_value != 1000000000)
                { zero_dict[str] += min_value; }
                min_value = 1000000000;
                for (int i = 1; i < branches.Count; i++)
                {

                    
                    if (branches[0][i] == Convert.ToInt32(str.Split(" ")[1]))
                    {
                        for (int j = 1; j < branches[i].Count; j++)
                        {
                            if ((branches[j][i] < min_value) && (branches[j][i] != -1) && (Convert.ToInt32(str.Split(" ")[0]) != branches[j][0]))
                            {

                                min_value = branches[j][i];


                            }
                        }
                    }
                    

                }
                if (min_value != 1000000000)
                { zero_dict[str] += min_value; }
            }
            foreach (string str in c)
            {
                Console.WriteLine(str + ":" + zero_dict[str]);
            }
            int max_zero = 0;
            string max_zero_str = "";
            foreach (string str in c)
            {
               if (zero_dict[str] >= max_zero)
                {
                    max_zero_str = str;
                    max_zero = zero_dict[str];
                }
            }
            changing_size(ref branches, ref max_zero, ref max_zero_str);
        }
        static void Main()
        { 
            List<List<int>> branches = new List<List<int>>();
            int min_value = 1000000000;
            int branches_cnt = 0;
            branches.Add(new List<int>() { 0, 1, 2, 3, 4, 5 });
            branches.Add(new List<int>() { 1, -1, 12, 22, 28, 32 });
            branches.Add(new List<int>() { 2, 12, -1, 10, 40, 20 });
            branches.Add(new List<int>() { 3, 22, 10, -1, 50, 10 });
            branches.Add(new List<int>() { 4, 28, 27,17, -1, 27 });
            branches.Add(new List<int>() { 5, 32, 20, 10, 60, -1 });

            for (int i = 0; i < branches.Count; i++)
            {
                for (int j = 0; j < branches[i].Count; j++)
                {
                    Console.Write(branches[i][j]+"\t");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();
            Console.WriteLine();


            while (branches.Count!=2)
            {
                changing_branches(ref branches, ref branches_cnt);
                found_zero(ref branches);
            }
            
            
           
            Console.WriteLine("Расстояние");
            Console.WriteLine(branches_cnt);
        }
            
        }
    }
