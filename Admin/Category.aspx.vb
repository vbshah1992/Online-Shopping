
Partial Class Admin_Category
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateCategory() Then
            If ViewState("ID") IsNot Nothing Then
                Update()
            Else
                Insert()
            End If
        Else
            lblMessage.Text += "Unsuccessful Validation"
        End If
    End Sub
    Private Sub Update()
        If ViewState("ID") IsNot Nothing Then
            Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
            Dim dtCategory As New ds_Category.CategoryDataTable
            dtCategory = daCategory.IsExistsForUpdate(CInt(ViewState("ID")), txtCategoryName.Text.Trim)
            If dtCategory IsNot Nothing Then
                If dtCategory.Rows.Count > 0 Then
                    lblMessage.Text = "Category is already exists"
                    Exit Sub
                End If
            End If
            dtCategory.Clear()
            dtCategory = daCategory.GetDataByPK(CInt(ViewState("ID")))
            If dtCategory IsNot Nothing Then
                If dtCategory.Rows.Count > 0 Then
                    Dim drCategory As ds_Category.CategoryRow
                    drCategory = dtCategory.Rows(0)
                    drCategory.BeginEdit()
                    drCategory.ParentCategoryId = CLng(ddlParentCategory.SelectedValue)
                    drCategory.CategoryName = txtCategoryName.Text.Trim
                    drCategory.EndEdit()
                    daCategory.Update(dtCategory)
                    Response.Redirect("~/Admin/ManageCategory.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
        Dim dtCategory As New ds_Category.CategoryDataTable
        dtCategory = daCategory.IsExistsForInsert(txtCategoryName.Text.Trim)
        If dtCategory IsNot Nothing Then
            If dtCategory.Rows.Count > 0 Then
                lblMessage.Text = "Category is already exists."
                Exit Sub
            End If
        End If
        daCategory.Insert(txtCategoryName.Text.Trim, CLng(ddlParentCategory.SelectedValue))
        Response.Redirect("~/Admin/ManageCategory.aspx")
    End Sub
    Private Function ValidateCategory() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtCategoryName.Text.Trim) Then
            strerror += rfvCategoryName.ErrorMessage & "</br>"
        Else
            Dim CategoryNameMatch As Match
            CategoryNameMatch = Regex.Match(txtCategoryName.Text.Trim, "[A-Z,a-z, ]$")
            If Not CategoryNameMatch.Success Then
                strerror += revCategoryName.ErrorMessage & "</br>"
            End If
        End If
        If strerror = String.Empty Then
            Return True
        Else
            lblMessage.Text = strerror
            Return False
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillParentCategory()
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillCategory()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub FillCategory()
        If ViewState("ID") IsNot Nothing Then
            Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
            Dim dtCategory As New ds_Category.CategoryDataTable
            dtCategory = daCategory.GetDataByPK(CInt(ViewState("ID")))
            If dtCategory IsNot Nothing Then
                If dtCategory.Rows.Count > 0 Then
                    Dim drCategory As ds_Category.CategoryRow
                    drCategory = dtCategory.Rows(0)
                    txtCategoryName.Text = drCategory.CategoryName
                    ddlParentCategory.SelectedValue = drCategory.ParentCategoryId
                End If
            End If
        End If
    End Sub
    Protected Sub FillParentCategory()
        Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
        Dim dtCategory As New ds_Category.CategoryDataTable
        dtCategory = daCategory.GetDataByFillParentCategory()
        If dtCategory IsNot Nothing Then
            If dtCategory.Rows.Count > 0 Then
                ddlParentCategory.DataSource = dtCategory
                ddlParentCategory.DataTextField = dtCategory.Columns(1).ColumnName
                ddlParentCategory.DataValueField = dtCategory.Columns(0).ColumnName
                ddlParentCategory.DataBind()
                ddlParentCategory.Items.Insert(0, New ListItem(" -- Select a Parent Category -- ", "0"))
            Else
                ddlParentCategory.Items.Insert(0, New ListItem(" -- No Parent Category Available -- ", "0"))
            End If
        Else
            ddlParentCategory.Items.Insert(0, New ListItem(" -- No Parent Category Available -- ", "0"))
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Admin/ManageCategory.aspx")
    End Sub
End Class
