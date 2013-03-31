
Partial Class Customer_MyOrder
    Inherits System.Web.UI.Page
    Protected Sub gvOrder_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvOrder.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim chkIsDelivered As CheckBox
                chkIsDelivered = CType(e.Row.Cells(3).Controls(0), CheckBox)
                If chkIsDelivered IsNot Nothing Then
                    chkIsDelivered.Visible = False
                    If chkIsDelivered.Checked Then
                        e.Row.Cells(3).Text = "Delivered"
                    Else
                        e.Row.Cells(3).Text = "Pending"
                    End If
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CUSTOMERID") Is Nothing Then
            Dim wm As Master_CustomerMaster = Master
            wm.ShowmpeLogin()
            'Response.Redirect("Login.aspx")
        Else
            If gvOrder.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
            End If
        End If
    End Sub
End Class
