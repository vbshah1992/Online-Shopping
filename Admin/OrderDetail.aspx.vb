
Partial Class Admin_OrderDetail
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateOrderDetail() Then
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
            Dim daOrderDetail As New ds_OrderDetailTableAdapters.OrderDetailTableAdapter
            Dim dtOrderDetail As New ds_OrderDetail.OrderDetailDataTable
            dtOrderDetail.Clear()
            dtOrderDetail = daOrderDetail.GetDataByPK(CInt(ViewState("ID")))
            If dtOrderDetail IsNot Nothing Then
                If dtOrderDetail.Rows.Count > 0 Then
                    Dim drOrderDetail As ds_OrderDetail.OrderDetailRow
                    drOrderDetail = dtOrderDetail.Rows(0)
                    drOrderDetail.BeginEdit()
                    drOrderDetail.OrderId = ViewState("OID")
                    drOrderDetail.ProductId = CLng(ddlProduct.SelectedValue)
                    drOrderDetail.Quantity = txtQuantity.Text.Trim
                    drOrderDetail.Price = lblPrice.Text.Trim
                    drOrderDetail.EndEdit()
                    daOrderDetail.Update(dtOrderDetail)
                    Response.Redirect("~/Admin/ManageOrderDetail.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daOrderDetail As New ds_OrderDetailTableAdapters.OrderDetailTableAdapter
        Dim dtOrderDetail As New ds_OrderDetail.OrderDetailDataTable
        daOrderDetail.Insert(CLng(ViewState("OID")), CLng(ddlProduct.SelectedValue), CInt(txtQuantity.Text.Trim), CDec(lblPrice.Text.Trim))
        'Updatequery (order)
        Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
        daOrder.UpdateQuery(CLng(ViewState("OID")))
        Response.Redirect("~/Admin/ManageOrderDetail.aspx?OID=" & ViewState("OID"))
    End Sub
    Private Function ValidateOrderDetail() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtQuantity.Text.Trim) Then
            strerror += rfvQuantity.ErrorMessage & "</br>"
        Else
            Dim QuantityMatch As Match
            QuantityMatch = Regex.Match(txtQuantity.Text.Trim, "[0-9, ]$")
            If Not QuantityMatch.Success Then
                strerror += revQuantity.ErrorMessage & "</br>"
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
            FillOrder()
            FillProduct()
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillOrderDetail()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub FillOrderDetail()
        If ViewState("ID") IsNot Nothing Then
            Dim daOrderDetail As New ds_OrderDetailTableAdapters.OrderDetailTableAdapter
            Dim dtOrderDetail As New ds_OrderDetail.OrderDetailDataTable
            dtOrderDetail = daOrderDetail.GetDataByPK(CInt(ViewState("ID")))
            If dtOrderDetail IsNot Nothing Then
                If dtOrderDetail.Rows.Count > 0 Then
                    Dim drOrderDetail As ds_OrderDetail.OrderDetailRow
                    drOrderDetail = dtOrderDetail.Rows(0)
                    ViewState("OID") = drOrderDetail.OrderId
                    ddlProduct.SelectedValue = drOrderDetail.ProductId
                    txtQuantity.Text = drOrderDetail.Quantity
                    lblPrice.Text = drOrderDetail.Price
                End If
            End If
        End If
    End Sub
    Protected Sub FillOrder()
        If ViewState("OID") IsNot Nothing Then
            Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
            Dim dtOrder As New ds_Order.OrderDataTable
            dtOrder = daOrder.GetDataByPK(CInt(ViewState("OID")))
            If dtOrder IsNot Nothing Then
                If dtOrder.Rows.Count > 0 Then
                    Dim drOrder As ds_Order.OrderRow
                    drOrder = dtOrder.Rows(0)
                    ViewState("OID") = drOrder.OrderId
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
    Protected Sub FillPrice()
        ViewState("OID") = Request.QueryString("OID")
        If ViewState("OID") IsNot Nothing Then
            Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
            Dim dtProduct As New ds_Product.ProductDataTable
            dtProduct = daProduct.GetDataByPK(CInt(ddlProduct.SelectedValue))
            If dtProduct IsNot Nothing Then
                If dtProduct.Rows.Count > 0 Then
                    Dim drProduct As ds_Product.ProductRow
                    drProduct = dtProduct.Rows(0)
                    lblPrice.Text = drProduct.Price
                End If
            End If
        End If
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("~/Admin/ManageOrderDetail.aspx")
    End Sub

    Protected Sub ddlProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProduct.SelectedIndexChanged
        FillPrice()
    End Sub
End Class
