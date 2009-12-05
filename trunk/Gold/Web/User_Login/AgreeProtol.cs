namespace GoldTradeNaming.Web.User_Login
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AgreeProtol : Page
    {
        protected Button Button1;
        protected HtmlForm form1;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("../franchiser_index.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
