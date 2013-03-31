Partial Class Admin_City
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateCity() Then
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
            Dim daCity As New ds_CityTableAdapters.CityTableAdapter
            Dim dtCity As New ds_City.CityDataTable
            dtCity = daCity.IsExistsForUpdate(CInt(ViewState("ID")), txtCity.Text.Trim)
            If dtCity IsNot Nothing Then
                If dtCity.Rows.Count > 0 Then
                    lblMessage.Text = "State is already exists"
                    Exit Sub
                End If
            End If
            dtCity.Clear()
            dtCity = daCity.GetDataByPK(CInt(ViewState("ID")))
            If dtCity IsNot Nothing Then
                If dtCity.Rows.Count > 0 Then
                    Dim drCity As ds_City.CityRow
                    drCity = dtCity.Rows(0)
                    drCity.BeginEdit()
                    drCity.CityName = txtCity.Text.Trim
                    drCity.StateId = CLng(ddlState.SelectedValue)
                    drCity.EndEdit()
                    daCity.Update(dtCity)
                    Response.Redirect("~/Admin/ManageCity.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daCity As New ds_CityTableAdapters.CityTableAdapter
        Dim dtCity As New ds_City.CityDataTable
        dtCity = daCity.IsExistsForInsert(txtCity.Text.Trim)
        If dtCity IsNot Nothing Then
            If dtCity.Rows.Count > 0 Then
                lblMessage.Text = "City is already exists."
                Exit Sub
            End If
        End If
        daCity.Insert(txtCity.Text.Trim, ddlState.SelectedValue)
        Response.Redirect("~/Admin/ManageCity.aspx")
    End Sub
    Private Function ValidateCity() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtCity.Text.Trim) Then
            strerror += rfvCity.ErrorMessage & "</br>"
        Else
            Dim CityMatch As Match
            CityMatch = Regex.Match(txtCity.Text.Trim, "[A-Z,a-z, ]$")
            If Not CityMatch.Success Then
                strerror += revCity.ErrorMessage & "</br>"
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
        If Not IsPostBack Then
            FillCountry()
            ddlState.Items.Insert(0, New ListItem(" -- No State Available-- ", "0"))
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillCity()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub FillCity()
        If ViewState("ID") IsNot Nothing Then
            Dim daCity As New ds_CityTableAdapters.CityTableAdapter
            Dim dtCity As New ds_City.CityDataTable
            dtCity = daCity.GetDataByStateandCountry(ViewState("ID"))
            If dtCity IsNot Nothing Then
                If dtCity.Rows.Count > 0 Then
                    Dim drCity As ds_City.CityRow
                    drCity = dtCity.Rows(0)
                    txtCity.Text = drCity.CityName
                    ddlCountry.SelectedValue = drCity.Item("CountryId")
                    FillState()
                    ddlState.SelectedValue = drCity.Item("StateId")
                End If
            End If
        End If
    End Sub
    Protected Sub FillState()
        Dim daState As New ds_StateTableAdapters.StateTableAdapter
        Dim dtState As New ds_State.StateDataTable
        dtState = daState.GetDataByCountry(CLng(ddlCountry.SelectedValue))
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
    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("~/Admin/ManageCity.aspx")
    End Sub

    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountry.SelectedIndexChanged
        ddlState.Items.Clear()
        If (ddlCountry.SelectedIndex > 0) Then
            FillState()
        Else
            ddlState.Items.Insert(0, New ListItem("--No State Available--", "0"))
        End If
    End Sub
End Class

