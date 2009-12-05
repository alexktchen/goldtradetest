namespace GoldTradeNaming.Web.franchiser_order_desc
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class SalesReport : Page
    {
        private readonly GoldTradeNaming.BLL.stock_main bll = new GoldTradeNaming.BLL.stock_main();
        private readonly GoldTradeNaming.BLL.franchiser_info bllA = new GoldTradeNaming.BLL.franchiser_info();
        private readonly GoldTradeNaming.BLL.franchiser_trade bllB = new GoldTradeNaming.BLL.franchiser_trade();
        private readonly GoldTradeNaming.BLL.franchiser_money bllC = new GoldTradeNaming.BLL.franchiser_money();
        protected Button btnAdd;
        protected CalendarExtender dtTo_CalendarExtender;
        protected Label Label1;
        protected TextBox leftPrice;
        protected ScriptManager ScriptManager1;
        protected GridView showData;
        protected TextBox TotalMoney;
        protected TextBox TotalTrade;
        protected TextBox txttime_from;
        protected TextBox txtTime_to;
        protected CalendarExtender txtTimeTo0_CalendarExtender;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string timeFrom = string.Empty;
            string timeTo = string.Empty;
            timeFrom = this.txttime_from.Text.Trim();
            timeTo = this.txtTime_to.Text.Trim();
            try
            {
                DataSet ds = this.bll.getSalesReprot(timeFrom, timeTo);
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    base.Response.Write("<script type='text/javascript'>alert('查无数据');</script>");
                    this.showData.Visible = false;
                }
                else
                {
                    this.Session["dataSrc"] = ds;
                    this.showData.DataSource = this.Session["dataSrc"] as DataSet;
                    this.showData.DataBind();
                    this.showData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.TradeReport.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!base.IsPostBack)
            {
                this.showInformation();
            }
        }

        protected void showData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.showData.PageIndex = e.NewPageIndex;
            this.showData.DataSource = this.Session["dataSrc"] as DataSet;
            this.showData.DataBind();
        }

        private void showInformation()
        {
            try
            {
                DataSet ds = this.bll.getSalesReprot("", "");
                string leftMoney = this.bll.getLeftMoney();
                string sumTrade = this.bll.getTotalTrade();
                string AddedMoney = this.bll.getAdMoeney();
                if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
                {
                    base.Response.Write("<script type='text/javascript'>alert('查无数据');</script>");
                    this.showData.Visible = false;
                }
                else
                {
                    this.Session["dataSrc"] = ds;
                    this.showData.DataSource = this.Session["dataSrc"] as DataSet;
                    this.showData.DataBind();
                    this.showData.Visible = true;
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
    }
}
