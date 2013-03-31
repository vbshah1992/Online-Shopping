
Partial Class Customer_LogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Abandon()
        Response.Redirect("~/Admin/ThankYou.aspx?MID=5")
    End Sub
End Class
