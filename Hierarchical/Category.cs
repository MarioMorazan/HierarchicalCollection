using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace PMEManager.Interfaces.Hierarchical
	{
	public class Category<T> : IHierarchicalCategory<T> where T : IHierarchicalElement
		{
		private List<T>;

			public Category ( )
			{

			}

		public Category ( Hierarchical<T>)
			{

			}
		public T this [ int index ] { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public IHierarchicalCategory<T> HierarchichalClass { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public int NumberOfLevels => throw new NotImplementedException ( );

		public int Count => throw new NotImplementedException ( );

		public bool IsReadOnly => throw new NotImplementedException ( );

		public bool ContainsListCollection => throw new NotImplementedException ( );

		public string HierarchicalEnumerator { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public int HierarchicalLevel => throw new NotImplementedException ( );

		public IHierarchicalCategory<T> CategoryClass { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		public int ElementCount { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		public int CategoryCount { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public Type ElementType => throw new NotImplementedException ( );

		public Expression Expression => throw new NotImplementedException ( );

		public IQueryProvider Provider => throw new NotImplementedException ( );

		public IHierarchical<IHierarchicalElement> ParentCategory { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		uint IHierarchicalElement.HierarchicalLevel { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public event PropertyChangedEventHandler PropertyChanged;
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public void Add ( T item )
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

		public void CopyTo ( T [] array , int arrayIndex )
			{
			throw new NotImplementedException ( );
			}

		public void CreateCategory ( )
			{
			throw new NotImplementedException ( );
			}

		public void DeleteCategory ( )
			{
			throw new NotImplementedException ( );
			}

		public IHierarchical<IHierarchicalElement> GetCategory ( params uint [] args )
			{
			throw new NotImplementedException ( );
			}

		public IEnumerator<T> GetEnumerator ( )
			{
			throw new NotImplementedException ( );
			}

		public IList<IHierarchicalElement> GetHierarchicalCategories ( uint Level )
			{
			throw new NotImplementedException ( );
			}

		public IList<IHierarchicalElement> GetHierarchicalElements ( )
			{
			throw new NotImplementedException ( );
			}

		public IList GetList ( )
			{
			throw new NotImplementedException ( );
			}

		public int IndexOf ( T item )
			{
			throw new NotImplementedException ( );
			}

		public void Insert ( int index , T item )
			{
			throw new NotImplementedException ( );
			}

		public void RemaneCategory ( )
			{
			throw new NotImplementedException ( );
			}

		public bool Remove ( T item )
			{
			throw new NotImplementedException ( );
			}

		public void RemoveAt ( int index )
			{
			throw new NotImplementedException ( );
			}

		IEnumerator IEnumerable.GetEnumerator ( )
			{
			throw new NotImplementedException ( );
			}
		}
	}
