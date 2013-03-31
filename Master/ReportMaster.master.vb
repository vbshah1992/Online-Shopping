
Partial Class Master_ReportMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("ADMINID") Is Nothing Then
            Dim requestURI As String = Request.Url.AbsoluteUri.ToLower()
            If Not String.IsNullOrEmpty(requestURI) Then
                If requestURI.IndexOf("login.aspx") = -1 Then
                    Response.Redirect("~/Admin/Login.aspx")
                End If
            Else
                Response.Redirect("~/Admin/Login.aspx")
            End If
        End If
        If Session("ADMINID") Is Nothing Then
            CltMenu.Visible = False
        Else
            CltMenu.Visible = True
        End If
    End Sub
End Class

