using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace PMEManager.Interfaces.Hierarchical
	{
	public interface IHierarchical<T> : IList<T>, IListSource, IEnumerable<T>, IQueryable, INotifyPropertyChanged, INotifyCollectionChanged where T : IHierarchicalElement
		{

		public Type CategoryClass { get; init; }
		public int ElementCount { get; set; }
		public int CategoryCount { get; set; }
		public int NumberOfLevels { get; }
		public void AddNewCategory ( string name );
		public void DeleteCategory ( );
		public void RemaneCategory ( );
		public IList<IHierarchicalElement> GetHierarchicalElements ( );
		public IList<IHierarchicalElement> GetHierarchicalCategories ( uint Level );
		public IHierarchical<IHierarchicalElement> GetCategory ( params uint [] args );
		public void UpdateEnums ( );
		}

	}
