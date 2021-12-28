using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TEST_REPORTS
{
    public class Coada_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Coada<string> coada;

        public Coada_Tests(ITestOutputHelper output)
        {
            coada = new Coada<string>();
            this.outputHelper = output;
        }

        [Fact]
        public void push_pop_peek_size_isEmpty()
        {
            for (int i = 1; i <= 4; i++)
                this.coada.push($"{i}");
            for (int i = 1; i <= 4; i++)
                Assert.True(this.coada.exist($"{i}"));
            Assert.False(this.coada.exist("5"));
            Assert.True(this.coada.size() == 4);
            for (int i = 1; i <= 4; i++){
                Assert.True(this.coada.peek().Data == $"{i}");
                Assert.True(this.coada.pop().Data == $"{i}");
            }
            Assert.True(this.coada.isEmpty() == true);
        }

        [Fact]
        public void afisare()
        {
            for (int i = 1; i <= 4; i++)
                this.coada.push($"{i}");
            this.outputHelper.WriteLine(this.coada.afisare());
            for (int i = 1; i <= 4; i++)
                this.coada.pop();
        }
    }
}
