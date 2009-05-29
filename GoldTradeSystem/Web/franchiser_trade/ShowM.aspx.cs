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
    public partial class ShowM:System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected void Page_LoadComplete(object sender,EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "查看交易";
        }
        protected void Page_Load(object sender,EventArgs e)
        {
            if(Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this,"您没有权限或登录超时！\\n请重新登录或与管理员联系","../User_Login/AdminLogin.aspx");
                return;
            }

            if(Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]),Model.Authority.ViewTrade.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if(!Page.IsPostBack)
            {
                bool bl = SearchTradeInfo(true);
                if(bl)
                {
                    //Session["gvTrade"] = ds;
                    //this.gvTrade.DataSource = ds;
                    //this.gvTrade.DataBind();   
                    divTradeDesc.Style.Add("display","none");
                    divSilverTradeDesc.Style.Add("display","none");
                    divTrade.Style.Add("display","block");
                    divTotal.Style.Add("display","none");

                }

            }
        }

        protected void gvTrade_SelectedIndexChanged(object sender,EventArgs e)
        {
            try
            {
                int sTradeID =Convert.ToInt32(gvTrade.SelectedRow.Cells[0].Text.Trim());
                DataSet ds = bll.GetTradeDesc(sTradeID);
                //Session["gvTradeDesc"] = ds;
                //gvTradeDesc.DataSource = ds;
                //gvTradeDesc.DataBind();
                lblFranCode.Text = gvTrade.SelectedRow.Cells[1].Text.Trim();
                lblTotalMoney.Text = gvTrade.SelectedRow.Cells[5].Text.Trim() + "元";
                lblTradeTime.Text = gvTrade.SelectedRow.Cells[3].Text.Trim();
                if(ds.Tables[0].Rows[0]["type"].ToString().Trim() == "1")
                {
                    gvSilverTradeDesc.DataSource = ds;
                    gvSilverTradeDesc.DataBind();
                    Session["gvSilverTradeDesc"] = ds;
                    Session["gvTradeDesc"] = null;
                    divSilverTradeDesc.Style.Add("display","block");
                }
                else
                {
                    gvTradeDesc.DataSource = ds;
                    gvTradeDesc.DataBind();
                    Session["gvTradeDesc"] = ds;
                    Session["gvSilverTradeDesc"] = null;
                    divTradeDesc.Style.Add("display","block");
                }
                divTrade.Style.Add("display","none");
                divTotal.Style.Add("display","block");
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.Message);
                return;
            }

            // divTradeDesc.Style.Add("display", "block");
            // divSilverTradeDesc.Style.Add("display", "none");

        }

        protected void gvTrade_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;

            if(Session["gvTrade"] != null)
            {
                this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
                this.gvTrade.DataBind();
            }
            //else
            //{
            //    Session["gvTrade"] = SearchTradeInfo();
            //    this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
            //    this.gvTrade.DataBind();
            //}
            gvTrade.SelectedIndex = -1;
        }

        protected void gvTradeDesc_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.gvTradeDesc.PageIndex = e.NewPageIndex;

            if(Session["gvTradeDesc"] != null)
            {
                this.gvTradeDesc.DataSource = Session["gvTradeDesc"] as DataSet;
                this.gvTradeDesc.DataBind();
            }
            gvTradeDesc.SelectedIndex = -1;

        }

        protected void gvSilverTradeDesc_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.gvSilverTradeDesc.PageIndex = e.NewPageIndex;

            if(Session["gvSilverTradeDesc"] != null)
            {
                this.gvTradeDesc.DataSource = Session["gvSilverTradeDesc"] as DataSet;
                this.gvTradeDesc.DataBind();
            }
            gvTradeDesc.SelectedIndex = -1;
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
            divSilverTradeDesc.Style.Add("display","none");
            divTrade.Style.Add("display","block");
            divTotal.Style.Add("display","none");
        }

        protected void btnReNew_Click(object sender,EventArgs e)
        {
            txttrade_id.Text = "";
            txtfranchiser_code.Text = "";
            txtfranchiser_name.Text = "";
            gvTrade.SelectedIndex = -1;
            lblQueryMsg.Text = "";
        }

        protected void btnQuery_Click(object sender,EventArgs e)
        {
            bool bl = SearchTradeInfo(false);

            if(bl)
            {
               // lblQueryMsg.Text = "查询成功";
                gvTrade.SelectedIndex = -1;
                divTradeDesc.Style.Add("display","none");
                divSilverTradeDesc.Style.Add("display","none");
                divTotal.Style.Add("display","none");
                divTrade.Style.Add("display","block");
            }
            //else
            //    lblQueryMsg.Text = "查无记录";


            //Session["gvTrade"] = ds;
            //this.gvTrade.DataSource = ds;
            //this.gvTrade.DataBind();


        }

        private bool SearchTradeInfo(bool isInit)
        {
            int franchiser_code = -1;
            int trade_id = -1;
            string franchiser_name = String.Empty;

            //StringBuilder strWhere = new StringBuilder();
            if(isInit)
            {
            }
            else
            {
                if(this.txtfranchiser_code.Text.Trim() != "")
                {
                    try
                    {
                        franchiser_code = Convert.ToInt32(txtfranchiser_code.Text.Trim());
                    }
                    catch
                    {
                        lblQueryMsg.Text = "请输入正确的经销商编号";
                        return false;
                    }

                }
                if(this.txttrade_id.Text.Trim() != "")
                {
                    try
                    {
                        trade_id = Convert.ToInt32(txttrade_id.Text.Trim());
                    }
                    catch
                    {
                        lblQueryMsg.Text = "请输入正确的交易单编号";
                        return false;
                    }
                }
                if(this.txtfranchiser_name.Text.Trim() != "")
                {
                    franchiser_name = txtfranchiser_name.Text.Trim();
                }
            }
            try
            {
                DataSet ds = bll.GetTradeByM(franchiser_code,trade_id,franchiser_name,isInit);
                Session["gvTrade"] = ds;
                this.gvTrade.DataSource = ds;
                this.gvTrade.DataBind();
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
