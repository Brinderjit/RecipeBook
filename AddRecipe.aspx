<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddRecipe.aspx.cs" Inherits="AddRecipe" %>
<%--Brinderjit Singh StudentId=300918321 --%>
<%@ Register Src="~/InlistControl.ascx" TagPrefix="uc1" TagName="InlistControl" %>

<%@ Reference Control="~/InlistControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="Content/recipe.css" rel="stylesheet" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
     <div class="container1"><h2 style="padding-left: 20px;">ADD NEW RECIPE</h2>
         <div style="padding-top: 20px;padding-left: 20px;">
         <asp:Label ID="lblName" runat="server" CssClass="label" Width="100px" Text="Name of recipe:"></asp:Label>
         <asp:TextBox ID="txtName" runat="server" CssClass="textres"></asp:TextBox><asp:RequiredFieldValidator ID="nameValidator" CssClass="validation" runat="server" ErrorMessage="Name is required" ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
         <br /><br />
          <asp:Label ID="lblSubmitedby" runat="server" CssClass="label" Width="100px" Text="Submitted By:"></asp:Label>
         <asp:TextBox ID="txtSubmittedby" runat="server" CssClass="textres"></asp:TextBox><asp:RequiredFieldValidator ID="subValidator"  CssClass="validation" runat="server" ErrorMessage="Submitted by is required" ControlToValidate="txtSubmittedby" Display="Dynamic"></asp:RequiredFieldValidator>
         <br /><br />
         <asp:Label ID="lblCategory" runat="server" CssClass="label" Width="100px" Text="Category:"></asp:Label>
         <asp:TextBox ID="txtCategory" runat="server" CssClass="textres"></asp:TextBox>
         <br /><br />
         <asp:Label ID="lblCooktm" runat="server" CssClass="label" Width="100px" Text="Cooking Time:"></asp:Label>
         <asp:TextBox ID="txtCooktm" runat="server" CssClass="textres"></asp:TextBox><asp:RegularExpressionValidator ID="timeValid"  CssClass="validation" ControlToValidate="txtCooktm" runat="server" ErrorMessage="Cooking time should be a number" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
         <br /><br />
          <asp:Label ID="lblServings" runat="server" CssClass="label" Width="100px" Text="Number of Servings:"></asp:Label>
         <asp:TextBox ID="txtServings" runat="server" CssClass="textres"></asp:TextBox><asp:RequiredFieldValidator ID="servValidator"  CssClass="validation" runat="server" ErrorMessage="Number of servings required" Display="Dynamic" ControlToValidate="txtServings">

                                                                                       </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="validation" ControlToValidate="txtServings" runat="server" ErrorMessage="Serving should be a number" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
         <br /><br />
         <asp:Label ID="lblDescription" runat="server" CssClass="label" Width="100px" Text="Recipe description:"></asp:Label>
         <asp:TextBox ID="txtDescription" runat="server" TextMode="multiline" Columns="50" Rows="5" CssClass="textres"></asp:TextBox><asp:RequiredFieldValidator ID="descValidator"  CssClass="validation" runat="server" ErrorMessage="Recipe Description" ControlToValidate="txtDescription" Display="Dynamic"></asp:RequiredFieldValidator>
         <br /><br />
        
             <h1 style="padding-top:10px">List of Ingredients</h1>
             <div>
                 <div style="padding-top:10px">
         <asp:placeholder id="IngConatainer"  runat="server" >
         <uc1:InlistControl runat="server" id="UserControlIn0" LblInName="Name"   LblInQuantity="Quantity"/> 
            
         </asp:placeholder>
                     </div> <div style="width:20%;float:right"> <asp:Button ID="add" runat="server" Text="Add" OnClick="Button_Add" CssClass="buttonadd" CausesValidation="False" />
             <asp:Button ID="remove" runat="server" Text="Remove" OnClick="Button_Remove" CssClass="buttonadd" CausesValidation ="false"  /></div></div>
            
         <br /><br />
             <asp:Label ID="Status" runat="server" Font-Size="Medium" ForeColor="#FF3300"></asp:Label><br /><br />
         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button" /><asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"/>
             </div>
     </div>
       
</asp:Content>

<%--Brinderjit Singh StudentId=300918321 --%>