using System.Collections.Generic;
using System.Linq;

namespace GoodMatch.Services
{
    public class CheckDuplicates
    {
        public static IEnumerable<List<string>> CheckForDuplicates(IEnumerable<List<string>> bothlists)
        {
            List<List<string>> results = new List<List<string>>();

            foreach (var list in bothlists)
            {
                results.Add(new List<string> (RemoveDuplicates(list)));
            }
            
            return results;
        }

        public static List<string> RemoveDuplicates(List<string> listOfNames)
        {
            for (int namePosition = 1; namePosition < listOfNames.Count; namePosition++)
            {
                if (listOfNames[namePosition] == listOfNames[namePosition - 1])
                {
                    listOfNames.RemoveAt(namePosition);
                }
            }

            return listOfNames;
        }
    }
}
