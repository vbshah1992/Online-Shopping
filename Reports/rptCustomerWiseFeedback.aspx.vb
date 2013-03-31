
Partial Class Reports_rptCustomerWiseFeedback
    Inherits System.Web.UI.Page
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillReport()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillCustomer()
        End If
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daFeedbackByCustomer As New rpt_FeedbackByCustomerTableAdapters.FeedbackByCustomerTableAdapter
        Dim dtFeedbackByCustomer As New rpt_FeedbackByCustomer.FeedbackByCustomerDataTable
        If ddlCustomer.SelectedValue = 0 Then
            dtFeedbackByCustomer = daFeedbackByCustomer.GetData
        Else
            dtFeedbackByCustomer = daFeedbackByCustomer.SearchByCustomer(CLng(ddlCustomer.SelectedValue))
        End If
        If dtFeedbackByCustomer IsNot Nothing Then
            If dtFeedbackByCustomer.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptCustomerWiseFeedback.rpt"))
                ReportDocument.SetDataSource(CType(dtFeedbackByCustomer, Data.DataTable))
                crvCustomerWiseFeedback.ReportSource = ReportDocument
                crvCustomerWiseFeedback.DataBind()
            End If
        End If
    End Sub
    Protected Sub FillCustomer()
        Dim daCustomer As New ds_CustomerTableAdapters.CustomerTableAdapter
        Dim dtCustomer As New ds_Customer.CustomerDataTable
        dtCustomer = daCustomer.GetData()
        If dtCustomer IsNot Nothing Then
            If dtCustomer.Rows.Count > 0 Then
                ddlCustomer.DataSource = dtCustomer
                ddlCustomer.DataTextField = dtCustomer.Columns(1).ColumnName
                ddlCustomer.DataValueField = dtCustomer.Columns(0).ColumnName
                ddlCustomer.DataBind()
                ddlCustomer.Items.Insert(0, New ListItem(" -- Select a Customer -- ", "0"))
            Else
                ddlCustomer.Items.Insert(0, New ListItem(" -- No Customer Available -- ", "0"))
            End If
        Else
            ddlCustomer.Items.Insert(0, New ListItem(" -- No Customer Available -- ", "0"))
        End If
    End Sub
End Class
