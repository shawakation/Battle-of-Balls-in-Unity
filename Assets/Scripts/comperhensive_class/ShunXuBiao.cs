using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinearList
{
	public interface IListDS<T>
	{
		int GetLength();		//return the length
		void Clear();		//clear
		bool IsEmpty();		//judge if it is empty
		bool IsFull();		//judge if it is full
		bool Add(T item);		//append an element
		bool Insert(T item, int i);		//insert am element
		bool Delete(int i);		//delete an element according to its number
		T GetElem(int i);		//get an element by its ID
		int Locate(T item);		//locate an element by its key
	}
	public class SeqList<T> : IListDS<T>
	{
		private int TheMaxSize;		//the maximum size of it
		private T[] tItems;		//the data
		private int ThePointerLast;		//point to the last element
		public int PointerLast
		{
			get { return this.ThePointerLast; }
		}
		public int Maxsize
		{
			get { return this.TheMaxSize; }
			set { this.TheMaxSize = value; }
		}
		public T this [int i] {
			get { return this.tItems [i]; }
		}
		public SeqList()
		{
			this.TheMaxSize = 16;
			this.tItems = new T[16];
			this.ThePointerLast = -1;
		}
		public SeqList(int size)
		{
			this.TheMaxSize = size;
			this.tItems = new T[size];
			this.ThePointerLast = -1;
		}
		public int GetLength()
		{
			return this.ThePointerLast + 1;
		}
		public void Clear()
		{
			this.ThePointerLast = -1;
		}
		public bool IsEmpty()
		{
			return (this.ThePointerLast == -1);
		}
		public bool IsFull()
		{
			return (this.ThePointerLast + 1 == this.TheMaxSize);
		}
		public bool Add(T item)		//add an element to the last position of the list
		{
			if (this.IsFull ())
				return false;
			else {
				this.tItems [++this.ThePointerLast] = item;
				return true;
			}
		}
		public bool Insert(T item, int i)
		{
			if (i < 1 || i > this.ThePointerLast + 1)
				return false;
			if (this.IsFull ())
				return false;
			for (int j = (++this.ThePointerLast); j >= i + 1; j--)
				this.tItems [j] = this.tItems [j - 1];
			this.tItems [i] = item;
			return true;
		}
		public bool Delete(int i)
		{
			if (this.ThePointerLast == -1)
				return false;
			if (i > this.ThePointerLast || i < 0)
				return false;
			for (int j = i; j < this.ThePointerLast; j++)
				this.tItems [j] = this.tItems [j + 1];
			this.ThePointerLast--;
			return true;
		}
		public T GetElem(int i)
		{
			if (this.ThePointerLast == -1)
				return default(T);
			if (i > this.ThePointerLast || i < 0)
				return default(T);
			return this.tItems [i];
		}
		public int Locate(T item)
		{
			if (this.ThePointerLast == -1)
				return -1;
			for (int i = 0; i <= this.ThePointerLast; i++)
				if (this.tItems [i].Equals (item))
					return i;
			return -1;
		}
	}
}
