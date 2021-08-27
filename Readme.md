<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128593909/12.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1253)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [WebSortListViewController.cs](./CS/WinWebSolution.Module.Web/WebSortListViewController.cs) (VB: [WebSortListViewController.vb](./VB/WinWebSolution.Module.Web/WebSortListViewController.vb))
* [WinSortListViewController.cs](./CS/WinWebSolution.Module.Win/WinSortListViewController.cs) (VB: [WinSortListViewController.vb](./VB/WinWebSolution.Module.Win/WinSortListViewController.vb))
* [SortListViewController.cs](./CS/WinWebSolution.Module/SortListViewController.cs) (VB: [SortListViewController.vb](./VB/WinWebSolution.Module/SortListViewController.vb))
<!-- default file list end -->
# How to sort a nested ListView at the business objects level, in code
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e1253)**
<!-- run online end -->


<p>This example demonstrates how to provide hidden and permanent sorting by a property in a nested ListView. Suppose we have Order and OrderItem classes that participate in an aggregated One-To-Many relationship. <br />
We want to sort the collection of OrderItem objects by the ModifiedOn property, but do it in a way that end-users won't be able to see that the grid is sorted. Please see the sources of the Order class for more details on how to accomplish this. With this solution, sorting is implemented on the business objects level. Another variant is to use the approach from the <a href="https://www.devexpress.com/Support/Center/p/E1276">How to sort a ListView in code</a> example. This solution uses a specific ViewController.<br />
Alternatively, you can use the <a href="http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModelIModelSortingtopic"><u>Sorting</u></a> property of the ListView application model element.</p><p><strong>See Also:</strong><br />
<a href="https://www.devexpress.com/Support/Center/p/E1254">How to prevent sorting and grouping by certain columns in a ListView</a></p>

<br/>


