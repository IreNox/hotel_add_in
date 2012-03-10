using System;
using System.Linq;
using System.Collections.Generic;

namespace HotelAddInApp
{
    public class VirtualList<T> : IList<T>
    {
        #region Vars
        protected List<T> list = new List<T>();
        #endregion

        #region Add
        public virtual void Add(T item)
        {
            list.Add(item);
        }

        public virtual void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public virtual void Insert(int index, T item)
        {
            list.Insert(index, item);
        }
        #endregion

        #region Remove
        public virtual bool Remove(T item)
        {
            return list.Remove(item);
        }

        public virtual void RemoveAt(int index)
        {
            Remove(list[index]);
        }

        public virtual void RemoveAll(Predicate<T> pre)
        {
            foreach (T item in list.Where(t => pre(t)))
            {
                Remove(item);
            }
        }
        #endregion

        #region Member
        public virtual int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public virtual void Clear()
        {
            list.Clear();
        }

        public virtual bool Contains(T item)
        {
            return list.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public void Sync(IEnumerable<T> sync)
        {
            list.RemoveAll(t => !sync.Contains(t));

            list.AddRange(
                sync.Where(t => !list.Contains(t))
            );
        }
        #endregion

        #region Fields
        public virtual T this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }

        public virtual int Count
        {
            get { return list.Count; }
        }

        public virtual bool IsReadOnly
        {
            get { return false; }
        }
        #endregion

        #region IEnumerable<T> Member

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion
    }
}
