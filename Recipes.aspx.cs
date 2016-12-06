    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

public partial class Recipes : System.Web.UI.Page
{
    RecipeRepository _objRepositary = new RecipeRepository();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dr;
        dr= _objRepositary.getRecipies();
        RecipeGrid.DataSource = dr;
        RecipeGrid.DataBind();
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
       
        this.Theme = "Light";
        HttpCookie myCookie = Request.Cookies["myCookie"];  
        if (myCookie != null)
        {
            if (!string.IsNullOrEmpty(myCookie.Values["theme"]))
            {
                string theme = myCookie.Values["theme"].ToString();
                this.Theme = theme;
            }
        }
    }
    protected void RecipeGrid_SelectedIndexChanged(object sender, EventArgs e)
    { 
    //   int recipeId=Convert.ToInt32(RecipeGrid.DataKeys[RecipeGrid.SelectedIndex].Value);
    //   Session["recipeId"] = recipeId;
    //   Response.Redirect("RecipeDetails.aspx");
    }
}