<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    Theme="AdminTheme" CodeFile="ManageCity.aspx.vb" Inherits="Admin_ManageCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage City</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 21px">
                <asp:Label runat="server" ForeColor="#C04000" ID="lblMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkCity" NavigateUrl="~/Admin/City.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="center" class="heading">
            City :
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            &nbsp; State :
            <asp:DropDownList ID="ddlState" runat="server">
            </asp:DropDownList>
            &nbsp; &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvCity" runat="server" EnableSortingAndPagingCallbacks="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="CityId" DataSourceID="odsCity">
                    <Columns>
                        <asp:BoundField DataField="CityName" HeaderText="City" SortExpression="CityName" />
                        <asp:BoundField DataField="StateName" HeaderText="State" SortExpression="StateName" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="CityId,CityName" DataNavigateUrlFormatString="~/Admin/City.aspx?Id={0}&amp;CityName={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsCity" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_CityTableAdapters.CityTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_CityId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="CityName" Type="String" />
                        <asp:Parameter Name="StateId" Type="Int64" />
                        <asp:Parameter Name="Original_CityId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CityName" Type="String" />
                        <asp:Parameter Name="StateId" Type="Int64" />
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
