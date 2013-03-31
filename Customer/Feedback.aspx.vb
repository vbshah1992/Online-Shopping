
Partial Class Customer_Feedback
    Inherits System.Web.UI.Page
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateFeedback() Then
            If ViewState("ID") IsNot Nothing Then
                Update()
            Else
                Insert()
            End If
        Else
            lblMessage.Text += "Unsuccessful Validation"
        End If
    End Sub
    Private Sub Insert()
        Dim daFeedback As New ds_FeedbackTableAdapters.FeedbackTableAdapter
        Dim dtFeedback As New ds_Feedback.FeedbackDataTable
        daFeedback.Insert(txtFeedback.Text.Trim, CDate(txtFeedbackDate.Text.Trim), CLng(ddlCustomer.SelectedValue))
        Response.Redirect("~/Admin/ManageFeedback.aspx")
    End Sub
    Private Sub Update()
        If ViewState("ID") IsNot Nothing Then
            Dim daFeedback As New ds_FeedbackTableAdapters.FeedbackTableAdapter
            Dim dtFeedback As New ds_Feedback.FeedbackDataTable
            dtFeedback = daFeedback.GetDataByPK(CInt(ViewState("ID")))
            If dtFeedback IsNot Nothing Then
                If dtFeedback.Rows.Count > 0 Then
                    Dim drFeedback As ds_Feedback.FeedbackRow
                    drFeedback = dtFeedback.Rows(0)
                    drFeedback.BeginEdit()
                    drFeedback.Feedback = txtFeedback.Text.Trim
                    drFeedback.FeedbackDate = txtFeedbackDate.Text.Trim
                    drFeedback.CustomerId = CLng(ddlCustomer.SelectedValue)
                    drFeedback.EndEdit()
                    daFeedback.Update(dtFeedback)
                    Response.Redirect("~/Admin/ManageFeedback.aspx")
                End If
            End If
        End If
    End Sub
    Private Function ValidateFeedback() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtFeedback.Text.Trim) Then
            strerror += rfvFeedback.ErrorMessage & "</br>"
        End If
        If String.IsNullOrEmpty(txtFeedbackDate.Text.Trim) Then
            strerror += rfvFeedbackDate.ErrorMessage & "</br>"
        Else
            If IsDate(txtFeedbackDate.Text.Trim) Then
                If CDate(txtFeedbackDate.Text.Trim) > Now.Date Then
                    strerror += "Future date not allowed in Feedback Date." & "<br/>"
                End If
            End If
        End If
        If strerror = String.Empty Then
            Return True
        Else
            lblMessage.Text = strerror
            Return False
        End If
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("CUSTOMERID") Is Nothing Then
            Dim wm As Master_CustomerMaster = Master
            wm.ShowmpeLogin()
            'Response.Redirect("Login.aspx")
        Else
            If Not IsPostBack Then
                FillCustomer()
                If Request.QueryString("ID") IsNot Nothing Then
                    ViewState("ID") = Request.QueryString("ID")
                    FillFeedback()
                    btnSave.Text = "Update"
                Else
                    btnSave.Text = "Save"
                End If
            End If
        End If
    End Sub
    Protected Sub FillFeedback()
        If ViewState("ID") IsNot Nothing Then
            Dim daFeedback As New ds_FeedbackTableAdapters.FeedbackTableAdapter
            Dim dtFeedback As New ds_Feedback.FeedbackDataTable
            dtFeedback = daFeedback.GetDataByPK(CInt(ViewState("ID")))
            If dtFeedback IsNot Nothing Then
                If dtFeedback.Rows.Count > 0 Then
                    Dim drFeedback As ds_Feedback.FeedbackRow
                    drFeedback = dtFeedback.Rows(0)
                    txtFeedback.Text = drFeedback.Feedback
                    txtFeedbackDate.Text = drFeedback.FeedbackDate
                    ddlCustomer.SelectedValue = drFeedback.CustomerId
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
        Response.Redirect("~/Customer/MyFeedback.aspx")
    End Sub
End Class
