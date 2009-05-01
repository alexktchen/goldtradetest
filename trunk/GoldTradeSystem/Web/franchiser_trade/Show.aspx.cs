using System;
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
    public partial class Show:System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            //(Master.FindControl("lblOrderOrTrade") as Label).Text = "点价可用余额：";
            //   (Master.FindControl("lblTitle") as Label).Text = "详细信息";
        }
        protected void Page_Load(object sender,EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(Session["fran"] == null || Session["fran"].ToString() == "")
                {
                    Response.Clear();
                    Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                    Response.End();
                    return;
                }
               // btnCancle.Attributes.Add("onclick","return confirm('" + "確定要取消交易嘛?" + "')");

                //  lbQuery.Attributes.Add("onclick","location.href='Show.aspx';return false;");
             //   lbAddNew.Attributes.Add("onclick","location.href='Add.aspx';return false;");
                //   btnCancle.Attributes.Add("onclick",);

                bool bl = GetTradeList(Session["fran"].ToString().Trim(),"",DateTime.Now.AddMonths(-1),DateTime.Now);
                if(bl)
                {
                    divTradeDesc.Style.Add("display","none");
                    divTrade.Style.Add("display","block");
                }

            }

        }
        protected void gvTrade_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                string sTradeID = gvTrade.SelectedRow.Cells[0].Text.Trim();
                DataSet ds = bll.GetTradeDesc(sTradeID);
                gvTradeDesc.DataSource = ds;
                gvTradeDesc.DataBind();
                Session["gvTradeDesc"] = ds;
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.Message);
                return;
            }
        //    txtReason.Text = "";
            divTradeDesc.Style.Add("display","block");
            divTrade.Style.Add("display","none");
        }

        protected void gvTrade_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;
            this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
            this.gvTrade.DataBind();
        }

        protected void gvTradeDesc_PageIndexChanging(object sender,GridViewPageEventArgs e)
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
        protected void btnReturn_Click(object sender,EventArgs e)
        {
            gvTradeDesc.DataSource = null;
            gvTradeDesc.DataBind();
            gvTrade.SelectedIndex = -1;

            divTradeDesc.Style.Add("display","none");
            divTrade.Style.Add("display","block");
        }

        /// <summary>
        /// 取消交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btnCancle_Click(object sender,EventArgs e)
        //{
        //    string sReason = txtReason.Text.Trim();
        //    if(sReason == "")
        //    {
        //        MessageBox.Show(this,"请输入取消原因");
        //        return;
        //    }
        //    string tradeid = gvTrade.SelectedRow.Cells[0].Text.Trim();
        //    int iCount = bll.CancleTradeInfo(tradeid,sReason);
        //    if(iCount == 1)
        //    {
        //        bool bl = GetTradeList(Session["fran"].ToString().Trim(),"",DateTime.Now.AddMonths(-1),DateTime.Now);
        //        if(bl)
        //        {
        //            divTradeDesc.Style.Add("display","none");
        //            divTrade.Style.Add("display","block");
        //        }
        //        MessageBox.Show(this,"取消成功！");

        //    }
        //    else
        //    {
        //        MessageBox.Show(this,"取消异常，修改" + iCount + "记录");
        //    }
        //}

        protected void btnReNew_Click(object sender,EventArgs e)
        {
            txtBeginDate.Text = "";
            txtEndDate.Text = "";
           // txtReason.Text = "";
            txttrade_id.Text = "";
            gvTrade.SelectedIndex = -1;
        }

        protected void btnQuery_Click(object sender,EventArgs e)
        {
            string franchiser_code = Session["fran"].ToString().Trim();
            string trade_id = txttrade_id.Text;
            DateTime dtFrom = Convert.ToDateTime("2000/01/01");
            DateTime dtTo = DateTime.Now;
            string errMsg = "";
           // string sType = drpType.SelectedValue.ToString();
            if(txtBeginDate.Text.Trim() != "")
            {
                try
                {
                    dtFrom = Convert.ToDateTime(txtBeginDate.Text.Trim());
                }
                catch
                {
                    errMsg += "起始日期输入错误！";
                }
            }

            if(txtEndDate.Text.Trim() != "")
            {
                try
                {
                    dtTo = Convert.ToDateTime(txtEndDate.Text.Trim());
                }
                catch
                {
                    errMsg += "终止日期输入错误！";
                }
            }

            if(errMsg != "")
            {
                MessageBox.Show(this,errMsg);
                return;
            }
            if(GetTradeList(franchiser_code,trade_id,dtFrom,dtTo))
            {
                divTradeDesc.Style.Add("display","none");
                divTrade.Style.Add("display","block");
            }
        }

        private bool GetTradeList(string franchiser_code,string trade_id,DateTime dtFrom,DateTime dtTo)
        {
            try
            {
                DataSet ds = bll.GetAllTrade(franchiser_code,trade_id,dtFrom,dtTo);
                gvTrade.DataSource = ds;
                gvTrade.DataBind();
                Session["gvTrade"] = ds;
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.Message);
                return false;
            }

        }

    }
}
