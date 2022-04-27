using GoodMatch.Services;
using System;
using System.IO;
using System.Linq;

namespace GoodMatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            var genderSortedData = ReadData.ReadAndSortData();
            var removeDuplicates = CheckDuplicates.CheckForDuplicates(genderSortedData);
            var goodMatchResults = Match.DoMatching(removeDuplicates);
                goodMatchResults = Ordering.OrderGoodMatchResults(goodMatchResults);
            ReadData.logResults(goodMatchResults.Select(x=>x.Result).ToList());
            
            Console.ReadLine();
        }     
    }
}
