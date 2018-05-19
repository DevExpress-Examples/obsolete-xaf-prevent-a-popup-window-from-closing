Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Windows.Forms

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Win
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Win.Templates

Namespace WinSolution.Win
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached
			Dim _application As New WinSolutionWindowsFormsApplication()
			DevExpress.ExpressApp.Demos.InMemoryDataStoreProvider.Register()
			_application.ConnectionString = "XpoProvider=" & DevExpress.ExpressApp.Demos.InMemoryDataStoreProvider.XpoProviderTypeString
			If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
				_application.ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
			End If
			Try
InMemoryDataStoreProvider.Register()
                _application.ConnectionString = InMemoryDataStoreProvider.ConnectionString
				_application.Setup()
				_application.Start()
			Catch e As Exception
				_application.HandleException(e)
			End Try
		End Sub
	End Class
End Namespace
