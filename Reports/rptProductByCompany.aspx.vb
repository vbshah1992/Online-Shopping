
Partial Class Reports_rptProductByCompany
    Inherits System.Web.UI.Page
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillCompany()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillCompany()
        End If
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
        Dim dtProduct As New ds_Product.ProductDataTable
        If ddlCompany.SelectedValue = 0 Then
            dtProduct = daProduct.GetDetails
        Else
            dtProduct = daProduct.SearchByCompany(CLng(ddlCompany.SelectedValue))
        End If
        If dtProduct IsNot Nothing Then
            If dtProduct.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptProduct.rpt"))
                ReportDocument.SetDataSource(CType(dtProduct, Data.DataTable))
                crvProductByCompany.ReportSource = ReportDocument
                crvProductByCompany.DataBind()
            End If
        End If
    End Sub
    Protected Sub FillCompany()
        Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
        Dim dtCompany As New ds_Company.CompanyDataTable
        dtCompany = daCompany.GetData()
        If dtCompany IsNot Nothing Then
            If dtCompany.Rows.Count > 0 Then
                ddlCompany.DataSource = dtCompany
                ddlCompany.DataTextField = dtCompany.Columns(1).ColumnName
                ddlCompany.DataValueField = dtCompany.Columns(0).ColumnName
                ddlCompany.DataBind()
                ddlCompany.Items.Insert(0, New ListItem(" -- Select a Company -- ", "0"))
            Else
                ddlCompany.Items.Insert(0, New ListItem(" -- No Company Available -- ", "0"))
            End If
        Else
            ddlCompany.Items.Insert(0, New ListItem(" -- No Company Available -- ", "0"))
        End If
    End Sub
End Class
