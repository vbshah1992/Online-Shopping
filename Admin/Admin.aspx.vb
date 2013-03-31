
Partial Class Admin_Admin
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateAdmin() Then
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
            Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
            Dim dtAdmin As New ds_Admin.AdminDataTable
            dtAdmin = daAdmin.IsExistsForUpdate(CInt(ViewState("ID")), txtEmailId.Text.Trim)
            If dtAdmin IsNot Nothing Then
                If dtAdmin.Rows.Count > 0 Then
                    lblMessage.Text = "Admin is already exists"
                    Exit Sub
                End If
            End If
            dtAdmin.Clear()
            dtAdmin = daAdmin.GetDataByPK(CInt(ViewState("ID")))
            If dtAdmin IsNot Nothing Then
                If dtAdmin.Rows.Count > 0 Then
                    Dim drAdmin As ds_Admin.AdminRow
                    drAdmin = dtAdmin.Rows(0)
                    drAdmin.BeginEdit()
                    drAdmin.FirstName = txtFirstName.Text.Trim
                    drAdmin.LastName = txtLastName.Text.Trim
                    drAdmin.DateOfBirth = txtDateOfBirth.Text.Trim
                    drAdmin.Address = txtAddress.Text.Trim
                    drAdmin.CityId = CLng(ddlCity.SelectedValue)
                    drAdmin.PinCode = txtPincode.Text.Trim
                    drAdmin.PhoneNumber = txtPhoneNumber.Text.Trim
                    drAdmin.ContactNumber = txtContactNumber.Text.Trim
                    drAdmin.EmailId = txtEmailId.Text.Trim
                    If Not String.IsNullOrEmpty(txtConfirmPassword.Text.Trim) Then
                        drAdmin.Password = SMSCommon.TripleDESEncode(txtConfirmPassword.Text.Trim)
                    End If
                    drAdmin.IsActive = chkIsActive.Checked
                    drAdmin.EndEdit()
                    daAdmin.Update(dtAdmin)
                    Response.Redirect("~/Admin/ThankYou.aspx?MID=4")
                    Response.Redirect("~/Admin/ManageAdmin.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
        Dim dtAdmin As New ds_Admin.AdminDataTable
        dtAdmin = daAdmin.IsExistsForInsert(txtEmailId.Text.Trim)
        If dtAdmin IsNot Nothing Then
            If dtAdmin.Rows.Count > 0 Then
                lblMessage.Text = "Admin is already exists."
                Exit Sub
            End If
        End If
        daAdmin.Insert(txtFirstName.Text.Trim, txtLastName.Text.Trim, CDate(txtDateOfBirth.Text.Trim), txtAddress.Text.Trim, CLng(ddlCity.SelectedValue), txtPincode.Text.Trim, txtPhoneNumber.Text.Trim, txtContactNumber.Text.Trim, txtEmailId.Text.Trim, SMSCommon.TripleDESEncode(txtPassword.Text.Trim), chkIsActive.Checked)
        Response.Redirect("~/Admin/ManageAdmin.aspx")
    End Sub
    Private Function ValidateAdmin() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtFirstName.Text.Trim) Then
            strerror += rfvFirstName.ErrorMessage & "</br>"
        Else
            Dim FirstNameMatch As Match
            FirstNameMatch = Regex.Match(txtFirstName.Text.Trim, "[A-Z,a-z, ]$")
            If Not FirstNameMatch.Success Then
                strerror += revFirstName.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtLastName.Text.Trim) Then
            strerror += rfvLastName.ErrorMessage & "</br>"
        Else
            Dim LastNameMatch As Match
            LastNameMatch = Regex.Match(txtLastName.Text.Trim, revLastName.ValidationExpression)
            If Not LastNameMatch.Success Then
                strerror += revLastName.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtDateOfBirth.Text.Trim) Then
            strerror += rfvDateOfBirth.ErrorMessage & "</br>"
        Else
            If IsDate(txtDateOfBirth.Text.Trim) Then
                If CDate(txtDateOfBirth.Text.Trim) > Now.Date Then
                    strerror += "Future date not allowed in date of birth." & "<br/>"
                End If
                If DateDiff(DateInterval.Year, CDate(txtDateOfBirth.Text.Trim), Now.Date) < 18 Then
                    strerror += "Admin should be atleast 18 years old." & "<br/>"
                End If
            End If
        End If
        If String.IsNullOrEmpty(txtAddress.Text.Trim) Then
            strerror += rfvAddress.ErrorMessage & "</br>"
        End If
        If String.IsNullOrEmpty(txtPincode.Text.Trim) Then
            strerror += rfvPincode.ErrorMessage & "</br>"
        Else
            If Not IsNumeric(txtPincode.Text.Trim) Then
                strerror += revPincode.ErrorMessage & "<br/>"
                'or
                ' Dim PincodeMatch As Match
                'PincodeMatch = Regex.Match(txtPincode.Text.Trim, revPincode.ValidationExpression)
                ' If Not PincodeMatch.Success Then
                ' strerror += revPincode.ErrorMessage & "</br>"
                'End If
            End If
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
        If String.IsNullOrEmpty(txtContactNumber.Text.Trim) Then
            strerror += rfvContactNumber.ErrorMessage & "</br>"
        Else
            Dim ContactNumberMatch As Match
            ContactNumberMatch = Regex.Match(txtContactNumber.Text.Trim, revContactNumber.ValidationExpression)
            If Not ContactNumberMatch.Success Then
                strerror += revContactNumber.ErrorMessage & "</br>"
            End If
        End If
        If String.IsNullOrEmpty(txtEmailId.Text.Trim) Then
            strerror += "Please Enter EmailId"
        Else
            Dim EmailMatch As Match
            EmailMatch = Regex.Match(txtEmailId.Text.Trim, revEmailId.ValidationExpression)
            If Not EmailMatch.Success Then
                strerror += revEmailId.ErrorMessage & "<br/>"
            End If
        End If
        If ViewState("ID") Is Nothing Then
            If String.IsNullOrEmpty(txtPassword.Text.Trim) Then
                strerror += "Please enter password." & "<br/>"
            Else
                If (rvPassword.MinimumValue > txtPassword.Text.Trim) And (rvPassword.MaximumValue < txtPassword.Text.Trim) Then
                    strerror += rvPassword.ErrorMessage & "<br/>"
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
        If Not IsPostBack Then
            FillCountry()
            ddlState.Items.Insert(0, New ListItem(" -- No State Available -- ", "0"))
            ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillAdmin()
                btnSave.Text = "Update"
                rfvPassword.Enabled = False
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub
    Protected Sub FillAdmin()
        If ViewState("ID") IsNot Nothing Then
            Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
            Dim dtAdmin As New ds_Admin.AdminDataTable
            dtAdmin = daAdmin.GetDataByStateandCountry(CInt(ViewState("ID")))
            If dtAdmin IsNot Nothing Then
                If dtAdmin.Rows.Count > 0 Then
                    Dim drAdmin As ds_Admin.AdminRow
                    drAdmin = dtAdmin.Rows(0)
                    txtFirstName.Text = drAdmin.FirstName
                    txtLastName.Text = drAdmin.LastName
                    txtDateOfBirth.Text = drAdmin.DateOfBirth
                    txtAddress.Text = drAdmin.Address
                    ddlCountry.SelectedValue = drAdmin.Item("CountryId")
                    FillState()
                    ddlState.SelectedValue = drAdmin.Item("StateId")
                    FillCity()
                    ddlCity.SelectedValue = drAdmin.CityId
                    txtPincode.Text = drAdmin.PinCode
                    txtPhoneNumber.Text = drAdmin.PhoneNumber
                    txtContactNumber.Text = drAdmin.ContactNumber
                    txtEmailId.Text = drAdmin.EmailId
                    txtPassword.Text = drAdmin.Password
                    chkIsActive.Checked = drAdmin.IsActive
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
        Response.Redirect("~/Admin/ManageAdmin.aspx")
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