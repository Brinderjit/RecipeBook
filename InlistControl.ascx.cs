using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class InlistControl : System.Web.UI.UserControl
{
   
    public InlistControl() { }
    public string IngMeasure
    {
        get { return txtInMeasure.Text; }
    }
    public string IngName
    {
        set { lblInName.Text = value; }
    }
    public string TxtName
    {
        get { return txtInName .Text; }
    }
    public string LblQuantity
    {
        set { lblInQuantity.Text = value; }
    }
    public string TxInQuantity
    {
        get { return txtInquantity.Text; }
    }
   

    protected void Page_Load(object sender, EventArgs e)
    { }
}