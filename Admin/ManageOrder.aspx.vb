
Partial Class Admin_ManageOrder
    Inherits System.Web.UI.Page
    Protected Sub gvOrder_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvOrder.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Exit Select
            Case DataControlRowType.DataRow
                Dim lnkToggle1 As LinkButton = CType(e.Row.Cells(5).Controls(0), LinkButton)
                If lnkToggle1 IsNot Nothing Then
                    If e.Row.DataItem("IsDelivered") Then
                        lnkToggle1.Text = "Delivered"
                    Else
                        lnkToggle1.Text = "Pending"
                    End If
                End If
                Dim lnkToggle2 As LinkButton = CType(e.Row.Cells(6).Controls(0), LinkButton)
                If lnkToggle2 IsNot Nothing Then
                    If e.Row.DataItem("IsComplete") Then
                        lnkToggle2.Text = "Complete"
                    Else
                        lnkToggle2.Text = "In-Complete"
                    End If
                End If
                Dim lnkDelete As LinkButton = CType(e.Row.Cells(9).Controls(0), LinkButton)
                If lnkDelete IsNot Nothing Then
                    lnkDelete.Attributes.Add("OnClick", "return CheckDelete();")
                End If
                Exit Select
            Case DataControlRowType.Footer
                Exit Select
        End Select
    End Sub

    Protected Sub gvOrder_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvOrder.RowCommand
        If e.CommandName = "IsDelivered" Then
            Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
            Dim dtOrder As New ds_Order.OrderDataTable
            dtOrder = daOrder.GetDataByPK(CLng(gvOrder.DataKeys(CInt(e.CommandArgument.ToString())).Value.ToString()))
            If dtOrder IsNot Nothing Then
                If dtOrder.Rows.Count > 0 Then
                    Dim drOrder As ds_Order.OrderRow
                    drOrder = dtOrder.Rows(0)
                    drOrder.BeginEdit()
                    drOrder.IsDelivered = Not drOrder.IsDelivered
                    drOrder.EndEdit()
                    daOrder.Update(dtOrder)
                    gvOrder.DataBind()
                End If
            End If
        End If
        If e.CommandName = "IsComplete" Then
            Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
            Dim dtOrder As New ds_Order.OrderDataTable
            dtOrder = daOrder.GetDataByPK(CLng(gvOrder.DataKeys(CInt(e.CommandArgument.ToString())).Value.ToString()))
            If dtOrder IsNot Nothing Then
                If dtOrder.Rows.Count > 0 Then
                    Dim drOrder As ds_Order.OrderRow
                    drOrder = dtOrder.Rows(0)
                    drOrder.BeginEdit()
                    drOrder.IsComplete = Not drOrder.IsComplete
                    drOrder.EndEdit()
                    daOrder.Update(dtOrder)
                    gvOrder.DataBind()
                End If
            End If
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        odsOrder.SelectParameters.Clear()
        'If String.IsNullOrEmpty(txtFromDate.Text) And String.IsNullOrEmpty(txtToDate.Text) And ddlCustomer.SelectedValue = "0" Then
        '    odsOrder.SelectMethod = "GetDetails"
        'ElseIf String.IsNullOrEmpty(txtFromDate.Text) And String.IsNullOrEmpty(txtToDate.Text) And ddlCustomer.SelectedValue <> "0" Then
        '    odsOrder.SelectMethod = "SearchByCustomer"
        '    odsOrder.SelectParameters.Add("CustomerId", ddlCustomer.SelectedValue)
        'ElseIf Not String.IsNullOrEmpty(txtFromDate.Text) And Not String.IsNullOrEmpty(txtToDate.Text) And ddlCustomer.SelectedValue = "0" Then
        '    odsOrder.SelectMethod = "SearchByOrderAndDeliveryDate"
        '    odsOrder.SelectParameters.Add("FromDate", txtFromDate.Text.Trim)
        '    odsOrder.SelectParameters.Add("ToDate", txtToDate.Text.Trim)
        'ElseIf Not String.IsNullOrEmpty(txtFromDate.Text) And Not String.IsNullOrEmpty(txtToDate.Text) And ddlCustomer.SelectedValue <> "0" Then
        '    odsOrder.SelectMethod = "SearchByCustomerAndOrderAndDeliveryDate"
        '    odsOrder.SelectParameters.Add("FromDate", txtFromDate.Text.Trim)
        '    odsOrder.SelectParameters.Add("ToDate", txtToDate.Text.Trim)
        '    odsOrder.SelectParameters.Add("CustomerId", ddlCustomer.SelectedValue)
        'End If
        odsOrder.SelectMethod = "SearchOrder"
        odsOrder.SelectParameters.Add("CustomerId", ddlCustomer.SelectedValue)
        odsOrder.SelectParameters.Add("FromDate", txtFromDate.Text.Trim)
        odsOrder.SelectParameters.Add("ToDate", txtToDate.Text.Trim)
        odsOrder.DataBind()
        gvOrder.DataBind()
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
            If gvOrder.Rows.Count <= 0 Then
                lblCount.Text = "No records found."
                btnExport.Visible = False
            End If
        End If
    End Sub

    Protected Sub gvOrder_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles gvOrder.RowDeleted
        Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
        daOrder.UpdateQuery(CLng(ViewState("OID")))
    End Sub
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
        Dim dtOrder As New ds_Order.OrderDataTable
        dtOrder = daOrder.GetDetails()

        If dtOrder IsNot Nothing Then
            If dtOrder.Rows.Count > 0 Then
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

                Dim bfOrderDate As New BoundField
                bfOrderDate.DataField = "OrderDate"
                bfOrderDate.HeaderText = "Order Date"

                Dim bfDeliveryDate As New BoundField
                bfDeliveryDate.DataField = "DeliverDate"
                bfDeliveryDate.HeaderText = "Delivery Date"

                Dim gvExport As New GridView
                gvExport.AllowPaging = False
                gvExport.AutoGenerateColumns = False
                gvExport.Columns.Add(bfFirstName)
                gvExport.Columns.Add(bfOrderDate)
                gvExport.Columns.Add(bfDeliveryDate)

                gvExport.Columns(0).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(0).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(1).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(1).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.Columns(2).HeaderStyle.BackColor = Drawing.Color.Blue
                gvExport.Columns(2).HeaderStyle.BorderStyle = BorderStyle.Solid

                gvExport.HeaderStyle.ForeColor = Drawing.Color.White
                gvExport.GridLines = GridLines.Both

                gvExport.DataSource = dtOrder.DefaultView
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
