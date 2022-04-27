using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodMatch.Models;

namespace GoodMatch.Services
{
    public class Ordering
    {
        //check if theres
        public static List<MatchResult> OrderGoodMatchResults(List<MatchResult> matchResults )
        {
            var val = matchResults.First().ResultPercentange;
           if( !matchResults.All(x => x.ResultPercentange == val))
            {
                return matchResults.OrderByDescending(x => x.ResultPercentange).ToList();
            }
                return matchResults.OrderBy(x => x.Result).ToList();

        }
    }
}
