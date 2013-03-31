<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="City.aspx.vb" Inherits="Admin_City" Title="City" Theme="AdminTheme" %>

<asp:Content ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
   <h2 align="center" class="heading">City</h2>
    <table align="center" class="text">        
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>     
           <tr>
            <td>
                Country
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                    ErrorMessage="Please select country." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                State
            </td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                    ErrorMessage="Please select state." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                City
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="Please enter city." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCity" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="Please enter valid city." ValidationExpression="[A-Z,a-z, ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsCity" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
