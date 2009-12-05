namespace GoldTradeNaming.Web.franchiser_trade
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ShowM : Page
    {
        protected AutoCompleteExtender AutoCompleteExtender1;
        private GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected Button btnQuery;
        protected Button btnReNew;
        protected Button btnReturn;
        protected Button Button1;
        protected HtmlGenericControl divSilverTradeDesc;
        protected HtmlGenericControl divTotal;
        protected HtmlGenericControl divTrade;
        protected HtmlGenericControl divTradeDesc;
        protected GridView gvSilverTradeDesc;
        protected GridView gvTrade;
        protected GridView gvTradeDesc;
        protected Label lblfranchiser_code;
        protected Label lblfranchiser_name;
        protected Label lblFranCode;
        protected Label lblQueryMsg;
        protected Label lblTotalMoney;
        protected Label lbltrade_id;
        protected Label lblTradeTime;
        protected ScriptManager ScriptManager1;
        protected TextBox txtfranchiser_code;
        protected TextBox txtfranchiser_name;
        protected TextBox txttrade_id;

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.SearchTradeInfo(false))
            {
                this.gvTrade.SelectedIndex = -1;
                this.divTradeDesc.Style.Add("display", "none");
                this.divSilverTradeDesc.Style.Add("display", "none");
                this.divTotal.Style.Add("display", "none");
                this.divTrade.Style.Add("display", "block");
            }
        }

        protected void btnReNew_Click(object sender, EventArgs e)
        {
            this.txttrade_id.Text = "";
            this.txtfranchiser_code.Text = "";
            this.txtfranchiser_name.Text = "";
            this.gvTrade.SelectedIndex = -1;
            this.lblQueryMsg.Text = "";
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.gvTradeDesc.DataSource = null;
            this.gvTradeDesc.DataBind();
            this.gvTrade.SelectedIndex = -1;
            this.divTradeDesc.Style.Add("display", "none");
            this.divSilverTradeDesc.Style.Add("display", "none");
            this.divTrade.Style.Add("display", "block");
            this.divTotal.Style.Add("display", "none");
        }

        protected void gvSilverTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvSilverTradeDesc.PageIndex = e.NewPageIndex;
            if (this.Session["gvSilverTradeDesc"] != null)
            {
                this.gvTradeDesc.DataSource = this.Session["gvSilverTradeDesc"] as DataSet;
                this.gvTradeDesc.DataBind();
            }
            this.gvTradeDesc.SelectedIndex = -1;
        }

        protected void gvTrade_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTrade.PageIndex = e.NewPageIndex;
            if (this.Session["gvTrade"] != null)
            {
                this.gvTrade.DataSource = this.Session["gvTrade"] as DataSet;
                this.gvTrade.DataBind();
            }
            this.gvTrade.SelectedIndex = -1;
        }

        protected void gvTrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sTradeID = Convert.ToInt32(this.gvTrade.SelectedRow.Cells[0].Text.Trim());
                DataSet ds = this.bll.GetTradeDesc(sTradeID);
                this.lblFranCode.Text = this.gvTrade.SelectedRow.Cells[1].Text.Trim();
                this.lblTotalMoney.Text = this.gvTrade.SelectedRow.Cells[5].Text.Trim() + "元";
                this.lblTradeTime.Text = this.gvTrade.SelectedRow.Cells[3].Text.Trim();
                if (ds.Tables[0].Rows[0]["type"].ToString().Trim() == "1")
                {
                    this.gvSilverTradeDesc.DataSource = ds;
                    this.gvSilverTradeDesc.DataBind();
                    this.Session["gvSilverTradeDesc"] = ds;
                    this.Session["gvTradeDesc"] = null;
                    this.divSilverTradeDesc.Style.Add("display", "block");
                }
                else
                {
                    this.gvTradeDesc.DataSource = ds;
                    this.gvTradeDesc.DataBind();
                    this.Session["gvTradeDesc"] = ds;
                    this.Session["gvSilverTradeDesc"] = null;
                    this.divTradeDesc.Style.Add("display", "block");
                }
                this.divTrade.Style.Add("display", "none");
                this.divTotal.Style.Add("display", "block");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        protected void gvTradeDesc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTradeDesc.PageIndex = e.NewPageIndex;
            if (this.Session["gvTradeDesc"] != null)
            {
                this.gvTradeDesc.DataSource = this.Session["gvTradeDesc"] as DataSet;
                this.gvTradeDesc.DataBind();
            }
            this.gvTradeDesc.SelectedIndex = -1;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewTrade.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack && this.SearchTradeInfo(true))
            {
                this.divTradeDesc.Style.Add("display", "none");
                this.divSilverTradeDesc.Style.Add("display", "none");
                this.divTrade.Style.Add("display", "block");
                this.divTotal.Style.Add("display", "none");
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "查看交易";
        }

        private bool SearchTradeInfo(bool isInit)
        {
            int franchiser_code = -1;
            int trade_id = -1;
            string franchiser_name = string.Empty;
            if (!isInit)
            {
                if (this.txtfranchiser_code.Text.Trim() != "")
                {
                    try
                    {
                        franchiser_code = Convert.ToInt32(this.txtfranchiser_code.Text.Trim());
                    }
                    catch
                    {
                        this.lblQueryMsg.Text = "请输入正确的经销商编号";
                        return false;
                    }
                }
                if (this.txttrade_id.Text.Trim() != "")
                {
                    try
                    {
                        trade_id = Convert.ToInt32(this.txttrade_id.Text.Trim());
                    }
                    catch
                    {
                        this.lblQueryMsg.Text = "请输入正确的交易单编号";
                        return false;
                    }
                }
                if (this.txtfranchiser_name.Text.Trim() != "")
                {
                    franchiser_name = this.txtfranchiser_name.Text.Trim();
                }
            }
            try
            {
                DataSet ds = this.bll.GetTradeByM(franchiser_code, trade_id, franchiser_name, isInit);
                this.Session["gvTrade"] = ds;
                this.gvTrade.DataSource = ds;
                this.gvTrade.DataBind();
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
