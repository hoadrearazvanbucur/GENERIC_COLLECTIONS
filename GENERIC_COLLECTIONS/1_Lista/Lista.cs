using System;
using System.Collections.Generic;
using System.Text;

namespace GENERIC_COLLECTIONS
{
    public class Lista<T> : ILista<T> where T : IComparable<T>
    {
        private Nod<T> head = null;

        public Nod<T> Head
        {
            get => this.head;
            set => this.head = value;
        }

        public void adaugareSfarsit(T data)
        {
            if (head == null)
            {
                Nod<T> n = new Nod<T>();
                n.Data = data;
                n.Next = null;
                this.head = n;
            }
            else
            {
                Nod<T> n = new Nod<T>();
                Nod<T> iterator = head;
                while (iterator.Next != null)
                    iterator = iterator.Next;
                iterator.Next = n;
                n.Next = null;
                n.Data = data;
            }
        }
        public void adaugareStart(T data)
        {
            if (head == null)
            {
                Nod<T> n = new Nod<T>();
                n.Data = data;
                n.Next = null;
                this.head = n;
            }
            else
            {
                Nod<T> nou = new Nod<T>();
                nou.Data = data;
                nou.Next = head;
                head = nou;
            }
        }

        public void stergere(T data)
        {
            int index = this.pozitieData(data), k = 0;
            Nod<T> save = head;
            if (index < dimensiune() && index > 0)
            {
                while (k < index - 1)
                {
                    save = save.Next;
                    k++;
                }
                save.Next = save.Next.Next;
            }
            else if (index == dimensiune())
                save = null;
            else if (index == 0)
                head = save.Next;
        }

        public void adaugarePozitie(T data, int index)
        {
            Nod<T> save = head;
            int k = 0;
            if (index != 0 && save != null)
            {
                while (k < index - 1)
                {
                    save = save.Next;
                    k++;
                }
                Nod<T> m = new Nod<T>();
                m.Data = data;
                m.Next = save.Next;
                save.Next = m;
            }
            else if (index != this.dimensiune())
            {
                Nod<T> m = new Nod<T>();
                m.Data = data;
                m.Next = save;
                head = m;
            }
            else
                this.adaugareSfarsit(data);
        }
        public Nod<T> obtine(int index)
        {
            int k = 0;
            Nod<T> save = head;
            while (save != null)
            {
                if (k == index)
                    return save;
                save = save.Next;
                k++;
            }
            return null;
        }
        public void modificare(T dataInlocuit, T dataInlocuire)
        {
            this.adaugarePozitie(dataInlocuire, this.pozitieData(dataInlocuit));
            this.stergere(dataInlocuit);
        }

        public bool exista(T data)
        {
            Nod<T> save = head;
            while (save != null)
            {
                if (save.Data.CompareTo(data) == 0)
                    return true;
                save = save.Next;
            }
            return false;
        }
        public bool listaGoala()
        {
            if (this.head == null)
                return true;
            return false;
        }
        public int dimensiune()
        {
            int k = 0;
            Nod<T> save = head;
            while (save != null)
            {
                k++;
                save = save.Next;
            }
            return k;
        }

        public int pozitieData(T data)
        {
            Nod<T> save = head;
            int k = 0;
            while (save != null)
            {
                if (save.Data.Equals(data))
                    return k;
                k++;
                save = save.Next;
            }
            return -1;
        }

        public void sortare(Comparer<T> comparator, int value)
        {
            int flag;
            do
            {
                flag = 0;
                for (int i = 0; i < this.dimensiune() - 1; i++)
                    if (comparator.Compare(this.obtine(i).Data, this.obtine(i + 1).Data) == value)
                    {
                        T aux = this.obtine(i).Data;
                        this.obtine(i).Data = this.obtine(i + 1).Data;
                        this.obtine(i + 1).Data = aux;
                        flag = 1;
                    }
            } while (flag == 1);
        }

        public string afisare()
        {
            Nod<T> save = this.head;
            int k = 1;
            string text = "";
            while (save != null)
            {
                text += $"Obiectul {k}\n---------------------\n" + save.Data.ToString() + "\n---------------------\n\n";
                save = save.Next;
                k++;
            }
            return text;
        }
    }
}
