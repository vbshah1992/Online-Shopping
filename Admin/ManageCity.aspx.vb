
Partial Class Admin_ManageCity
    Inherits System.Web.UI.Page
    Protected Sub gvCity_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCity.RowDataBound
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
        odsCity.SelectParameters.Clear()
        'If (ddlState.SelectedValue = "0") Then
        '    odsCity.SelectMethod = "GetDetails"
        'ElseIf (ddlState.SelectedValue <> "0") Then
        '    odsCity.SelectMethod = "SearchByState"
        '    odsCity.SelectParameters.Add("StateId", ddlState.SelectedValue)
        'End If
        odsCity.SelectMethod = "SearchCity"
        odsCity.SelectParameters.Add("CityName", "%" & txtCity.Text.Trim & "%")
        odsCity.SelectParameters.Add("StateId", ddlState.SelectedValue)
        odsCity.DataBind()
        gvCity.DataBind()
    End Sub
    Protected Sub FillState()
        Dim daState As New ds_StateTableAdapters.StateTableAdapter
        Dim dtState As New ds_State.StateDataTable
        dtState = daState.GetData()
        If dtState IsNot Nothing Then
            If dtState.Rows.Count > 0 Then
                ddlState.DataSource = dtState
                ddlState.DataTextField = dtState.Columns(1).ColumnName
                ddlState.DataValueField = dtState.Columns(0).ColumnName
                ddlState.DataBind()
                ddlState.Items.Insert(0, New ListItem(" -- Select a State -- ", "0"))
            Else
                ddlState.Items.Insert(0, New ListItem(" -- No State Available -- ", "0"))
            End If
        Else
            ddlState.Items.Insert(0, New ListItem(" -- No State Available -- ", "0"))
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = String.Empty
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            FillState()
            If gvCity.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
                btnExport.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim daCity As New ds_CityTableAdapters.CityTableAdapter
        Dim dtCity As New ds_City.CityDataTable
        dtCity = daCity.GetDetails()

        If dtCity IsNot Nothing Then
            If dtCity.Rows.Count > 0 Then
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

                Dim bfCityName As New BoundField
                bfCityName.DataField = "CityName"
                bfCityName.HeaderText = "City"


                Dim bfStateName As New BoundField
                bfStateName.DataField = "StateName"
                bfStateName.HeaderText = "State"
                
                Dim gvExport As New GridView
                gvExport.AllowPaging = False
                gvExport.AutoGenerateColumns = False
                gvExport.Columns.Add(bfCityName)
                gvExport.Columns.Add(bfStateName)

                gvExport.Columns(0).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(0).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(1).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(1).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.HeaderStyle.ForeColor = Drawing.Color.White
                gvExport.GridLines = GridLines.Both


                gvExport.DataSource = dtCity.DefaultView
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

    Protected Sub gvCity_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvCity.RowDeleting
        Dim CityId As Int64 = CLng(gvCity.DataKeys(e.RowIndex).Value)
        Dim daCity As New ds_CityTableAdapters.CityTableAdapter
        Dim AdminCount As Int32 = 0
        AdminCount = daCity.CheckReferenceAdmin(CityId)
        If AdminCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If

        Dim CustomerCount As Int32 = 0
        CustomerCount = daCity.CheckReferenceCustomer(CityId)
        If CustomerCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If
        
        Dim CompanyCount As Int32 = 0
        CompanyCount = daCity.CheckReferenceCompany(CityId)
        If CompanyCount > 0 Then
            e.Cancel = True
            lblMessage.Text = "You can't delete record because it refers in another table."
            Exit Sub
        End If
    End Sub
End Class
