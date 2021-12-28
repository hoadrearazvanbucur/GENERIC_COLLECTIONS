using System;
using System.Collections.Generic;
using System.Text;

namespace GENERIC_COLLECTIONS
{
    public class Set<T> where T : IComparable<T>
    {
        private Lista<T> lista;

        public Set()
        {
            this.lista = new Lista<T>();
        }

        public void adaugare(T data, Comparer<T> comparer,int value)
        {
            Nod<T> it = lista.Head;
            if (lista.exista(data) == false)
                if (it == null)
                    this.lista.adaugareSfarsit(data);
                else{
                    int k = 0;
                    while (it != null && comparer.Compare(it.Data, data) == value){
                        k += 1;
                        it = it.Next;
                    }
                    this.lista.adaugarePozitie(data, k);
                }
        }
        public void stergere(T data)
        {
            this.lista.stergere(data);
        }

        public Nod<T> obtine(int index) => this.lista.obtine(index);

        public bool listaGoala() => this.lista.listaGoala();
        public int dimensiune() => this.lista.dimensiune();
        public bool exista(T data) => this.lista.exista(data);

        public int pozitieData(T data) => this.lista.pozitieData(data);

        public string afisare() => lista.afisare();

        public Lista<T> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }
    }
}
