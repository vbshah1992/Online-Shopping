<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ManageCompany.aspx.vb" Inherits="Admin_ManageCompany" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Company</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ForeColor="#C04000" ID="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkCompany" NavigateUrl="~/Admin/Company.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="heading">
                Company :
                <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
                &nbsp; City :
                <asp:DropDownList ID="ddlCity" runat="server">
                </asp:DropDownList>
                &nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvCompany" runat="server" EnableSortingAndPagingCallbacks="True" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="CompanyId" DataSourceID="odsCompany">
                    <Columns>
                        <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="PhoneNumber" />
                        <asp:BoundField DataField="CityName" HeaderText="City" SortExpression="CityName" />
                        <asp:BoundField DataField="Website" HeaderText="Website" SortExpression="Website" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email Id" SortExpression="EmailId" />
                        <asp:ButtonField Text="Edit" CommandName="IsActive" HeaderText="Is Active" SortExpression="IsActive" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="CompanyId,CompanyName" DataNavigateUrlFormatString="~/Admin/Company.aspx?Id={0}&amp;CompanyName={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCompany" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_CompanyTableAdapters.CompanyTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CompanyId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="PhoneNumber" Type="String" />
                        <asp:Parameter Name="CityId" Type="Int64" />
                        <asp:Parameter Name="Website" Type="String" />
                        <asp:Parameter Name="EmailId" Type="String" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
                        <asp:Parameter Name="Original_CompanyId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CompanyName" Type="String" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="PhoneNumber" Type="String" />
                        <asp:Parameter Name="CityId" Type="Int64" />
                        <asp:Parameter Name="Website" Type="String" />
                        <asp:Parameter Name="EmailId" Type="String" />
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
