Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Win.Editors

Namespace WinWebSolution.Module.Win
	Public Class WinSortListViewController
		Inherits SortListViewControllerBase
		Protected Overrides Sub OnViewControlsCreated()
			MyBase.OnViewControlsCreated()
			Dim gridListEditor As GridListEditor = TryCast(View.Editor, GridListEditor)
			If gridListEditor IsNot Nothing Then
				gridListEditor.GridView.OptionsCustomization.AllowSort = False
			End If
		End Sub
	End Class
End Namespace
