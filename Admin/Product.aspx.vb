
Partial Class Admin_Product
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateProduct() Then
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
            Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
            Dim dtProduct As New ds_Product.ProductDataTable
            dtProduct = daProduct.IsExistsForUpdate(CInt(ViewState("ID")), txtProductName.Text.Trim)
            If dtProduct IsNot Nothing Then
                If dtProduct.Rows.Count > 0 Then
                    lblMessage.Text = "Product is already exists"
                    Exit Sub
                End If
            End If
            dtProduct.Clear()
            dtProduct = daProduct.GetDataByPK(CInt(ViewState("ID")))
            If dtProduct IsNot Nothing Then
                If dtProduct.Rows.Count > 0 Then
                    Dim drProduct As ds_Product.ProductRow
                    drProduct = dtProduct.Rows(0)
                    drProduct.BeginEdit()
                    drProduct.ProductName = txtProductName.Text.Trim
                    drProduct.Price = txtPrice.Text.Trim
                    drProduct.BriefDescription = txtBriefDescription.Text.Trim
                    drProduct.Description = txtDescription.Text.Trim
                    drProduct.CategoryId = CLng(ddlCategory.SelectedValue)
                    drProduct.CompanyId = CLng(ddlCompany.SelectedValue)
                    drProduct.IsAvailable = chkIsAvailable.Checked
                    drProduct.EndEdit()
                    daProduct.Update(dtProduct)
                    Response.Redirect("~/Admin/ManageProduct.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
        Dim dtProduct As New ds_Product.ProductDataTable
        dtProduct = daProduct.IsExistsForInsert(txtProductName.Text.Trim)
        If dtProduct IsNot Nothing Then
            If dtProduct.Rows.Count > 0 Then
                lblMessage.Text = "Product is already exists."
                Exit Sub
            End If
        End If
        daProduct.Insert(txtProductName.Text.Trim, CDec(txtPrice.Text.Trim), txtBriefDescription.Text.Trim, txtDescription.Text.Trim, CLng(ddlCategory.SelectedValue), CLng(ddlCompany.SelectedValue), chkIsAvailable.Checked)
        Response.Redirect("~/Admin/ManageProduct.aspx")
    End Sub
    Private Function ValidateProduct() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtProductName.Text.Trim) Then
            strerror += rfvProductName.ErrorMessage & "</br>"
        Else
            Dim ProductNameMatch As Match
            ProductNameMatch = Regex.Match(txtProductName.Text.Trim, "[A-Z,a-z, ]$")
            If Not ProductNameMatch.Success Then
                strerror += revProductName.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtPrice.Text.Trim) Then
            strerror += rfvPrice.ErrorMessage & "</br>"
        Else
            Dim PriceMatch As Match
            PriceMatch = Regex.Match(txtPrice.Text.Trim, revPrice.ValidationExpression)
            If Not PriceMatch.Success Then
                strerror += revPrice.ErrorMessage & "</br>"
            End If
            If CDec(txtPrice.Text.Trim) < 1 Then
                strerror += "Price should be greater than 0." & "<br/>"
            End If
        End If
        If String.IsNullOrEmpty(txtBriefDescription.Text.Trim) Then
            strerror += rfvBriefDescription.ErrorMessage & "</br>"
        End If
        If String.IsNullOrEmpty(txtDescription.Text.Trim) Then
            strerror += rfvDescription.ErrorMessage & "</br>"
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
            FillCategory()
            FillCompany()
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillProduct()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub FillProduct()
        If ViewState("ID") IsNot Nothing Then
            Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
            Dim dtProduct As New ds_Product.ProductDataTable
            dtProduct = daProduct.GetDataByPK(CInt(ViewState("ID")))
            If dtProduct IsNot Nothing Then
                If dtProduct.Rows.Count > 0 Then
                    Dim drProduct As ds_Product.ProductRow
                    drProduct = dtProduct.Rows(0)
                    txtProductName.Text = drProduct.ProductName
                    txtPrice.Text = drProduct.Price
                    txtBriefDescription.Text = drProduct.BriefDescription
                    txtDescription.Text = drProduct.Description
                    ddlCategory.SelectedValue = drProduct.CategoryId
                    ddlCompany.SelectedValue = drProduct.CompanyId
                    chkIsAvailable.Checked = drProduct.IsAvailable
                End If
            End If
        End If
    End Sub
    Protected Sub FillCategory()
        Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
        Dim dtCategory As New ds_Category.CategoryDataTable
        dtCategory = daCategory.GetDataByNotParentCategoryId(0)
        If dtCategory IsNot Nothing Then
            If dtCategory.Rows.Count > 0 Then
                ddlCategory.DataSource = dtCategory
                ddlCategory.DataTextField = dtCategory.Columns(1).ColumnName
                ddlCategory.DataValueField = dtCategory.Columns(0).ColumnName
                ddlCategory.DataBind()
                ddlCategory.Items.Insert(0, New ListItem(" -- Select a Category -- ", "0"))
            Else
                ddlCategory.Items.Insert(0, New ListItem(" -- No Category Available -- ", "0"))
            End If
        Else
            ddlCategory.Items.Insert(0, New ListItem(" -- No Category Available -- ", "0"))
        End If
    End Sub
    Protected Sub FillCompany()
        Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
        Dim dtCompany As New ds_Company.CompanyDataTable
        dtCompany = daCompany.GetData()
        If dtCompany IsNot Nothing Then
            If dtCompany.Rows.Count > 0 Then
                ddlCompany.DataSource = dtCompany
                ddlCompany.DataTextField = dtCompany.Columns(1).ColumnName
                ddlCompany.DataValueField = dtCompany.Columns(0).ColumnName
                ddlCompany.DataBind()
                ddlCompany.Items.Insert(0, New ListItem(" -- Select a Company -- ", "0"))
            Else
                ddlCompany.Items.Insert(0, New ListItem(" -- No Company Available -- ", "0"))
            End If
        Else
            ddlCompany.Items.Insert(0, New ListItem(" -- No Company Available -- ", "0"))
        End If
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("~/Admin/ManageProduct.aspx")
    End Sub
End Class
