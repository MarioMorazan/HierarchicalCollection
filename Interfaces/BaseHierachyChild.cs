using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hierarchical.Interfaces
	{
	public abstract class BaseHierarchyChild<TCategory, TElement> : BaseHierarchyComponent
			where TCategory : BaseHierarchyCategory<TCategory , TElement>, new()
			where TElement : BaseHierarchyChild<TCategory , TElement>, new()
		{
		private protected BaseHierarchyCategory<TCategory , TElement> parent = null;
		private NumerationStyles numerationStyle = NumerationStyles.Numerical;
		private string iD = "not set in BaseHierarchyChild";

		public int Index { get => GetIndex ( ); }
		public string ID
			{
			get => GetID ( );
			}
		public NumerationStyles NumerationStyle
			{
			get => numerationStyle;
			set
				{
				NumerationStyles previousStyle = numerationStyle;
				numerationStyle=value;
				if ( !previousStyle.Equals ( value ) ) NumerationStyleChanged ( );
				OnPropertyChanged ( );
				}
			}
		public BaseHierarchyCategory<TCategory , TElement> Parent
			{
			get { return parent; }
			set
				{
				parent=value;
				ParentChanged ( );
				OnPropertyChanged ( );
				}
			}
		private int GetIndex ( )
			{
			if ( index!=parent.IndexOf ( this ) )
				{
				index=parent.IndexOf ( this );
				UpdateID ( );
				OnPropertyChanged ( "Index" );
				}

			return index;
			}
		private string GetID ( )
			{
			if ( index!=parent.IndexOf ( this ) )
				{
				index=parent.IndexOf ( this );
				UpdateID ( );
				OnPropertyChanged ( "ID" );
				OnPropertyChanged ( "Index" );
				}
			return iD;
			}

		#region NumerationUpdates
		private int index = -1;
		protected void ParentChanged ( ) => UpdateID ( );
		protected void NumerationStyleChanged ( ) => UpdateID ( );
		protected virtual void UpdateID ( ) => iD=Parent.ID+"."+ComponentID ( NumerationStyle );
		protected virtual string ComponentID ( NumerationStyles style )
			{
			switch ( style )
				{
				case NumerationStyles.Numerical:
					return parent.IndexOf ( this ).ToString ( );
				case NumerationStyles.Alphabetical_UpperCase:
					int indxNumber = parent.IndexOf ( this )+1;
					int counts = (int) Math.Ceiling ( (double) indxNumber/26D );
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
					indxNumber=parent.IndexOf ( this )+1;
					counts=(int) Math.Ceiling ( (double) indxNumber/26D );
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
			}
		#endregion

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

		public event PropertyChangedEventHandler PropertyChanged;
		public abstract bool BeforePropertyChange ( object sender , string propertyChanged );
		protected virtual void OnPropertyChanged ( [CallerMemberName] string propertyName = null )
			{
			BeforePropertyChange ( this , propertyName );
			PropertyChanged?.Invoke ( this , new PropertyChangedEventArgs ( propertyName ) );
			}



		public abstract void Update ( );
		public abstract void BeforeParentUpdate ( );
		public virtual void UpdateParent ( )
			{
			BeforeParentUpdate ( );
			Parent.Update ( );
			}


		}
	}
