﻿Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Xpo

Namespace PopupSizeExample.Win
    ' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWinWinApplicationMembersTopicAll.aspx
    Partial Public Class PopupSizeExampleWindowsFormsApplication
        Inherits WinApplication

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProviders.Add(New XPObjectSpaceProvider(args.ConnectionString, args.Connection, False))
            args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
        End Sub
        Private Sub PopupSizeExampleWindowsFormsApplication_CustomizeLanguagesList(ByVal sender As Object, ByVal e As CustomizeLanguagesListEventArgs) Handles MyBase.CustomizeLanguagesList
            Dim userLanguageName As String = System.Threading.Thread.CurrentThread.CurrentUICulture.Name
            If userLanguageName <> "en-US" AndAlso e.Languages.IndexOf(userLanguageName) = -1 Then
                e.Languages.Add(userLanguageName)
            End If
        End Sub
        Private Sub PopupSizeExampleWindowsFormsApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Dim message As String = "The application cannot connect to the specified database, " & "because the database doesn't exist, its version is older " & "than that of the application or its schema does not match " & "the ORM data model structure. To avoid this error, use one " & "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article."

                If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
                    message &= ControlChars.CrLf & ControlChars.CrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
                End If
                Throw New InvalidOperationException(message)
            End If
#End If
        End Sub
    End Class
End Namespace
