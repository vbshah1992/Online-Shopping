
Partial Class Controls_cltCompanyMenu
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillMenu()
        End If
    End Sub

    Protected Sub FillMenu()
        Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
        Dim dtCompany As New ds_Company.CompanyDataTable
        dtCompany = daCompany.GetData
        If dtCompany IsNot Nothing Then
            If dtCompany.Rows.Count > 0 Then
                For Each drCompany As ds_Company.CompanyRow In dtCompany.Rows
                    Dim skmMenuParentCompany As skmMenu.MenuItem = New skmMenu.MenuItem(drCompany.CompanyName, "ProductList.aspx?COID= " & drCompany.CompanyId)
                    mnuCompany.Items.Add(skmMenuParentCompany)
                Next
            End If
        End If
    End Sub
End Class
