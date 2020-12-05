using System.ComponentModel;

namespace PMEManager.Interfaces.Hierarchical
	{
	public interface IHierarchicalElement : INotifyPropertyChanged
		{
		public string HierarchicalEnumerator { get; set; }
		public IHierarchical<IHierarchicalElement> ParentCategory { get; set; }
		public uint HierarchicalLevel { get; set; }
		}
	}
