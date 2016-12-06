using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetupPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        /*switch (Request.QueryString["theme"])
        {
            case "Dark":
                Page.Theme = "Dark";
                break;
            case "Red":
                Page.Theme = "Red";
                break;
        }*/
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


    protected void save_Click(object sender, EventArgs e)
    {
        
        string theme="Light";
        if (lightRadio.Checked)
        {
            theme = "Light";
        }
        else if(darkRadio.Checked){
            theme = "Dark";
        }
        HttpCookie myCookie = new HttpCookie("myCookie");
        myCookie.Values.Add("theme", theme);
        myCookie.Expires = DateTime.Now.AddMonths(1);
        Response.Cookies.Add(myCookie);
        Response.Redirect("SetupPage.aspx?theme="+theme);

    }
}