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
namespace GoldTradeNaming.Web.goldtrade_IA100
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "查看认证锁";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null || Session["admin"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/AdminLogin.aspx");
                return;
            }

            if (Session["admin"] == null || Session["admin"].ToString() == ""
                    || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.SearchIA.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                btnAdd_Click(sender, e);
            }
        }

        private void ShowInfo(Guid IA100GUID)
        {
            GoldTradeNaming.BLL.goldtrade_IA100 bll = new GoldTradeNaming.BLL.goldtrade_IA100();
            GoldTradeNaming.Model.goldtrade_IA100 model = bll.GetModel(IA100GUID);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GoldTradeNaming.BLL.goldtrade_IA100 bll = new GoldTradeNaming.BLL.goldtrade_IA100();
                string str = this.GetQueryParam();
                Session["grd_data"] = bll.GetList(str);
                this.GridView1.DataSource = Session["grd_data"] as DataSet;
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
                strWhere.Append("1=1");
            else
            {
                strWhere.Append("IA100GUID= '");
                strWhere.Append(this.txt_IA100_guid.Text.Trim());
                strWhere.Append("'");
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
            this.GridView1.DataSource = Session["grd_data"] as DataSet;
            this.GridView1.DataBind();
        }


    }
}
