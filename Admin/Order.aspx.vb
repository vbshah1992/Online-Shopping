
Partial Class Admin_Order
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateOrder() Then
            If ViewState("ID") IsNot Nothing Then
                Update()
            Else
                Insert()
            End If
        Else
            lblMessage.Text += "Unsuccessful Validation"
        End If
    End Sub
    Private Sub Update()
        If ViewState("ID") IsNot Nothing Then
            Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
            Dim dtOrder As New ds_Order.OrderDataTable
            dtOrder.Clear()
            dtOrder = daOrder.GetDataByPK(CInt(ViewState("ID")))
            If dtOrder IsNot Nothing Then
                If dtOrder.Rows.Count > 0 Then
                    Dim drOrder As ds_Order.OrderRow
                    drOrder = dtOrder.Rows(0)
                    drOrder.BeginEdit()
                    drOrder.CustomerId = CLng(ddlCustomer.SelectedValue)
                    drOrder.OrderDate = txtOrderDate.Text.Trim
                    drOrder.DeliverDate = txtDeliveryDate.Text.Trim
                    drOrder.BillingAddress = txtBillingAddress.Text.Trim
                    drOrder.BillingPhoneNumber = txtBillingPhoneNumber.Text.Trim
                    drOrder.ShippingAddress = txtShippingAddress.Text.Trim
                    drOrder.ShippingPhoneNumber = txtShippingPhoneNumber.Text.Trim
                    drOrder.IPNNumber = txtIPNNumber.Text.Trim
                    drOrder.IsDelivered = chkIsDelivered.Checked
                    drOrder.IsComplete = chkIsComplete.Checked
                    drOrder.EndEdit()
                    daOrder.Update(dtOrder)
                    Response.Redirect("~/Admin/ManageOrder.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
        Dim dtOrder As New ds_Order.OrderDataTable
        daOrder.Insert(CLng(ddlCustomer.SelectedValue), 0, CDate(txtOrderDate.Text.Trim), CDate(txtDeliveryDate.Text.Trim), txtBillingAddress.Text.Trim, txtBillingPhoneNumber.Text.Trim, txtShippingAddress.Text.Trim, txtShippingPhoneNumber.Text.Trim, txtIPNNumber.Text.Trim, chkIsDelivered.Checked, chkIsComplete.Checked)
        Response.Redirect("~/Admin/ManageOrder.aspx")
    End Sub
    Private Function ValidateOrder() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtOrderDate.Text.Trim) Then
            strerror += rfvOrderDate.ErrorMessage & "</br>"
        Else
            If IsDate(txtOrderDate.Text.Trim) Then
                If CDate(txtOrderDate.Text.Trim) > Now.Date Then
                    strerror += "Future date not allowed in order date." & "<br/>"
                End If
            End If
        End If
        If String.IsNullOrEmpty(txtDeliveryDate.Text.Trim) Then
            strerror += rfvDeliveryDate.ErrorMessage & "</br>"
        End If
        If String.IsNullOrEmpty(txtBillingAddress.Text.Trim) Then
            strerror += rfvBillingAddress.ErrorMessage & "</br>"
        End If
        If String.IsNullOrEmpty(txtBillingPhoneNumber.Text.Trim) Then
            strerror += rfvBillingPhoneNumber.ErrorMessage & "</br>"
        Else
            Dim BillingPhoneNumberMatch As Match
            BillingPhoneNumberMatch = Regex.Match(txtBillingPhoneNumber.Text.Trim, revBillingPhoneNumber.ValidationExpression)
            If Not BillingPhoneNumberMatch.Success Then
                strerror += revBillingPhoneNumber.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtShippingAddress.Text.Trim) Then
            strerror += rfvShippingAddress.ErrorMessage & "</br>"
        End If
        If String.IsNullOrEmpty(txtShippingPhoneNumber.Text.Trim) Then
            strerror += rfvBillingPhoneNumber.ErrorMessage & "</br>"
        Else
            Dim ShippingPhoneNumberMatch As Match
            ShippingPhoneNumberMatch = Regex.Match(txtShippingPhoneNumber.Text.Trim, revShippingPhoneNumber.ValidationExpression)
            If Not ShippingPhoneNumberMatch.Success Then
                strerror += revShippingPhoneNumber.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtIPNNumber.Text.Trim) Then
            strerror += rfvIPNNumber.ErrorMessage & "</br>"
        End If
        If strerror = String.Empty Then
            Return True
        Else
            lblMessage.Text = strerror
            Return False
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillCustomer()
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillOrder()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub FillOrder()
        If ViewState("ID") IsNot Nothing Then
            Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
            Dim dtOrder As New ds_Order.OrderDataTable
            dtOrder = daOrder.GetDataByPK(CInt(ViewState("ID")))
            If dtOrder IsNot Nothing Then
                If dtOrder.Rows.Count > 0 Then
                    Dim drOrder As ds_Order.OrderRow
                    drOrder = dtOrder.Rows(0)
                    ddlCustomer.SelectedValue = drOrder.CustomerId
                    txtOrderDate.Text = drOrder.OrderDate
                    txtDeliveryDate.Text = drOrder.DeliverDate
                    txtBillingAddress.Text = drOrder.BillingAddress
                    txtBillingPhoneNumber.Text = drOrder.BillingPhoneNumber
                    txtShippingAddress.Text = drOrder.ShippingAddress
                    txtShippingPhoneNumber.Text = drOrder.ShippingPhoneNumber
                    txtIPNNumber.Text = drOrder.IPNNumber
                    chkIsDelivered.Checked = drOrder.IsDelivered
                    chkIsComplete.Checked = drOrder.IsComplete
                End If
            End If
        End If
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

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("~/Admin/ManageOrder.aspx")
    End Sub
End Class
