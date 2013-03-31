
Partial Class Controls_cltMenu
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillMenu()
        End If
    End Sub

    Protected Sub FillMenu()


        Dim skmMenuUsers As skmMenu.MenuItem = New skmMenu.MenuItem("Users")
        skmMenuUsers.SubItems.Add(New skmMenu.MenuItem("Admin", "../Admin/ManageAdmin.aspx"))
        skmMenuUsers.SubItems.Add(New skmMenu.MenuItem("Customer", "../Admin/ManageCustomer.aspx"))

        Dim skmMenuProduct As skmMenu.MenuItem = New skmMenu.MenuItem("Product")
        skmMenuProduct.SubItems.Add(New skmMenu.MenuItem("Product", "../Admin/ManageProduct.aspx"))
        skmMenuProduct.SubItems.Add(New skmMenu.MenuItem("Image", "../Admin/ManageImage.aspx"))
        skmMenuProduct.SubItems.Add(New skmMenu.MenuItem("Category", "../Admin/ManageCategory.aspx"))
        skmMenuProduct.SubItems.Add(New skmMenu.MenuItem("Company", "../Admin/ManageCompany.aspx"))

        Dim skmMenuLocation As skmMenu.MenuItem = New skmMenu.MenuItem("Location")
        skmMenuLocation.SubItems.Add(New skmMenu.MenuItem("City", "../Admin/ManageCity.aspx"))
        skmMenuLocation.SubItems.Add(New skmMenu.MenuItem("State", "../Admin/ManageState.aspx"))
        skmMenuLocation.SubItems.Add(New skmMenu.MenuItem("Country", "../Admin/ManageCountry.aspx"))

        Dim skmMenuReport As skmMenu.MenuItem = New skmMenu.MenuItem("Report")

        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Admin", "../Reports/rptAdmin.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Customer", "../Reports/rptCustomer.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Company", "../Reports/rptCompany.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Product", "../Reports/rptProduct.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Order", "../Reports/rptOrder.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("City Wise Admin", "../Reports/rptCityWiseAdmin.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("City Wise Customer", "../Reports/rptCityWiseCustomer.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("City Wise Company", "../Reports/rptCityWiseCompany.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Customer By Order", "../Reports/rptCustomerByOrder.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Customer Wise Feedback", "../Reports/rptCustomerWiseFeedback.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Company By Product", "../Reports/rptCompanyByProduct.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Product By Company", "../Reports/rptProductByCompany.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Product By Order", "../Reports/rptProductByOrder.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Month Wise Order", "../Reports/rpt_MonthlyOrder.aspx"))
        skmMenuReport.SubItems.Add(New skmMenu.MenuItem("Month Wise Feedback", "../Reports/rpt_MonthlyFeedback.aspx"))

        Dim skmMenuOrder As skmMenu.MenuItem = New skmMenu.MenuItem("Order", "../Admin/ManageOrder.aspx")

        Dim skmMenuFeedback As skmMenu.MenuItem = New skmMenu.MenuItem("Feedback", "../Admin/ManageFeedback.aspx")

        Dim skmMenuLogout As skmMenu.MenuItem = New skmMenu.MenuItem("Logout", "../Admin/LogOut.aspx")

        mnuAdmin.Items.Add(skmMenuUsers)
        mnuAdmin.Items.Add(skmMenuProduct)
        mnuAdmin.Items.Add(skmMenuLocation)
        mnuAdmin.Items.Add(skmMenuReport)
        mnuAdmin.Items.Add(skmMenuOrder)
        mnuAdmin.Items.Add(skmMenuFeedback)
        mnuAdmin.Items.Add(skmMenuLogout)

    End Sub
End Class
