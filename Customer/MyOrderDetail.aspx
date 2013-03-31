<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false"
    CodeFile="MyOrderDetail.aspx.vb" Inherits="Customer_MyOrderDetail" Theme="CustomerTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td>
                <table width="100%" class="text">
                    <tr>
                        <td align="center" colspan="2">
                            <h2 class="heading">
                                My Order Detail</h2>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:LinkButton runat="server" ID="lnkManageOrder">Back</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Billing Phone Number :
                        </td>
                        <td>
                            <asp:Label ID="lblBillingPhoneNumber" runat="server" ForeColor="#C04000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Billing Address :
                        </td>
                        <td>
                            <asp:Label ID="lblBillingAddress" runat="server" ForeColor="#C04000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Shipping Phone Number :
                        </td>
                        <td>
                            <asp:Label ID="lblShippingPhoneNumber" runat="server" ForeColor="#C04000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Shipping Address :
                        </td>
                        <td>
                            <asp:Label ID="lblShippingAddress" runat="server" ForeColor="#C04000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Amount :
                        </td>
                        <td>
                            <asp:Label ID="lblAmount" runat="server" ForeColor="#C04000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            IPN Number :
                        </td>
                        <td>
                            <asp:Label ID="lblIPNNumber" runat="server" ForeColor="#C04000"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" class="text">
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
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Image ID="imgRuppes" runat="server" Height="14px" ImageUrl="~/Images/Rupee.gif"
                                                Width="20px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                                    <asp:TemplateField HeaderText="Total Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalPrice" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:TemplateField>
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
            </td>
        </tr>
    </table>
</asp:Content>
