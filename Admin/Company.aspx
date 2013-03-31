<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Company.aspx.vb" Inherits="Admin_Company" Title="Company" Theme="AdminTheme" %>

<asp:Content ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
   <h2 align="center" class="heading">
        Company</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Company</td>
            <td>
                <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ControlToValidate="txtCompanyName"
                    ErrorMessage="Please enter company." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCompanyName" runat="server" ControlToValidate="txtCompanyName"
                    ErrorMessage="Please enter valid company." ValidationExpression="[A-Z,a-z, ]*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                Address</td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="Please enter address." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Phone Number</td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                    ErrorMessage="Please enter phone number." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                    ErrorMessage="Please enter valid phone number." ValidationExpression="\w{10}"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                Country
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                    ErrorMessage="Please select country." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                State
            </td>
            <td>
                <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                    ErrorMessage="Please select state." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                City</td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" Width="155px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                    ErrorMessage="Please select city." ValidationGroup="vgLogIn" InitialValue="0">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Website</td>
            <td>
                <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvWebsite" runat="server" ControlToValidate="txtWebsite"
                    ErrorMessage="Please enter website." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revWebsite" runat="server" ControlToValidate="txtWebsite"
                    ErrorMessage="Please enter valid website." ValidationExpression="([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                Email Id</td>
            <td>
                <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailId" runat="server" ControlToValidate="txtEmailId"
                    ErrorMessage="Please enter email id." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailId" runat="server" ControlToValidate="txtEmailId"
                    ErrorMessage="Please enter valid email id." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td>
                Is Active</td>
            <td>
                <asp:CheckBox ID="chkIsActive" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsCompany" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
