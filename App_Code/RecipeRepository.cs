using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for RecipeRepository
/// </summary>
public class RecipeRepository
{
    private static String conString = System.Configuration.ConfigurationManager.ConnectionStrings["recipeBook"].ToString();
    OracleConnection conn;
    OracleDataAdapter update;
    public RecipeRepository()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int insertIngredients(Ingridients ingredient)
    {
        int error = 0;
        conn = new OracleConnection(conString);
        try
        {
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "PROC_INSERTINGREDIENTS";
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                cmd1.Parameters.Add("RID", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = ingredient.RecipeId;
                cmd1.Parameters.Add("iNAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredient.name.TrimStart().TrimEnd();
                cmd1.Parameters.Add("iQUANTITY", OracleDbType.Double, System.Data.ParameterDirection.Input).Value = ingredient.Quantity;
                cmd1.Parameters.Add("iMEASUREUNITS", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredient.measureUnit.TrimStart().TrimEnd();
            conn.Open();
                cmd1.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            error = 1;
        }
        finally
        {
            conn.Close();
        }
        return error;
    }
    public int insertRecipe(Recipe recipe)
    {
        int error = 0;
        conn = new OracleConnection(conString);
        OracleCommand cmd = new OracleCommand();

        try
        {
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_INSERTRECIPE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("rNAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.name.TrimStart().TrimEnd();
            cmd.Parameters.Add("rSUBMITTEDBY", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.submittedBy.TrimStart().TrimEnd();
            cmd.Parameters.Add("rcategory", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.category.TrimStart().TrimEnd();
            cmd.Parameters.Add("rCOOKTIME", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipe.time;
            cmd.Parameters.Add("rNOSERVINGS", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipe.servings;
            cmd.Parameters.Add("rDESCRIPTION", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.description.TrimStart().TrimEnd();
            int recipeId = Convert.ToInt32(cmd.Parameters.Add("RECIPE_ID", OracleDbType.Int32, System.Data.ParameterDirection.Output).Value);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            foreach (Ingridients ingredient in recipe.ingredients)
            {
                ingredient.RecipeId = recipeId;
                error=insertIngredients(ingredient);

            }
            

        }
        catch (Exception e)
        {
            error = 1;
        }
        finally
        {
       
            cmd.Dispose();

        }
        return error;
    }
    public DataTable getIngredients()
    {
        OracleDataAdapter ad;
        OracleCommand cmd;
        DataTable dt = new DataTable();
        try {
            conn = new OracleConnection(conString);

            // create the command for the stored procedure
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_GETINGREDIENTS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameters for the stored procedure including the REF CURSOR
            // to retrieve the result set
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
                System.Data.ParameterDirection.Output;
            // open the connection and create the DataReader
            conn.Open();
            ad = new OracleDataAdapter(cmd);
            ad.Fill(dt);
        }
        catch (Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
        return dt;
    }
    public DataTable SearchRecipe(String Name, String Submittedby, String ingredients)
    {
        OracleCommand cmd;
        OracleDataAdapter ad;
        DataTable dt = new DataTable();
        try
        {
            conn = new OracleConnection(conString);
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_GETSEARCHEDRECIPE ";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("RCATEGORY", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = Name;
            cmd.Parameters.Add("SUBMITTEDBY", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = Submittedby;
            cmd.Parameters.Add("INAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredients;
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
                System.Data.ParameterDirection.Output;
            conn.Open();
            ad = new OracleDataAdapter(cmd);
            ad.Fill(dt);
        }
        catch (Exception e)
        {

        }
        finally
        {
            conn.Close();
        }

        return dt;
    }
    
    public DataTable getDIngredientDetails(int id)
    {
        DataTable dt = new DataTable();
        OracleDataAdapter ad;
        OracleCommand cmd;
        try
        {
            conn = new OracleConnection(conString);
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_GETINGREDIENTSDETAIL";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("RID", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = id;
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =System.Data.ParameterDirection.Output;
            conn.Open();
            ad = new OracleDataAdapter(cmd);
            ad.Fill(dt);
        }
        catch(Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
        
        return dt;
    }
    public DataTable getDetails(int recipeId)
    {
        OracleCommand cmd;
        conn = new OracleConnection(conString);
        
        DataTable dt = new DataTable();
        try
        {
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_RECIPEDETAILS";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("rId", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipeId;
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
                System.Data.ParameterDirection.Output;
            conn.Open();
            update = new OracleDataAdapter(cmd);
            update.Fill(dt);
        }
        catch(Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
        
        return dt;
    }
    public int updateRecipe(DataTable recipe,DataTable ingredients)
    {
        int error = 0;
        conn = new OracleConnection(conString);
        try
        {

           OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_UPDATERECIPE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("r_Id", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipe.Rows[0]["recipeid"];
            cmd.Parameters.Add("Rname", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.Rows[0]["NAME"];
            cmd.Parameters.Add("Rsubmittedby", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.Rows[0]["SUBMITTEDBY"];
            cmd.Parameters.Add("Rcategory", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.Rows[0]["category"];
            cmd.Parameters.Add("Rcooktime", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipe.Rows[0]["COOKTIME"];
            cmd.Parameters.Add("Rnoservings", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = recipe.Rows[0]["NOSERVINGS"];
            cmd.Parameters.Add("rDESCRIPTION", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = recipe.Rows[0]["DESCRIPTION"];
            conn.Open();
            cmd.ExecuteNonQuery();
            if (ingredients.Rows.Count != 0)
            {
                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "PROC_DELETEINGREDIENTS";
                cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                cmd2.Parameters.Add("r_Id", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = ingredients.Rows[1]["recipeId"];
                cmd2.ExecuteNonQuery();
                for (int i = 0; i < ingredients.Rows.Count; i++)
                {
                    OracleCommand cmd1 = new OracleCommand();
                    cmd1.Connection = conn;
                    cmd1.CommandText = "PROC_INSERTINGREDIENTS";

                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.Add("recipeId", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = ingredients.Rows[i]["recipeId"];
                    cmd1.Parameters.Add("NAME", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredients.Rows[i]["NAME"];
                    cmd1.Parameters.Add("QUANTITY", OracleDbType.Double, System.Data.ParameterDirection.Input).Value = ingredients.Rows[i]["QUANTITY"];
                    cmd1.Parameters.Add("MEASUREUNITS", OracleDbType.Varchar2, System.Data.ParameterDirection.Input).Value = ingredients.Rows[i]["MEASUREUNITS"];
                    cmd1.ExecuteNonQuery();

                }
            }
            conn.Close();

        }
        catch (Exception e)
        {
            error = 1;
        }
        finally
        {
            conn.Close();
          

        }
        return error;
    }
   
    public void DeleteRecipe(int id)
    {
        conn = new OracleConnection(conString);
        OracleCommand cmd;
        try { 
            conn = new OracleConnection(conString);
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_DELETERECIPE";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("rId", OracleDbType.Int32, System.Data.ParameterDirection.Input).Value = id;
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
        
        
    }
    public Boolean login(String userName,String password)
    {
        Boolean isValid=true;
        return isValid;
    }
    public List<ListItem> getCategory()
    {
        List<ListItem> dd = new List<ListItem>();
        DataTable dt = new DataTable();
        dt = getRecipies();
        DataTable distinctCategory = dt.DefaultView.ToTable(true, "Category");
        dd.Add(new ListItem { Text = "--Select--" });
        for (int i=0;i< distinctCategory.Rows.Count;i++)
        {
            dd.Add(new ListItem { Text= distinctCategory.Rows[i]["Category"].ToString(), Value=i.ToString()});
            
        }
        return dd;
    }
    public DataTable getRecipies()
    {
        conn = new OracleConnection(conString);
        OracleDataAdapter ad;
        OracleCommand cmd;
        DataTable dt = new DataTable();
        try
        {
        // create the command for the stored procedure
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROC_GETRECIPIES";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // add the parameters for the stored procedure including the REF CURSOR
            // to retrieve the result set
            cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction =
                System.Data.ParameterDirection.Output;
            // open the connection and create the DataReader
            conn.Open();
            ad=new OracleDataAdapter(cmd);  
            ad.Fill(dt);
        }
        catch(Exception e)
        {

        }
        finally
        {
            conn.Close();
        }
        return dt;
    }
}