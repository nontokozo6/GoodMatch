using GoodMatch.Services;
using System;
using System.IO;

namespace GoodMatch
{
    public class Program
    {
        static void Main(string[] args)
        {
            var genderSortedData = ReadData.ReadAndSortData();
            var removeDuplicates = CheckDuplicates.CheckForDuplicates(genderSortedData);
            var goodMatchResults = Match.DoMatching(removeDuplicates);
            ReadData.logResults(goodMatchResults);
            
            Console.ReadLine();
        }     
    }
}
