<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ManageCountry.aspx.vb" Inherits="Admin_ManageCountry" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Country</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ForeColor="#C04000" ID="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkCountry" NavigateUrl="~/Admin/Country.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="heading">
                Country :
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvCountry" runat="server" EnableSortingAndPagingCallbacks="True"
                    AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CountryId"
                    DataSourceID="odsCountry">
                    <Columns>
                        <asp:BoundField DataField="CountryName" HeaderText="Country" SortExpression="CountryName" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="CountryId,CountryName" DataNavigateUrlFormatString="~/Admin/Country.aspx?Id={0}&amp;CountryName={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCountry" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="ds_CountryTableAdapters.CountryTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CountryId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CountryName" Type="String" />
                        <asp:Parameter Name="Original_CountryId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CountryName" Type="String" />
                    </InsertParameters>
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
