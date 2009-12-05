namespace GoldTradeNaming.Web.franchiser_info
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class OrderInfo : Page
    {
        protected Button btnReturn;
        protected GridView GridView1;
        protected Label lblfranchiser_name;
        protected TextBox txtfranchiser_name;

        private void BindInfo()
        {
            if (base.Request.Params.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(" franchiser_code='" + Convert.ToInt32(base.Request.Params["id"].ToString()).ToString() + "'");
                this.txtfranchiser_name.Text = base.Request.Params["name"].ToString();
                DataSet ds = new GoldTradeNaming.BLL.franchiser_order().GetList(sb.ToString());
                this.Session["datasrc"] = ds;
                this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
                this.GridView1.DataBind();
            }
        }

        protected void btnReturn_Click1(object sender, EventArgs e)
        {
            base.Response.Redirect("ShowNoEdit.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewFran.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindInfo();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "订单管理";
        }
    }
}
