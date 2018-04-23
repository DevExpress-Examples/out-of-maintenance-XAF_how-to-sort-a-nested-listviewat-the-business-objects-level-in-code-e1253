Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace WinWebSolution.Module
	Public MustInherit Class SortListViewControllerBase
		Inherits ViewController(Of ListView)
		Public Sub New()
			TargetObjectType = GetType(OrderItem)
			TargetViewNesting = Nesting.Nested
		End Sub
	End Class
	<DefaultClassOptions> _
	Public Class Order
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _Name, value)
			End Set
		End Property
		<Association("Order-Items"), Aggregated> _
		Public ReadOnly Property Items() As XPCollection(Of OrderItem)
			Get
				Dim xpCollection As XPCollection(Of OrderItem) = GetCollection(Of OrderItem)("Items")
				SortingHelper.Sort(xpCollection, "ModifiedOn", SortingDirection.Descending)
				Return xpCollection
			End Get
		End Property
	End Class
	Public Class OrderItem
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Persistent("ModifiedOn"), ValueConverter(GetType(UtcDateTimeConverter))> _
		Protected _ModifiedOn As DateTime = DateTime.Now
		<PersistentAlias("_ModifiedOn"), Browsable(False)> _
		Public ReadOnly Property ModifiedOn() As DateTime
			Get
				Return _ModifiedOn
			End Get
		End Property
		Friend Overridable Sub UpdateModifiedOn()
			UpdateModifiedOn(DateTime.Now)
		End Sub
		Friend Overridable Sub UpdateModifiedOn(ByVal [date] As DateTime)
			_ModifiedOn = [date]
			Save()
		End Sub
		Protected Overrides Sub OnChanged(ByVal propertyName As String, ByVal oldValue As Object, ByVal newValue As Object)
			MyBase.OnChanged(propertyName, oldValue, newValue)
			If propertyName = "Subject" OrElse propertyName = "Description" Then
				UpdateModifiedOn()
			End If
		End Sub
		Private _Subject As String
		Public Property Subject() As String
			Get
				Return _Subject
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Subject", _Subject, value)
			End Set
		End Property
		Private _Description As String
		Public Property Description() As String
			Get
				Return _Description
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Description", _Description, value)
			End Set
		End Property
		Private _Order As Order
		<Association("Order-Items")> _
		Public Property Order() As Order
			Get
				Return _Order
			End Get
			Set(ByVal value As Order)
				SetPropertyValue("Order", _Order, value)
			End Set
		End Property
	End Class
	Public Class SortingHelper
		Public Shared Sub Sort(ByVal collection As XPBaseCollection, ByVal [property] As String, ByVal direction As SortingDirection)
			Dim isSortingAdded As Boolean = False
			For Each sortProperty As SortProperty In collection.Sorting
				If sortProperty.Property.Equals(DevExpress.Data.Filtering.CriteriaOperator.Parse([property])) Then
					isSortingAdded = True
				End If
			Next sortProperty
			If (Not isSortingAdded) Then
				collection.Sorting.Add(New SortProperty([property], direction))
			End If
		End Sub
	End Class
End Namespace