<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SetupPage.aspx.cs" Inherits="SetupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Content/recipe.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content1"><h1>Select Theme </h1>
    <asp:Label ID="Label1" CssClass="label" runat="server" Text="Dark:"></asp:Label><asp:RadioButton ID="darkRadio" runat="server" GroupName="theme" /><br />
        </br><asp:Label ID="Label2" CssClass="label" runat="server" Text="Light:" ></asp:Label><asp:RadioButton ID="lightRadio"  runat="server" GroupName="theme" />
    <br /><asp:Button ID="save" runat="server" Text="save"  CssClass="button" OnClick="save_Click"/></div>
</asp:Content>

