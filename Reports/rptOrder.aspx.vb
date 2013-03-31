Partial Class Reports_rptOrder
    Inherits System.Web.UI.Page
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillReport()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daOrder As New ds_OrderTableAdapters.OrderTableAdapter
        Dim dtOrder As New ds_Order.OrderDataTable
        If ((String.IsNullOrEmpty(txtStartDate.Text)) And (String.IsNullOrEmpty(txtEndDate.Text))) Then
            dtOrder = daOrder.GetDetails
        Else
            dtOrder = daOrder.SearchByOrderAndDeliveryDate(CDate(txtStartDate.Text.Trim), CDate(txtEndDate.Text.Trim))
        End If
        If dtOrder IsNot Nothing Then
            If dtOrder.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptOrder.rpt"))
                ReportDocument.SetDataSource(CType(dtOrder, Data.DataTable))
                crvOrder.ReportSource = ReportDocument
                crvOrder.DataBind()
            End If
        End If
    End Sub
End Class
