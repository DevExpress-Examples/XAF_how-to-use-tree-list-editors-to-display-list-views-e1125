Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

<NavigationItem()> _
Public MustInherit Class CategoryWithIssues
   Inherits BaseObject
   Implements ITreeNode
   <Association("CategoryWithIssues-Issues")> _
   Public ReadOnly Property Issues() As XPCollection(Of Issue)
      Get
         Return GetCollection(Of Issue)("Issues")
      End Get
   End Property
   Private fAllIssues As XPCollection(Of Issue)
   Public ReadOnly Property AllIssues() As XPCollection(Of Issue)
      Get
         If fAllIssues Is Nothing Then
            fAllIssues = New XPCollection(Of Issue)(Session, False)
            CollectIssuesRecursive(Me, fAllIssues)
            fAllIssues.BindingBehavior = CollectionBindingBehavior.AllowNone
         End If
         Return fAllIssues
      End Get
   End Property
   Private Sub CollectIssuesRecursive(ByVal issueCategory As CategoryWithIssues, ByVal target As XPCollection(Of Issue))
      target.AddRange(issueCategory.Issues)
      For Each childCategory As CategoryWithIssues In issueCategory.Children
         CollectIssuesRecursive(childCategory, target)
      Next childCategory
   End Sub
   Private fName As String
   Protected MustOverride ReadOnly Property Parent() As ITreeNode
   Protected MustOverride ReadOnly Property Children() As IBindingList
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Property Name() As String
      Get
         Return fName
      End Get
      Set(ByVal value As String)
         SetPropertyValue("Name", fName, value)
      End Set
   End Property
#Region "ITreeNode"
   Private ReadOnly Property ICategorizedItem_Children() As IBindingList Implements ITreeNode.Children
      Get
         Return Children
      End Get
   End Property
   Private ReadOnly Property ICategorizedItem_Name() As String Implements ITreeNode.Name
      Get
         Return Name
      End Get
   End Property
   Private ReadOnly Property ICategorizedItem_Parent() As ITreeNode Implements ITreeNode.Parent
      Get
         Return Parent
      End Get
   End Property
#End Region
End Class
Public Class ProjectGroupWithIssues
   Inherits CategoryWithIssues
   Protected Overrides ReadOnly Property Parent() As ITreeNode
      Get
         Return Nothing
      End Get
   End Property
   Protected Overrides ReadOnly Property Children() As IBindingList
      Get
         Return ProjectsWithIssues
      End Get
   End Property
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Sub New(ByVal session As Session, ByVal name As String)
      MyBase.New(session)
      Me.Name = name
   End Sub
   <Association("ProjectGroupWithIssues-ProjectsWithIssues"), Aggregated()> _
   Public ReadOnly Property ProjectsWithIssues() As XPCollection(Of ProjectWithIssues)
      Get
         Return GetCollection(Of ProjectWithIssues)("ProjectsWithIssues")
      End Get
   End Property
End Class

Public Class ProjectWithIssues
   Inherits CategoryWithIssues
   Private fProjectGroupWithIssues As ProjectGroupWithIssues
   Protected Overrides ReadOnly Property Parent() As ITreeNode
      Get
         Return fProjectGroupWithIssues
      End Get
   End Property
   Protected Overrides ReadOnly Property Children() As IBindingList
      Get
         Return ProjectAreasWithIssues
      End Get
   End Property
   Public Sub New(ByVal session As Session)
      MyBase.New(session)
   End Sub
   Public Sub New(ByVal session As Session, ByVal name As String)
      MyBase.New(session)
      Me.Name = name
   End Sub
   <Association("ProjectGroupWithIssues-ProjectsWithIssues")> _
   Public Property ProjectGroupWithIssues() As ProjectGroupWithIssues
      Get
         Return fProjectGroupWithIssues
      End Get
      Set(ByVal value As ProjectGroupWithIssues)
         SetPropertyValue("ProjectGroupWithIssues", fProjectGroupWithIssues, value)
      End Set
   End Property
   <Association("ProjectWithIssues-ProjectAreasWithIssues"), Aggregated()> _
   Public ReadOnly Property ProjectAreasWithIssues() As XPCollection(Of ProjectAreaWithIssues)
      Get
         Return GetCollection(Of ProjectAreaWithIssues)("ProjectAreasWithIssues")
      End Get
   End Property
End Class

Public Class ProjectAreaWithIssues
   Inherits CategoryWithIssues
   Private fProjectWithIssues As ProjectWithIssues
   Protected Overrides ReadOnly Property Parent() As ITreeNode
      Get
         Return fProjectWithIssues
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
   <Association("ProjectWithIssues-ProjectAreasWithIssues")> _
   Public Property ProjectWithIssues() As ProjectWithIssues
      Get
         Return fProjectWithIssues
      End Get
      Set(ByVal value As ProjectWithIssues)
         SetPropertyValue("ProjectWithIssues", fProjectWithIssues, value)
      End Set
   End Property
End Class

