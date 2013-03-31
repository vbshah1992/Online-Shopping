
Partial Class Admin_ManageOrderDetail
    Inherits System.Web.UI.Page
    Dim TotalPrice As Decimal
    Dim GrandTotal As Decimal
    Protected Sub gvOrderDetail_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvOrderDetail.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                TotalPrice = 0
                GrandTotal = 0
                Exit Select
            Case DataControlRowType.DataRow
                Dim Prices As Decimal
                Dim quantity As Integer
                Prices = CDec(e.Row.Cells(1).Text)
                quantity = CDec(e.Row.Cells(2).Text)
                TotalPrice = Prices * quantity
                e.Row.Cells(3).Text = TotalPrice.ToString()
                GrandTotal += TotalPrice
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(4).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                e.Row.Cells(3).Text = "Total : " + "Rs. " + GrandTotal.ToString()
                ViewState("AMOUNT") = GrandTotal.ToString()
                e.Row.Cells(3).Font.Bold = True
                Exit Select
        End Select
    End Sub
    Protected Sub FillDetails()
        If ViewState("OID") IsNot Nothing Then
            Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
            Dim dtOrder As New ds_Order.OrderDataTable
            dtOrder = daOrder.GetDataByOrderId(CInt(ViewState("OID")))
            If dtOrder IsNot Nothing Then
                If dtOrder.Rows.Count > 0 Then
                    Dim drOrder As ds_Order.OrderRow
                    drOrder = dtOrder.Rows(0)
                    lblAmount.Text = "Rs. " & drOrder.Amount
                    lblBillingPhoneNumber.Text = drOrder.BillingPhoneNumber
                    lblShippingPhoneNumber.Text = drOrder.ShippingPhoneNumber
                    lblBillingAddress.Text = drOrder.BillingAddress
                    lblShippingAddress.Text = drOrder.ShippingAddress
                    lblIPNNumber.Text = drOrder.IPNNumber
                End If
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCount.Text = String.Empty
        If Request.QueryString("OID") IsNot Nothing Then
            ViewState("OID") = Request.QueryString("OID")
            FillDetails()
            If gvOrderDetail.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
            End If
        End If
    End Sub

    Protected Sub lnkOrderDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkOrderDetail.Click
        Response.Redirect("~/Admin/OrderDetail.aspx?OID=" & ViewState("OID"))
    End Sub

    Protected Sub lnkManageOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkManageOrder.Click
        Response.Redirect("~/Admin/ManageOrder.aspx")
    End Sub
End Class
