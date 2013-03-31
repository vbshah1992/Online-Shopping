
Partial Class Admin_ManageFeedback
    Inherits System.Web.UI.Page
    Protected Sub gvFeedback_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvFeedback.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(4).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsFeedback.SelectParameters.Clear()
        'If String.IsNullOrEmpty(txtFromDate.Text) And String.IsNullOrEmpty(txtToDate.Text) Then
        '    odsFeedback.SelectMethod = "GetDetails"
        'ElseIf Not String.IsNullOrEmpty(txtFromDate.Text) And Not String.IsNullOrEmpty(txtToDate.Text) Then
        '    odsFeedback.SelectMethod = "SearchByFeedbackDate"
        '    odsFeedback.SelectParameters.Add("FromDate", txtFromDate.Text.Trim)
        '    odsFeedback.SelectParameters.Add("ToDate", txtToDate.Text.Trim)
        'End If
        odsFeedback.SelectMethod = "SearchFeedback"
        odsFeedback.SelectParameters.Add("FromDate", txtFromDate.Text.Trim)
        odsFeedback.SelectParameters.Add("ToDate", txtToDate.Text.Trim)
        odsFeedback.SelectParameters.Add("CustomerId", ddlCustomer.SelectedValue)
        odsFeedback.DataBind()
        gvFeedback.DataBind()
    End Sub
    Protected Sub FillCustomer()
        Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
        Dim dtCustomer As New ds_Customer.CustomerDataTable
        dtCustomer = daCustomer.GetData()
        If dtCustomer IsNot Nothing Then
            If dtCustomer.Rows.Count > 0 Then
                ddlCustomer.DataSource = dtCustomer
                ddlCustomer.DataTextField = dtCustomer.Columns(1).ColumnName
                ddlCustomer.DataValueField = dtCustomer.Columns(0).ColumnName
                ddlCustomer.DataBind()
                ddlCustomer.Items.Insert(0, New ListItem(" -- Select a Customer -- ", "0"))
            Else
                ddlCustomer.Items.Insert(0, New ListItem(" -- No Customer Available -- ", "0"))
            End If
        Else
            ddlCustomer.Items.Insert(0, New ListItem(" -- No Customer Available -- ", "0"))
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Text = String.Empty
        lblCount.Text = String.Empty
        If Not IsPostBack Then
            FillCustomer()
            If gvFeedback.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
                btnExport.Visible = False
            End If
        End If
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim daFeedback As New ds_FeedbackTableAdapters.FeedbackTableAdapter
        Dim dtFeedback As New ds_Feedback.FeedbackDataTable
        dtFeedback = daFeedback.GetDetails()

        If dtFeedback IsNot Nothing Then
            If dtFeedback.Rows.Count > 0 Then
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

                Dim bfFeedback As New BoundField
                bfFeedback.DataField = "Feedback"
                bfFeedback.HeaderText = "Feedback"

                Dim bfFeedbackDate As New BoundField
                bfFeedbackDate.DataField = "FeedbackDate"
                bfFeedbackDate.HeaderText = "Feedback Date"

                Dim bfFirstName As New BoundField
                bfFirstName.DataField = "FirstName"
                bfFirstName.HeaderText = "First Name"

                Dim gvExport As New GridView
                gvExport.AllowPaging = False
                gvExport.AutoGenerateColumns = False
                gvExport.Columns.Add(bfFeedback)
                gvExport.Columns.Add(bfFeedbackDate)
                gvExport.Columns.Add(bfFirstName)

                gvExport.Columns(0).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(0).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(1).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(1).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(2).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(2).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.HeaderStyle.ForeColor = Drawing.Color.White
                gvExport.GridLines = GridLines.Both

                gvExport.DataSource = dtFeedback.DefaultView
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
