Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinSolution.Module
	<NonPersistent> _
	Public Class NonPersistentObject
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _currentCollectionDate As DateTime
		Public Property CurrentCollectionDate() As DateTime
			Get
				Return _currentCollectionDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("CurrentCollectionDate", _currentCollectionDate, value)
			End Set
		End Property
		Private _previousCollectionDate As DateTime
		Public Property PreviousCollectionDate() As DateTime
			Get
				Return _previousCollectionDate
			End Get
			Set(ByVal value As DateTime)
				SetPropertyValue("PreviousCollectionDate", _previousCollectionDate, value)
			End Set
		End Property
	End Class
End Namespace
