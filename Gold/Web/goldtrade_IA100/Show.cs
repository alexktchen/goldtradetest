namespace GoldTradeNaming.Web.goldtrade_IA100
{
    using GoldTradeNaming.BLL;
    using GoldTradeNaming.Model;
    using LTP.Common;
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Show : Page
    {
        protected Button btnAdd;
        protected GridView GridView1;
        protected Label GUID;
        protected Label GUIDState;
        protected ListBox lstIA100_State;
        protected TextBox txt_IA100_guid;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GoldTradeNaming.BLL.goldtrade_IA100 bll = new GoldTradeNaming.BLL.goldtrade_IA100();
                string str = this.GetQueryParam();
                this.Session["grd_data"] = bll.GetList(str);
                this.GridView1.DataSource = this.Session["grd_data"] as DataSet;
                this.GridView1.DataBind();
            }
            catch
            {
                MessageBox.Show(this, "查询过程发生错误！");
            }
        }

        private string GetQueryParam()
        {
            StringBuilder strWhere = new StringBuilder();
            if (this.txt_IA100_guid.Text.Trim() == "")
            {
                strWhere.Append("1=1");
            }
            else
            {
                strWhere.Append("IA100GUID LIKE '%");
                strWhere.Append(this.txt_IA100_guid.Text.Trim());
                strWhere.Append("%'");
            }
            if (this.lstIA100_State.SelectedValue == "2")
            {
                strWhere.Append(" AND 1=1 ");
            }
            else
            {
                strWhere.Append(" AND IA100State='");
                strWhere.Append(this.lstIA100_State.SelectedValue);
                strWhere.Append("'");
            }
            return strWhere.ToString();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = this.Session["grd_data"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((this.Session["admin"] == null) || (this.Session["admin"].ToString() == ""))
            {
                this.Session.Clear();
                base.Response.Clear();
                MessageBox.ShowAndRedirect(this, @"您没有权限或登录超时！\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
            }
            else if (!(((this.Session["admin"] != null) && (this.Session["admin"].ToString() != "")) && CommBaseBLL.HasRight(Convert.ToInt32(this.Session["admin"]), Authority.SearchIA.ToString())))
            {
                base.Response.Clear();
                base.Response.Write(@"<script defer>window.alert('您没有权限操作该功能！\n请重新登录或与管理员联系');history.back();</script>");
                base.Response.End();
            }
            else if (!this.Page.IsPostBack)
            {
                this.btnAdd_Click(sender, e);
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (base.Master.FindControl("lblTitle") as Label).Text = "查看认证锁";
        }

        private void ShowInfo(Guid IA100GUID)
        {
            GoldTradeNaming.Model.goldtrade_IA100 model = new GoldTradeNaming.BLL.goldtrade_IA100().GetModel(IA100GUID);
        }
    }
}
