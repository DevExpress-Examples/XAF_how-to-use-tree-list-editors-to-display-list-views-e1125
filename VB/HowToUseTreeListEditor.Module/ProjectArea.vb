Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

Public Class ProjectArea
   Inherits Category
   Private fProject As Project
   Protected Overrides ReadOnly Property Parent() As ITreeNode
      Get
         Return fProject
      End Get
   End Property
   Protected Overrides ReadOnly Property Children() As IBindingList
      Get
         Return New BindingList(Of Object)()
      End Get
   End Property
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Sub New(ByVal session As Session, ByVal name As String)
      MyBase.New(session)
      Me.Name = name
   End Sub
   <Association("Project-ProjectAreas")> _
   Public Property Project() As Project
      Get
         Return fProject
      End Get
      Set(ByVal value As Project)
         SetPropertyValue("Project", fProject, Value)
      End Set
   End Property
End Class

