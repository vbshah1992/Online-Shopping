
Partial Class Customer_MyFeedback
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CUSTOMERID") Is Nothing Then
            Dim wm As Master_CustomerMaster = Master
            wm.ShowmpeLogin()
            'Response.Redirect("Login.aspx")
        End If
        If gvMyFeedback.Rows.Count <= 0 Then
            lblCount.Text = "No records found."
        End If
    End Sub

    Protected Sub lnkAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAdd.Click
        Response.Redirect("~/Customer/Feedback.aspx")
    End Sub
End Class
