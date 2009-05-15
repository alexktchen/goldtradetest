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
namespace GoldTradeNaming.Web.franchiser_order_desc
{
    public partial class Show : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            //(Master.FindControl("lblTitle") as Label).Text = "订单详细信息";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fran"] == null || Session["fran"].ToString() == "")
            {
                Session.Clear();
                Response.Clear();
                LTP.Common.MessageBox.ShowAndRedirect(this, "您没有权限或登录超时！\\n请重新登录或与管理员联系", "../User_Login/flogin.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {                
                if (Request.QueryString["id"].ToString() != "")
                    ShowInfo(Request.QueryString["id"].ToString());
            }

        }

        private void ShowInfo(string id)
        {
            string orderid = id;
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" franchiser_order_id = '");
            strWhere.Append(orderid + "'");
            GoldTradeNaming.BLL.send_main orderdscBll = new GoldTradeNaming.BLL.send_main();
            DataSet ds = orderdscBll.GetOrderedProductList(strWhere.ToString());
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }

    }
}
