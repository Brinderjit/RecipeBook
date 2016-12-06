<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="vs_RecipeBook_Search" %>
<%--Brinderjit Singh StudentId=300918321 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link href="Content/recipe.css" rel="stylesheet" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><h2>RECIPES SEARCH</h2>
         
     </div>
    <asp:Label ID="lblcategory" CssClass="label" Width="100px" text="RecipeCategory" runat="server" ></asp:Label>
      <asp:DropDownList ID="category" runat="server" CssClass="textres" ViewStateMode="Enabled" OnSelectedIndexChanged="Name_SelectedIndexChanged" ></asp:DropDownList>
    <asp:Label ID="lblSubmittedBy" CssClass="label" Width="100px" text="Submitted By" runat="server" ></asp:Label>
    <asp:DropDownList ID="SubmittedBy" runat="server" CssClass="textres" ViewStateMode="Enabled" ></asp:DropDownList>
    <asp:Label ID="lblIngName" CssClass="label" Width="100px" text="Ingredient Name" runat="server" ></asp:Label>
<asp:DropDownList ID="Ingredients" runat="server" CssClass="textres" ViewStateMode="Enabled" ></asp:DropDownList>
    <br />
    <asp:Button ID="submit" runat="server" Text="Submit" CssClass="button" OnClick="submit_Click" />
  <br />
    <br />
       <div>
    <asp:GridView ID="searchGrid" runat="server"  CellPadding="7" ForeColor="#333333" GridLines="None" Width="50%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="15px" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Overline="False" Font-Size="15px" HorizontalAlign="Center"  />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
           </div>
      
</asp:Content>


<%--Brinderjit Singh StudentId=300918321 --%>