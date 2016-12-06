using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;

public partial class RecipeDetails : System.Web.UI.Page
{
    RecipeRepository _objrepositry=new RecipeRepository();
    //Brinderjit Singh StudentId=300918321

    protected void Page_PreRender(object sender, EventArgs e)
    {
        
       int recipeId=Convert.ToInt32(Request.QueryString["ID"]);
       if(recipeId==0)
        {
            Response.Redirect("Recipes.aspx");
        }
        DataTable dr = _objrepositry.getDetails(recipeId);
        recipeGrid.HeaderText = dr.Rows[0]["Name"].ToString().ToUpper();
        string selecteditem = dr.Rows[0]["Category"].ToString();
        if (!Page.IsPostBack)
        {
            ViewState["Recipe"] = dr;
            recipeGrid.DataSource = dr;
            DataTable dr1 = _objrepositry.getDIngredientDetails(recipeId);
            recipeGrid.DataBind();
            ViewState["Ingredients"] = dr1;
            IngredientsGrid.DataSource = dr1;
            IngredientsGrid.DataBind();
        }
        else
        {
            recipeGrid.DataSource = (DataTable)ViewState["Recipe"];
            IngredientsGrid.DataSource = (DataTable)ViewState["Ingredients"];
            recipeGrid.DataBind();
            IngredientsGrid.DataBind();
        }
       
    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(recipeGrid.DataKey.Value.ToString());
        _objrepositry.DeleteRecipe(id);
        update.Text = "Recipe Sucessfully Deleted";
        Response.Redirect("Recipes.aspx");
    }





