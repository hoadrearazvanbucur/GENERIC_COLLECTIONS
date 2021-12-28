using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TEST_REPORTS
{
    public class Set_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Set<string> set;

        public Set_Tests(ITestOutputHelper output)
        {
            set = new Set<string>();
            this.outputHelper = output;
        }

        [Fact]
        public void adaugare1_stergere_obtine()
        {
            for (int i = 1; i <= 4; i++)
                this.set.adaugare($"{i}", new ComparerTest(), 1);
            Assert.True(this.set.listaGoala() == false);
            Assert.True(this.set.dimensiune() == 4);
            int k = 1;
            for (int i = 4; i >= 1; i--){
                Assert.True(this.set.obtine(i - 1).Data == $"{k}");
                Assert.True(this.set.exista($"{k}"));
                this.set.stergere($"{k}");
                Assert.False(this.set.exista($"{k++}"));
            }
            Assert.True(this.set.listaGoala());
        }

        [Fact]
        public void adaugare2_stergere_obtine()
        {
            for (int i = 4; i >= 1; i--)
                this.set.adaugare($"{i}", new ComparerTest(), -1);
            Assert.True(this.set.listaGoala() == false);
            Assert.True(this.set.dimensiune() == 4);
            int k = 0;
            for (int i = 1; i <= 4; i++){
                Assert.True(this.set.obtine(i - 1 - k++).Data == $"{i}");
                Assert.True(this.set.exista($"{i}"));
                this.set.stergere($"{i}");
                Assert.False(this.set.exista($"{i}"));
            }
            Assert.True(this.set.listaGoala());
        }

        [Fact]
        public void adaugare3_stergere_obtine()
        {
            this.set.adaugare("1", new ComparerTest(), -1);
            this.set.adaugare("4", new ComparerTest(), -1);
            this.set.adaugare("3", new ComparerTest(), -1);
            this.set.adaugare("2", new ComparerTest(), -1);
            Assert.True(this.set.listaGoala() == false);
            Assert.True(this.set.dimensiune() == 4);
            int k = 0;
            for (int i = 1; i <= 4; i++)
            {
                Assert.True(this.set.obtine(i - 1 - k++).Data == $"{i}");
                Assert.True(this.set.exista($"{i}"));
                this.set.stergere($"{i}");
                Assert.False(this.set.exista($"{i}"));
            }
            Assert.True(this.set.listaGoala());
        }

        [Fact]
        public void pozitieData_afisare()
        {
            for (int i = 1; i <= 4; i++)
                this.set.adaugare($"{i}", new ComparerTest(), 1);
            Assert.True(this.set.dimensiune() == 4);
            outputHelper.WriteLine(this.set.afisare());
            int k = 0;
            for (int i = 4; i >= 1; i--)
                Assert.True(this.set.pozitieData($"{i}") == k++);
            for (int i = 1; i <= 4; i++)
                this.set.stergere($"{i}");
            Assert.True(this.set.listaGoala() == true);
        }
    }
}
