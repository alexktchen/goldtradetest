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
namespace GoldTradeNaming.Web.franchiser_info
{
    public partial class TradeInfo : System.Web.UI.Page
    {
        GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == ""
                   || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewFran.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限登录本系统！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }

            DataSet ds = SearchTradeInfo();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                Session["gvTrade"] = ds;
                this.gvTrade.DataSource = ds;
                this.gvTrade.DataBind();
            }
            divTradeDesc.Style.Add("display", "none");
            divTrade.Style.Add("display", "block");
               
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

        private DataSet SearchTradeInfo()
        {
            StringBuilder strWhere = new StringBuilder();

            if (Request.Params.Count > 0)
            {
                this.txtfranchiser_name.Text = Request.Params["name"].ToString();
                StringBuilder sb = new StringBuilder();
                sb.Append(" franchiser_code='" + Request.Params["id"].ToString() + "'");
            }
           
            return bll.GetTradeByM(strWhere.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowNoEdit.aspx");
        }





    }
}
