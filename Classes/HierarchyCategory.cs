using Hierarchical.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hierarchical.Classes
	{
	public class HierarchyCategory<T> : BaseHierarchyChild, IHierachyCategory<T> where T : BaseHierarchyChild
		{


		public T this [ int index ] { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		object IList.this [ int index ] { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		T IReadOnlyList<T>.this [ int index ] => throw new NotImplementedException ( );

		public uint Level { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public int Count => throw new NotImplementedException ( );

		public bool IsReadOnly => throw new NotImplementedException ( );

		public bool IsFixedSize => throw new NotImplementedException ( );

		public bool IsSynchronized => throw new NotImplementedException ( );

		public object SyncRoot => throw new NotImplementedException ( );

		public int CategoryIndex { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		public List<BaseHierarchyChild> Children { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		public List<IHierachyCategory<T>> CategoryChildren { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		string IHierachyCategory<T>.ID { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		int IHierachyCategory<T>.Level { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public event PropertyChangedEventHandler PropertyChanged;

		public void Add ( T item )
			{
			throw new NotImplementedException ( );
			}

		public int Add ( object value )
			{
			throw new NotImplementedException ( );
			}

		public override void BeforeParentUpdate ( )
			{
			throw new NotImplementedException ( );
			}

		public override bool BeforePropertyChange ( object sender , string propertyChanged )
			{
			throw new NotImplementedException ( );
			}

		public void Clear ( )
			{
			throw new NotImplementedException ( );
			}

		public bool Contains ( T item )
			{
			throw new NotImplementedException ( );
			}

		public bool Contains ( object value )
			{
			throw new NotImplementedException ( );
			}

		public void CopyTo ( T [] array , int arrayIndex )
			{
			throw new NotImplementedException ( );
			}

		public void CopyTo ( Array array , int index )
			{
			throw new NotImplementedException ( );
			}

		public IEnumerator<T> GetEnumerator ( )
			{
			throw new NotImplementedException ( );
			}

		public int IndexOf ( T item )
			{
			throw new NotImplementedException ( );
			}

		public int IndexOf ( object value )
			{
			throw new NotImplementedException ( );
			}

		public void Insert ( int index , T item )
			{
			throw new NotImplementedException ( );
			}

		public void Insert ( int index , object value )
			{
			throw new NotImplementedException ( );
			}

		public bool Remove ( T item )
			{
			throw new NotImplementedException ( );
			}

		public void Remove ( object value )
			{
			throw new NotImplementedException ( );
			}

		public void RemoveAt ( int index )
			{
			throw new NotImplementedException ( );
			}

		public override void Update ( )
			{
			throw new NotImplementedException ( );
			}

		public override void UpdateThis ( )
			{
			throw new NotImplementedException ( );
			}

		IEnumerator IEnumerable.GetEnumerator ( )
			{
			throw new NotImplementedException ( );
			}
		}
	}
