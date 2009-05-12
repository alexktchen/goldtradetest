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
using LTP.Common;
using System.Text;

namespace GoldTradeNaming.Web.franchiser_trade
{
    public partial class ShowM : System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "查看交易";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Session["TradeM"] = "1010";//测试数据                 

                if (Session["admin"] == null || Session["admin"].ToString() == ""
                     || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewTrade.ToString())
                    )
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }

                DataSet ds = bll.GetTradeByM("");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    Session["gvTrade"] = ds;
                    this.gvTrade.DataSource = ds;
                    this.gvTrade.DataBind();

                }
                divTradeDesc.Style.Add("display", "none");
                divTrade.Style.Add("display", "block");
            }
        }

        protected void gvTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sTradeID = gvTrade.SelectedRow.Cells[0].Text.Trim();
                DataSet ds = bll.GetTradeDesc(sTradeID);
                Session["gvTradeDesc"] = ds;
                gvTradeDesc.DataSource = ds;
                gvTradeDesc.DataBind();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }

            divTradeDesc.Style.Add("display", "block");
            divTrade.Style.Add("display", "none");
        }

        protected void gvTrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;

            if (Session["gvTrade"] != null)
            {
                this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
                this.gvTrade.DataBind();
            }
            else
            {
                Session["gvTrade"] = SearchTradeInfo();
                this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
                this.gvTrade.DataBind();
            }
            gvTrade.SelectedIndex = -1;
        }

        protected void gvTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTradeDesc.PageIndex = e.NewPageIndex;

            if (Session["gvTradeDesc"] != null)
            {
                this.gvTradeDesc.DataSource = Session["gvTradeDesc"] as DataSet;
                this.gvTradeDesc.DataBind();
            }
            gvTradeDesc.SelectedIndex = -1;

        }


        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            gvTradeDesc.DataSource = null;
            gvTradeDesc.DataBind();
            gvTrade.SelectedIndex = -1;

            divTradeDesc.Style.Add("display", "none");
            divTrade.Style.Add("display", "block");
        }

        protected void btnReNew_Click(object sender, EventArgs e)
        {
            txttrade_id.Text = "";
            txtfranchiser_code.Text = "";
            gvTrade.SelectedIndex = -1;
            lblQueryMsg.Text = "";
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            DataSet ds = SearchTradeInfo();

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblQueryMsg.Text = "查询成功";
            }
            else
                lblQueryMsg.Text = "查无记录";


            Session["gvTrade"] = ds;
            this.gvTrade.DataSource = ds;
            this.gvTrade.DataBind();
        }

        private DataSet SearchTradeInfo()
        {

            StringBuilder strWhere = new StringBuilder();

            if (this.txtfranchiser_code.Text.Trim() == "")
            {
                strWhere.Append("1=1");
            }
            else
            {
                strWhere.Append("a.franchiser_code like N'%");
                strWhere.Append(this.txtfranchiser_code.Text.Trim());
                strWhere.Append("%' ");
            }
            if (this.txttrade_id.Text.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND a.trade_id like N'%");
                strWhere.Append(this.txttrade_id.Text.Trim());
                strWhere.Append("%'");
            }
            if (this.txtfranchiser_name.Text.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND b.franchiser_name like N'%");
                strWhere.Append(this.txtfranchiser_name.Text.Trim());
                strWhere.Append("%'");
            }
            return bll.GetTradeByM(strWhere.ToString());
        }
    }
}
