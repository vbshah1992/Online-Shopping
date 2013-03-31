
Partial Class Admin_Country
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If validatecountry() Then
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
            Dim daCountry As New ds_CountryTableAdapters.CountryTableAdapter
            Dim dtCountry As New ds_Country.CountryDataTable
            dtCountry = daCountry.IsExistsForUpdate(CInt(ViewState("ID")), txtCountry.Text.Trim)
            If dtCountry IsNot Nothing Then
                If dtCountry.Rows.Count > 0 Then
                    lblMessage.Text = "Country is already exists"
                    Exit Sub
                End If
            End If
            dtCountry.Clear()
            dtCountry = daCountry.GetDataByPK(CInt(ViewState("ID")))
            If dtCountry IsNot Nothing Then
                If dtCountry.Rows.Count > 0 Then
                    Dim drCountry As ds_Country.CountryRow
                    drCountry = dtCountry.Rows(0)
                    drCountry.BeginEdit()
                    drCountry.CountryName = txtCountry.Text.Trim
                    drCountry.EndEdit()
                    daCountry.Update(dtCountry)
                    Response.Redirect("~/Admin/ManageCountry.aspx")
                End If
            End If
        End If
    End Sub
    Private Sub Insert()
        Dim daCountry As New ds_CountryTableAdapters.CountryTableAdapter
        Dim dtCountry As New ds_Country.CountryDataTable
        dtCountry = daCountry.IsExistsForInsert(txtCountry.Text.Trim)
        If dtCountry IsNot Nothing Then
            If dtCountry.Rows.Count > 0 Then
                lblMessage.Text = "Country is already exists."
                Exit Sub
            End If
        End If
        daCountry.Insert(txtCountry.Text.Trim)
        Response.Redirect("~/Admin/ManageCountry.aspx")
    End Sub
    Protected Sub FillCountry()
        If ViewState("ID") IsNot Nothing Then
            Dim daCountry As New ds_CountryTableAdapters.CountryTableAdapter
            Dim dtCountry As New ds_Country.CountryDataTable
            dtCountry = daCountry.GetDataByPK(CInt(ViewState("ID")))
            If dtCountry IsNot Nothing Then
                If dtCountry.Rows.Count > 0 Then
                    Dim drCountry As ds_Country.CountryRow
                    drCountry = dtCountry.Rows(0)
                    txtCountry.Text = drCountry.CountryName
                End If
            End If
        End If
    End Sub
    Private Function validatecountry() As Boolean
        Dim strerror As String = String.Empty
        If String.IsNullOrEmpty(txtCountry.Text.Trim) Then
            strerror += rfvCountry.ErrorMessage & "</br>"
        Else
            Dim CountryMatch As Match
            CountryMatch = Regex.Match(txtCountry.Text.Trim, "[A-Z,a-z, ]$")
            If Not CountryMatch.Success Then
                strerror += revCountry.ErrorMessage & "</br>"
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
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillCountry()
                btnSave.Text = "Update"
            Else
                btnSave.Text = "Save"
            End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("~/Admin/ManageCountry.aspx")
    End Sub
End Class
