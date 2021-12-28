using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TEST_REPORTS
{
    public class Lista_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private ILista<string> lista;

        public Lista_Tests(ITestOutputHelper output)
        {
            lista = new Lista<string>();
            this.outputHelper = output;
        }

        [Fact]
        public void adaugareSfarsit_stergere()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            Assert.True(this.lista.dimensiune() == 4);
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
            Assert.True(this.lista.dimensiune() == 4);
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
            Assert.True(this.lista.dimensiune() == 4);
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
        public void obtine()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            Assert.True(this.lista.dimensiune() == 4);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.lista.obtine(i - 1).Data == $"{i}");
            for (int i = 1; i <= 4; i++)
                Assert.False(this.lista.obtine(i - 1).Data == $"{4-i+1}");
            for (int i = 1; i <= 4; i++)
                this.lista.stergere($"{i}");
            Assert.True(this.lista.listaGoala() == true);
        }

        [Fact]
        public void modificare()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            Assert.True(this.lista.dimensiune() == 4);
            for (int i = 4; i >=1; i--)
                this.lista.modificare($"{i}", $"{i + 1}");
            for (int i = 1; i <= 4; i++)
                Assert.True(this.lista.obtine(i - 1).Data == $"{i + 1}");
            for (int i = 1; i <= 4; i++)
                this.lista.stergere($"{i+1}");
            Assert.True(this.lista.listaGoala() == true);
        }

        [Fact]
        public void exista_listaGoala_dimensiune_pozitieData()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            Assert.True(this.lista.dimensiune() == 4);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.lista.exista($"{i}") == true);
            Assert.True(this.lista.exista("5") == false);
            Assert.True(this.lista.listaGoala() == false);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.lista.pozitieData($"{i}") == i - 1);
            for (int i = 1; i <= 4; i++)
                this.lista.stergere($"{i}");
            Assert.True(this.lista.listaGoala() == true);
        }

        [Fact]
        public void sortare()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            Assert.True(this.lista.dimensiune() == 4);
            this.lista.sortare(new ComparerTest(), -1);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.lista.obtine(i - 1).Data == $"{5 - i}");
            for (int i = 1; i <= 4; i++)
                this.lista.stergere($"{i}");
            Assert.True(this.lista.listaGoala() == true);
            for (int i = 4; i >= 1; i--)
                this.lista.adaugareSfarsit($"{i}");
            Assert.True(this.lista.dimensiune() == 4);
            this.lista.sortare(new ComparerTest(), 1);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.lista.obtine(i - 1).Data == $"{i}");
            for (int i = 1; i <= 4; i++)
                this.lista.stergere($"{i}");
            Assert.True(this.lista.listaGoala() == true);
        }

        [Fact]
        public void afisare()
        {
            for (int i = 1; i <= 4; i++)
                this.lista.adaugareSfarsit($"{i}");
            Assert.True(this.lista.dimensiune() == 4);
            this.outputHelper.WriteLine(this.lista.afisare());
            for (int i = 1; i <= 4; i++)
                this.lista.stergere($"{i}");
            Assert.True(this.lista.listaGoala() == true);
        }
    }
}
