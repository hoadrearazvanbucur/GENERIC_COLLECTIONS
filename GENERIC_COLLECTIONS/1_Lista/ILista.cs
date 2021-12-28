using System;
using System.Collections.Generic;
using System.Text;

namespace GENERIC_COLLECTIONS
{
    public interface ILista<T>
    {
        void adaugareSfarsit(T data);
        void adaugareStart(T data);

        void stergere(T data);

        void adaugarePozitie(T data, int index);
        Nod<T> obtine(int index);
        void modificare(T dataInlocuit, T dataInlocuire);

        bool exista(T data);
        bool listaGoala();
        int dimensiune();

        int pozitieData(T data);

        void sortare(Comparer<T> comparator,int value);

        string afisare();  
    }
}
