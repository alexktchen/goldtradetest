namespace GoldTradeNaming.Web.stock_main
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class stockModifyLog : Page
    {
        private GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
        protected GridView showData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewStockLog.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.showData.Visible = false;
                DataSet ds = this.bll.getStockModifyLog();
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    this.showData.Visible = false;
                }
                else
                {
                    this.Session["data"] = ds;
                    this.showData.DataSource = ds;
                    this.showData.DataBind();
                    this.showData.Visible = true;
                }
            }
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet ds = (DataSet) this.Session["data"];
            this.showData.PageIndex = e.NewPageIndex;
            this.showData.Visible = true;
            this.showData.DataSource = ds;
            this.showData.DataBind();
        }
    }
}
