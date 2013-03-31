
Partial Class Customer_ThankYou
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("MID") = 1 Then
            lblMessage.Text = "Your profile successfully register." + "<br>" + "Use your E-mail ID and Password to login."
        End If
        If Request.QueryString("MID") = 2 Then
            lblMessage.Text = "Your password changed successfully."
        End If
        If Request.QueryString("MID") = 3 Then
            lblMessage.Text = "Login successfully."
        End If
        If Request.QueryString("MID") = 4 Then
            lblMessage.Text = "Your profile successfully updated."
        End If
        If Request.QueryString("MID") = 5 Then
            lblMessage.Text = "Your order place successfully." + "<br>" + "Our customer care executive contact you very soon for confirmation your order."
        End If
        If Request.QueryString("MID") = 6 Then
            lblMessage.Text = "Your process has successfully."
        End If
        If Request.QueryString("MID") = 7 Then
            lblMessage.Text = "Logout successfully."
        End If
    End Sub
End Class
