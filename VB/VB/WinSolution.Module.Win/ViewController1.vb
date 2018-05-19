Imports DevExpress.ExpressApp.DC
Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.XtraEditors

Namespace WinSolution.Module.Win
	Partial Public Class ViewController1
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
		End Sub
		Private Sub simpleAction1_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs) Handles simpleAction1.Execute
			Dim objectSpaceInternal As IObjectSpace = Application.CreateObjectSpace()
			Dim obj As NonPersistentObject = objectSpaceInternal.CreateObject(Of NonPersistentObject)()
			e.ShowViewParameters.CreatedView = Application.CreateDetailView(objectSpaceInternal, obj)
			e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow
			e.ShowViewParameters.Context = TemplateContext.PopupWindow
			e.ShowViewParameters.CreateAllControllers = True
			Dim dc As DialogController = Application.CreateController(Of DialogController)()
			AddHandler dc.AcceptAction.Execute, AddressOf AcceptAction_Execute
			AddHandler dc.CancelAction.Executing, AddressOf CancelAction_Executing
			e.ShowViewParameters.Controllers.Add(dc)
		End Sub
		Private Sub CancelAction_Executing(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim action As ActionBase = CType(sender, ActionBase)
			CType(action.Controller, DialogController).CanCloseWindow = True
			XtraMessageBox.Show("Cancel")
		End Sub
		Private Sub AcceptAction_Execute(ByVal sender As Object, ByVal e As SimpleActionExecuteEventArgs)
			Dim obj As NonPersistentObject = CType(e.CurrentObject, NonPersistentObject)
			If obj.CurrentCollectionDate < obj.PreviousCollectionDate Then
				XtraMessageBox.Show("Error")
				CType(e.Action.Controller, DialogController).CanCloseWindow = False
			Else
				XtraMessageBox.Show("Success")
			End If
		End Sub
	End Class
End Namespace