    protected void recipeGrid_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        if (e.CancelingEdit == true)
        {
            recipeGrid.ChangeMode(DetailsViewMode.ReadOnly);
            recipeGrid.DataBind();
        }
        else
        {
            recipeGrid.ChangeMode(DetailsViewMode.Edit);
            //List<ListItem> categoryList = _objrepositry.getCategory();
            //List<ListItem> withSelected = new List<ListItem>();
            //foreach (ListItem category in categoryList)
            //{
            //    if (category.Text == selecteditem)
            //    {
            //        withSelected.Add(new ListItem { Text = category.Text, Value = category.Value, Selected = true });
            //    }
            //    else
            //    {
            //        withSelected.Add(new ListItem { Text = category.Text, Value = category.Value });
            //    }
            //}
            //withSelected.Add(new ListItem { Text = "Others", Value = withSelected.Count.ToString() });
            //((DropDownList)recipeGrid.Rows[2].Cells[1].FindControl("DropDownList1")).DataSource = withSelected;
            recipeGrid.DataBind();
        }
    }
    //Brinderjit Singh StudentId=300918321
    protected void recipeGrid_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        int temp =Convert.ToInt32(recipeGrid.DataKey.Value.ToString());
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["Recipe"];
        dt.Rows[0]["Name"] = ((TextBox)recipeGrid.Rows[0].Cells[1].Controls[1]).Text;
        String category= ((TextBox)recipeGrid.Rows[2].Cells[1].Controls[3]).Text;
        if (category == "")
        {
            dt.Rows[0]["Category"] = ((DropDownList)recipeGrid.Rows[2].Cells[1].Controls[1]).SelectedItem.Text;
        }
        else
        {
            dt.Rows[0]["Category"] = ((TextBox)recipeGrid.Rows[2].Cells[1].Controls[3]).Text;
        }
        dt.Rows[0]["cookTime"] = Convert.ToInt32(((TextBox)recipeGrid.Rows[3].Cells[1].Controls[1]).Text);
        dt.Rows[0]["noservings"] = Convert.ToInt32(((TextBox)recipeGrid.Rows[4].Cells[1].Controls[1]).Text);
        dt.Rows[0]["description"] = ((TextBox)recipeGrid.Rows[5].Cells[1].Controls[1]).Text;
        ViewState["Recipe"] = dt;
        recipeGrid.DataSource = (DataTable)ViewState["Recipe"];
        recipeGrid.ChangeMode(DetailsViewMode.ReadOnly);
        recipeGrid.DataBind();
    }


    protected void IngredientsGrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int ingId = Convert.ToInt32(IngredientsGrid.DataKeys[IngredientsGrid.SelectedIndex]);
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["Ingredients"];
    }

    protected void IngredientsGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        IngredientsGrid.EditIndex = e.NewEditIndex;
        recipeGrid.DataBind();
    }
    
    protected void IngredientsGrid_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
    {
        IngredientsGrid.EditIndex = -1;
    }

    protected void IngredientsGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int temp = Convert.ToInt32(IngredientsGrid.DataKeys[e.RowIndex].Value.ToString());
        DataTable dt = new DataTable();
        dt = (DataTable)ViewState["Ingredients"];
        dt.Rows[e.RowIndex]["Name"] = ((TextBox)IngredientsGrid.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        dt.Rows[e.RowIndex]["Quantity"] = Convert.ToInt32(((TextBox)IngredientsGrid.Rows[e.RowIndex].Cells[1].Controls[1]).Text);
        dt.Rows[e.RowIndex]["Measureunits"] = ((TextBox)IngredientsGrid.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        ViewState["Ingredients"] = dt;
        DataBind();
        IngredientsGrid.EditIndex = -1;

    }

    protected void recipeGrid_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }

    protected void btnSaveChanges_Click(object sender, EventArgs e)
    {
        DataTable recipe = (DataTable)ViewState["Recipe"];
        DataTable ingredients =(DataTable) ViewState["Ingredients"];
        Ingridients objIn = (Ingridients)ViewState["NewIngredient"];
        
        int error1=_objrepositry.updateRecipe(recipe, ingredients);
        //int error2 = _objrepositry.insertIngredients(objIn);
        if(error1 == 0 )
        {
            update.Text = "Recipe Updated Successfully";
        }
        else
        {
            update.Text = "Error Occurred";
        }

    }

    protected void IngredientsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Insert")
        {
            DataTable dt = new DataTable();
            DataTable newIngredient = new DataTable();
            dt = (DataTable)ViewState["Ingredients"];
            if (dt.Rows.Count < 15)
            {
                Ingridients ing = new Ingridients();
                ing.RecipeId = Convert.ToInt32(recipeGrid.DataKey.Value.ToString());
                ing.name = ((TextBox)IngredientsGrid.FooterRow.FindControl("txtName")).Text;
                ing.Quantity = Convert.ToInt32(((TextBox)IngredientsGrid.FooterRow.FindControl("txtQuantity")).Text);
                ing.measureUnit = ((TextBox)IngredientsGrid.FooterRow.FindControl("txtMeasureUnits")).Text;
                DataRow newIng = dt.NewRow();
                newIng[1] = ing.name;
                newIng[2] = ing.Quantity;
                newIng[3] = ing.measureUnit;
                newIng[4] = ing.RecipeId;
                dt.Rows.Add(newIng);
                ViewState["Ingredients"] = dt;
                ViewState["NewIngredient"] = ing;
                IngredientsGrid.DataSource = dt;
                IngredientsGrid.DataBind();
            }
            else
            {
                update.Text = "Can't add more than 15 Ingredients ";
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(((DropDownList)recipeGrid.Rows[2].Cells[1].Controls[1]).SelectedItem.Text=="Others")
        {
            ((TextBox)recipeGrid.Rows[2].Cells[1].Controls[3]).Visible = true;
        }
    }

    protected void DropDownList1_DataBinding(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)ViewState["Recipe"];
        string selectedText = dt.Rows[0]["Category"].ToString();
        List<ListItem> categoryList = _objrepositry.getCategory();
        List<ListItem> withSelected = new List<ListItem>();
        foreach (ListItem category in categoryList)
        {
            if (category.Text == selectedText)
            {
                withSelected.Add(new ListItem { Text = category.Text, Value = category.Value, Selected = true });
            }
            else
            {
                withSelected.Add(new ListItem { Text = category.Text, Value = category.Value });
            }
        }
        withSelected.Add(new ListItem { Text = "Others", Value = withSelected.Count.ToString() });
        ((DropDownList)recipeGrid.Rows[2].FindControl("DropDownList1")).DataSource = withSelected;


    }

    protected void recipeGrid_DataBound(object sender, EventArgs e)
    {
       
    }

    protected void recipeGrid_DataBinding(object sender, EventArgs e)
    {
       
    }
    //Brinderjit Singh StudentId=300918321
}