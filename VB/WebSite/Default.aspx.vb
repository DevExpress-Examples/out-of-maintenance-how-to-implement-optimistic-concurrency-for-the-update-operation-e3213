Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web
Imports DevExpress.Web.Data

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub grid_RowInserting(ByVal sender As Object, ByVal e As ASPxDataInsertingEventArgs)
		e.NewValues("Version") = 0
	End Sub

	Protected Sub grid_CustomJSProperties(ByVal sender As Object, ByVal e As ASPxGridViewClientJSPropertiesEventArgs)
		Dim grid As ASPxGridView = CType(sender, ASPxGridView)
		If grid.IsEditing AndAlso (Not grid.IsNewRowEditing) Then
			' Pass the editing row version to the client
			e.Properties("cpEditRowVersion") = GetVersionField(grid)
		End If
	End Sub

	Protected Sub grid_RowUpdating(ByVal sender As Object, ByVal e As ASPxDataUpdatingEventArgs)
		Dim grid As ASPxGridView = CType(sender, ASPxGridView)

		Dim prevVersion As Integer = Convert.ToInt32(ASPxHiddenField1("GridEditRowVersion"))
		Dim currentVersion As Integer = Convert.ToInt32(GetVersionField(grid))

		If prevVersion <> currentVersion Then
			Throw New Exception("The row has been changed")
		End If

		e.NewValues("Version") = 1 + currentVersion
	End Sub

	Private Function GetVersionField(ByVal grid As ASPxGridView) As Object
		Return grid.GetRowValues(grid.EditingRowVisibleIndex, "Version")
	End Function

	Protected Sub AccessDataSource1_Updating(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
		' Remove the line to allow the editing
		Throw New Exception("Data modification is not allowed in the online demo")
	End Sub
End Class
