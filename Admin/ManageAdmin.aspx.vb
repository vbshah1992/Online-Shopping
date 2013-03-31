
Partial Class Admin_ManageAdmin
    Inherits System.Web.UI.Page
    Protected Sub gvAdmin_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAdmin.RowDataBound
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
                If CInt(gvAdmin.DataKeys(CInt(e.Row.RowIndex)).Value) = CInt(Session("ADMINID")) Then
                    e.Row.Cells(7).Enabled = False
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

    Protected Sub gvAdmin_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAdmin.RowCommand
        If e.CommandName = "IsActive" Then
            Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
            Dim dtAdmin As New ds_Admin.AdminDataTable
            dtAdmin = daAdmin.GetDataByPK(CLng(gvAdmin.DataKeys(CInt(e.CommandArgument.ToString())).Value.ToString()))
            If dtAdmin IsNot Nothing Then
                If dtAdmin.Rows.Count > 0 Then
                    Dim drAdmin As ds_Admin.AdminRow
                    drAdmin = dtAdmin.Rows(0)
                    drAdmin.BeginEdit()
                    drAdmin.IsActive = Not drAdmin.IsActive
                    drAdmin.EndEdit()
                    daAdmin.Update(dtAdmin)
                    gvAdmin.DataBind()
                End If
            End If
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsAdmin.SelectParameters.Clear()
        'If String.IsNullOrEmpty(txtSearch.Text) And (ddlCity.SelectedValue = "0") Then
        '    odsAdmin.SelectMethod = "GetDetails"
        'ElseIf Not String.IsNullOrEmpty(txtSearch.Text) And (ddlCity.SelectedValue = "0") Then
        '    odsAdmin.SelectMethod = "SearchByName"
        '    odsAdmin.SelectParameters.Add("SearchKey", "%" & txtSearch.Text.Trim & "%")

        'ElseIf String.IsNullOrEmpty(txtSearch.Text) And (ddlCity.SelectedValue <> "0") Then
        '    odsAdmin.SelectMethod = "SearchByCity"
        '    odsAdmin.SelectParameters.Add("CityId", ddlCity.SelectedValue)
        'ElseIf Not String.IsNullOrEmpty(txtSearch.Text) And (ddlCity.SelectedValue <> "0") Then
        '    odsAdmin.SelectMethod = "SearchByNameANDCity"
        '    odsAdmin.SelectParameters.Add("SearchKey", "%" & txtSearch.Text.Trim & "%")
        '    odsAdmin.SelectParameters.Add("CityId", ddlCity.SelectedValue)
        'End If
        'Using SP
        odsAdmin.SelectMethod = "SearchAdmin"
        odsAdmin.SelectParameters.Add("Name", "%" & txtSearch.Text.Trim & "%")
        odsAdmin.SelectParameters.Add("CityId", ddlCity.SelectedValue)
        odsAdmin.DataBind()
        gvAdmin.DataBind()
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
            If gvAdmin.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
                btnExport.Visible = False
            End If
        End If
    End Sub

    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
        Dim dtAdmin As New ds_Admin.AdminDataTable
        dtAdmin = daAdmin.GetDetails()

        If dtAdmin IsNot Nothing Then
            If dtAdmin.Rows.Count > 0 Then
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

                Dim bfFirstName As New BoundField
                bfFirstName.DataField = "FirstName"
                bfFirstName.HeaderText = "First Name"


                Dim bfLastName As New BoundField
                bfLastName.DataField = "LastName"
                bfLastName.HeaderText = "Last Name"

                Dim bfDateOfBirth As New BoundField
                bfDateOfBirth.DataField = "DateOfBirth"
                bfDateOfBirth.HeaderText = "Date Of Birth"

                Dim bfAddress As New BoundField
                bfAddress.DataField = "Address"
                bfAddress.HeaderText = "Address"

                Dim bfCityName As New BoundField
                bfCityName.DataField = "CityName"
                bfCityName.HeaderText = "City"

                Dim bfPinCode As New BoundField
                bfPinCode.DataField = "PinCode"
                bfPinCode.HeaderText = "Pin Code"

                Dim bfPhoneNumber As New BoundField
                bfPhoneNumber.DataField = "PhoneNumber"
                bfPhoneNumber.HeaderText = "Phone Number"

                Dim bfContactNumber As New BoundField
                bfContactNumber.DataField = "ContactNumber"
                bfContactNumber.HeaderText = "Contact Number"

                Dim bfEmailId As New BoundField
                bfEmailId.DataField = "EmailId"
                bfEmailId.HeaderText = "Email Id"

                Dim gvExport As New GridView
                gvExport.AllowPaging = False
                gvExport.AutoGenerateColumns = False
                gvExport.Columns.Add(bfFirstName)
                gvExport.Columns.Add(bfLastName)
                gvExport.Columns.Add(bfDateOfBirth)
                gvExport.Columns.Add(bfAddress)
                gvExport.Columns.Add(bfCityName)
                gvExport.Columns.Add(bfPinCode)
                gvExport.Columns.Add(bfPhoneNumber)
                gvExport.Columns.Add(bfContactNumber)
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

                gvExport.Columns(6).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(6).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(7).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(7).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(8).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(8).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.HeaderStyle.ForeColor = Drawing.Color.White
                gvExport.GridLines = GridLines.Both


                gvExport.DataSource = dtAdmin.DefaultView
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
