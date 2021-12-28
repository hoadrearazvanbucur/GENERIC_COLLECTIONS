using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TEST_REPORTS
{
    public class Hash_Table_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Simple_Dictionary<string, string> hashTable;

        public Hash_Table_Tests(ITestOutputHelper output)
        {
            hashTable = new Simple_Dictionary<string, string>();
            this.outputHelper = output;
        }

        [Fact]
        public void test()
        {

        }
    }
}
