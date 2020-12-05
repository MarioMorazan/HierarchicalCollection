using System.Collections.Specialized;
using System.ComponentModel;

namespace PMEManager.Interfaces.Hierarchical
	{
	public interface IHierarchicalCategory<T> : IHierarchicalElement, IHierarchical<T>, INotifyPropertyChanged, INotifyCollectionChanged where T : IHierarchicalElement
		{
		public string Title { get; set; }
		}
	}
