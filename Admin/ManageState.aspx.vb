
Partial Class Admin_ManageState
    Inherits System.Web.UI.Page
    Protected Sub gvState_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvState.RowDataBound
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
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsState.SelectParameters.Clear()
        'If (ddlCountry.SelectedValue = "0") Then
        '    odsState.SelectMethod = "GetDetails"
        'ElseIf (ddlCountry.SelectedValue <> "0") Then
        '    odsState.SelectMethod = "SearchByCountry"
        '    odsState.SelectParameters.Add("CountryId", ddlCountry.SelectedValue)
        'End If
        odsState.SelectMethod = "SearchState"
        odsState.SelectParameters.Add("StateName", "%" & txtState.Text.Trim & "%")
        odsState.SelectParameters.Add("CountryId", ddlCountry.SelectedValue)
        odsState.DataBind()
        gvState.DataBind()
    End Sub
    Protected Sub FillCountry()
        Dim daCountry As New ds_CountryTableAdapters.CountryTableAdapter
        Dim dtCountry As New ds_Country.CountryDataTable
        dtCountry = daCountry.GetData()
        If dtCountry IsNot Nothing Then
            If dtCountry.Rows.Count > 0 Then
                ddlCountry.DataSource = dtCountry
                ddlCountry.DataTextField = dtCountry.Columns(1).ColumnName
                ddlCountry.DataValueField = dtCountry.Columns(0).ColumnName
                ddlCountry.DataBind()
                ddlCountry.Items.Insert(0, New ListItem(" -- Select a Country -- ", "0"))
            Else
                ddlCountry.Items.Insert(0, New ListItem(" -- No Country Available -- ", "0"))
            End If
        Else
            ddlCountry.Items.Insert(0, New ListItem(" -- No Country Available -- ", "0"))
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = String.Empty
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            FillCountry()
            If gvState.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
                btnExport.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim daState As New ds_StateTableAdapters.StateTableAdapter
        Dim dtState As New ds_State.StateDataTable
        dtState = daState.GetDetails()

        If dtState IsNot Nothing Then
            If dtState.Rows.Count > 0 Then
                Response.Clear()
                Response.AddHeader("content-disposition", "attachment;filename=" & Now.Ticks.ToString() & ".xls")
                Response.ContentType = "application/vnd.xls"

                Response.Charset = String.Empty
                Response.Cache.SetCacheability(HttpCacheability.NoCache)

                Dim stringWrite As New System.IO.StringWriter()
                Dim htmlWrite As New HtmlTextWriter(stringWrite)
                'New Column
                'Dim DC As New Data.DataColumn
                'DC.ColumnName = "FullName"
                'DC.Expression = "FirstName + ' ' + MiddleName + ' ' + LastName"
                'dtStudent.Columns.Add(DC)

                Dim bfStateName As New BoundField
                bfStateName.DataField = "StateName"
                bfStateName.HeaderText = "State Name"

                Dim bfCountryName As New BoundField
                bfCountryName.DataField = "CountryName"
                bfCountryName.HeaderText = "Country Name"

                Dim gvExport As New GridView
                gvExport.AllowPaging = False
                gvExport.AutoGenerateColumns = False
                gvExport.Columns.Add(bfStateName)
                gvExport.Columns.Add(bfCountryName)
                
                gvExport.Columns(0).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(0).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(1).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(1).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.HeaderStyle.ForeColor = Drawing.Color.White
                gvExport.GridLines = GridLines.Both

                gvExport.DataSource = dtState.DefaultView
                gvExport.DataBind()
                gvExport.Visible = True
                gvExport.RenderControl(htmlWrite)
                Response.Write(stringWrite.ToString())
                Response.End()
            Else
                lblMessage.Text = "No Record found."
            End If
        Else
            lblMessage.Text = "No Record found."
        End If

    End Sub

    Protected Sub gvState_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvState.RowDeleting
        Dim StateId As Int64 = CLng(gvState.DataKeys(e.RowIndex).Value)
        Dim daState As New ds_StateTableAdapters.StateTableAdapter
        Dim CityCount As Int32 = 0
        CityCount = daState.CheckReference(StateId)
        If CityCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If
    End Sub
End Class
