using System.Collections.Generic;

namespace Linq_Samples.Linq_Samples_Codes.OrderingOperators
{
    public class CaseInsensitiveCompare : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }
    }
}