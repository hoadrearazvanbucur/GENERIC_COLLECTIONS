using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TEST_REPORTS
{
    public class List_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private ILista<string> lista;

        public List_Tests(ITestOutputHelper output)
        {
            lista = new Lista<string>();
            this.outputHelper = output;
        }

        [Fact]
        public void adaugareSfarsit_stergere()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            int k = 1;
            for (int i = 1; i <= 4; i++){
                Assert.True(this.lista.obtine(i-k).Data == $"{i}");
                this.lista.stergere($"{i}");
                Assert.False(this.lista.exista($"{i}"));
                k++;
            }
            Assert.True(this.lista.listaGoala() == true);
        }

        [Fact]
        public void adaugareStart_stergere()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareStart($"{i}");
            for (int i = 1; i <= 4; i++){
                Assert.True(this.lista.obtine(0).Data == $"{5 - i}");
                this.lista.stergere(this.lista.obtine(0).Data);
                Assert.False(this.lista.exista($"{5 - i}"));
            }
            Assert.True(this.lista.listaGoala() == true);
        }

        [Fact]
        public void adaugarePozitie_stergere()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            for (int i = 1; i <= 4; i++){
                this.lista.adaugarePozitie("9", i - 1);
                Assert.True(this.lista.obtine(i - 1).Data == "9");
                this.lista.stergere(this.lista.obtine(i - 1).Data);
                Assert.False(this.lista.obtine(i - 1).Data == "9");
                Assert.True(this.lista.obtine(i - 1).Data == $"{i}");
            }
            Assert.False(this.lista.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.lista.stergere(this.lista.obtine(0).Data);
            Assert.True(this.lista.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            this.lista.adaugarePozitie("9", this.lista.dimensiune());
            Assert.True(this.lista.obtine(this.lista.dimensiune() - 1).Data == "9");
            for (int i = 1; i <= 5; i++)
                this.lista.stergere(this.lista.obtine(0).Data);
            Assert.True(this.lista.listaGoala() == true);
        }



        [Fact]
        public void sortare()
        {
            for (int i = 4; i >= 0; i--)
                lista.adaugareSfarsit($"{i}");
            lista.sortare(new ComparerTest(),-1);
            outputHelper.WriteLine(this.lista.afisare());

        }
    }
}
