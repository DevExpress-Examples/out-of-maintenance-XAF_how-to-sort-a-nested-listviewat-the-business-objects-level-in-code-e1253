Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating

Namespace WinWebSolution.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal os As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(os, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Dim order As Order = ObjectSpace.CreateObject (Of Order)()
			order.Name = "Order 1"
			For i As Integer = 0 To 4
				Dim item As OrderItem = ObjectSpace.CreateObject(Of OrderItem)()
				item.Subject = "OrderItem " & i.ToString()
				item.Order = order
				item.UpdateModifiedOn(DateTime.Now + TimeSpan.FromDays(i))
				item.Save()
			Next i
		End Sub
	End Class
End Namespace
