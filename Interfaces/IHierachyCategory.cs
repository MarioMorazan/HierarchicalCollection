using System.Collections.Generic;
using System.ComponentModel;

namespace Hierarchical.Interfaces
	{
	public interface IHierachyCategory<T> : IList<T>, INotifyPropertyChanged where T : BaseHierarchyComponent
		{
		public string ID { get; set; }
		public int Level { get; set; }
		public int CategoryIndex { get; set; }
		public List<T> Children { get; set; }
		public List<T> CategoryChildren { get; set; }
		public void UpdateChildrens ( );
		public void Update ( );


		}
	}
