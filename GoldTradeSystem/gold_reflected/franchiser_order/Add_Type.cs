namespace GoldTradeNaming.Web.franchiser_order
{
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add_Type : Page
    {
        protected ImageButton ImageButton1;
        protected ImageButton ImageButton2;

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.Session.Remove("OrderMain");
            this.Session.Remove("orderdesclist");
            base.Response.Redirect("~/franchiser_order/Add.aspx?prodtype=0");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            this.Session.Remove("OrderMain");
            this.Session.Remove("orderdesclist");
            base.Response.Redirect("~/franchiser_order/Add.aspx?prodtype=1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["fran"] == null) || (this.Session["fran"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
            }
        }
    }
}
