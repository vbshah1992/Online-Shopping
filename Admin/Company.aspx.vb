
Partial Class Admin_Company
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateCompany() Then
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
            Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
            Dim dtCompany As New ds_Company.CompanyDataTable
            dtCompany = daCompany.IsExistsForUpdate(CInt(ViewState("ID")), txtCompanyName.Text.Trim)
            If dtCompany IsNot Nothing Then
                If dtCompany.Rows.Count > 0 Then
                    lblMessage.Text = "Company is already exists"
                    Exit Sub
                End If
            End If
            dtCompany.Clear()
            dtCompany = daCompany.GetDataByPK(CInt(ViewState("ID")))
            If dtCompany IsNot Nothing Then
                If dtCompany.Rows.Count > 0 Then
                    Dim drCompany As ds_Company.CompanyRow
                    drCompany = dtCompany.Rows(0)
                    drCompany.BeginEdit()
                    drCompany.CompanyName = txtCompanyName.Text.Trim
                    drCompany.Address = txtAddress.Text.Trim
                    drCompany.PhoneNumber = txtPhoneNumber.Text.Trim
                    drCompany.CityId = CLng(ddlCity.SelectedValue)
                    drCompany.Website = txtWebsite.Text.Trim
                    drCompany.EmailId = txtEmailId.Text.Trim
                    drCompany.IsActive = chkIsActive.Checked
                    drCompany.EndEdit()
                    daCompany.Update(dtCompany)
                    Response.Redirect("~/Admin/ManageCompany.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
        Dim dtCompany As New ds_Company.CompanyDataTable
        dtCompany = daCompany.IsExistsForInsert(txtCompanyName.Text.Trim)
        If dtCompany IsNot Nothing Then
            If dtCompany.Rows.Count > 0 Then
                lblMessage.Text = "Company is already exists."
                Exit Sub
            End If
        End If
        daCompany.Insert(txtCompanyName.Text.Trim, txtAddress.Text.Trim, txtPhoneNumber.Text.Trim, CLng(ddlCity.SelectedValue), txtWebsite.Text.Trim, txtEmailId.Text.Trim, chkIsActive.Checked)
        Response.Redirect("~/Admin/ManageCompany.aspx")
    End Sub
    Private Function ValidateCompany() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtCompanyName.Text.Trim) Then
            strerror += rfvCompanyName.ErrorMessage & "</br>"
        Else
            Dim CompanyNameMatch As Match
            CompanyNameMatch = Regex.Match(txtCompanyName.Text.Trim, "[A-Z,a-z, ]$")
            If Not CompanyNameMatch.Success Then
                strerror += revCompanyName.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtAddress.Text.Trim) Then
            strerror += rfvAddress.ErrorMessage & "</br>"
        End If
        If String.IsNullOrEmpty(txtPhoneNumber.Text.Trim) Then
            strerror += rfvPhoneNumber.ErrorMessage & "</br>"
        Else
            Dim PhoneNumberMatch As Match
            PhoneNumberMatch = Regex.Match(txtPhoneNumber.Text.Trim, revPhoneNumber.ValidationExpression)
            If Not PhoneNumberMatch.Success Then
                strerror += revPhoneNumber.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtWebsite.Text.Trim) Then
            strerror += "Please Enter Website"
        Else
            Dim WebsiteMatch As Match
            WebsiteMatch = Regex.Match(txtWebsite.Text.Trim, revWebsite.ValidationExpression)
            If Not WebsiteMatch.Success Then
                strerror = +revEmailId.ErrorMessage & "<br/>"
            End If
        End If
        If String.IsNullOrEmpty(txtEmailId.Text.Trim) Then
            strerror += "Please Enter EmailId"
        Else
            Dim EmailMatch As Match
            EmailMatch = Regex.Match(txtEmailId.Text.Trim, revEmailId.ValidationExpression)
            If Not EmailMatch.Success Then
                strerror = +revEmailId.ErrorMessage & "<br/>"
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
            ddlState.Items.Insert(0, New ListItem(" -- No State Available -- ", "0"))
            ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillCompany()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub FillCompany()
        If ViewState("ID") IsNot Nothing Then
            Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
            Dim dtCompany As New ds_Company.CompanyDataTable
            dtCompany = daCompany.GetDataByStateAndCountry(CInt(ViewState("ID")))
            If dtCompany IsNot Nothing Then
                If dtCompany.Rows.Count > 0 Then
                    Dim drCompany As ds_Company.CompanyRow
                    drCompany = dtCompany.Rows(0)
                    txtCompanyName.Text = drCompany.CompanyName
                    txtAddress.Text = drCompany.Address
                    txtPhoneNumber.Text = drCompany.PhoneNumber
                    ddlCountry.SelectedValue = drCompany.Item("CountryId")
                    FillState()
                    ddlState.SelectedValue = drCompany.Item("StateId")
                    FillCity()
                    ddlCity.SelectedValue = drCompany.CityId
                    txtWebsite.Text = drCompany.Website
                    txtEmailId.Text = drCompany.EmailId
                    chkIsActive.Checked = drCompany.IsActive
                End If
            End If
        End If
    End Sub
    Protected Sub FillCity()
        Dim daCity As New ds_CityTableAdapters.CityTableAdapter
        Dim dtCity As New ds_City.CityDataTable
        dtCity = daCity.GetDataByState(CLng(ddlState.SelectedValue))
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
            ddlCity.Items.Insert(0, New ListItem(" -- No State Available -- ", "0"))
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
        Response.Redirect("~/Admin/ManageCompany.aspx")
    End Sub
    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountry.SelectedIndexChanged
        ddlState.Items.Clear()
        ddlCity.Items.Clear()
        If (ddlCountry.SelectedIndex > 0) Then
            FillState()
            ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
        Else
            ddlState.Items.Insert(0, New ListItem(" -- No State Available -- ", "0"))
            ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
        End If
    End Sub

    Protected Sub ddlState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlState.SelectedIndexChanged
        ddlCity.Items.Clear()
        If (ddlState.SelectedIndex > 0) Then
            FillCity()
        Else
            ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
        End If
    End Sub
End Class
