
Partial Class Customer_LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Abandon()
        Response.Redirect("~/Customer/ThankYou.aspx?MID=7")
    End Sub
End Class
