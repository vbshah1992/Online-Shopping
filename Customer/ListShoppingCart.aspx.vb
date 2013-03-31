
Partial Class Customer_ListShoppingCart
    Inherits System.Web.UI.Page
    Dim TotalPrice As Decimal
    Dim GrandTotal As Decimal

    Protected Sub gvShoppingCart_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvShoppingCart.RowCommand
        If e.CommandName = "Delete" Then
            If gvShoppingCart.Rows.Count <= 1 Then
                btnPlaceOrder.Visible = False
                lblCount.Text = "No records found in your shopping cart."
            End If
        End If
    End Sub
    Protected Sub gvShoppingCart_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvShoppingCart.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                TotalPrice = 0
                GrandTotal = 0
                Exit Select
            Case DataControlRowType.DataRow
                Dim Prices As Decimal
                Dim quantity As Integer
                Prices = CDec(e.Row.Cells(2).Text)
                quantity = CDec(e.Row.Cells(3).Text)
                TotalPrice = Prices * quantity
                e.Row.Cells(5).Text = TotalPrice.ToString()
                GrandTotal += TotalPrice
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(6).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                e.Row.Cells(4).Text = "Total : "
                e.Row.Cells(5).Text = "Rs." + GrandTotal.ToString()
                ViewState("AMOUNT") = GrandTotal.ToString()
                e.Row.Cells(5).Font.Bold = True
                Exit Select
        End Select
    End Sub

    Protected Sub btnPlaceOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPlaceOrder.Click
        Response.Redirect("PlaceOrder.aspx?ID=" & CDec(ViewState("AMOUNT")))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CUSTOMERID") IsNot Nothing Then
            If gvShoppingCart.Rows.Count <= 0 Then
                btnPlaceOrder.Visible = False
                lblCount.Text = "No records found in your shopping cart."
            Else
                btnPlaceOrder.Visible = True
                lblCount.Text = ""
            End If
        Else
            Dim wm As Master_CustomerMaster = Master
            wm.ShowmpeLogin()
            'Response.Redirect("Login.aspx")
        End If
    End Sub
End Class
