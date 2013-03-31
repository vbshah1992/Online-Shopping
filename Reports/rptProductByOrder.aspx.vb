
Partial Class Reports_rptProductByOrder
    Inherits System.Web.UI.Page
    Protected Sub FillReport()
        Dim daProductByOrder As New ds_ProductByOrderTableAdapters.ProductTableAdapter
        Dim dtProductByOrder As New ds_ProductByOrder.ProductDataTable
        If ddlProduct.SelectedValue = 0 Then
            dtProductByOrder = daProductByOrder.GetData
        Else
            dtProductByOrder = daProductByOrder.SearchByProduct(CLng(ddlProduct.SelectedValue))
        End If
        If dtProductByOrder IsNot Nothing Then
            If dtProductByOrder.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptProductByOrder.rpt"))
                ReportDocument.SetDataSource(CType(dtProductByOrder, Data.DataTable))
                crvProductByOrder.ReportSource = ReportDocument
                crvProductByOrder.DataBind()
            End If
        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillReport()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillProduct()
        End If
        FillReport()
    End Sub
    Protected Sub FillProduct()
        Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
        Dim dtProduct As New ds_Product.ProductDataTable
        dtProduct = daProduct.GetData()
        If dtProduct IsNot Nothing Then
            If dtProduct.Rows.Count > 0 Then
                ddlProduct.DataSource = dtProduct
                ddlProduct.DataTextField = dtProduct.Columns(1).ColumnName
                ddlProduct.DataValueField = dtProduct.Columns(0).ColumnName
                ddlProduct.DataBind()
                ddlProduct.Items.Insert(0, New ListItem(" -- Select a Product -- ", "0"))
            Else
                ddlProduct.Items.Insert(0, New ListItem(" -- No Product Available -- ", "0"))
            End If
        Else
            ddlProduct.Items.Insert(0, New ListItem(" -- No Product Available -- ", "0"))
        End If
    End Sub
End Class
