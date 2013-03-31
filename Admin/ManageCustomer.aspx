<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    Theme="AdminTheme" CodeFile="ManageCustomer.aspx.vb" Inherits="Admin_ManageCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Customer</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label runat="server" ForeColor="#C04000" ID="lblMessage"></asp:Label>
            </td>
        </tr>       
        <tr>
            <td colspan="2" align="center" class="heading">
                First Or Last Name :
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp; City : &nbsp;<asp:DropDownList ID="ddlCity" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
         <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkAdmin" NavigateUrl="~/Admin/Customer.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvCustomer" runat="server"  AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="CustomerId" DataSourceID="odsCustomer">
                    <Columns>
                        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                            <ItemTemplate>
                                <%#Eval("FirstName") %>
                                <%#Eval("LastName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CityName" HeaderText="City" SortExpression="CityName" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email Id" SortExpression="EmailId" />
                        <asp:ButtonField Text="Edit" CommandName="IsActive" HeaderText="Is Active" SortExpression="IsActive" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="CustomerId,FirstName" DataNavigateUrlFormatString="~/Admin/Customer.aspx?Id={0}&amp;FirstName={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCustomer" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_CustomerTableAdapters.CustomerTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CustomerId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="CityId" Type="Int64" />
                        <asp:Parameter Name="PinCode" Type="String" />
                        <asp:Parameter Name="PhoneNumber" Type="String" />
                        <asp:Parameter Name="ContactNumber" Type="String" />
                        <asp:Parameter Name="EmailId" Type="String" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
                        <asp:Parameter Name="Original_CustomerId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="CityId" Type="Int64" />
                        <asp:Parameter Name="PinCode" Type="String" />
                        <asp:Parameter Name="PhoneNumber" Type="String" />
                        <asp:Parameter Name="ContactNumber" Type="String" />
                        <asp:Parameter Name="EmailId" Type="String" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
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
