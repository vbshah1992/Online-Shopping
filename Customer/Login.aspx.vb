
Partial Class Customer_Login
    Inherits System.Web.UI.Page
    Protected Sub btnLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogIn.Click
        Try
            Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
            Dim dtCustomer As New ds_Customer.CustomerDataTable
            dtCustomer = daCustomer.GetDataByLoginDetails(txtEmailId.Text.Trim, SMSCommon.TripleDESEncode(txtPassword.Text.Trim))
            If dtCustomer IsNot Nothing Then
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomer As ds_Customer.CustomerRow
                    drCustomer = dtCustomer.Rows(0)
                    Session("CUSTOMERID") = drCustomer.CustomerId
                    lblMessage.Text = "Login Successful."
                    Response.Redirect("~/Customer/ThankYou.aspx?MID=3")
                Else
                    lblMessage.Text = "Invalid emailid or password."
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub lnkForgotPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkForgotPassword.Click
        Response.Redirect("~/Customer/ForgotPassword.aspx")
    End Sub
End Class
