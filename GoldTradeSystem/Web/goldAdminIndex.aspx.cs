using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using GoldTradeNaming.Web.goldtrade_db_admin;
using System.Text;
namespace GoldTradeNaming.Web
{
    public partial class goldAdminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                loadData();
            }
        }

        private void loadData()
        {
            bool hasNewMsg = false;
            StringBuilder sb = new StringBuilder();

            sb.Append(" franchiser_order_state='0'");

            GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            DataSet ds = bll.GetList(sb.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
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

            //GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            ds = bll.GetList(sb.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.HyperLink2.Text = "有" + ds.Tables[0].Rows.Count.ToString() + "张订单待发货。";
                hasNewMsg = true;
            }
            else
            {
                this.HyperLink2.Visible = false;
            }


            GoldTradeNaming.BLL.franchiser_trade bll2 = new GoldTradeNaming.BLL.franchiser_trade();
            int count = bll2.TradeCount(DateTime.Now);
            if (count > 0)
            {
                this.HyperLink3.Text = "今天已有" + count.ToString() + "笔交易。";
                hasNewMsg = true;
            }
            else{
                this.HyperLink3.Visible = false;
            }

            if (!hasNewMsg)
            {
                this.HyperLink1.Visible = true;
                this.HyperLink1.NavigateUrl = "";
                this.HyperLink1.Text = "现在没有最新消息。";
            }


            //sb = new StringBuilder();
            //sb.Append(" franchiser_order_state='1");

            //GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
            //ds = bll.GetList(sb.ToString());
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    this.Label3.Text = "有" + ds.Tables[0].Rows.Count.ToString() + "订单待发货。";
            //}


        }
    }
}
