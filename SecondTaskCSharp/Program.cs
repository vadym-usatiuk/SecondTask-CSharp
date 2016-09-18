using System;
using System.Collections.Generic;
using System.IO;
namespace SecondTaskCSharp
{
    class Program
    {
        static void Main()
        {
            DateTime start = DateTime.Now;
            StreamReader sr = new StreamReader(@"../../triangle.txt");
            List<List<int>> triangle = new List<List<int>>();
            //1
            for (int i = 0; i < 100; i++)
            {
                string s = sr.ReadLine();
                char[] c = { ' ' };
                string[] sa = s.Split(c);
                List<int> line = new List<int>();
                foreach (string s1 in sa)
                    line.Add(int.Parse(s1));
                triangle.Add(line);
            }
            for (int i = 1; i < 100; i++)

                for (int j = 0; j <= i; j++)
                    if (j == 0)
                        triangle[i][0] = triangle[i][0] + triangle[i - 1][0];
                    else if (j == triangle[i].Count - 1)
                        triangle[i][triangle[i].Count - 1] = triangle[i][triangle[i].Count - 1] +
                                                             triangle[i - 1][triangle[i - 1].Count - 1];
                    else
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i][j] > triangle[i - 1][j] + triangle[i][j]
                                             ? triangle[i - 1][j - 1] + triangle[i][j]
                                             : triangle[i - 1][j] + triangle[i][j];
            int max = 0;
            foreach (int i in triangle[triangle.Count - 1])
                max = i > max ? i : max;
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}