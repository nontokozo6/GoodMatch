using System;
using System.Collections.Generic;
using System.Linq;

namespace GoodMatch.Services
{
    public class Match
    {
        const string keyWord = "matches";

        public static List<string> DoMatching(IEnumerable<List<string>> readyList)
        {
            var females = new List<string>(readyList.ElementAt(0));
            var males = new List<string>(readyList.ElementAt(1));
            int matchResult = 0;
            List<string> matchResults = new List<string>();
           
            foreach(var name in females)
            {
                for (int maleNamePosition = 0; maleNamePosition < males.Count; maleNamePosition++)
                {
                    matchResult = (CountMatches(name, males[maleNamePosition]));
                    string result = $"{name} matches {males[maleNamePosition]} {matchResult}% ";

                    if(matchResult >= 80)
                    {
                        result += "good match";
                    }

                    matchResults.Add(result);
                }
            }

            return matchResults;
        }

        private static int CountMatches(string female, string male)
        {
            string combinedString = female + keyWord + male;
            char[] letters = combinedString.ToCharArray();
            List<int> matches = new List<int>();

            for (int letterPosition = 0; letterPosition < combinedString.Length; letterPosition++)
            {
                if (combinedString[letterPosition]==' ')
                {
                    continue;
                }

                matches.Add(combinedString.Count(f => f == combinedString[letterPosition]));
                combinedString = combinedString.Replace(combinedString[letterPosition], ' ');
            }

            return MakeTwoDigits(matches);
        }

        public static int MakeTwoDigits(List<int> matches)
        {
            List<int> Addedmatches = new List<int> ();

            for (int numberPosition = 0; numberPosition < matches.Count;)
            {
                int addedNumbers = matches[numberPosition] + matches[(matches.Count - 1)];
                Addedmatches.Add(addedNumbers);

                matches.RemoveAt(numberPosition);

                if (matches.Count ==0)
                {
                    break;
                }

                matches.RemoveAt(matches.Count - (numberPosition + 1));
            }

            while (Addedmatches.Count > 2)
            {
                List<int> tempAddedmatches = new List<int>();

                for (int numberPosition = 0; numberPosition < Addedmatches.Count;)
                {
                    int addedNumbers = Addedmatches[numberPosition] + Addedmatches[Addedmatches.Count - 1];

                    foreach (char digit in addedNumbers.ToString())
                    {
                        tempAddedmatches.Add(Convert.ToInt16(digit.ToString()));
                    }

                    Addedmatches.RemoveAt(numberPosition);
                    Addedmatches.RemoveAt(Addedmatches.Count - (numberPosition + 1));

                    if (Addedmatches.Count == 1 )
                    {
                        tempAddedmatches.Add(Addedmatches[0]);
                        Addedmatches.RemoveAt(numberPosition);
                    }
                }

                Addedmatches = tempAddedmatches;
            }

            string twoDigitnumber = "";

            foreach (var number in Addedmatches)
            {
                twoDigitnumber += number.ToString();
            } 

            return Convert.ToInt32(twoDigitnumber);
        } 
    }
}
