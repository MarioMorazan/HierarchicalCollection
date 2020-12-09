using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hierarchical.Interfaces
	{
	public abstract class BaseHierarchyCategory<TCategory, TElement> : BaseHierarchyComponent, IEnumerable, INotifyPropertyChanged, INotifyCollectionChanged
		where TCategory : BaseHierarchyCategory<TCategory , TElement>, new()
		where TElement : BaseHierarchyChild<TCategory , TElement>, new()
		{

		public string ID { get => GetID ( ); }
		public int Index { get => GetIndex ( ); }
		private int GetIndex ( )
			{
			if ( index!=parent.ChildrenCategories.IndexOf ( this ) )
				{
				index=parent.ChildrenCategories.IndexOf ( this );
				UpdateID ( );
				OnPropertyChanged ( "Index" );
				}

			return index;
			}
		private string GetID ( )
			{
			if ( index!=parent.ChildrenCategories.IndexOf ( this ) )
				{
				index=parent.ChildrenCategories.IndexOf ( this );
				UpdateID ( );
				OnPropertyChanged ( "ID" );
				OnPropertyChanged ( "Index" );
				}
			return iD;
			}

		private BaseHierarchyCategory<TCategory , TElement> parent;
		public BaseHierarchyCategory<TCategory , TElement> Parent
			{
			get => parent;
			set
				{
				if ( !parent.Equals ( value ) )
					{
					parent.CollectionChanged-=Parent_CollectionChanged;
					parent.ParentChanged-=Parent_ParentChanged;
					parent=value;
					parent.CollectionChanged+=Parent_CollectionChanged;
					parent.ParentChanged+=Parent_ParentChanged;
					OnParentChanged ( );
					}

				}
			}


		private NumerationStyles numerationStyleCategories;
		public NumerationStyles NumerationStyleCategories
			{
			get => numerationStyleCategories;
			set
				{
				if ( !numerationStyleCategories.Equals ( value ) )
					{
					NumerationStyleChanged ( );
					numerationStyleCategories=value;
					}
				}
			}

		private NumerationStyles numerationStyleElements;
		public NumerationStyles NumerationStyleElements
			{
			get => numerationStyleElements;
			set
				{
				numerationStyleElements=value;
				}
			}


		public List<BaseHierarchyComponent> Children = new ( );
		public List<BaseHierarchyCategory<TCategory , TElement>> ChildrenCategories = new ( );
		public List<BaseHierarchyChild<TCategory , TElement>> ChildrenElements = new ( );





		#region Setters for INPC
#nullable enable
		protected virtual bool SetProperty<T> ( ref T backingStore , T value ,
			[CallerMemberName] string propertyName = null , Action? onChanged = null ,
			Func<T , T , bool>? validateValue = null )
			{
			backingStore=value;
			onChanged?.Invoke ( );
			OnPropertyChanged ( propertyName );
			return true;
			}

		protected virtual bool SetPropertyWithValidation<T> ( ref T backingStore , T value ,
	[CallerMemberName] string propertyName = null , Action? onChanged = null ,
	Func<T , T , bool>? validateValue = null )
			{
			//if value didn't change
			if ( EqualityComparer<T>.Default.Equals ( backingStore , value ) )
				return false;

			//if value changed but didn't validate
			if ( validateValue!=null&&!validateValue ( backingStore , value ) )
				return false;

			backingStore=value;
			onChanged?.Invoke ( );
			OnPropertyChanged ( propertyName );
			return true;
			}
#nullable disable
		#endregion

		#region Methods
		public void AddNewCategory ( )
			{
			TCategory category = new TCategory ( );
			category.Parent=this;
			category.NumerationStyleCategories=NumerationStyleCategories;
			Children.Add ( category );
			ChildrenCategories.Add ( category );
			category.PropertyChanged+=Category_PropertyChanged;
			category.PropertyChanged+=IndexOrParenChanged;
			}
		protected abstract void Category_PropertyChanged ( object sender , PropertyChangedEventArgs e );


		public void AddNewElement ( )
			{
			TElement element = new ( );
			element.Parent=this;
			element.NumerationStyle=NumerationStyleElements;
			Children.Add ( element );
			ChildrenElements.Add ( element );
			element.UpdateNumeration ( );
			element.PropertyChanged+=Element_PropertyChanged;
			}
		protected abstract void Element_PropertyChanged ( object sender , PropertyChangedEventArgs e );

		public int IndexOf ( BaseHierarchyComponent item )
			{
			return Children.IndexOf ( item );
			}

		public IEnumerator GetEnumerator ( )
			{
			return Children.GetEnumerator ( );
			}
		#endregion

		#region Emiting Events

		public event PropertyChangedEventHandler PropertyChanged;
		public event NotifyCollectionChangedEventHandler CollectionChanged;
		public event PropertyChangedEventHandler ParentChanged;

		protected virtual void OnCollectionRemove ( TElement element , int iindex )
			{
			CollectionChanged?.Invoke ( this , new NotifyCollectionChangedEventArgs ( NotifyCollectionChangedAction.Remove , element , iindex ) );
			}
		protected virtual void OnCollectionMove ( TElement element , int oldIndex , int newIndex )
			{
			CollectionChanged?.Invoke ( this , new NotifyCollectionChangedEventArgs ( NotifyCollectionChangedAction.Move , element , newIndex , oldIndex ) );
			}
		protected virtual void OnCollectionReplace ( TElement oldElement , TElement newElement )
			{
			CollectionChanged?.Invoke ( this , new NotifyCollectionChangedEventArgs ( NotifyCollectionChangedAction.Replace , newElement , oldElement ) );
			}
		protected virtual void OnCollectionReset ( )
			{
			CollectionChanged?.Invoke ( this , new NotifyCollectionChangedEventArgs ( NotifyCollectionChangedAction.Reset ) );
			}
		protected virtual void OnCollectionAdd ( TElement element , int indx )
			{
			CollectionChanged?.Invoke ( this , new NotifyCollectionChangedEventArgs ( NotifyCollectionChangedAction.Add , element , indx ) );
			}
		public abstract bool BeforePropertyChange ( object sender , string propertyChanged );
		protected virtual void OnPropertyChanged ( [CallerMemberName] string propertyName = null )
			{
			BeforePropertyChange ( this , propertyName );
			PropertyChanged?.Invoke ( this , new PropertyChangedEventArgs ( propertyName ) );
			}
		protected virtual void OnParentChanged ( )
			{
			UpdateID ( );
			ParentChanged?.Invoke ( this , new PropertyChangedEventArgs ( "Parent" ) );
			}
		#endregion

		#region Recieving Events
		private void Parent_CollectionChanged ( object sender , NotifyCollectionChangedEventArgs e )
			{
			switch ( e.Action )
				{
				case NotifyCollectionChangedAction.Add:
					break;
				case NotifyCollectionChangedAction.Remove:
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
				case NotifyCollectionChangedAction.Move:
					break;
				case NotifyCollectionChangedAction.Reset:
					break;
				default:
					break;
				}
			}
		private void Parent_ParentChanged ( object sender , PropertyChangedEventArgs e )
			{
			UpdateNumeration ( );
			}
		public abstract void Update ( );
		public abstract void BeforeParentUpdate ( );
		public virtual void UpdateParent ( )
			{
			BeforeParentUpdate ( );
			Parent.Update ( );
			}

		#region NumerationUpdates
		private int index = -1; private string iD;

		protected void NumerationStyleChanged ( ) => UpdateID ( );
		protected virtual void UpdateID ( ) => iD=Parent.ID+"."+ComponentID ( NumerationStyleCategories );
		protected virtual string ComponentID ( NumerationStyles style )
			{
			switch ( style )
				{
				case NumerationStyles.Numerical:
					return parent.IndexOf ( this ).ToString ( );
				case NumerationStyles.Alphabetical_UpperCase:
					int indxNumber = parent.ChildrenCategories.IndexOf ( this )+1;
					int numberOfLetters = (int) Math.Ceiling ( Math.Log ( (double) indxNumber , 26D ) );

					string letterNumeration = "";
					int lettersInNumbers;
					double currentNumber = (double) indxNumber;
					for ( int i = numberOfLetters ; i>=0 ; i-- )
						{
						lettersInNumbers=(int) Math.Floor ( currentNumber/Math.Pow ( 26 , i-1 ) );
						currentNumber=currentNumber%Math.Pow ( 26 , i-1 );
						letterNumeration+=( (char) ( lettersInNumbers+64 ) ).ToString ( );
						}

					return letterNumeration;
				case NumerationStyles.Alphabetical_LowerCase:
					indxNumber=parent.ChildrenCategories.IndexOf ( this )+1;
					numberOfLetters=(int) Math.Ceiling ( Math.Log ( (double) indxNumber , 26D ) );

					letterNumeration="";
					currentNumber=(double) indxNumber;
					for ( int i = numberOfLetters ; i>=0 ; i-- )
						{
						lettersInNumbers=(int) Math.Floor ( currentNumber/Math.Pow ( 26 , i-1 ) );
						currentNumber=currentNumber%Math.Pow ( 26 , i-1 );
						letterNumeration+=( (char) ( lettersInNumbers+96 ) ).ToString ( );
						}

					return letterNumeration;
				default:
					return "numeration by letter not working";
				}

			}
		public override void UpdateNumeration ( )
			{
			GetID ( );
			GetIndex ( );
			UpdateChildrenEnumeration ( );
			}
		public void UpdateChildrenEnumeration ( )
			{
			foreach ( BaseHierarchyComponent item in Children )
				{
				item.UpdateNumeration ( );
				}

			}
		#endregion
		#endregion
		}
	}
