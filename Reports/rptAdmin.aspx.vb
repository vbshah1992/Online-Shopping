
Partial Class Reports_rptAdmin
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
        Dim dtAdmin As New ds_Admin.AdminDataTable
        dtAdmin = daAdmin.GetDetails
        If dtAdmin IsNot Nothing Then
            If dtAdmin.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptAdmin.rpt"))
                ReportDocument.SetDataSource(CType(dtAdmin, Data.DataTable))
                crvAdmin.ReportSource = ReportDocument
                crvAdmin.DataBind()
            End If
        End If
    End Sub
End Class
