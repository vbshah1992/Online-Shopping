<%@ Page Language="VB" MasterPageFile="~/Master/AdminMaster.master" AutoEventWireup="false"
    CodeFile="Order.aspx.vb" Inherits="Admin_Order" Title="Order" Theme="AdminTheme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
  <h2 align="center" class="heading">
        Order</h2>
    <table align="center" class="text">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#C04000"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Customer</td>
            <td>
                <asp:DropDownList ID="ddlCustomer" runat="server" Width="155px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="rfvCustomer" runat="server" ControlToValidate="ddlCustomer"
                    ErrorMessage="Please select customer." InitialValue="0" ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator></td>
        </tr>        
        <tr>
            <td>
                Order Date</td>
            <td>
                <asp:TextBox ID="txtOrderDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="imgCalendar2" ImageUrl="~/Images/Calendar.png"
                    AlternateText="Click to show calendar" /><br />
                <atk:CalendarExtender ID="calendarButtonExtender2" runat="server" TargetControlID="txtOrderDate"
                    PopupButtonID="imgCalendar2" />
                <asp:RequiredFieldValidator ID="rfvOrderDate" runat="server" ControlToValidate="txtOrderDate"
                    ErrorMessage="Please enter order date." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvOrderDate" runat="server" ControlToValidate="txtOrderDate"
                    ErrorMessage="Please enter valid order date." ValidationGroup="vgLogIn" Operator="DataTypeCheck"
                    Type="Date">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td>
                Delivery Date</td>
            <td>
                <asp:TextBox ID="txtDeliveryDate" runat="server"></asp:TextBox>
                <asp:ImageButton runat="Server" ID="imgCalendar3" ImageUrl="~/Images/Calendar.png"
                    AlternateText="Click to show calendar" /><br />
                <atk:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDeliveryDate"
                    PopupButtonID="imgCalendar3" />
                <asp:RequiredFieldValidator ID="rfvDeliveryDate" runat="server" ControlToValidate="txtDeliveryDate"
                    ErrorMessage="Please enter delivery date." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Billing Address</td>
            <td>
                <asp:TextBox ID="txtBillingAddress" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvBillingAddress" runat="server" ControlToValidate="txtBillingAddress"
                    ErrorMessage="Please enter billing address." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                Billing Phone Number</td>
            <td>
                <asp:TextBox ID="txtBillingPhoneNumber" runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvBillingPhoneNumber" runat="server" ControlToValidate="txtBillingPhoneNumber"
                    ErrorMessage="Please enter billing phone number." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revBillingPhoneNumber" runat="server" ControlToValidate="txtBillingPhoneNumber"
                    ErrorMessage="Please enter valid billing phone number" ValidationExpression="\w{10}"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td>
                Shipping Address</td>
            <td>
                <asp:TextBox ID="txtShippingAddress" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvShippingAddress" runat="server" ControlToValidate="txtShippingAddress"
                    ErrorMessage="Please enter shipping address." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td>
                Shipping Phone Number</td>
            <td>
                <asp:TextBox ID="txtShippingPhoneNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvShippingPhoneNumber" runat="server" ControlToValidate="txtShippingPhoneNumber"
                    ErrorMessage="Please enter shipping phone number." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>&nbsp;
               <asp:RegularExpressionValidator ID="revShippingPhoneNumber" runat="server" ControlToValidate="txtShippingPhoneNumber"
                    ErrorMessage="Please enter valid shipping phone number" ValidationExpression="\w{10}"
                    ValidationGroup="vgLogIn">*</asp:RegularExpressionValidator>
             </td>
        </tr>
     <tr>
         <td>
             IPN Number</td>
         <td>
             <asp:TextBox ID="txtIPNNumber" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvIPNNumber" runat="server" ControlToValidate="txtIPNNumber"
                 ErrorMessage="Please enter ipn number." ValidationGroup="vgLogIn">*</asp:RequiredFieldValidator>
         </td>
     </tr>
        <tr>
            <td style="height: 22px">
                IsDelivered</td>
            <td style="height: 22px">
                <asp:CheckBox ID="chkIsDelivered" runat="server" /></td>
        </tr>
        <tr>
            <td>
                Is Complete</td>
            <td>
                <asp:CheckBox ID="chkIsComplete" runat="server" /></td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vgLogIn" />
                <asp:Button ID="btncancel" runat="server" Text="Cancel" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="vsOrder" runat="server" ValidationGroup="vgLogIn" ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
