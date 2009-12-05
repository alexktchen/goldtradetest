namespace GoldTradeNaming.Web
{
    using GoldTradeNaming.Web.Controls;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MasterPage : System.Web.UI.MasterPage
    {
        protected CheckRight CheckRight1;
        protected ContentPlaceHolder ContentPlaceHolder1;
        protected GoldTradeNaming.Web.Controls.CopyRight1 CopyRight1;
        protected HtmlForm form1;
        protected ContentPlaceHolder head;
        protected Label lblTitle;
        protected Logo Logo1;
        protected LeftMenu MenuTree1;

        private int GetAdminRight(int adminid)
        {
            return 1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
