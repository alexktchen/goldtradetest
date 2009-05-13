﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using LTP.Common;
namespace GoldTradeNaming.Web.franchiser_trade
{
    public partial class Show : System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //(Master.FindControl("lblOrderOrTrade") as Label).Text = "点价可用余额：";
            //   (Master.FindControl("lblTitle") as Label).Text = "详细信息";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["fran"] == null || Session["fran"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }

                bool bl = GetTradeList(true);
                if (bl)
                {
                    divTradeDesc.Style.Add("display", "none");
                    divTrade.Style.Add("display", "block");
                }
            }

        }
        protected void gvTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sTradeID = gvTrade.SelectedRow.Cells[0].Text.Trim();
                DataSet ds = bll.GetTradeDesc(sTradeID);
                gvTradeDesc.DataSource = ds;
                gvTradeDesc.DataBind();
                Session["gvTradeDesc"] = ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return;
            }
            //    txtReason.Text = "";
            divTradeDesc.Style.Add("display", "block");
            divTrade.Style.Add("display", "none");
        }

        protected void gvTrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;
            this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
            this.gvTrade.DataBind();
        }

        protected void gvTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTradeDesc.PageIndex = e.NewPageIndex;
            this.gvTradeDesc.DataSource = Session["gvTradeDesc"] as DataSet;
            this.gvTradeDesc.DataBind();

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
            txtBeginDate.Text = "";
            txtEndDate.Text = "";
            // txtReason.Text = "";
            txttrade_id.Text = "";
            gvTrade.SelectedIndex = -1;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (GetTradeList(false))
            {
                divTradeDesc.Style.Add("display", "none");
                divTrade.Style.Add("display", "block");
            }
        }

        private bool GetTradeList(bool isInit)
        {
            string franchiser_code = Session["fran"].ToString().Trim();
            StringBuilder strWhere = new StringBuilder();
            DateTime dtFrom = new DateTime(2000, 1, 1);
            DateTime dtTo = DateTime.Now;
            strWhere.Append(" franchiser_code ='" + franchiser_code + "' ");
            if (isInit)
            {
            }
            else
            {
                if (this.txttrade_id.Text.Trim() == "")
                {
                    strWhere.Append(" AND 1=1");
                }
                else
                {
                    strWhere.Append(" AND trade_id = N'");
                    strWhere.Append(this.txttrade_id.Text.Trim());
                    strWhere.Append("'");
                }
                if (txtBeginDate.Text.Trim() != "")
                {
                    try
                    {
                        dtFrom = Convert.ToDateTime(txtBeginDate.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的时间格式");
                        return false;
                    }
                }

                if (txtEndDate.Text.Trim() != "")
                {
                    try
                    {
                        dtTo = Convert.ToDateTime(txtEndDate.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show(this, "请输入正确的时间格式");
                        return false;
                    }
                }
                strWhere.Append("AND trade_time between '" + dtFrom.ToString("yyyy/MM/dd") + "' and '" + dtTo.ToString("yyyy/MM/dd 23:59:59") + "' ");
            }
            strWhere.Append(" order by trade_time desc; ");
            try
            {
                DataSet ds = bll.GetAllTrade(strWhere.ToString(), isInit);
                gvTrade.DataSource = ds;
                gvTrade.DataBind();
                Session["gvTrade"] = ds;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }

        }
    }
}
