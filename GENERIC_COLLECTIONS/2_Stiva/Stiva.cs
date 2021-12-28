using System;
using System.Collections.Generic;
using System.Text;

namespace GENERIC_COLLECTIONS
{
    public class Stiva<T> where T : IComparable<T>
    {
        private Lista<T> lista;

        public Stiva()
        {
            lista = new Lista<T>();
        }

        public void push(T data)
        {
            this.lista.adaugareSfarsit(data);
        }
        public Nod<T> pop()
        {
            Nod<T> nod = this.lista.obtine(this.lista.dimensiune() - 1);
            this.lista.stergere(this.lista.obtine(this.lista.dimensiune() - 1).Data);
            return nod;
        }
        public Nod<T> peek() => this.lista.obtine(this.lista.dimensiune() - 1);
        public bool exist(T data) => this.lista.exista(data);
        public int size() => this.lista.dimensiune();
        public bool isEmpty() => this.lista.listaGoala();
        public string afisare() => this.lista.afisare();

        public Lista<T> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }
    }
}
