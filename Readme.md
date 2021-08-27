<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128541244/15.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3213)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to implement optimistic concurrency for the update operation
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3213/)**
<!-- run online end -->


<p>The example demonstrates how to implement the optimistic concurrency for the update operation performed by ASPxGridView.<br />
This approach can be performed for any control that has events similar to grid's .</p><p>It is not reliable to use the <strong>e.OldValues</strong> collection when callbacks are employed and a caching feature is disabled.</p><p><strong>See also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E2168">How to use a timestamp to check for data conflicts when you update data by using a LinqDataSource</a><br />
<a href="https://www.devexpress.com/Support/Center/p/E2384">How to control concurrency when editing persistent objects in the ASPxGridView</a></p><p><a href="http://martinfowler.com/eaaCatalog/optimisticOfflineLock.html"><u>Optimistic Offline Lock</u></a></p>

<br/>


