
Partial Class Admin_State
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If validatestate() Then
            If ViewState("ID") IsNot Nothing Then
                Update()
            Else
                insert()
            End If
        Else
            lblMessage.Text += "Unsuccessful Validation"
        End If
    End Sub
    Private Sub Update()
        If ViewState("ID") IsNot Nothing Then
            Dim daState As New ds_StateTableAdapters.StateTableAdapter
            Dim dtState As New ds_State.StateDataTable
            dtState = daState.IsExistsForUpdate(CInt(ViewState("ID")), txtState.Text.Trim)
            If dtState IsNot Nothing Then
                If dtState.Rows.Count > 0 Then
                    lblMessage.Text = "State is already exists"
                    Exit Sub
                End If
            End If
            dtState.Clear()
            dtState = daState.GetDataByPK(CInt(ViewState("ID")))
            If dtState IsNot Nothing Then
                If dtState.Rows.Count > 0 Then
                    Dim drState As ds_State.StateRow
                    drState = dtState.Rows(0)
                    drState.BeginEdit()
                    drState.StateName = txtState.Text.Trim
                    drState.CountryId = CLng(ddlCountry.SelectedValue)
                    drState.EndEdit()
                    daState.Update(dtState)
                    Response.Redirect("~/Admin/ManageState.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub insert()
        Dim daState As New ds_StateTableAdapters.StateTableAdapter
        Dim dtState As New ds_State.StateDataTable
        dtState = daState.IsExistsForInsert(txtState.Text.Trim)
        If dtState IsNot Nothing Then
            If dtState.Rows.Count > 0 Then
                lblMessage.Text = "State is already exists."
                Exit Sub
            End If
        End If
        daState.Insert(txtState.Text.Trim, ddlCountry.SelectedValue)
        Response.Redirect("~/Admin/ManageState.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillCountry()
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                fillState()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub fillState()
        If ViewState("ID") IsNot Nothing Then
            Dim daState As New ds_StateTableAdapters.StateTableAdapter
            Dim dtState As New ds_State.StateDataTable
            dtState = daState.GetDataByPK(CInt(ViewState("ID")))
            If dtState IsNot Nothing Then
                If dtState.Rows.Count > 0 Then
                    Dim drState As ds_State.StateRow
                    drState = dtState.Rows(0)
                    txtState.Text = drState.StateName
                    ddlCountry.SelectedValue = drState.CountryId
                End If
            End If
        End If
    End Sub
    Protected Sub fillCountry()
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
    Private Function validatestate() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtState.Text.Trim) Then
            strerror += rfvCountry.ErrorMessage & "</br>"
        Else
            Dim StateMatch As Match
            StateMatch = Regex.Match(txtState.Text.Trim, "[A-Z,a-z, ]$")
            If Not StateMatch.Success Then
                strerror += revState.ErrorMessage & "</br>"
            End If
        End If
        If strerror = String.Empty Then
            Return True
        Else
            lblMessage.Text += strerror
            Return False
        End If
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Admin/ManageState.aspx")
    End Sub
End Class
