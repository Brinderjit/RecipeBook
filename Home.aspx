<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>
<%--Brinderjit Singh StudentId=300918321 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:100%;height:300px;padding-top:10px"><asp:AdRotator ID="AdRotator1" CssClass="rotator" runat="server" AdvertisementFile="Content/advertisement.xml"/></div>
    <div class="description"><div class="content1"><h3>Welcome to Recipe Book</h3><p>Recipe Book allows you to add your innovative Recipes to online recipe book.You just need to have an account on recipe book website and you can post as many recipes as you want.Your recipe will get rated by other people.Recipe Book also allows you to Search recipes posted by other users.You can view highly rated recipies according to their ranking.Different Chef have posted their master piece on Recipe book</p></div></div>
    <div>
    <div class="content2"><h3>Caesar</h3>
        <asp:Image ID="recipeImg" CssClass="tileImages" ImageUrl="Content/Images/caesar.jpg" runat="server" /><p>A Caesar or Bloody Caesar is a cocktail created and primarily consumed in Canada. It typically contains vodka, Clamato (a proprietary blend of tomato juice and clam broth), hot sauce and Worcestershire sauce, and is served with ice in a large, celery salt-rimmed glass.</p></div>
    <div class="content2"><h3>Fried sweet dough</h3>
        <asp:Image ID="recipeImg1" CssClass="tileImages" ImageUrl="Content/Images/fried-douph.jpg"  runat="server" /><p>So, you think you need a deep fryer and some kind of special county fair chef expertise to make fried dough? Think again! This easy version uses a simple baking powder dough, and fries in just 1/4" of vegetable oil — no messy deep frying necessary.</p></div>
        <div class="content2"><h3>Fried sweet dough</h3>
        <asp:Image ID="recipeImg2" CssClass="tileImages" ImageUrl="Content/Images/Poutine.jpg"  runat="server" /><p>Poutine is a Canadian dish, originating in the province of Québec, made with French fries and cheese curds topped with a light brown gravy.</p></div>
        </div>
</asp:Content>
