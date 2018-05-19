using System;
using System.Configuration;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Win.Templates;

namespace WinSolution.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            WinSolutionWindowsFormsApplication _application = new WinSolutionWindowsFormsApplication();
            DevExpress.ExpressApp.Demos.InMemoryDataStoreProvider.Register();
            _application.ConnectionString = "XpoProvider=" + DevExpress.ExpressApp.Demos.InMemoryDataStoreProvider.XpoProviderTypeString;
            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                _application.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
            try {
                InMemoryDataStoreProvider.Register();
                _application.ConnectionString = InMemoryDataStoreProvider.ConnectionString;
                _application.Setup();
                _application.Start();
            } catch (Exception e) {
                _application.HandleException(e);
            }
        }
    }
}
