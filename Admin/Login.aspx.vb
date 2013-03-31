
Partial Class Admin_Login
    Inherits System.Web.UI.Page

    Protected Sub btnLogIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogIn.Click, txtPassword.TextChanged
        Try
            Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
            Dim dtAdmin As New ds_Admin.AdminDataTable
            dtAdmin = daAdmin.GetDataByLoginDetails(txtEmailId.Text.Trim, SMSCommon.TripleDESEncode(txtPassword.Text.Trim))
            If dtAdmin IsNot Nothing Then
                If dtAdmin.Rows.Count > 0 Then
                    Dim drAdmin As ds_Admin.AdminRow
                    drAdmin = dtAdmin.Rows(0)
                    Session("ADMINID") = drAdmin.AdminId
                    lblMessage.Text = "Login Successful."
                    Response.Redirect("~/Admin/ThankYou.aspx?MID=3")
                    Response.Redirect("ManageAdmin.aspx")
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
