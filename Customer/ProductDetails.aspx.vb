
Partial Class Customer_ProductDetails
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("ID") IsNot Nothing Then
                ViewState("ID") = Request.QueryString("ID")
                FillProduct()
            Else
                Response.Redirect("~/Customer/ProductList.aspx")
            End If
        End If
    End Sub
    Protected Sub FillProduct()
        If ViewState("ID") IsNot Nothing Then
            Dim daProduct As New ds_ProductTableAdapters.ProductTableAdapter
            Dim dtProduct As New ds_Product.ProductDataTable
            dtProduct = daProduct.GetDataByCategoryandCompany(CInt(ViewState("ID")))
            If dtProduct IsNot Nothing Then
                If dtProduct.Rows.Count > 0 Then
                    Dim drProduct As ds_Product.ProductRow
                    drProduct = dtProduct.Rows(0)
                    lblProduct.Text = drProduct.ProductName
                    lblPrice.Text = CInt(drProduct.Price)
                    lblBriefDescription.Text = drProduct.BriefDescription
                    lblDescription.Text = drProduct.Description
                    lblCategory.Text = drProduct.Item("CategoryName")
                    lblCompany.Text = drProduct.Item("CompanyName")
                End If
            End If
        End If
    End Sub

    Protected Sub btnAddtoCart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddtoCart.Click
        If Session("CUSTOMERID") IsNot Nothing Then
            Dim dpShoppingCart As New ds_ShoppingCartTableAdapters.ShoppingCartTableAdapter
            Dim dtShoppingCart As New ds_ShoppingCart.ShoppingCartDataTable
            dtShoppingCart = dpShoppingCart.IsExistsForInsert(CLng(Session("CUSTOMERID")), CLng(ViewState("ID")))
            If dtShoppingCart IsNot Nothing Then
                If dtShoppingCart.Rows.Count > 0 Then
                    Dim drShoppingCart As ds_ShoppingCart.ShoppingCartRow
                    drShoppingCart = dtShoppingCart(0)
                    If (drShoppingCart.Quantity + CInt(txtQuantity.Text.Trim)) >= 5 Then
                        lblQuantityCheck.Text = "* You have already buy" + " " + Convert.ToString(drShoppingCart.Quantity) + " " + "Peace *" + "<br>" + "* Order For One Product < 6 Peace *"
                        Return
                    End If
                    drShoppingCart.BeginEdit()
                    drShoppingCart.Quantity += CInt(txtQuantity.Text.Trim())
                    drShoppingCart.EndEdit()
                    dpShoppingCart.Update(dtShoppingCart)
                    Response.Redirect("ProductList.aspx")
                End If
            End If
            Dim daShoppingCart As New ds_ShoppingCartTableAdapters.ShoppingCartTableAdapter
            daShoppingCart.Insert(CLng(ViewState("ID")), CLng(Session("CUSTOMERID")), CDec(lblPrice.Text), CInt(txtQuantity.Text.Trim), CDate(System.DateTime.Now))
            Response.Redirect("ProductList.aspx")
        Else
            Dim wm As Master_CustomerMaster = Master
            wm.ShowmpeLogin()
            'Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("ProductList.aspx")
    End Sub
End Class
