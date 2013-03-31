
Partial Class Admin_ManageCountry
    Inherits System.Web.UI.Page
    Protected Sub gvCountry_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCountry.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(2).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsCountry.SelectParameters.Clear()
        'Using SP
        odsCountry.SelectMethod = "SearchCountry"
        odsCountry.SelectParameters.Add("CountryName", "%" & txtSearch.Text.Trim & "%")
        odsCountry.DataBind()
        gvCountry.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            If gvCountry.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
            End If
        End If
    End Sub

    Protected Sub gvCountry_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCountry.RowDeleting
        Dim CountryId As Int64 = CLng(gvCountry.DataKeys(e.RowIndex).Value)
        Dim daCountry As New ds_CountryTableAdapters.CountryTableAdapter
        Dim StateCount As Int32 = 0
        StateCount = daCountry.CheckReference(CountryId)
        If StateCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If
    End Sub
End Class
