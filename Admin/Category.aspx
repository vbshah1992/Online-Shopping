<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Category.aspx.vb" Inherits="Admin_Category" Title="Category" Theme="AdminTheme" %>

<asp:Content ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2 align="center" class="heading">
                Category</h2>
            <table align="center" class="text">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Parent Category
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlParentCategory" runat="server" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvParentCategory" runat="server" ControlToValidate="ddlParentCategory"
                            ErrorMessage="Please select parent category." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>
                        Category
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategoryName" runat="server" Width="195px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" ControlToValidate="txtCategoryName"
                            ErrorMessage="Please enter category." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCategoryName" runat="server" ControlToValidate="txtCategoryName"
                            ErrorMessage="Please enter valid category." ValidationExpression="[A-Z,a-z, ]*"
                            ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:ValidationSummary ID="vsCategory" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True"
                            ShowSummary="False" />
                    </td>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
