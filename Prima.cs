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
                        int iz = Convert.ToInt32(r.Split()[0]);
                        int v = Convert.ToInt32(r.Split()[1]);
                        if (used.Contains(iz)) i_v = v;
                        else if (used.Contains(v)) i_v = iz;
                    }
                }                
                used.Add(i_v);
