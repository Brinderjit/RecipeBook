<%@ Page  Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Recipes.aspx.cs" Inherits="Recipes" %>
<%--Brinderjit Singh StudentId=300918321 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- <link href="Content/recipe.css" rel="stylesheet" />-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div><h1>RECIPES</h1>
         
     </div><div class="datagrid">
         <asp:GridView ID="RecipeGrid" runat="server" AutoGenerateColumns="False" CellPadding="10" EnableTheming="True" ForeColor="#000099" GridLines="None" HorizontalAlign="Center" DataKeyNames="RecipeId" OnSelectedIndexChanged="RecipeGrid_SelectedIndexChanged" Width="100%" Font-Names="Arial">
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
                 <asp:TemplateField HeaderText="Name">
                     <ItemTemplate>
                         <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#"RecipeDetails.aspx?Id=" + Eval("RecipeId") %>' Text='<%# Eval("Name") %>'></asp:HyperLink>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="SubmittedBy" DataField="SubmittedBy" InsertVisible="False"></asp:BoundField>
                 <asp:BoundField HeaderText="Category" DataField="Category"></asp:BoundField>
                 <asp:BoundField HeaderText="Cook Time" DataField="CookTime"></asp:BoundField>
                 <asp:BoundField DataField="noservings" HeaderText="Number of Servings" />
                 <asp:BoundField DataField="description" HeaderText="Description" />
                 
             </Columns>
             
             <EditRowStyle BackColor="#999999" />
             <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="15px" />
             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="15px" />
             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             <SortedAscendingCellStyle BackColor="#E9E7E2" />
             <SortedAscendingHeaderStyle BackColor="#506C8C" />
             <SortedDescendingCellStyle BackColor="#FFFDF8" />
             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
             
         </asp:GridView>
    
   </div>
    
</asp:Content>
<%--Brinderjit Singh StudentId=300918321 --%>
