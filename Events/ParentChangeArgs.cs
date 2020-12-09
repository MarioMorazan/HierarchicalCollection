using Hierarchical.Interfaces;
using System;

namespace Hierarchical.Events
	{
	public class ParentChangeArgs : EventArgs
		{
		public ParentChangeArgs ( IHierachyCategory<BaseHierarchyChild> oldParent , IHierachyCategory<BaseHierarchyChild> newParent )
			{
			NewParent=newParent;
			OldParent=oldParent;
			}

		public IHierachyCategory<BaseHierarchyChild> OldParent { get; init; }
		public IHierachyCategory<BaseHierarchyChild> NewParent { get; init; }
		}

	}
