using System;

namespace Hierarchical.Interfaces
	{

	public enum NumerationStyles
		{
		Numerical,
		Alphabetical_UpperCase,
		Alphabetical_LowerCase
		}
	public interface IHierarchyCollection<TCategory, TElement>
		where TCategory : BaseHierarchyCategory<BaseHierarchyChild>
		where TElement : BaseHierarchyChild
		{

		static IHierarchyCollection ( )
			{
			ValidateGenerics ( );
			}

		private static void ValidateGenerics ( )
			{

			if ( !typeof ( IHierachyCategory<BaseHierarchyChild> ).IsAssignableFrom ( typeof ( TCategory ) ) )
				{
				throw new Exception ( "TCategory must inherit IHierarchyCategory" );
				}
			if ( typeof ( IHierachyCategory<BaseHierarchyChild> ).IsAssignableFrom ( typeof ( TElement ) ) )
				{
				throw new Exception ( "TElement must not inherit IHierarchyCategory" );
				}

			}



		}
	}
