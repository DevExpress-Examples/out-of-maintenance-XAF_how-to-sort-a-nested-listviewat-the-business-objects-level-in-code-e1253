using DevExpress.ExpressApp.Win.Editors;

namespace WinWebSolution.Module.Win {
    public class WinSortListViewController : SortListViewControllerBase {
        protected override void OnViewControlsCreated() {
            base.OnViewControlsCreated();
            GridListEditor gridListEditor = View.Editor as GridListEditor;
            if (gridListEditor != null) {
                gridListEditor.GridView.OptionsCustomization.AllowSort = false;
            }
        }
    }
}
