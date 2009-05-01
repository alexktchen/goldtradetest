using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace GoldTradeNaming.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["admin"] == null)
            //    Session["admin"] = "1001";
          //  Session["admin"] = Session["admin"].ToString() + "  Default ";

           // this.Label1.Text = Session["admin"].ToString();
            //(Master.FindControl("lblTitle") as Label).Text = Session["admin"].ToString() ;
            //this.TextBox1.Text = "1001";
            //this.TextBox3.Text = "1000";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["fran"] = TextBox1.Text.Trim();
            Response.Redirect("franchiser_index.aspx");
            //franchiser_index.aspx">经销商入口</asp:LinkButton>
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["admin"] = TextBox3.Text.Trim();
            Response.Redirect("goldAdminIndex.aspx");
        }


    }
}
