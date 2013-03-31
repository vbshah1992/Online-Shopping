
Partial Class Reports_rpt_MonthlyFeedback
    Inherits System.Web.UI.Page
    Protected Sub FillReport()
        Dim daFeedback As New rpt_MonthlyFeedbackTableAdapters.MonthlyFeedbackTableAdapter
        Dim dtFeedaback As New rpt_MonthlyFeedback.MonthlyFeedbackDataTable
        Dim dtStartDate As Date = (txtDate.Text)
        Dim dtEndDate As Date = dtStartDate.AddDays(Date.DaysInMonth(dtStartDate.Year, dtStartDate.Month) - 1)
        dtFeedaback = daFeedback.GetData(dtStartDate, dtEndDate)
        If dtFeedaback IsNot Nothing Then
            If dtFeedaback.Rows.Count > 0 Then
                'Set Report Document
                Dim drcrpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                drcrpt.Load(MapPath("~") & "\Reports\crptMonthlyFeedback.rpt")
                drcrpt.SetDataSource(CType(dtFeedaback, Data.DataTable))
                'Set Data Source
                crvMonthlyFeedback.ReportSource = drcrpt
                crvMonthlyFeedback.DataBind()
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
