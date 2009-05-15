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
    public partial class OrderInfo : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            (Master.FindControl("lblTitle") as Label).Text = "订单管理";
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
                   || !GoldTradeNaming.BLL.CommBaseBLL.HasRight(Convert.ToInt32(Session["admin"]), Model.Authority.ViewFran.ToString()))
            {
                Response.Clear();
                Response.Write("<script defer>window.alert('" + "您没有权限操作该功能！\\n请重新登录或与管理员联系" + "');history.back();</script>");
                Response.End();
                return;
            } 

            if (!Page.IsPostBack)
            {
                BindInfo();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        private void BindInfo()
        {
            if (Request.Params.Count > 0)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append(" franchiser_code='" + Request.Params["id"].ToString() + "'");

                GoldTradeNaming.BLL.franchiser_order bll = new GoldTradeNaming.BLL.franchiser_order();
                DataSet ds = bll.GetList(sb.ToString());
                Session["datasrc"] = ds;
                this.GridView1.DataSource = Session["datasrc"] as DataSet;
                this.GridView1.DataBind();

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = Session["datasrc"] as DataSet;
            this.GridView1.DataBind();
        }

        protected void btnReturn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ShowNoEdit.aspx");
        }

       
    }
}
