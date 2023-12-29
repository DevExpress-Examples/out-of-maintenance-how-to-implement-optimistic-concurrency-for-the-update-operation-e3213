<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to implement optimistic concurrency for the update operation


<p>The example demonstrates how to implement the optimistic concurrency for the update operation performed by ASPxGridView.<br />
This approach can be performed for any control that has events similar to grid's .</p><p>It is not reliable to use the <strong>e.OldValues</strong> collection when callbacks are employed and a caching feature is disabled.</p><p><strong>See also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2168">How to use a timestamp to check for data conflicts when you update data by using a LinqDataSource</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E2384">How to control concurrency when editing persistent objects in the ASPxGridView</a></p><p><a href="http://martinfowler.com/eaaCatalog/optimisticOfflineLock.html"><u>Optimistic Offline Lock</u></a></p>


<h3>Description</h3>

<p>The main idea of the example is that when the update operation is performed, the grid updates some invisible field in a data table by incrementing it by 1.</p><p>When two users open the same row for editing, the grid reads the value from the invisible column (<i>Version</i>). The value is transferred to the client side using <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CustomJSPropertiestopic"><u>ASPxGridView.CustomJSProperties</u></a> event and stored in ASPxHiddenField.</p><p>When either of the users clicks the Update button, the code retrieves the Version column value (it is an actual value, and it is never cached by the grid, because the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_EnableRowsCachetopic"><u>ASPxGridView.EnableRowsCache</u></a> property is disabled) and compares it with the value gotten from the hidden field.</p><p>If the comparison result is true (this means that neither of the users changed the row), the grid&#39;s updating is allowed, and the Version field value is increased by 1.</p>

<br/>


