<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecipeDetails.aspx.cs" Inherits="RecipeDetails" %>
<%--Brinderjit Singh StudentId=300918321 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Content/recipe.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>RECIPE</h1>
    
    <br />
    <asp:DetailsView ID="recipeGrid" runat="server" Height="40%" Width="40%" CellPadding="7" ForeColor="#333333" GridLines="None"  AutoGenerateRows="False" OnModeChanging="recipeGrid_ModeChanging" DataKeyNames="recipeid" OnItemUpdating="recipeGrid_ItemUpdating" OnPageIndexChanging="recipeGrid_PageIndexChanging" Font-Names="Arial" OnDataBinding="recipeGrid_DataBinding" OnDataBound="recipeGrid_DataBound" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="White" Font-Size="15px" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:TemplateField HeaderText="NAME">
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox><asp:RequiredFieldValidator ID="nameValidator"  ValidationGroup="recipeGroup" CssClass="validation" runat="server" ErrorMessage="Name is required" ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="SUBMITTED BY">
               
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("submittedby") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="CATEGORY">
                <EditItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnDataBinding="DropDownList1_DataBinding" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>   
                    <asp:TextBox ID="txtCategory" runat="server" Text='<%# Bind("Category") %>' ></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtCategory" runat="server" Text='<%# Bind("Category") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="COOKING TIME">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCooktime" runat="server" Text='<%# Bind("cooktime") %>'></asp:TextBox><asp:RegularExpressionValidator ID="timeValid"  CssClass="validation" ControlToValidate="txtCooktime" runat="server" ErrorMessage="*"  ValidationGroup="recipeGroup" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtCooktime" runat="server" Text='<%# Bind("cooktime") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCooktime" runat="server" Text='<%# Bind("cooktime") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NUMBER OF SERVING">
                <EditItemTemplate>
                    <asp:TextBox ID="txtnoofserving" runat="server" Text='<%# Bind("noservings") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="servValidator"  CssClass="validation"  ValidationGroup="recipeGroup" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtnoofserving">

                                                                                       </asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ValidationGroup="recipeGroup" CssClass="validation" ControlToValidate="txtnoofserving" runat="server" ErrorMessage="*" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtnoofserving" runat="server" Text='<%# Bind("noservings") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblnoofserving" runat="server" Text='<%# Bind("noservings") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DESCRIPTION">
                <EditItemTemplate>
                    <asp:TextBox ID="txtdescription" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="descValidator"  CssClass="validation" runat="server"  ValidationGroup="recipeGroup" ErrorMessage="*" ControlToValidate="txtdescription" Display="Dynamic"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="txtdescription" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbldescription" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True"  ButtonType="Button"  ControlStyle-CssClass="buttonadd" CausesValidation="true" ValidationGroup="recipeGroup">
<ControlStyle CssClass="buttonadd"></ControlStyle>
            </asp:CommandField>
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="15px" />
    </asp:DetailsView>
    <br />
    <br />
    <h1>INGEDIENTS</h1>
    <br />
    <asp:GridView ID="IngredientsGrid" runat="server" CellPadding="7" DataKeyNames="INGID" GridLines="None" AutoGenerateColumns="False" Width="75%" OnRowEditing="IngredientsGrid_RowEditing" OnSelectedIndexChanged="IngredientsGrid_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" BackColor="White" EmptyDataText="No Ingredients Found" OnRowCancelingEdit="IngredientsGrid_RowCancelingEdit1" OnRowUpdating="IngredientsGrid_RowUpdating" ShowFooter="True" OnRowCommand="IngredientsGrid_RowCommand" Font-Names="Arial">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" HorizontalAlign="Center" />
        <Columns>
            <asp:TemplateField HeaderText="Name">
                <InsertItemTemplate>   <asp:TextBox ID="txtName" runat="server"></asp:TextBox></InsertItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="InNameValid" CssClass="validation" ControlToValidate="txtName" ValidationGroup="ingGroup" runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
      
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <InsertItemTemplate>  <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></InsertItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox><asp:RegularExpressionValidator ID="quantityValid" ValidationGroup="ingGroup" CssClass="validation" ControlToValidate="txtQuantity" runat="server" ErrorMessage="*" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Measure Units">
                <InsertItemTemplate>  <asp:TextBox ID="txtUnits" runat="server"></asp:TextBox></InsertItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("measureunits") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtMeasureUnits" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("measureunits") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="true" ValidationGroup="ingGroup" CommandName="Insert" Text="Add" CssClass="buttonadd" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="White" HorizontalAlign="Center" Font-Size="15px" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" Font-Size="15px" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

    <br />
    <br />
     <asp:Label ID="update" runat="server" ForeColor="#FF3300"  Font-Size="20px"></asp:Label>
    <br />
    <asp:Button ID="Delete" runat="server" Text="Delete" CssClass="button" OnClick="Delete_Click" /><asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" CssClass="button" OnClick="btnSaveChanges_Click"  />

   <%--Brinderjit Singh StudentId=300918321 --%>

</asp:Content>

