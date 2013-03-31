
Partial Class Reports_rptCityWiseAdmin
    Inherits System.Web.UI.Page
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillReport()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillCity()
        End If
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daAdmin As New ds_AdminTableAdapters.AdminTableAdapter
        Dim dtAdmin As New ds_Admin.AdminDataTable
        If ddlCity.SelectedValue > 0 Then
            dtAdmin = daAdmin.SearchByCity(CLng(ddlCity.SelectedValue))
        Else
            dtAdmin = daAdmin.GetDetails
        End If
        If dtAdmin IsNot Nothing Then
            If dtAdmin.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCityWiseAdmin.rpt"))
                ReportDocument.SetDataSource(CType(dtAdmin, Data.DataTable))
                crvCityWiseAdmin.ReportSource = ReportDocument
                crvCityWiseAdmin.DataBind()
            End If
        End If
    End Sub
    Protected Sub FillCity()
        Dim daCity As New ds_CityTableAdapters.CityTableAdapter
        Dim dtCity As New ds_City.CityDataTable
        dtCity = daCity.GetData
        If dtCity IsNot Nothing Then
            If dtCity.Rows.Count > 0 Then
                ddlCity.DataSource = dtCity
                ddlCity.DataTextField = dtCity.Columns(1).ColumnName
                ddlCity.DataValueField = dtCity.Columns(0).ColumnName
                ddlCity.DataBind()
                ddlCity.Items.Insert(0, New ListItem(" -- Select a City -- ", "0"))
            Else
                ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
            End If
        Else
            ddlCity.Items.Insert(0, New ListItem(" -- No City Available -- ", "0"))
        End If
    End Sub
End Class

