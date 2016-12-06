using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ingridients
/// </summary>
///
 [Serializable]
public class Ingridients
{
    public int RecipeId { get; set;}
    public String name { get; set; }
    public int Quantity { get; set; }
    public String measureUnit { get; set; }
    public Ingridients()
    { 
       
        
    }
}