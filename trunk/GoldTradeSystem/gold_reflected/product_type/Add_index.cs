namespace GoldTradeNaming.Web.product_type
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Add_index : Page
    {
        private GoldTradeNaming.BLL.product_type bll = new GoldTradeNaming.BLL.product_type();
        protected ImageButton ImageButton1;
        protected ImageButton ImageButton2;

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("Add.aspx?type=0");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("Add.aspx?type=1");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.AddProduct.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "添加产品";
        }
    }
}
