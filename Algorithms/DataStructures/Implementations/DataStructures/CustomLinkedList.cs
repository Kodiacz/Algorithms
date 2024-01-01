namespace DataStructures.Implementations.DataStructures
{
    public class CustomLinkedList<TValue> : IEnumerable<TValue>
    {
        private Element<TValue> headAndTail = new Element<TValue>(default!);
        private int size;

        public CustomLinkedList()
        {
            Clear();
        }

        public int Count => size;

        public Element<TValue> First => GetElement(0);

        public Element<TValue> Last => GetElement(Count - 1);

        public void Insert(int index, TValue value)
        {
            CheckOutOfBounds(index);

            Element<TValue> element = new Element<TValue>(value);
            element.AttachBefore(GetElement(index));
            size++;
        }

        public void Add(TValue value)
        {
            Insert(size, value);
        }

        public TValue Get(int index)
        {
            CheckOutOfBounds(index);
            return GetElement(index).GetValue();
        }

        public TValue Set(int index, TValue value)
        {
            CheckOutOfBounds(index);

            Element<TValue> element = GetElement(index);
            TValue oldValue = element.GetValue();
            element.SetValue(value);
            return oldValue;
        }

        public int IndexOf(TValue value)
        {
            int index = 0;

            for (Element<TValue> e = headAndTail!.GetNext(); e != headAndTail; e = e.GetNext())
            {
                if (value!.Equals(e.GetValue())) return index;

                index++;
            }

            return -1;
        }

        public TValue Delete(int index)
        {
            CheckOutOfBounds(index);

            Element<TValue> element = GetElement(index);
            element.Detach();
            size--;
            return element.GetValue();
        }

        public bool Delete(TValue value)
        {
            for (Element<TValue> e = headAndTail!.GetNext(); e != headAndTail; e = e.GetNext())
            {
                if (value?.Equals(e.GetValue()) ?? false)
                {
                    e.Detach();
                    size--;
                    return true;
                }
            }

            return false;
        }

        public bool Contains(TValue value)
        {
            return IndexOf(value) != -1;
        }

        public bool IsEmpty() => size == 0;

        public void Clear()
        {
            headAndTail.SetPrevious(headAndTail);
            headAndTail.SetNext(headAndTail);
            size = 0;
        }

        private Element<TValue> GetElement(int index)
        {
            Element<TValue>? element = headAndTail.GetNext();

            for (int i = index; i > 0; --i)
            {
                element = element!.GetNext();
            }

            return element!;
        }

        private void CheckOutOfBounds(int index)
        {
            if (IsOutOfBounds(index)) throw new IndexOutOfRangeException($"index {index}");
        }

        private bool IsOutOfBounds(int index)
        {
            return index < 0 || index > size;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            return new Enumerator<TValue>(headAndTail!);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Element<TValue>
    {
        private TValue value;
        private Element<TValue>? previous;
        private Element<TValue>? next;

        public Element(TValue value)
        {
            this.value = value!;
        }

        public TValue GetValue()
        {
            return value!;
        }

        public void SetValue(TValue value)
        {
            this.value = value;
        }

        public Element<TValue> GetPrevious()
        {
            return previous!;
        }

        public void SetPrevious(Element<TValue> element)
        {
            previous = element;
        }

        public Element<TValue> GetNext()
        {
            return next!;
        }

        public void SetNext(Element<TValue> element)
        {
            next = element;
        }

        public void AttachBefore(Element<TValue> next)
        {
            Element<TValue> previous = next.GetPrevious();

            SetNext(next!);
            SetPrevious(previous!);

            next!.SetPrevious(this);
            previous!.SetNext(this);
        }

        public void Detach()
        {
            next!.SetPrevious(previous!);
            previous!.SetNext(next!);
        }
    }

    public struct Enumerator<TValue> : IEnumerator<TValue>
    {
        private Element<TValue> current;
        private Element<TValue> headAndTeil;

        internal Enumerator(Element<TValue> headAndTail)
        {
            headAndTeil = headAndTail;
            current = headAndTeil.GetNext();
        }

        public TValue Current => current.GetPrevious().GetValue();

        object IEnumerator.Current => Current!;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (current.GetValue() == null) return false;
            current = current.GetNext();
            return true;
        }

        public void Reset()
        {
            current = headAndTeil.GetNext();
        }
    }
}