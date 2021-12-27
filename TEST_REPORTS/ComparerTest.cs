using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TEST_REPORTS
{
    public class ComparerTest : Comparer<string>
    {
        public override int Compare([AllowNull] string xs, [AllowNull] string ys)
        {
            int x = int.Parse(xs), y = int.Parse(ys);
            if (x < y)
                return -1;
            else if (x == y)
                return 0;
            else
                return 1;
        }
    }
}
