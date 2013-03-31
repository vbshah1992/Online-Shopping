<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="ManageAdmin.aspx.vb" Inherits="Admin_ManageAdmin" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>--%>
    <table width="100%" class="text">
        <tr>
            <td align="center" colspan="2">
                <h2 class="heading">
                    Manage Admin</h2>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label runat="server" ID="lblMessage" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="tdCount" align="center">
                <asp:Label ID="lblCount" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="heading">
                First Or Last Name :
                <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>&nbsp; City : &nbsp;<asp:DropDownList
                    ID="ddlCity" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink runat="server" ID="hlkAdmin" NavigateUrl="~/Admin/Admin.aspx">Add</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="height: 312px" valign="top">
                <asp:GridView ID="gvAdmin" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" DataKeyNames="AdminId" DataSourceID="odsAdmin">
                    <Columns>
                        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
                            <ItemTemplate>
                                <%#Eval("FirstName") %>
                                <%#Eval("LastName") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" SortExpression="DateOfBirth"
                            DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField="CityName" HeaderText="City" SortExpression="CityName" />
                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" SortExpression="ContactNumber" />
                        <asp:BoundField DataField="EmailId" HeaderText="Email Id" SortExpression="EmailId" />
                        <asp:ButtonField Text="Edit" CommandName="IsActive" HeaderText="Is Active" SortExpression="IsActive" />
                        <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="AdminId,FirstName" DataNavigateUrlFormatString="~/Admin/Admin.aspx?Id={0}&amp;FirstName={1}"
                            HeaderText="Edit" />
                        <asp:CommandField ShowDeleteButton="True" HeaderText="Delete" />
                         <%--<asp:TemplateField>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <a id="A1" href="Admin.aspx" target="_blank" runat="server">Home</a>
                                        </td>
                                    </tr>
                                </table>
                                </tr></ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="odsAdmin" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetDetails" TypeName="ds_AdminTableAdapters.AdminTableAdapter"
                    UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="Original_AdminId" Type="Int64" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="DateOfBirth" Type="DateTime" />
                        <asp:Parameter Name="Address" Type="String" />
                        <asp:Parameter Name="CityId" Type="Int64" />
                        <asp:Parameter Name="PinCode" Type="String" />
                        <asp:Parameter Name="PhoneNumber" Type="String" />
                        <asp:Parameter Name="ContactNumber" Type="String" />
                        <asp:Parameter Name="EmailId" Type="String" />
                        <asp:Parameter Name="Password" Type="String" />
                        <asp:Parameter Name="IsActive" Type="Boolean" />
                        <asp:Parameter Name="Original_AdminId" Type="Int64" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="FirstName" Type="String" />
                        <asp:Parameter Name="LastName" Type="String" />
                        <asp:Parameter Name="DateOfBirth" Type="DateTime" />
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
    <%--</contenttemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
