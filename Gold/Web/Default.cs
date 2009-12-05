namespace GoldTradeNaming.Web
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Default : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HyperLink HyperLink1;
        protected HyperLink HyperLink2;
        protected Label Label1;
        protected Label Label3;
        protected TextBox TextBox1;
        protected TextBox TextBox3;

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Session["fran"] = this.TextBox1.Text.Trim();
            base.Response.Redirect("User_Login/AgreeProtol.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Session["admin"] = this.TextBox3.Text.Trim();
            base.Response.Redirect("goldAdminIndex.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
