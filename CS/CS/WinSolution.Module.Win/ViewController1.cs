using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.XtraEditors;

namespace WinSolution.Module.Win {
    public partial class ViewController1 : ViewController {
        public ViewController1() {
            InitializeComponent();
            RegisterActions(components);
        }
        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e) {
            ObjectSpace objectSpaceInternal = Application.CreateObjectSpace();
            NonPersistentObject obj = objectSpaceInternal.CreateObject<NonPersistentObject>();
            e.ShowViewParameters.CreatedView = Application.CreateDetailView(objectSpaceInternal, obj);
            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
            e.ShowViewParameters.Context = TemplateContext.PopupWindow;
            e.ShowViewParameters.CreateAllControllers = true;
            DialogController dc = Application.CreateController<DialogController>();
            dc.AcceptAction.Execute += new SimpleActionExecuteEventHandler(AcceptAction_Execute);
            dc.CancelAction.Executing += new CancelEventHandler(CancelAction_Executing);
            e.ShowViewParameters.Controllers.Add(dc);
        }
        void CancelAction_Executing(object sender, CancelEventArgs e) {
            ActionBase action = (ActionBase)sender;
            ((DialogController)action.Controller).CanCloseWindow = true;
            XtraMessageBox.Show("Cancel");
        }
        void AcceptAction_Execute(object sender, SimpleActionExecuteEventArgs e) {
            NonPersistentObject obj = (NonPersistentObject)e.CurrentObject;
            if (obj.CurrentCollectionDate < obj.PreviousCollectionDate) {
                XtraMessageBox.Show("Error");
                ((DialogController)(e.Action.Controller)).CanCloseWindow = false;
            }
            else {
                XtraMessageBox.Show("Success");
            }
        }
    }
}
