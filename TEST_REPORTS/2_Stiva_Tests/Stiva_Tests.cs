using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TEST_REPORTS
{
    public class Stiva_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Stiva<string> stiva;

        public Stiva_Tests(ITestOutputHelper output)
        {
            stiva = new Stiva<string>();
            this.outputHelper = output;
        }

        [Fact]
        public void push_pop_peek_size_isEmpty()
        {
            for (int i = 1; i <= 4; i++)
                this.stiva.push($"{i}");
            for (int i = 1; i <= 4; i++)
                Assert.True(this.stiva.exist($"{i}"));
            Assert.False(this.stiva.exist("5"));
                Assert.True(this.stiva.size() == 4);
            for (int i = 1; i <= 4; i++){
                Assert.True(this.stiva.peek().Data == $"{5 - i}");
                Assert.True(this.stiva.pop().Data == $"{5 - i}");
            }
            Assert.True(this.stiva.isEmpty() == true);
        }

        [Fact]
        public void afisare()
        {
            for (int i = 1; i <= 4; i++)
                this.stiva.push($"{i}");
            this.outputHelper.WriteLine(this.stiva.afisare());
            for (int i = 1; i <= 4; i++)
                this.stiva.pop();
        }
    }
}
