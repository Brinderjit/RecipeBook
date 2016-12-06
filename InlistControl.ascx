<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InlistControl.ascx.cs" Inherits="InlistControl" %>
<p>
    <asp:Label ID="lblInName" CssClass="label"  runat="server" Text="Name:" ></asp:Label>
    <asp:TextBox ID="txtInName"  runat="server" CssClass="textres"></asp:TextBox><asp:RequiredFieldValidator ID="InNameValid" CssClass="validation" ControlToValidate="txtInName" runat="server" ErrorMessage="Name required" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:Label ID="lblInQuantity" CssClass="label"  runat="server" Text="Quantity:" ></asp:Label>
    <asp:TextBox ID="txtInquantity"  runat="server" CssClass="textres"></asp:TextBox><asp:RegularExpressionValidator ID="quantityValid" CssClass="validation" ControlToValidate="txtInquantity" runat="server" ErrorMessage="Quantity should be a number" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
     <asp:Label ID="lblInMeasure" CssClass="label"  runat="server" Text="Units of Measure:" ></asp:Label>
    <asp:TextBox ID="txtInMeasure" runat="server" CssClass="textres"></asp:TextBox>
</p>