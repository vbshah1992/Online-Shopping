
Partial Class Reports_rptCompany
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
        Dim dtCompany As New ds_Company.CompanyDataTable
        dtCompany = daCompany.GetDetails
        If dtCompany IsNot Nothing Then
            If dtCompany.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCompany.rpt"))
                ReportDocument.SetDataSource(CType(dtCompany, Data.DataTable))
                crvCompany.ReportSource = ReportDocument
                crvCompany.DataBind()
            End If
        End If
    End Sub
End Class
