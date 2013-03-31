
Partial Class Controls_cltCategoryMenu
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillMenu()
        End If
    End Sub

    Protected Sub FillMenu()
        Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
        Dim dtCategory As New ds_Category.CategoryDataTable
        dtCategory = daCategory.GetDataByParentCategoryId(0)
        If dtCategory IsNot Nothing Then
            If dtCategory.Rows.Count > 0 Then
                For Each drCategory As ds_Category.CategoryRow In dtCategory.Rows
                    Dim skmMenuParentCategory As skmMenu.MenuItem = New skmMenu.MenuItem(drCategory.CategoryName, "ProductList.aspx?PCID= " & drCategory.CategoryId)
                    'Fill Child Categories
                    FillChildNode(skmMenuParentCategory, drCategory.CategoryId)
                    mnuCategory.Items.Add(skmMenuParentCategory)
                Next
            End If
        End If
    End Sub
    Public Sub FillChildNode(ByRef MenuParentCategory As skmMenu.MenuItem, ByVal CategoryId As Long)
        Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
        Dim dtCategory As New ds_Category.CategoryDataTable
        dtCategory = daCategory.GetDataByParentCategoryId(CategoryId)
        If dtCategory IsNot Nothing Then
            If dtCategory.Rows.Count > 0 Then
                For Each drCategory As ds_Category.CategoryRow In dtCategory.Rows
                    Dim skmMenuChildCategory As skmMenu.MenuItem = New skmMenu.MenuItem(drCategory.CategoryName, "ProductList.aspx?CID= " & drCategory.CategoryId)
                    'Fill Child Categories
                    FillChildNode(skmMenuChildCategory, drCategory.CategoryId)
                    MenuParentCategory.SubItems.Add(skmMenuChildCategory)
                Next
            End If
        End If
    End Sub
End Class
