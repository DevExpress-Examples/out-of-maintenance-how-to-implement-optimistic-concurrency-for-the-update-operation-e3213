<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v10.2" Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.2" Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.2" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>How to implement optimistic concurrency for the update operation</title>
	<script type="text/javascript">
		function grid_BeginCallback(s, e) {
			ClientHiddenField1.Set("GridEditRowVersion", s.cpEditRowVersion);
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1" KeyFieldName="ID" 
			EnableRowsCache="false"
			OnRowInserting="grid_RowInserting" 
			OnCustomJSProperties="grid_CustomJSProperties" 
			OnRowUpdating="grid_RowUpdating">
			<Columns>
				<dx:GridViewCommandColumn VisibleIndex="0">
					<EditButton Visible="True">
					</EditButton>
				</dx:GridViewCommandColumn>
				<dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="1" />
				<dx:GridViewDataTextColumn FieldName="Year" VisibleIndex="2" />
			</Columns>
			<ClientSideEvents BeginCallback="grid_BeginCallback" />
		</dx:ASPxGridView>

		<dx:ASPxHiddenField id="ASPxHiddenField1" runat="server" ClientInstanceName="ClientHiddenField1">
		</dx:ASPxHiddenField>        

		<asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/DataBase.mdb"
			InsertCommand="INSERT INTO [Table1] ([Name], [Year], [Version]) VALUES (?, ?, ?)"
			DeleteCommand="DELETE FROM [Table1] WHERE [ID] = ?" 
			SelectCommand="SELECT * FROM [Table1]" UpdateCommand="UPDATE [Table1] SET [Name] = ?, [Year] = ?, [Version] = ? WHERE [ID] = ?" OnUpdating="AccessDataSource1_Updating">
			<DeleteParameters>
				<asp:Parameter Name="ID" Type="Int32" />
			</DeleteParameters>
			<UpdateParameters>
				<asp:Parameter Name="Name" Type="String" />
				<asp:Parameter Name="Year" Type="Int16" />
				<asp:Parameter Name="Version" Type="Int16" />
				<asp:Parameter Name="ID" Type="Int32" />
			</UpdateParameters>
			<InsertParameters>
				<asp:Parameter Name="Name" Type="String" />
				<asp:Parameter Name="Year" Type="Int16" />
				<asp:Parameter Name="Version" Type="Int16" />
			</InsertParameters>
		</asp:AccessDataSource>                

	</form>
</body>
</html>