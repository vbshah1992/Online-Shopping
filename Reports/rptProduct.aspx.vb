
Partial Class Reports_rptProduct
    Inherits System.Web.UI.Page
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillCategory()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillCategory()
        End If
        FillReport()
    End Sub
    Protected Sub FillReport()
        Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
        Dim dtProduct As New ds_Product.ProductDataTable
        If ddlCategory.SelectedValue = 0 Then
            dtProduct = daProduct.GetDetails
        Else
            dtProduct = daProduct.SearchByCategory(CLng(ddlCategory.SelectedValue))
        End If
        If dtProduct IsNot Nothing Then
            If dtProduct.Rows.Count > 0 Then
                Dim ReportDocument As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                ReportDocument.Load(MapPath("~/Reports/crptProduct.rpt"))
                ReportDocument.SetDataSource(CType(dtProduct, Data.DataTable))
                crvProduct.ReportSource = ReportDocument
                crvProduct.DataBind()
            End If
        End If
    End Sub
    Protected Sub FillCategory()
        Dim daCategory As New ds_CategoryTableAdapters.CategoryTableAdapter
        Dim dtCategory As New ds_Category.CategoryDataTable
        dtCategory = daCategory.GetDataByNotParentCategoryId(0)
        If dtCategory IsNot Nothing Then
            If dtCategory.Rows.Count > 0 Then
                ddlCategory.DataSource = dtCategory
                ddlCategory.DataTextField = dtCategory.Columns(1).ColumnName
                ddlCategory.DataValueField = dtCategory.Columns(0).ColumnName
                ddlCategory.DataBind()
                ddlCategory.Items.Insert(0, New ListItem(" -- Select a Category -- ", "0"))
            Else
                ddlCategory.Items.Insert(0, New ListItem(" -- No Category Available -- ", "0"))
            End If
        Else
            ddlCategory.Items.Insert(0, New ListItem(" -- No Category Available -- ", "0"))
        End If
    End Sub
End Class
