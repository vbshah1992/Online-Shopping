Imports System.IO
Partial Class Admin_ManageImage
    Inherits System.Web.UI.Page
    Protected Sub gvImage_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvImage.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim lnkToggle1 As LinkButton = CType(e.Row.Cells(2).Controls(0), LinkButton)
                If lnkToggle1 IsNot Nothing Then
                    If e.Row.DataItem("IsCoverImage") Then
                        lnkToggle1.Text = "Yes"
                    Else
                        lnkToggle1.Text = "No"
                    End If
                End If
                Dim lnkToggle2 As LinkButton = CType(e.Row.Cells(3).Controls(0), LinkButton)
                If lnkToggle2 IsNot Nothing Then
                    If e.Row.DataItem("IsVisible") Then
                        lnkToggle2.Text = "Visible"
                    Else
                        lnkToggle2.Text = "In-Visible"
                    End If
                End If
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(5).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub

    Protected Sub gvImage_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvImage.RowCommand
        If e.CommandName = "IsCoverImage" Then
            Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter
            Dim dtImage As New ds_Image.ImageDataTable
            dtImage = daImage.GetDataByPK(CLng(gvImage.DataKeys(CInt(e.CommandArgument.ToString())).Value.ToString()))
            If dtImage IsNot Nothing Then
                If dtImage.Rows.Count > 0 Then
                    Dim drImage As ds_Image.ImageRow
                    drImage = dtImage.Rows(0)
                    drImage.BeginEdit()
                    drImage.IsCoverImage = Not drImage.IsCoverImage
                    drImage.EndEdit()
                    daImage.Update(dtImage)
                    gvImage.DataBind()
                End If
            End If
        End If
        If e.CommandName = "IsVisible" Then
            Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter
            Dim dtImage As New ds_Image.ImageDataTable
            dtImage = daImage.GetDataByPK(CLng(gvImage.DataKeys(CInt(e.CommandArgument.ToString())).Value.ToString()))
            If dtImage IsNot Nothing Then
                If dtImage.Rows.Count > 0 Then
                    Dim drImage As ds_Image.ImageRow
                    drImage = dtImage.Rows(0)
                    drImage.BeginEdit()
                    drImage.IsVisible = Not drImage.IsVisible
                    drImage.EndEdit()
                    daImage.Update(dtImage)
                    gvImage.DataBind()
                End If
            End If
        End If
        'This coding for downloading something. 
        'If e.CommandName = "Download" Then
        '    Dim sPath As String = String.Empty
        '    Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter
        '    Dim dtImage As New ds_Image.ImageDataTable
        '    dtImage = daImage.GetDataByPK(CInt(e.CommandArgument))
        '    If dtImage IsNot Nothing Then
        '        If dtImage.Rows.Count > 0 Then
        '            Dim drImage As ds_Image.ImageRow
        '            drImage = dtImage.Rows(0)
        '            Dim ext As String = Path.GetExtension(drImage.ImagePath)
        '            If drImage.ImagePath IsNot Nothing Then
        '                sPath = Server.MapPath("~" + "/Images/Product/" + drImage.ImagePath)
        '                Dim File As New System.IO.FileInfo(sPath)
        '                If (File.Exists) Then
        '                    Response.Clear()
        '                    Response.AddHeader("Content-Disposition", "attachment; filename=" + drImage.ImagePath + ext)
        '                    Response.AddHeader("Content-Length", File.Length.ToString())
        '                    Response.WriteFile(File.FullName)
        '                    Response.End()
        '                Else
        '                    Response.Write("This File Does Not Exist.")
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    Protected Sub lnkImage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkImage.Click
        Response.Redirect("~/Admin/Image.aspx?PID=" & ViewState("PID"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            FillProduct()
            If gvImage.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
            End If
        End If
        If Request.QueryString("ID") IsNot Nothing Then
            ViewState("ID") = Request.QueryString("ID")
        ElseIf Request.QueryString("PID") IsNot Nothing Then
            ViewState("PID") = Request.QueryString("PID")
        End If
    End Sub

    Protected Sub lbnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbnBack.Click
        Response.Redirect("~/Admin/ManageProduct.aspx")
    End Sub
    Protected Sub FillProduct()
        Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
        Dim dtProduct As New ds_Product.ProductDataTable
        dtProduct = daProduct.GetData()
        If dtProduct IsNot Nothing Then
            If dtProduct.Rows.Count > 0 Then
                ddlProduct.DataSource = dtProduct
                ddlProduct.DataTextField = dtProduct.Columns(1).ColumnName
                ddlProduct.DataValueField = dtProduct.Columns(0).ColumnName
                ddlProduct.DataBind()
                ddlProduct.Items.Insert(0, New ListItem(" -- Select a Product -- ", "0"))
            Else
                ddlProduct.Items.Insert(0, New ListItem(" -- No Product Available -- ", "0"))
            End If
        Else
            ddlProduct.Items.Insert(0, New ListItem(" -- No Product Available -- ", "0"))
        End If
    End Sub

    Protected Sub ddlProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProduct.SelectedIndexChanged
        If ddlProduct.SelectedValue <> "0" Then
            odsImage.SelectParameters.Clear()
            odsImage.SelectMethod = "SearchByProduct"
            odsImage.SelectParameters.Add("ProductId", ddlProduct.SelectedValue)
            odsImage.DataBind()
            gvImage.DataBind()
            If gvImage.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
            Else
                lblCount.Text = String.Empty
            End If
        End If
    End Sub
End Class
