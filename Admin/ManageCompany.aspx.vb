
Partial Class Admin_ManageCompany
    Inherits System.Web.UI.Page
    Protected Sub gvCompany_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCompany.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim lnkToggle As LinkButton = CType(e.Row.Cells(5).Controls(0), LinkButton)
                If lnkToggle IsNot Nothing Then
                    If e.Row.DataItem("IsActive") Then
                        lnkToggle.Text = "Active"
                    Else
                        lnkToggle.Text = "In-Active"
                    End If
                End If
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(7).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub

    Protected Sub gvCompany_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCompany.RowCommand
        If e.CommandName = "IsActive" Then
            Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
            Dim dtCompany As New ds_Company.CompanyDataTable
            dtCompany = daCompany.GetDataByPK(CLng(gvCompany.DataKeys(CInt(e.CommandArgument.ToString())).Value.ToString()))
            If dtCompany IsNot Nothing Then
                If dtCompany.Rows.Count > 0 Then
                    Dim drCompany As ds_Company.CompanyRow
                    drCompany = dtCompany.Rows(0)
                    drCompany.BeginEdit()
                    drCompany.IsActive = Not drCompany.IsActive
                    drCompany.EndEdit()
                    daCompany.Update(dtCompany)
                    gvCompany.DataBind()
                End If
            End If
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsCompany.SelectParameters.Clear()
        'If (ddlCity.SelectedValue = "0") Then
        '    odsCompany.SelectMethod = "GetDetails"
        'ElseIf (ddlCity.SelectedValue <> "0") Then
        '    odsCompany.SelectMethod = "SearchByCityInCompany"
        '    odsCompany.SelectParameters.Add("CityId", ddlCity.SelectedValue)
        'End If
        odsCompany.SelectMethod = "SearchCompany"
        odsCompany.SelectParameters.Add("CompanyName", "%" & txtCompany.Text.Trim & "%")
        odsCompany.SelectParameters.Add("CityId", ddlCity.SelectedValue)
        odsCompany.DataBind()
        gvCompany.DataBind()
    End Sub
    Protected Sub FillCity()
        Dim daCity As New ds_CityTableAdapters.CityTableAdapter
        Dim dtCity As New ds_City.CityDataTable
        dtCity = daCity.GetData()
        If dtCity IsNot Nothing Then
            If dtCity.Rows.Count > 0 Then
                ddlCity.DataSource = dtCity
                ddlCity.DataTextField = dtCity.Columns(1).ColumnName
                ddlCity.DataValueField = dtCity.Columns(0).ColumnName
                ddlCity.DataBind()
                ddlCity.Items.Insert(0, New ListItem(" -- Select a City -- ", "0"))
            Else
                ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
            End If
        Else
            ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = String.Empty
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            FillCity()
            If gvCompany.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
                btnExport.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
        Dim dtCompany As New ds_Company.CompanyDataTable
        dtCompany = daCompany.GetDetails()

        If dtCompany IsNot Nothing Then
            If dtCompany.Rows.Count > 0 Then
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

                Dim bfCompanyName As New BoundField
                bfCompanyName.DataField = "CompanyName"
                bfCompanyName.HeaderText = "Company Name"


                Dim bfAddress As New BoundField
                bfAddress.DataField = "Address"
                bfAddress.HeaderText = "Address"

                Dim bfPhoneNumber As New BoundField
                bfPhoneNumber.DataField = "PhoneNumber"
                bfPhoneNumber.HeaderText = "Phone Number"

                Dim bfCityName As New BoundField
                bfCityName.DataField = "CityName"
                bfCityName.HeaderText = "City"

                Dim bfWebsite As New BoundField
                bfWebsite.DataField = "Website"
                bfWebsite.HeaderText = "Website"

                Dim bfEmailId As New BoundField
                bfEmailId.DataField = "EmailId"
                bfEmailId.HeaderText = "EmailId"
                
                Dim gvExport As New GridView
                gvExport.AllowPaging = False
                gvExport.AutoGenerateColumns = False
                gvExport.Columns.Add(bfCompanyName)
                gvExport.Columns.Add(bfAddress)
                gvExport.Columns.Add(bfPhoneNumber)
                gvExport.Columns.Add(bfCityName)
                gvExport.Columns.Add(bfWebsite)
                gvExport.Columns.Add(bfEmailId)

                gvExport.Columns(0).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(0).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(1).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(1).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(2).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(2).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(3).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(3).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(4).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(4).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(5).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(5).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.HeaderStyle.ForeColor = Drawing.Color.White
                gvExport.GridLines = GridLines.Both

                gvExport.DataSource = dtCompany.DefaultView
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

End Class
