<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ManageOrderDetail.aspx.vb" Inherits="Admin_ManageOrderDetail" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
    <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Order Detail</h2>
            </td>
        </tr>
        <tr>
            <td>
                Billing Phone Number :
                <asp:Label ID="lblBillingPhoneNumber" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Shipping Phone Number :
                <asp:Label ID="lblShippingPhoneNumber" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Billing Address :
                <asp:Label ID="lblBillingAddress" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Shipping Address :
                <asp:Label ID="lblShippingAddress" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Amount :
                <asp:Label ID="lblAmount" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                IPN Number :
                <asp:Label ID="lblIPNNumber" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
         <tr>
            <td align="left">
                <asp:LinkButton runat="server" ID="lnkOrderDetail">Add</asp:LinkButton>
            </td>
            <td align="right">
                <asp:LinkButton runat="server" ID="lnkManageOrder">Back</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvOrderDetail" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="OrderDetailId" DataSourceID="odsOrderDetail"
                    ShowFooter="True">
                    <Columns>
                        <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
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
                <asp:ObjectDataSource ID="odsOrderDetail" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByOrder" TypeName="ds_OrderDetailTableAdapters.OrderDetailTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_OrderDetailId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="OrderId" Type="Int64" />
                        <asp:Parameter Name="ProductId" Type="Int64" />
                        <asp:Parameter Name="Quantity" Type="Int32" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="Original_OrderDetailId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="OrderId" Type="Int64" />
                        <asp:Parameter Name="ProductId" Type="Int64" />
                        <asp:Parameter Name="Quantity" Type="Int32" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="0" Name="OrderId" QueryStringField="OID"
                            Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
