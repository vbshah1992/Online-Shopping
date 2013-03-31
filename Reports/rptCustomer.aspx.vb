
Partial Class Reports_rptCustomer
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
        Dim dtCustomer As New ds_Customer.CustomerDataTable
        dtCustomer = daCustomer.GetDetails
        If dtCustomer IsNot Nothing Then
            If dtCustomer.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCustomer.rpt"))
                ReportDocument.SetDataSource(CType(dtCustomer, Data.DataTable))
                crvCustomer.ReportSource = ReportDocument
                crvCustomer.DataBind()
            End If
        End If
    End Sub
End Class
