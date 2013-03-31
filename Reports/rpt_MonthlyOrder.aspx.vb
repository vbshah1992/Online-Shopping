
Partial Class Reports_rpt_MonthlyOrder
    Inherits System.Web.UI.Page
    Protected Sub FillReport()
        Dim daOrder As New rpt_MonthlyOrderTableAdapters.MonthlyOrderTableAdapter
        Dim dtOrder As New rpt_MonthlyOrder.MonthlyOrderDataTable
        Dim dtStartDate As Date = (txtDate.Text)
        Dim dtEndDate As Date = dtStartDate.AddDays(Date.DaysInMonth(dtStartDate.Year, dtStartDate.Month) - 1)
        dtOrder = daOrder.GetData(dtStartDate, dtEndDate)
        If dtOrder IsNot Nothing Then
            If dtOrder.Rows.Count > 0 Then
                'Set Report Document
                Dim drcrpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                drcrpt.Load(MapPath("~") & "\Reports\crptMonthlyOrder.rpt")
                drcrpt.SetDataSource(CType(dtOrder, Data.DataTable))
                'Set Data Source
                crvMonthlyOrder.ReportSource = drcrpt
                crvMonthlyOrder.DataBind()
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtDate.Text = Now.Date.ToString("MMM-yyyy")
            FillReport()
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillReport()
    End Sub
End Class
