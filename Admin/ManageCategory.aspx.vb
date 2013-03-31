
Partial Class Admin_ManageCategory
    Inherits System.Web.UI.Page
    Protected Sub gvCategory_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCategory.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(3).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            If gvCategory.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
            End If
        End If
    End Sub
End Class
