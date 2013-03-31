
Partial Class Controls_cltRegistration
    Inherits System.Web.UI.UserControl
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ValidateCustomer() Then
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
            Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
            Dim dtCustomer As New ds_Customer.CustomerDataTable
            dtCustomer = daCustomer.IsExistsForUpdate(CInt(ViewState("ID")), txtEmailId.Text.Trim)
            If dtCustomer IsNot Nothing Then
                If dtCustomer.Rows.Count > 0 Then
                    lblMessage.Text = "Customer is already exists"
                    Exit Sub
                End If
            End If
            dtCustomer.Clear()
            dtCustomer = daCustomer.GetDataByPK(CInt(ViewState("ID")))
            If dtCustomer IsNot Nothing Then
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomer As ds_Customer.CustomerRow
                    drCustomer = dtCustomer.Rows(0)
                    drCustomer.BeginEdit()
                    drCustomer.FirstName = txtFirstName.Text.Trim
                    drCustomer.LastName = txtLastName.Text.Trim
                    drCustomer.Address = txtAddress.Text.Trim
                    drCustomer.CityId = CLng(ddlCity.SelectedValue)
                    drCustomer.PinCode = txtPincode.Text.Trim
                    drCustomer.PhoneNumber = txtPhoneNumber.Text.Trim
                    drCustomer.ContactNumber = txtContactNumber.Text.Trim
                    drCustomer.EmailId = txtEmailId.Text.Trim
                    If Not String.IsNullOrEmpty(txtPassword.Text.Trim) Then
                        drCustomer.Password = SMSCommon.TripleDESEncode(txtPassword.Text.Trim)
                    End If
                    drCustomer.EndEdit()
                    daCustomer.Update(dtCustomer)
                    Response.Redirect("~/Customer/ThankYou.aspx?MID=4")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
        Dim dtCustomer As New ds_Customer.CustomerDataTable
        dtCustomer = daCustomer.IsExistsForInsert(txtEmailId.Text.Trim)
        If dtCustomer IsNot Nothing Then
            If dtCustomer.Rows.Count > 0 Then
                lblMessage.Text = "Customer is already exists."
                Exit Sub
            End If
        End If
        daCustomer.Insert(txtFirstName.Text.Trim, txtLastName.Text.Trim, txtAddress.Text.Trim, CLng(ddlCity.SelectedValue), txtPincode.Text.Trim, txtPhoneNumber.Text.Trim, txtContactNumber.Text.Trim, txtEmailId.Text.Trim, SMSCommon.TripleDESEncode(txtPassword.Text.Trim), True)
        Response.Redirect("~/Customer/ThankYou.aspx?MID=1")
    End Sub
    Private Function ValidateCustomer() As Boolean
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
                FillCustomer()
                btnSave.Text = "Update"
                rfvPassword.Enabled = False
            Else
                btnSave.Text = "Register"
            End If
        End If
    End Sub
    Protected Sub FillCustomer()
        If ViewState("ID") IsNot Nothing Then
            Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
            Dim dtCustomer As New ds_Customer.CustomerDataTable
            dtCustomer = daCustomer.GetDataByStateandCountry(CInt(ViewState("ID")))
            If dtCustomer IsNot Nothing Then
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomer As ds_Customer.CustomerRow
                    drCustomer = dtCustomer.Rows(0)
                    txtFirstName.Text = drCustomer.FirstName
                    txtLastName.Text = drCustomer.LastName
                    txtAddress.Text = drCustomer.Address
                    ddlCountry.SelectedValue = drCustomer.Item("CountryId")
                    FillState()
                    ddlState.SelectedValue = drCustomer.Item("StateId")
                    FillCity()
                    ddlCity.SelectedValue = drCustomer.CityId
                    txtPincode.Text = drCustomer.PinCode
                    txtPhoneNumber.Text = drCustomer.PhoneNumber
                    txtContactNumber.Text = drCustomer.ContactNumber
                    txtEmailId.Text = drCustomer.EmailId
                    txtPassword.Text = drCustomer.Password
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
        Response.Redirect("~/Customer/ProductList.aspx")
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
