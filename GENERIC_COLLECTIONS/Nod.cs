using System;
using System.Collections.Generic;
using System.Text;

namespace GENERIC_COLLECTIONS
{
    public class Nod<T>
    {
        private T data;
        private Nod<T> next;

        public Nod() { }

        public T Data
        {
            get => this.data;
            set => this.data = value;
        }
        public Nod<T> Next
        {
            get => this.next;
            set => this.next = value;
        }
    }
}
