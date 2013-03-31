
Partial Class Admin_ChangePassword
    Inherits System.Web.UI.Page
    Protected Sub btnChagePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        If Session("ADMINID") IsNot Nothing Then
            Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
            Dim dtAdmin As New ds_Admin.AdminDataTable
            dtAdmin = daAdmin.GetDataByChangePassword(CInt(Session("ADMINID")), txtOldPassword.Text.Trim)
            If dtAdmin IsNot Nothing Then
                If dtAdmin.Rows.Count > 0 Then
                    Dim drAdmin As ds_Admin.AdminRow
                    drAdmin = dtAdmin.Rows(0)
                    drAdmin.BeginEdit()
                    drAdmin.Password = txtNewPassword.Text.Trim
                    drAdmin.EndEdit()
                    daAdmin.Update(dtAdmin)
                    Response.Redirect("~/Admin/ThankYou.aspx?MID=2")
                End If
            End If
        End If
    End Sub
End Class
