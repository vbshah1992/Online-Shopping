Partial Class Reports_rptCityWiseCompany
    Inherits System.Web.UI.Page
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillCity()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillCity()
        End If
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daCompany As New ds_CompanyTableAdapters.CompanyTableAdapter
        Dim dtCompany As New ds_Company.CompanyDataTable
        If ddlCity.SelectedValue = 0 Then
            dtCompany = daCompany.GetDetails
        Else
            dtCompany = daCompany.SearchByCity(CLng(ddlCity().SelectedValue))
        End If
        If dtCompany IsNot Nothing Then
            If dtCompany.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCityWiseCompany.rpt"))
                ReportDocument.SetDataSource(CType(dtCompany, Data.DataTable))
                crvCompany.ReportSource = ReportDocument
                crvCompany.DataBind()
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
