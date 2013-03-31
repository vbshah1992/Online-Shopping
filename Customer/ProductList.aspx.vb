
Partial Class Customer_ProductList
    Inherits System.Web.UI.Page

    Protected Sub dlProduct_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlProduct.ItemDataBound
        Dim img As Image
        img = e.Item.FindControl("img")
        Dim daImage As New ds_ImageTableAdapters.ImageTableAdapter()
        Dim dtImage As New ds_Image.ImageDataTable
        dtImage = daImage.GetDataByProductDetails(CLng((e.Item.DataItem).Row.ItemArray(0)))
        If dtImage IsNot Nothing Then
            If dtImage.Rows.Count > 0 Then
                Dim drImage As ds_Image.ImageRow
                drImage = dtImage.Rows(0)
                img.ImageUrl = ("~") & "\Images\Product\" & drImage.ImagePath
            End If
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsProduct.DataBind()
        dlProduct.DataBind()
        Lable()
    End Sub
    Public Sub Lable()
        If dlProduct.Items.Count <= 0 Then
            lblMessage.Text = "No records found"
        Else
            lblMessage.Text = String.Empty
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = String.Empty
        Lable()
    End Sub
End Class
