Imports System.io
Partial Class Admin_Image
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateImage() Then
            If ViewState("ID") IsNot Nothing Then
                Update()
            Else
                Insert()
            End If
        Else
            lblMessage.Text += "Unsuccessful Validation"
        End If
    End Sub
    Private Sub Insert()
        Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter
        Dim dtImage As New ds_Image.ImageDataTable
        Dim nImageId As Integer
        Dim Exts As String
        dtImage = daImage.IsExistsForInsert(txtTitle.Text.Trim, CLng(ddlProduct.SelectedValue))
        If dtImage IsNot Nothing Then
            If dtImage.Rows.Count > 0 Then
                lblMessage.Text = "Image is already exists."
                Exit Sub
            End If
        End If
        nImageId = daImage.InsertQuery(txtTitle.Text.Trim, String.Empty, CLng(ddlProduct.SelectedValue), chkIsCoverImage.Checked, chkIsVisible.Checked)
        If Not String.IsNullOrEmpty(fupImage.FileName) Then
            Exts = Path.GetExtension(fupImage.FileName)
            dtImage = daImage.GetDataByPK(nImageId)
            If dtImage IsNot Nothing Then
                If dtImage.Rows.Count > 0 Then
                    Dim drImage As ds_Image.ImageRow
                    drImage = dtImage.Rows(0)
                    drImage.BeginEdit()
                    drImage.ImagePath = nImageId & Exts
                    drImage.EndEdit()
                    daImage.Update(dtImage)
                    fupImage.SaveAs(Server.MapPath("~") & "/Images/Product/" & nImageId & Exts)
                End If
            End If
        End If
        Response.Redirect("~/Admin/ManageImage.aspx?PID=" & ViewState("PID"))
    End Sub
    Private Sub Update()
        If ViewState("ID") IsNot Nothing Then
            Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter
            Dim dtImage As New ds_Image.ImageDataTable
            Dim Exts As String
            dtImage = daImage.IsExistsForUpdate(CInt(ViewState("ID")), txtTitle.Text.Trim, CLng(ddlProduct.SelectedValue))
            If dtImage IsNot Nothing Then
                If dtImage.Rows.Count > 0 Then
                    lblMessage.Text = "Image is already exists"
                    Exit Sub
                End If
            End If
            dtImage = daImage.GetDataByPK(CInt(ViewState("ID")))
            If dtImage IsNot Nothing Then
                If dtImage.Rows.Count > 0 Then
                    Dim drImage As ds_Image.ImageRow
                    drImage = dtImage.Rows(0)
                    drImage.BeginEdit()
                    drImage.Title = txtTitle.Text.Trim
                    If Not String.IsNullOrEmpty(fupImage.FileName) Then
                        Exts = Path.GetExtension(fupImage.FileName)
                        drImage.ImagePath = ViewState("ID") & Exts
                        fupImage.SaveAs(Server.MapPath("~") & "/Images/Product/" & ViewState("ID") & Exts)
                    End If
                    drImage.ProductId = CLng(ddlProduct.SelectedValue)
                    drImage.IsCoverImage = chkIsCoverImage.Checked
                    drImage.IsVisible = chkIsVisible.Checked
                    drImage.EndEdit()
                    daImage.Update(dtImage)
                    Response.Redirect("~/Admin/ManageImage.aspx?PID=" & ViewState("PID"))
                End If
            End If
        End If
    End Sub
    Private Function ValidateImage() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtTitle.Text.Trim) Then
            strerror += rfvTitle.ErrorMessage & "</br>"
        Else
            Dim TitleMatch As Match
            TitleMatch = Regex.Match(txtTitle.Text.Trim, "[A-Z,a-z, ]$")
            If Not TitleMatch.Success Then
                strerror += revTitle.ErrorMessage & "</br>"
            End If
        End If
        If ViewState("ID") IsNot Nothing Then
            rfvfupImage.Enabled = False
        Else
            rfvfupImage.Enabled = True
            If String.IsNullOrEmpty(fupImage.FileName) Then
                strerror += rfvfupImage.ErrorMessage & "</br>"
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
            FillProduct()
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillImage()
                btnSave.Text = "Update"
                tdfupImage.Visible = True
                tdImage.Visible = True
                tdDelete.Visible = True
                rfvfupImage.Enabled = True
            Else
                tdfupImage.Visible = True
                tdImage.Visible = False
                tdDelete.Visible = False
                rfvfupImage.Enabled = True
                btnSave.Text = "Save"
            End If
            If Request.QueryString("PID") IsNot Nothing Then
                ViewState("PID") = Request.QueryString("PID")
                ddlProduct.SelectedValue = ViewState("PID").ToString()
                ddlProduct.Enabled = False
            End If
        End If
    End Sub
    Protected Sub FillImage()
        If ViewState("ID") IsNot Nothing Then
            Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter
            Dim dtImage As New ds_Image.ImageDataTable
            dtImage = daImage.GetDataByPK(CInt(ViewState("ID")))
            If dtImage IsNot Nothing Then
                If dtImage.Rows.Count > 0 Then
                    Dim drImage As ds_Image.ImageRow
                    drImage = dtImage.Rows(0)
                    txtTitle.Text = drImage.Title
                    If Not String.IsNullOrEmpty(drImage.ImagePath) Then
                        tdfupImage.Visible = False
                        tdImage.Visible = True
                        tdDelete.Visible = True
                        imgProduct.ImageUrl = ("~") & "/Images/Product/" & drImage.ImagePath
                    End If
                    ddlProduct.SelectedValue = drImage.ProductId
                    chkIsCoverImage.Checked = drImage.IsCoverImage
                    chkIsVisible.Checked = drImage.IsVisible
                End If
            End If
        End If
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

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("~/Admin/ManageImage.aspx?PID=" & ViewState("PID"))
    End Sub
    Protected Sub lnkDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDelete.Click
        If ViewState("ID") IsNot Nothing Then
            Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter
            Dim dtImage As New ds_Image.ImageDataTable
            dtImage = daImage.GetDataByPK(CInt(ViewState("ID")))
            If dtImage IsNot Nothing Then
                If dtImage.Rows.Count > 0 Then
                    Dim drImage As ds_Image.ImageRow
                    ' assign First row to Row Instance
                    drImage = dtImage.Rows(0)
                    drImage.BeginEdit()
                    If File.Exists(Server.MapPath("~") & "\Images\Product\" & drImage.ImagePath) Then
                        File.Delete(Server.MapPath("~") & "\Images\Product\" & drImage.ImagePath)
                    End If
                    drImage.ImagePath = String.Empty
                    drImage.EndEdit()
                    daImage.Update(dtImage)
                    tdfupImage.Visible = True
                    tdImage.Visible = False
                    tdDelete.Visible = False
                    rfvfupImage.Enabled = True
                End If
            End If
        End If
    End Sub
End Class

