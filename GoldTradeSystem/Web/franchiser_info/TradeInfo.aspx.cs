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
using System.Text;
using LTP.Common;

namespace GoldTradeNaming.Web.franchiser_info
{
    public partial class TradeInfo:System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();

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
                   || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]),Model.Authority.ViewFran.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if(!Page.IsPostBack)
            {
                bool bl = SearchTradeInfo();
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
                int sTradeID = Convert.ToInt32(gvTrade.SelectedRow.Cells[0].Text.Trim());
                DataSet ds = bll.GetTradeDesc(sTradeID);
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    Session["gvTradeDesc"] = ds;
                    gvTradeDesc.DataSource = ds;
                    gvTradeDesc.DataBind();
                    divTradeDesc.Style.Add("display","block");
                    divTrade.Style.Add("display","none");
                }
                else
                {
                    MessageBox.Show(this,"查无数据");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.Message);
            }
        }

        protected void gvTrade_PageIndexChanging(object sender,GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;

            if(Session["gvTrade"] != null)
            {
                this.gvTrade.DataSource = Session["gvTrade"] as DataSet;
                this.gvTrade.DataBind();
            }         
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

        private bool SearchTradeInfo()
        {
            StringBuilder strWhere = new StringBuilder();
            bool isInit = true;
            int franchiser_code = -1;
            try
            {
                if(Request.Params.Count > 0)
                {
                    this.txtfranchiser_name.Text = Request.Params["name"].ToString();                  
                    franchiser_code = Convert.ToInt32(Request.Params["id"].ToString().Trim());
                    isInit = false;
                }

                DataSet ds = bll.GetTradeByM(franchiser_code,-1,String.Empty,isInit);
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

        protected void Button1_Click(object sender,EventArgs e)
        {
            Response.Redirect("ShowNoEdit.aspx");
        }
    }
}
