<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Image.aspx.vb" Inherits="Admin_Image" Title="Image" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
     <h2 align="center" class="heading">
        Image</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" runat="server" id="tdImage">
                <asp:Image ID="imgProduct" runat="server" Height="200px" Width="200px" /></td>
        </tr>
        <tr>
            <td align="right" colspan="2" runat="server" id="tdDelete">
                <asp:LinkButton runat="server" ID="lnkDelete" Text="Delete"></asp:LinkButton></td>
        </tr>
        <tr>
            <td>
                Title</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                    ErrorMessage="Please enter title." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTitle" runat="server" ControlToValidate="txtTitle"
                    ErrorMessage="Please enter valid  title." ValidationExpression="[A-Z,a-z, ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Product
            </td>
            <td>
                <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="ddlProduct"
                    ErrorMessage="Please select product." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Product Image</td>
            <td id="tdfupImage" runat="server">
                &nbsp;<asp:FileUpload ID="fupImage" runat="server" />&nbsp;
                <asp:RequiredFieldValidator ID="rfvfupImage" runat="server" ControlToValidate="fupImage"
                    ErrorMessage="Please select image." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Is Cover Image</td>
            <td>
                <asp:CheckBox ID="chkIsCoverImage" runat="server" /></td>
        </tr>
        <tr>
            <td>
                Is Visible</td>
            <td>
                <asp:CheckBox ID="chkIsVisible" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 49px">
                <asp:ValidationSummary ID="vsImage" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True"
                    ShowSummary="False" />
            </td>
        </tr>
    </table>
</asp:Content>
