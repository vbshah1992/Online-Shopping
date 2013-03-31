<%@ Page Language="VB" AutoEventWireup="false" Title="Submmit To Gateway"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>

<!-- <form action="https://www.paisapay.com/cgi-bin/webscr" method="post" id="submit" > -->
<form  action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" name="frmSubmit">
<input type="hidden" name="cmd" value="_xclick" />
<input type="hidden" name="business" value="vbshah1992@gmail.co.in" /> 
<input type="hidden" name="return" value="http://59.144.101.190/OnlineShopping/Customer/ThankYou.aspx?MsgId=6" />

<input type="hidden" name="item_name" value="<%=Request.QueryString("DETAILS")%>" />
<input type="hidden" name="amount" value="<%=Request.QueryString("AMOUNT")%>" />
<input type="hidden" name="custom" value="<%=Request.QueryString("OID")%>" />

<input type="hidden" name="charset" value="utf-8" />
<input type="hidden" name="notify_url" value="http://59.144.101.190/OnlineShopping/Customer/ThankYou.aspx" />
<input type="hidden" name="no_shipping" value="0" />
<input type="hidden" name="cancel_return" value="http://59.144.101.190/OnlineShopping/Customer/ListShoppingCart.aspx" />
<input type="hidden" name="no_note" value="0" />
<input type="hidden" name="rm" value="2" />
</form>
<script language="javascript" type="text/javascript" >
document.frmSubmit.submit();
</script>
</body>
</html>