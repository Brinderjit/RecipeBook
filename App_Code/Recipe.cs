using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Recipe
/// </summary>
public class Recipe
{
    public String name { get; set; }
    public String submittedBy { get; set; }
    public String category { get; set; }
    public int time { get; set; }
    public int servings { get; set; }
    public String description { get; set; }

    public List<Ingridients> ingredients = new List<Ingridients>();
    public Recipe()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}