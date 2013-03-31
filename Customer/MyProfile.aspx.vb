
Partial Class Customer_MyProfile
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("CUSTOMERID") Is Nothing Then
                Dim wm As Master_CustomerMaster = Master
                wm.ShowmpeLogin()
                'Response.Redirect("Login.aspx")
            End If
            FillCustomer()
        End If
    End Sub
    Protected Sub FillCustomer()
        If Session("CUSTOMERID") IsNot Nothing Then
            Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
            Dim dtCustomer As New ds_Customer.CustomerDataTable
            dtCustomer = daCustomer.GetDataByCustomer(Session("CUSTOMERID"))
            If dtCustomer IsNot Nothing Then
                If dtCustomer.Rows.Count > 0 Then
                    Dim drCustomer As ds_Customer.CustomerRow
                    drCustomer = dtCustomer.Rows(0)
                    lblFirstName.Text = drCustomer.FirstName
                    lblLastName.Text = drCustomer.LastName
                    lblAddress.Text = drCustomer.Address
                    lblCity.Text = drCustomer.Item("CityName")
                    lblPincode.Text = drCustomer.PinCode
                    lblPhoneNumber.Text = drCustomer.PhoneNumber
                    lblContactNumber.Text = drCustomer.ContactNumber
                    lblEmailId.Text = drCustomer.EmailId
                End If
            End If
        End If
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("~/Customer/ProductList.aspx")
    End Sub

    Protected Sub lnkEditProfile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEditProfile.Click
        Response.Redirect("~/Customer/Registration.aspx?ID=" & Session("CUSTOMERID"))
    End Sub
End Class
