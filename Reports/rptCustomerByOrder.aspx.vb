
Partial Class Reports_rptCustomerByOrder
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daOrderCount As New ds_OrderCountTableAdapters.OrderCountTableAdapter
        Dim dtOrderCount As New ds_OrderCount.OrderCountDataTable
        dtOrderCount = daOrderCount.GetData()
        If dtOrderCount IsNot Nothing Then
            If dtOrderCount.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCustomerByOrder.rpt"))
                ReportDocument.SetDataSource(CType(dtOrderCount, Data.DataTable))
                crvCustomerByOrderCount.ReportSource = ReportDocument
                crvCustomerByOrderCount.DataBind()
            End If
        End If
    End Sub
End Class