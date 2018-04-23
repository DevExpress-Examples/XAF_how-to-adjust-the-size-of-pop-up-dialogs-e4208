﻿Imports System
Imports System.Linq
Imports System.Text
Imports System.ComponentModel
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Model.DomainLogics
Imports DevExpress.ExpressApp.Model.NodeGenerators

Namespace PopupSizeExample.Module.Win
    <ToolboxItemFilter("Xaf.Platform.Win")>
    Public NotInheritable Partial Class PopupSizeExampleWindowsFormsModule
        Inherits ModuleBase
    ' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
            Return ModuleUpdater.EmptyModuleUpdaters
        End Function
        Public Overrides Sub Setup(ByVal application As XafApplication)
            MyBase.Setup(application)
            ' Manage various aspects of the application UI and behavior at the module level.
        End Sub
    End Class
End Namespace
