Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.Base.General
Imports System.ComponentModel

<NavigationItem()> _
Public MustInherit Class Category
   Inherits BaseObject
   Implements ITreeNode
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
         SetPropertyValue("Name", fName, Value)
      End Set
   End Property
#Region "ITreeNode"
   Private ReadOnly Property ICategorizedItem_Children() As IBindingList _
         Implements ITreeNode.Children
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

