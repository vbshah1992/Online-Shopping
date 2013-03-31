
Partial Class Customer_PlaceOrder
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CUSTOMERID") Is Nothing Then
            Dim wm As Master_CustomerMaster = Master
            wm.ShowmpeLogin()
            'Response.Redirect("Login.aspx")
        Else
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("AMOUNT") = Request.QueryString("ID")
                lblAmount.Text = "Rs. " & ViewState("AMOUNT")
            End If
        End If
    End Sub

    Protected Sub btnCheckOut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheckOut.Click
        If Session("CUSTOMERID") IsNot Nothing Then
            Dim OrderId As Integer
            Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
            OrderId = daOrder.InsertQuery((Session("CUSTOMERID")), CDec(ViewState("AMOUNT")), CDate(System.DateTime.Now), CDate(System.DateTime.Now), txtBillingAddress.Text.Trim, txtBillingPhoneNumber.Text.Trim, txtShippingAddress.Text.Trim, txtShippingPhoneNumber.Text.Trim, String.Empty, False, False)
            Dim daShoppingCart As New ds_ShoppingCartTableAdapters.ShoppingCartTableAdapter
            Dim dtShoppingCart As New ds_ShoppingCart.ShoppingCartDataTable
            dtShoppingCart = daShoppingCart.GetDataByCustomer((Session("CUSTOMERID")))
            If dtShoppingCart IsNot Nothing Then
                If dtShoppingCart.Rows.Count > 0 Then
                    Dim daOrderDetail As New ds_OrderDetailTableAdapters.OrderDetailTableAdapter
                    Dim dtOrderDetail As New ds_OrderDetail.OrderDetailDataTable
                    Dim drShoppingCart As ds_ShoppingCart.ShoppingCartRow
                    drShoppingCart = dtShoppingCart.Rows(0)
                    Dim i As Integer
                    For i = 0 To i < dtOrderDetail.Rows.Count
                        drShoppingCart = dtShoppingCart.Rows(i)
                        daOrderDetail.Insert(CLng(OrderId), CLng(drShoppingCart.ProductId), drShoppingCart.Quantity, CDec(drShoppingCart.Price))
                        daShoppingCart.DeleteQuery((Session("CUSTOMERID")))
                        i += 1
                    Next
                    Response.Redirect("~/Customer/ThankYou.aspx?MID=5")
                    Response.Redirect("SubmitToGateway.aspx?DETAILS=Product Details&AMOUNT=" & ViewState("AMOUNT") + "&OID=" & OrderId)
                    Response.Redirect("~/Customer/ThankYou.aspx?MID=6")
                End If
            End If
        End If
    End Sub
    Protected Sub chkSameAddres_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSameAddres.CheckedChanged
        If chkSameAddres.Checked = True Then
            txtShippingPhoneNumber.Text = txtBillingPhoneNumber.Text
            txtShippingAddress.Text = txtBillingAddress.Text
        Else
            txtShippingPhoneNumber.Text = ""
            txtShippingAddress.Text = ""
        End If
    End Sub
End Class
