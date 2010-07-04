namespace GoldTradeNaming.Web.franchiser_info
{
    using AjaxControlToolkit;
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class ShowNoEdit : Page
    {
        protected AutoCompleteExtender AutoCompleteExtender1;
        private GoldTradeNaming.BLL.franchiser_info bll = new GoldTradeNaming.BLL.franchiser_info();
        private GoldTradeNaming.BLL.goldtrade_IA100 bll100 = new GoldTradeNaming.BLL.goldtrade_IA100();
        protected Button btnQuery;
        protected Button btnReNew;
        protected GridView gvList;
        protected Label lblfranchiser_code;
        protected Label lblfranchiser_name;
        protected Label lblQueryMsg;
        protected Panel plSource;
        protected ScriptManager ScriptManager1;
        protected TextBox txtfranchiser_code;
        protected TextBox txtfranchiser_name;

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            DataSet ds = this.SearchFranchiserInfo();
            if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
            {
                this.lblQueryMsg.Text = "查询成功";
                this.Session["gvList"] = ds;
            }
            else
            {
                this.lblQueryMsg.Text = "查无记录";
            }
            this.gvList.DataSource = ds;
            this.gvList.DataBind();
        }

        protected void btnReNew_Click(object sender, EventArgs e)
        {
            this.txtfranchiser_code.Text = "";
            this.txtfranchiser_name.Text = "";
            this.gvList.SelectedIndex = -1;
            this.lblQueryMsg.Text = "";
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvList.PageIndex = e.NewPageIndex;
            if (this.Session["gvList"] != null)
            {
                this.gvList.DataSource = this.Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            else
            {
                this.Session["gvList"] = this.SearchFranchiserInfo();
                this.gvList.DataSource = this.Session["gvList"] as DataSet;
                this.gvList.DataBind();
            }
            this.gvList.SelectedIndex = -1;
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
            else if (!this.Page.IsPostBack)
            {
                DataSet ds = this.SearchFranchiserInfo();
                if (ds != null)
                {
                    this.gvList.DataSource = ds;
                    this.gvList.DataBind();
                    this.Session["gvList"] = ds;
                }
                this.plSource.Style.Add("display", "block");
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "查看经销商";
        }

        protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int rowindex = e.Row.RowIndex;
            if (rowindex>= 0)
            {
                int franid = Convert.ToInt32(e.Row.Cells[0].Text);
                ((Label)e.Row.FindControl("lblorder")).Text = CommBaseBLL.GetBalance(franid).ToString();

                ((Label)e.Row.FindControl("lbltrade")).Text = CommBaseBLL.GetTradeBalance(franid).ToString(); ;
            }
        }

        private DataSet SearchFranchiserInfo()
        {
            StringBuilder strWhere = new StringBuilder();
            if (this.txtfranchiser_code.Text.Trim() == "")
            {
                strWhere.Append("1=1");
            }
            else
            {
                strWhere.Append("franchiser_code like N'%");
                strWhere.Append(CleanString.htmlInputText(this.txtfranchiser_code.Text.Trim()));
                strWhere.Append("%'");
            }
            if (this.txtfranchiser_name.Text.Trim() == "")
            {
                strWhere.Append(" AND 1=1");
            }
            else
            {
                strWhere.Append(" AND franchiser_name like N'%");
                strWhere.Append(CleanString.htmlInputText(this.txtfranchiser_name.Text.Trim()));
                strWhere.Append("%'");
            }
            return this.bll.GetFranAllInfo(strWhere.ToString());
        }
    }
}
