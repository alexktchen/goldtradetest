namespace GoldTradeNaming.Web.franchiser_info
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TradeInfo : Page
    {
        private GoldTradeNaming.BLL.franchiser_trade bll = new GoldTradeNaming.BLL.franchiser_trade();
        protected Button btnReturn;
        protected Button Button1;
        protected HtmlGenericControl divTrade;
        protected HtmlGenericControl divTradeDesc;
        protected GridView gvTrade;
        protected GridView gvTradeDesc;
        protected Label lblfranchiser_name;
        protected TextBox txtfranchiser_name;

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.gvTradeDesc.DataSource = null;
            this.gvTradeDesc.DataBind();
            this.gvTrade.SelectedIndex = -1;
            this.divTradeDesc.Style.Add("display", "none");
            this.divTrade.Style.Add("display", "block");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ShowNoEdit.aspx");
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
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    this.Session["gvTradeDesc"] = ds;
                    this.gvTradeDesc.DataSource = ds;
                    this.gvTradeDesc.DataBind();
                    this.divTradeDesc.Style.Add("display", "block");
                    this.divTrade.Style.Add("display", "none");
                }
                else
                {
                    MessageBox.Show(this, "查无数据");
                }
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
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.ViewFran.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack && this.SearchTradeInfo())
            {
                this.divTradeDesc.Style.Add("display", "none");
                this.divTrade.Style.Add("display", "block");
            }
        }

        private bool SearchTradeInfo()
        {
            StringBuilder strWhere = new StringBuilder();
            bool isInit = true;
            int franchiser_code = -1;
            try
            {
                if (base.Request.Params.Count > 0)
                {
                    this.txtfranchiser_name.Text = base.Request.Params["name"].ToString();
                    franchiser_code = Convert.ToInt32(base.Request.Params["id"].ToString().Trim());
                    isInit = false;
                }
                DataSet ds = this.bll.GetTradeByM(franchiser_code, -1, string.Empty, isInit);
                this.gvTrade.DataSource = ds;
                this.gvTrade.DataBind();
                this.Session["gvTrade"] = ds;
                return true;
            }
            catch (Exception ex)
            {
                this.txtfranchiser_name.Text = base.Request.Params["name"].ToString();
                StringBuilder sb = new StringBuilder();
                MessageBox.Show(this, ex.Message);
                return false;
            }
        }
    }
}
