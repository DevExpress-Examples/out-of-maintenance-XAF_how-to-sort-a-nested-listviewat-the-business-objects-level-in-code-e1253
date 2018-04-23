using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace WinWebSolution.Module.Win {
    public class WinSortRootListViewController : SortListViewControllerBase {
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            ASPxGridListEditor gridListEditor = View.Editor as ASPxGridListEditor;
            if (gridListEditor != null) {
                gridListEditor.Grid.SettingsBehavior.AllowSort = false;
            }
        }
    }
}