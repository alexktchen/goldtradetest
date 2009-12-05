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

    public class MoneyInfo : Page
    {
        protected Button Button1;
        protected GridView showDate;
        protected TextBox txtadd_money;
        protected TextBox txtfran_id;

        private void BindInfo()
        {
            if (base.Request.Params.Count > 0)
            {
                this.txtfran_id.Text = base.Request.Params["name"].ToString();
                this.txtadd_money.Text = CommBaseBLL.GetAddMoneyTotal(Convert.ToInt32(base.Request.Params["id"].ToString())).ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append(" franchiser_code='" + Convert.ToInt32(base.Request.Params["id"].ToString()).ToString() + "'");
                DataSet ds = new GoldTradeNaming.BLL.franchiser_money().GetList(sb.ToString());
                this.Session["datasrc"] = ds;
                this.showDate.DataSource = this.Session["datasrc"] as DataSet;
                this.showDate.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShowNoEdit.aspx");
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

        protected void showDate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.showDate.PageIndex = e.NewPageIndex;
            this.showDate.DataSource = this.Session["datasrc"] as DataSet;
            this.showDate.DataBind();
        }
    }
}
