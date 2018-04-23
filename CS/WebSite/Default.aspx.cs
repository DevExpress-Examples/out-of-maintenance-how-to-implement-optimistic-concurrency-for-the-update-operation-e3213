using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
using DevExpress.Web.Data;

public partial class _Default : System.Web.UI.Page {

    protected void grid_RowInserting(object sender, ASPxDataInsertingEventArgs e) {
        e.NewValues["Version"] = 0;
    }

    protected void grid_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e) {        
        ASPxGridView grid = (ASPxGridView)sender;
        if(grid.IsEditing && !grid.IsNewRowEditing) {
            // Pass the editing row version to the client
            e.Properties["cpEditRowVersion"] = GetVersionField(grid);
        }
    }

    protected void grid_RowUpdating(object sender, ASPxDataUpdatingEventArgs e) {
        ASPxGridView grid = (ASPxGridView)sender;

        int prevVersion = Convert.ToInt32(ASPxHiddenField1["GridEditRowVersion"]);
        int currentVersion = Convert.ToInt32(GetVersionField(grid));

        if(prevVersion != currentVersion)
            throw new Exception("The row has been changed");

        e.NewValues["Version"] = 1 + currentVersion;
    }

    object GetVersionField(ASPxGridView grid) {
        return grid.GetRowValues(grid.EditingRowVisibleIndex, "Version");
    }

    protected void AccessDataSource1_Updating(object sender, SqlDataSourceCommandEventArgs e) {
        // Remove the line to allow the editing
        throw new Exception("Data modification is not allowed in the online demo");   
    }
}
