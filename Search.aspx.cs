using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;

//Brinderjit Singh StudentId=300918321
public partial class vs_RecipeBook_Search : System.Web.UI.Page
{
    RecipeRepository _objRecipe = new RecipeRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDropdown();
        }
    }

    public void BindDropdown()
    {
        category.DataSource = _objRecipe.getCategory();
        SubmittedBy.Items.Insert(0, new ListItem("--Select--", "NA"));
        Ingredients.Items.Insert(0, new ListItem("--Select--", "NA"));
        DataTable obj = _objRecipe.getRecipies();
        DataTable distinctSubmittedBy = obj.DefaultView.ToTable(true, "SUBMITTEDBY");
        for (int j = 0; j < distinctSubmittedBy.Rows.Count-1; j++)
            {
                
                SubmittedBy.Items.Add(new ListItem { Text = distinctSubmittedBy.Rows[j]["SUBMITTEDBY"].ToString(), Value = j.ToString() });
           
            }
            DataTable obj1 = _objRecipe.getIngredients();
            DataTable distinct = obj1.DefaultView.ToTable(true, "Name");
            for (int j = 0; j < distinct.Rows.Count-1; j++)
            {
           
                  Ingredients.Items.Add(new ListItem { Text = distinct.Rows[j]["NAME"].ToString(), Value = j.ToString() });
            }
        Ingredients.DataBind();
        category.DataBind();
        SubmittedBy.DataBind();
    }
    protected void submit_Click(object sender, EventArgs e)
    {
        DataTable obj = _objRecipe.SearchRecipe(category.SelectedItem.Text, SubmittedBy.SelectedItem.Text, Ingredients.SelectedItem.Text);
        searchGrid.DataSource = obj;
        searchGrid.DataBind();
    }

    protected void Name_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //Brinderjit Singh StudentId=300918321
}