
Partial Class Reports_rptCompanyByProduct
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daProductCount As New ds_ProductCountTableAdapters.CompanyTableAdapter
        Dim dtProductCount As New ds_ProductCount.CompanyDataTable
        dtProductCount = daProductCount.GetData
        If dtProductCount IsNot Nothing Then
            If dtProductCount.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCompanyByProduct.rpt"))
                ReportDocument.SetDataSource(CType(dtProductCount, Data.DataTable))
                crvCompanyByProductCount.ReportSource = ReportDocument
                crvCompanyByProductCount.DataBind()
            End If
        End If
    End Sub
End Class