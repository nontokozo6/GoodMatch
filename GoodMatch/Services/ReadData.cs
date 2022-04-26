using System;
using System.Collections.Generic;
using System.IO;

namespace GoodMatch.Services
{
    public class ReadData
    {
        public static IEnumerable<List<string>> ReadAndSortData()
        {
            
            List<string> listF = new List<string>();
            List<string> listM = new List<string>();

            using (var reader = new StreamReader("Resources/GoodMatchData.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Contains("f"))
                    {
                       
                        listF.Add(line.ToString().Substring(0,line.IndexOf(",")));
                    }
                    else
                    {
                        listM.Add(line.ToString().Substring(0, line.IndexOf(",")));
                    }
                }
            }

            return new List<List<string>> { listF, listM };
        }
        public static void logResults(List<string> goodMatchResults)
        {
            using (StreamWriter writer = new StreamWriter("Resources/MatchResults.txt"))
            {
                foreach (var goodMatch in goodMatchResults)
                {
                    writer.WriteLine(goodMatch);
                }
            }

            foreach (var goodMatch in goodMatchResults)
            {
                Console.WriteLine(goodMatch);
            }

        }
       

    }
}
