using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GoodMatch.Services
{
    public class ReadData
    {

        public static IEnumerable<List<string>> ReadAndSortData()
        {

            List<string> listF = new List<string>();
            List<string> listM = new List<string>();


            // using (var reader = new StreamReader("Resources/GoodMatchData.csv"))
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "Resources", "GoodMatchData.csv");
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"\Resources\GoodMatchData.csv");
            using (var reader = new StreamReader(filePath))
           // D:/ xxx.csv
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (line.Contains("f"))
                    {
                        if (!listF.Contains(line))
                        {
                            listF.Add(line.ToString().Substring(0, line.IndexOf(",")));
                        }
                    }
                    else
                    {
                        if (!listM.Contains(line))
                        {
                            listM.Add(line.ToString().Substring(0, line.IndexOf(",")));
                        }

                    }
                }
            }

            return new List<List<string>> { listF, listM };
        }
        public static void logResults(List<string> goodMatchResults)
        {
            List<string> displayedList = new List<string>();
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "Resources", "Output.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                //adds results into a list 
                foreach (var goodMatch in goodMatchResults)
                {

                    displayedList.Add(goodMatch);
                    //displayedList = displayedList.OrderBy(q => q).ToList(); 


                }
                //writes sorted list to the text file

                foreach (var goodMatch in displayedList)
                {
                    writer.WriteLine(goodMatch);
                }

            }
            displayedList = displayedList.Distinct().
                ToList();

            //prints on the console
            foreach (var goodMatch in displayedList)
            {
                Console.WriteLine(goodMatch);
            }

        }


    }
}
