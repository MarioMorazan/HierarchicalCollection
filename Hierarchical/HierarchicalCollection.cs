using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace PMEManager.Interfaces.Hierarchical
	{
	public class HierarchicalCollection<T> : IHierarchical<T> where T : IHierarchicalElement
		{
		private List<T> Ts;
		private List<T> allElements;
		private List<IHierarchicalCategory<T>> categories;

		private IHierarchicalCategory<T> selectedCategory;
		public Type CategoryClass { get; init; }
		public HierarchicalCollection ( IHierarchicalCategory<T> categoryClass )
			{
			if ( categoryClass.GetType ( ).IsClass )
				{
				Ts=new List<T> ( );
				allElements=new List<T> ( );
				categories=new List<IHierarchicalCategory<T>> ( );
				CategoryClass=categoryClass.GetType ( );
				}
			}
		public HierarchicalCollection ( )
			{
			Ts=new List<T> ( );
			allElements=new List<T> ( );
			categories=new List<IHierarchicalCategory<T>> ( );
			CategoryClass=typeof ( Category<T> );
			}




		public T this [ int index ] { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }


		public int ElementCount { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }
		public int CategoryCount { get => throw new NotImplementedException ( ); set => throw new NotImplementedException ( ); }

		public int NumberOfLevels => throw new NotImplementedException ( );

		public int Count => throw new NotImplementedException ( );

		public bool IsReadOnly => throw new NotImplementedException ( );

		public bool ContainsListCollection => throw new NotImplementedException ( );

		public Type ElementType => throw new NotImplementedException ( );

		public Expression Expression => throw new NotImplementedException ( );

		public IQueryProvider Provider => throw new NotImplementedException ( );

		public event PropertyChangedEventHandler PropertyChanged;
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public void Add ( T item )
			{

			}

		public struct MyStruct
			{
			public Type D { get; init; }
			public MyStruct ( Type d )
				{

				}


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

		public void AddNewCategory ( string name )
			{
			object cat = Activator.CreateInstance ( CategoryClass );
			IHierarchicalCategory<T> category = (IHierarchicalCategory<T>) cat;
			category.Title=name;
			selectedCategory.Add ( (T) category );
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

		public void UpdateEnums ( )
			{
			throw new NotImplementedException ( );
			}
		}
	}
