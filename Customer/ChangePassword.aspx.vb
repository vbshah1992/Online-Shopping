
Partial Class Customer_ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub btnChagePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChagePassword.Click
        If Session("CUSTOMERID") IsNot Nothing Then
            Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
            Dim dtCustomer As New ds_Customer.CustomerDataTable
            dtCustomer = daCustomer.GetDataByChangePassword(CInt(Session("CUSTOMERID")), txtOldPassword.Text.Trim)
            If dtCustomer IsNot Nothing Then
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomer As ds_Customer.CustomerRow
                    drCustomer = dtCustomer.Rows(0)
                    drCustomer.BeginEdit()
                    drCustomer.Password = txtNewPassword.Text.Trim
                    drCustomer.EndEdit()
                    daCustomer.Update(dtCustomer)
                    Response.Redirect("~/Customer/ThankYou.aspx?MID=2")
                Else
                    lblMessage.Text = "Old password does not match with our database."
                End If
            End If
        End If
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("~/Customer/ProductList.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CUSTOMERID") Is Nothing Then
            Dim wm As Master_CustomerMaster = Master
            wm.ShowmpeLogin()
            'Response.Redirect("Login.aspx")
        End If
    End Sub
End Class
