using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace GoldTradeNaming.Web.franchiser_order_desc
{
    public partial class SalesReport : System.Web.UI.Page
    {
        private readonly GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
        private readonly GoldTradeNaming.BLL.franchiser_info bllA = new GoldTradeNaming.BLL.franchiser_info();
        private readonly GoldTradeNaming.BLL.franchiser_trade bllB = new GoldTradeNaming.BLL.franchiser_trade();
        private readonly GoldTradeNaming.BLL.franchiser_money bllC = new GoldTradeNaming.BLL.franchiser_money();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.TradeReport.ToString())
               
                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
                else
                {
                    showInformation();
                }

            }
        }
        private void showInformation()
        {
            try
            {
                DataSet ds = bll.getSalesReprot();
                string leftMoney = bll.getLeftMoney();
                string sumTrade = bll.getTotalTrade();
                string AddedMoney = bll.getAdMoeney();
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script type='text/javascript'>alert('查无数据');</script>");
                    showData.Visible = false;
                }
                else
                {
                    Session["dataSrc"] = ds;
                    showData.DataSource = Session["dataSrc"] as DataSet;
                    showData.DataBind();
                    showData.Visible = true;
                    this.leftPrice.Text = leftMoney;
                    this.TotalTrade.Text = sumTrade;
                    this.TotalMoney.Text = AddedMoney;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //this.GridView1.PageIndex = e.NewPageIndex;
            //this.GridView1.DataSource = Session["datasrc"] as DataSet;
            //this.GridView1.DataBind();
            this.showData.PageIndex = e.NewPageIndex;
            this.showData.DataSource = Session["dataSrc"] as DataSet;
            this.showData.DataBind();
        }
    }
}
