<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false" Theme="CustomerTheme"
    CodeFile="ListShoppingCart.aspx.vb" Inherits="Customer_ListShoppingCart" Title="List Shopping Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <center>
        <h2 class="heading">
            Shopping Cart
        </h2>
    </center>
    <table  class="text" align="center">
        <tr>
            <td align="center">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvShoppingCart" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    DataKeyNames="ShoppingCartId" DataSourceID="odsShoppingCart" ShowFooter="True">
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgRuppes" runat="server" Height="14px" ImageUrl="~/Images/Rupee.gif"
                                    Width="20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                        <asp:BoundField DataField="ShoppingDate" HeaderText="ShoppingDate" SortExpression="ShoppingDate"
                            DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:TemplateField HeaderText="Total Price">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ObjectDataSource ID="odsShoppingCart" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByDetails"
                    TypeName="ds_ShoppingCartTableAdapters.ShoppingCartTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_ShoppingCartId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProductId" Type="Int64" />
                        <asp:Parameter Name="CustomerId" Type="Int64" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="Quantity" Type="Int32" />
                        <asp:Parameter Name="ShoppingDate" Type="DateTime" />
                        <asp:Parameter Name="Original_ShoppingCartId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProductId" Type="Int64" />
                        <asp:Parameter Name="CustomerId" Type="Int64" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="Quantity" Type="Int32" />
                        <asp:Parameter Name="ShoppingDate" Type="DateTime" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="CustomerId" SessionField="CUSTOMERID"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
