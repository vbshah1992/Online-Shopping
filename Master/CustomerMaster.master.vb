
Partial Class Master_CustomerMaster
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CUSTOMERID") IsNot Nothing Then
            liLogIn.Visible = False
            liLogOut.Visible = True
            liChangePassword.Visible = True
            liMyProfile.Visible = True
            tdRegistration.Visible = False
            tdShoppingCart.Visible = True
            limyOrder.Visible = True
            liMyFeedback.Visible = True
        Else
            liLogIn.Visible = True
            liLogOut.Visible = False
            liChangePassword.Visible = False
            liMyProfile.Visible = False
            tdRegistration.Visible = True
            tdShoppingCart.Visible = False
            limyOrder.Visible = False
            liMyFeedback.Visible = False
        End If
    End Sub

    Protected Sub lnkLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogIn.Click
        ShowmpeLogin()
    End Sub

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
                    ShowmpeLogin()
                    lblMessage.Text = "Invalid emailid or password."
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub lnkForgotPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkForgotPassword.Click
        Response.Redirect("~/Customer/ForgotPassword.aspx")
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        Response.Redirect("~/Customer/ProductList.aspx")
    End Sub

    Public Sub ShowmpeLogin()
        mpeLogin.Show()
    End Sub
End Class

