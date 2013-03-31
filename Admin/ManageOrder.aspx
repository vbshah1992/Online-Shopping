<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ManageOrder.aspx.vb" Inherits="Admin_ManageOrder" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Order</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkOrder" NavigateUrl="~/Admin/Order.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="heading">
                Customer :&nbsp;
                <asp:DropDownList ID="ddlCustomer" runat="server">
                </asp:DropDownList><br />
                From Date :
                <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ic1" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" />
                <atk:CalendarExtender ID="cbe1" runat="server" TargetControlID="txtFromDate" PopupButtonID="ic1" />
                &nbsp; To Date :
                <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="ic2" ImageUrl="~/Images/Calendar.png" AlternateText="Click to show calendar" />
                <atk:CalendarExtender ID="ce2" runat="server" TargetControlID="txtToDate" PopupButtonID="ic2" />
                <asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvOrder" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="OrderId" DataSourceID="odsOrder">
                    <Columns>
                        <asp:BoundField DataField="FirstName" HeaderText="Customer" SortExpression="FirstName" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="imgRuppes" runat="server" Height="15px" ImageUrl="~/Images/rup.png"
                                    Width="15px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate"
                            DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField="DeliverDate" HeaderText="Deliver Date" SortExpression="DeliverDate"
                            DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:ButtonField Text="Edit" CommandName="IsDelivered" HeaderText="Is Delivered"
                            SortExpression="IsDelivered" />
                        <asp:ButtonField Text="Edit" CommandName="IsComplete" HeaderText="Is Complete" SortExpression="IsComplete" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="OrderId" DataNavigateUrlFormatString="~/Admin/Order.aspx?ID={0}"
                            HeaderText="Edit" />
                        <asp:HyperLinkField Text="Details" DataNavigateUrlFields="OrderId" DataNavigateUrlFormatString="~/Admin/ManageOrderDetail.aspx?OID={0}"
                            HeaderText="Details" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsOrder" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_OrderTableAdapters.OrderTableAdapter"
                    UpdateMethod="Update">
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
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnExport" runat="server" Text="Export" />
            </td>
        </tr>
    </table>
</asp:Content>
