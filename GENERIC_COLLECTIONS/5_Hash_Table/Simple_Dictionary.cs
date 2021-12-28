using System;
using System.Collections.Generic;
using System.Text;

namespace GENERIC_COLLECTIONS
{
    public class Simple_Dictionary<K, V>
    {
        private Stored<K, V>[] hastable;

        public Simple_Dictionary()
        {
            this.hastable = new Stored<K, V>[10];
        }

        private int hashKey(K key)
        {
            return key.ToString().Length % hastable.Length;
        }

        public void put(K key, V value)
        {
            int positie = hashKey(key);
            if (occupied(positie))
            {
                int stop = positie;
                if (positie == hastable.Length - 1)
                {
                    positie = 0;
                }
                else
                {
                    positie++;
                }
                while (occupied(positie) && positie != stop)
                {
                    positie = (positie + 1) % hastable.Length;
                }
            }
            if (occupied(positie))
            {
                Console.WriteLine("There are no more free space");
            }
            else
            {
                hastable[positie] = new Stored<K, V>();
                hastable[positie].Key = key;
                hastable[positie].Value = value;
            }
        }

        public V get(K key) => find(key) != -1 ? hastable[find(key)].Value : default(V);

        public void remove(K key)
        {
            int pozitie = hashKey(key);
            int save = pozitie;

            int stop = pozitie + 1;
            while (stop != pozitie && this.hastable[stop] != null && this.get(this.hastable[stop].Key).Equals(this.get(key)) == false)
            {
                stop = (stop + 1) % this.hastable.Length;
            }

            if (this.hastable[save] != null && this.hastable[stop] != null && this.get(this.hastable[stop].Key).Equals(this.get(key)) == true && pozitie != stop)
            {
                this.hastable[save] = this.hastable[stop];
                this.hastable[stop] = null;
            }
            else
                if (this.hastable[save] != null && this.get(this.hastable[save].Key).Equals(this.get(key)) == true)
            {
                this.hastable[save] = null;
            }
            else
                Console.WriteLine("This key cannot be removed.");
        }

        public int find(K key)
        {

            int pozitie = hashKey(key);

            if (hastable[pozitie] != null && hastable[pozitie].Key.Equals(key))
            {
                return pozitie;
            }

            int stop = pozitie;

            if (pozitie == hastable.Length - 1)
            {
                pozitie = 0;
            }
            else
            {
                pozitie++;
            }

            while (pozitie != stop && hastable[pozitie] != null && !hastable[pozitie].Key.Equals(key))
            {
                pozitie = (pozitie + 1) % hastable.Length;
            }


            if (hastable[pozitie] != null && hastable[pozitie].Key.Equals(key))
            {
                return pozitie;
            }
            else
            {
                return -1;
            }


        }

        private bool occupied(int position)
        {
            return hastable[position] != null;
        }

        public string afisare(int dimensiune)
        {
            string text = "";
            for (int i = 1; i <= dimensiune; i++)
                if (this.hastable[i] != null)
                    text += this.hastable[i].Value.ToString() + "\n";
            return text;
        }
    }
}
