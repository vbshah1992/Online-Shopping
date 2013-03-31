Partial Class Reports_rptCityWiseCustomer
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
        Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
        Dim dtCustomer As New ds_Customer.CustomerDataTable
        If ddlCity.SelectedValue = 0 Then
            dtCustomer = daCustomer.GetDetails
        Else
            dtCustomer = daCustomer.SearchByCity(CLng(ddlCity.SelectedValue))
        End If
        If dtCustomer IsNot Nothing Then
            If dtCustomer.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCityWiseCustomer.rpt"))
                ReportDocument.SetDataSource(CType(dtCustomer, Data.DataTable))
                crvCityWiseCustomer.ReportSource = ReportDocument
                crvCityWiseCustomer.DataBind()
            End If
        End If
    End Sub
    Protected Sub FillCity()
        Dim daCity As New ds_CityTableAdapters.CityTableAdapter
        Dim dtCity As New ds_City.CityDataTable
        dtCity = daCity.GetData()
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

