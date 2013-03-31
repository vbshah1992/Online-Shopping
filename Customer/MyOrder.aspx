<%@ Page Language="VB" MasterPageFile="~/Master/CustomerMaster.master" AutoEventWireup="false"
    CodeFile="MyOrder.aspx.vb" Inherits="Customer_MyOrder" Theme="CustomerTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphCustomer" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    My Order</h2>
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
                <asp:GridView ID="gvOrder" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="OrderId" DataSourceID="odsOrder">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgRuppes" runat="server" Height="14px" ImageUrl="~/Images/Rupee.gif"
                                    Width="20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate"
                            DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:CheckBoxField DataField="IsDelivered" HeaderText="Is Delivered" SortExpression="IsDelivered" />
                        <asp:HyperLinkField Text="Details" DataNavigateUrlFields="OrderId" DataNavigateUrlFormatString="~/Customer/MyOrderDetail.aspx?OID={0}"
                            HeaderText="Details" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsOrder" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCustomerId"
                    TypeName="ds_OrderTableAdapters.OrderTableAdapter" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_OrderId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CustomerId" Type="Int64" />
                        <asp:Parameter Name="Amount" Type="Decimal" />
                        <asp:Parameter Name="OrderDate" Type="DateTime" />
                        <asp:Parameter Name="DeliverDate" Type="DateTime" />
                        <asp:Parameter Name="BillingAddress" Type="String" />
                        <asp:Parameter Name="BillingPhoneNumber" Type="String" />
                        <asp:Parameter Name="ShippingAddress" Type="String" />
                        <asp:Parameter Name="ShippingPhoneNumber" Type="String" />
                        <asp:Parameter Name="IPNNumber" Type="String" />
                        <asp:Parameter Name="IsDelivered" Type="Boolean" />
                        <asp:Parameter Name="IsComplete" Type="Boolean" />
                        <asp:Parameter Name="Original_OrderId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CustomerId" Type="Int64" />
                        <asp:Parameter Name="Amount" Type="Decimal" />
                        <asp:Parameter Name="OrderDate" Type="DateTime" />
                        <asp:Parameter Name="DeliverDate" Type="DateTime" />
                        <asp:Parameter Name="BillingAddress" Type="String" />
                        <asp:Parameter Name="BillingPhoneNumber" Type="String" />
                        <asp:Parameter Name="ShippingAddress" Type="String" />
                        <asp:Parameter Name="ShippingPhoneNumber" Type="String" />
                        <asp:Parameter Name="IPNNumber" Type="String" />
                        <asp:Parameter Name="IsDelivered" Type="Boolean" />
                        <asp:Parameter Name="IsComplete" Type="Boolean" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="CustomerId" SessionField="CUSTOMERID"
                            Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
