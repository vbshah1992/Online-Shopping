
Partial Class Admin_ManageProduct
    Inherits System.Web.UI.Page
    Protected Sub gvProduct_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProduct.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim lnkToggle As LinkButton = CType(e.Row.Cells(8).Controls(0), LinkButton)
                If lnkToggle IsNot Nothing Then
                    If e.Row.DataItem("IsAvailable") Then
                        lnkToggle.Text = "Available"
                    Else
                        lnkToggle.Text = "Un-Available"
                    End If
                End If
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(10).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub

    Protected Sub gvProduct_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProduct.RowCommand
        If e.CommandName = "IsAvailable" Then
            Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
            Dim dtProduct As New ds_Product.ProductDataTable
            dtProduct = daProduct.GetDataByPK(CLng(gvProduct.DataKeys(CInt(e.CommandArgument.ToString())).Value.ToString()))
            If dtProduct IsNot Nothing Then
                If dtProduct.Rows.Count > 0 Then
                    Dim drProduct As ds_Product.ProductRow
                    drProduct = dtProduct.Rows(0)
                    drProduct.BeginEdit()
                    drProduct.IsAvailable = Not drProduct.IsAvailable
                    drProduct.EndEdit()
                    daProduct.Update(dtProduct)
                    gvProduct.DataBind()
                End If
            End If
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsProduct.SelectParameters.Clear()
        'If (ddlCompany.SelectedValue = "0") And (ddlCategory.SelectedValue = "0") Then
        '    odsProduct.SelectMethod = "GetDetails"
        'ElseIf (ddlCompany.SelectedValue <> "0") And (ddlCategory.SelectedValue = "0") Then
        '    odsProduct.SelectMethod = "SearchByCompany"
        '    odsProduct.SelectParameters.Add("CompanyId", ddlCategory.SelectedValue)
        'ElseIf (ddlCompany.SelectedValue = "0") And (ddlCategory.SelectedValue <> "0") Then
        '    odsProduct.SelectMethod = "SearchByCategory"
        '    odsProduct.SelectParameters.Add("CategoryId", ddlCategory.SelectedValue)
        'ElseIf (ddlCompany.SelectedValue <> "0") And (ddlCategory.SelectedValue <> "0") Then
        '    odsProduct.SelectMethod = "SearchByCompanyANDCategory"
        '    odsProduct.SelectParameters.Add("CompanyId", ddlCompany.SelectedValue)
        '    odsProduct.SelectParameters.Add("CategoryId", ddlCategory.SelectedValue)
        'End If
        odsProduct.SelectMethod = "SearchByManageProduct"
        odsProduct.SelectParameters.Add("ProductName", "%" & txtProduct.Text.Trim & "%")
        odsProduct.SelectParameters.Add("CompanyId", ddlCompany.SelectedValue)
        odsProduct.SelectParameters.Add("CategoryId", ddlCategory.SelectedValue)
        odsProduct.DataBind()
        gvProduct.DataBind()
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = String.Empty
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            FillCategory()
            FillCompany()
            If gvProduct.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
                btnExport.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
        Dim dtProduct As New ds_Product.ProductDataTable
        dtProduct = daProduct.GetDetails()

        If dtProduct IsNot Nothing Then
            If dtProduct.Rows.Count > 0 Then
                Response.Clear()
                Response.AddHeader("content-disposition", "attachment;filename=" & Now.Ticks.ToString() & ".xls")
                Response.ContentType = "application/vnd.xls"

                Response.Charset = String.Empty
                Response.Cache.SetCacheability(HttpCacheability.NoCache)

                Dim stringWrite As New System.IO.StringWriter()
                Dim htmlWrite As New HtmlTextWriter(stringWrite)
                'New Column
                'Dim DC As New Data.DataColumn
                'DC.ColumnName = "FullName"
                'DC.Expression = "FirstName + ' ' + MiddleName + ' ' + LastName"
                'dtStudent.Columns.Add(DC)

                Dim bfProductName As New BoundField
                bfProductName.DataField = "ProductName"
                bfProductName.HeaderText = "Product Name"

                Dim bfPrice As New BoundField
                bfPrice.DataField = "Price"
                bfPrice.HeaderText = "Price"

                Dim bfBriefDescription As New BoundField
                bfBriefDescription.DataField = "BriefDescription"
                bfBriefDescription.HeaderText = "Brief Description"

                Dim bfCategoryName As New BoundField
                bfCategoryName.DataField = "CategoryName"
                bfCategoryName.HeaderText = "Category"

                Dim bfCompany As New BoundField
                bfCompany.DataField = "CompanyName"
                bfCompany.HeaderText = "Company"

                Dim gvExport As New GridView
                gvExport.AllowPaging = False
                gvExport.AutoGenerateColumns = False
                gvExport.Columns.Add(bfProductName)
                gvExport.Columns.Add(bfPrice)
                gvExport.Columns.Add(bfBriefDescription)
                gvExport.Columns.Add(bfCategoryName)
                gvExport.Columns.Add(bfCompany)

                gvExport.Columns(0).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(0).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(1).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(1).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(2).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(2).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(3).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(3).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(4).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(4).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.HeaderStyle.ForeColor = Drawing.Color.White
                gvExport.GridLines = GridLines.Both

                gvExport.DataSource = dtProduct.DefaultView
                gvExport.DataBind()
                gvExport.Visible = True
                gvExport.RenderControl(htmlWrite)
                Response.Write(stringWrite.ToString())
                Response.End()
            Else
                lblMessage.Text = "No Record found."
            End If
        Else
            lblMessage.Text = "No Record found."
        End If

    End Sub

    Protected Sub gvProduct_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvProduct.RowDeleting
        Dim ProductId As Int64 = CLng(gvProduct.DataKeys(e.RowIndex).Value)
        Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
        Dim ImageCount As Int32 = 0
        ImageCount = daProduct.CheckReferenceImage(ProductId)
        If ImageCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If

        Dim OrderDetailCount As Int32 = 0
        OrderDetailCount = daProduct.CheckReferenceOrderDetail(ProductId)
        If OrderDetailCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If

        Dim ShoppingCartCount As Int32 = 0
        ShoppingCartCount = daProduct.CheckReferenceShoppingCart(ProductId)
        If ShoppingCartCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If
    End Sub
End Class
