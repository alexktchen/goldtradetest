namespace GoldTradeNaming.Web
{
    using GoldTradeNaming.BLL;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class goldAdminIndex : Page
    {
        protected HyperLink HyperLink1;
        protected HyperLink HyperLink2;
        protected HyperLink HyperLink3;

        private void loadData()
        {
            bool hasNewMsg = false;
            StringBuilder sb = new StringBuilder();
            sb.Append(" franchiser_order_state='0'");
            GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            DataSet ds = bll.GetList(sb.ToString());
            if (((ds != null) && (ds.Tables.Count > 0)) && (ds.Tables[0].Rows.Count > 0))
            {
                this.HyperLink1.Text = "有" + ds.Tables[0].Rows.Count.ToString() + "张订单待确认。";
                hasNewMsg = true;
            }
            else
            {
                this.HyperLink1.Visible = false;
            }
            sb = new StringBuilder();
            sb.Append(" franchiser_order_state='1'");
            ds = bll.GetList(sb.ToString());
            if (((ds != null) && (ds.Tables.Count > 0)) && (ds.Tables[0].Rows.Count > 0))
            {
                this.HyperLink2.Text = "有" + ds.Tables[0].Rows.Count.ToString() + "张订单待发货。";
                hasNewMsg = true;
            }
            else
            {
                this.HyperLink2.Visible = false;
            }
            int count = new GoldTradeNaming.BLL.franchiser_trade().TradeCount(DateTime.Now);
            if (count > 0)
            {
                this.HyperLink3.Text = "今天已有" + count.ToString() + "笔交易。";
                hasNewMsg = true;
            }
            else
            {
                this.HyperLink3.Visible = false;
            }
            if (!hasNewMsg)
            {
                this.HyperLink1.Visible = true;
                this.HyperLink1.NavigateUrl = "";
                this.HyperLink1.Text = "现在没有最新消息。";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
                {
                    base.Response.Clear();
                    base.Response.Write(@"<script defer>window.alert('您没有权限登录本系统！\n请重新登录或与管理员联系');history.back();</script>");
                    base.Response.End();
                }
                else
                {
                    this.loadData();
                }
            }
        }
    }
}
